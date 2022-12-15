using DataBase;
using Entity;
using Entity.Enums;
using Entity.Enums.Instock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProfitAndLossBusiness
    {

        public static void LossBarcodes(IEnumerable<LossBarcode> barcodes, string userName)
        {
            if (!barcodes.Any())
            {
                return;
            }
            StringBuilder sb = new StringBuilder();

            string orderId = Guid.NewGuid().ToString("D");
            string orderNo = $"Loss{DateTime.Now:yyyyMMddHHmmssfff}{barcodes.Count()}";
            sb.AppendLine($@"INSERT INTO Wms_DeliveryOrder
(BusinessId, DeliveryNo, WorkOrderId, SortingId, ProductNo, LineId, OrderType, DeliveryType, OrderStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
VALUES('{orderId}', '{orderNo}', '', '', '', '', {(int)OutOrderTypeEnum.盘点模式}, {(int)DeliveryOrderTypeEnum.TotalSet}, {(int)DeliveryOrderStatusEnum.Delivered}, '盘亏创建', getdate(), '{userName}', getdate(), '{userName}');");

            var barcodeGroup = barcodes.GroupBy(p => p.MaterialNo);
            foreach (var item in barcodeGroup)
            {
                string detailId = Guid.NewGuid().ToString("D");
                sb.AppendLine($@"INSERT INTO Wms_DeliveryDetail
(BusinessId, DeliveryId, WorkOrderDetailId, SlotNo, RowNum, MaterialNo, RequireCount, DetailStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
VALUES('{detailId}', '{orderId}', '', '', 0, '{item.Key}', {item.Sum(p => p.Quantity)}, {(int)DeliveryDetailStatusEnum.Delivered}, getdate(), '{userName}', getdate(), '{userName}');");

                foreach (var barcode in item)
                {
                    sb.AppendLine($@"INSERT INTO Wms_DeliveryBarcode
(BusinessId, DeliveryId, DeliveryDetailId, BoxNo, Barcode, OrigionBarcode, DeliveryAreaId, DeliveryQuantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser, DeliveryLocation, ExecuteResult)
VALUES('{Guid.NewGuid():D}', '{orderId}', '{detailId}', '', '{barcode.Barcode}', '', {barcode.Tower}, {barcode.Quantity}, {(int)DeliveryBarcodeStatusEnum.Delivered}, getdate(), '{userName}', getdate(), '{userName}', '{barcode.Location}', 0);");

                    sb.AppendLine($@"update smt_zd_material set Status={(int)BarcodeStatusEnum.Delivered}; ");
                }
            }

            DbHelper.ExcuteWithTransaction(sb.ToString(), out string _);
        }


        public static void ProfitBarcodes(IEnumerable<ProfitBarcode> barcodes, string userName)
        {
            if (!barcodes.Any())
            {
                return;
            }
            StringBuilder sb = new StringBuilder();

            string orderId = Guid.NewGuid().ToString("D");
            string orderNo = $"Profit{DateTime.Now:yyyyMMddHHmmssfff}{barcodes.Count()}";
            sb.AppendLine($@"INSERT INTO Wms_InstockOrder
(BusinessId, InstockNo, InstockType, OrderStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
VALUES('{orderId}', '{orderNo}', {(int)InOrderTypeEnum.Excel导入}, {(int)InstockOrderStatusEnum.Finished}, '盘盈创建', getdate(), '{userName}', getdate(), '{userName}');");

            var barcodeGroup = barcodes.GroupBy(p => p.PartNumber);
            foreach (var item in barcodeGroup)
            {
                string detailId = Guid.NewGuid().ToString("D");
                sb.AppendLine($@"INSERT INTO Wms_InstockDetail
(BusinessId, InstockId, MaterialNo, RequireCount, DetailStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
VALUES('{detailId}', '{orderId}', '{item.Key}', {item.Sum(p => p.Qty)}, {(int)InstockDetailStatusEnum.Received}, getdate(), '{userName}', getdate(), '{userName}');");

                foreach (var barcode in item)
                {
                    sb.AppendLine($@"INSERT INTO Wms_InstockBarcode
(BusinessId, InstockId, InstockDetailId, InstockAreaId, Barcode, InstockQuantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
VALUES('{Guid.NewGuid():D}', '{orderId}', '{detailId}', 0, '{barcode.UPN}', {barcode.Qty}, {(int)InstockBarcodeStatusEnum.Received}, getdate(), '{userName}', getdate(), '{userName}');");

                    sb.AppendLine($"DELETE FROM smt_zd_material WHERE ReelID = '{barcode.UPN}';");
                    sb.AppendLine($@"insert into smt_zd_material(Reelid, Part_Number, Qty, DateCode, Lot, FactoryCode, WZ_SCCJ, MSD, ReelType, SerialNo, QRCode, CameraString, MinPacking, isSave, isTake, isTakeCheck, Status, LockTowerNo)
                                            values('{barcode.UPN}', '{barcode.PartNumber}', {barcode.Qty}, '{barcode.DataCode}', '{barcode.SerialNo}', '{barcode.Supplier}', '{barcode.Supplier}', '{barcode.MSD}', '{barcode.ReelType}', '{barcode.SerialNo}', '{barcode.QRCode}', '', '{barcode.MiniPacking}', 1, 0, 0, { (int)BarcodeStatusEnum.Saved}, { (int)TowerEnum.SortingArea}); ");
                }
            }

        }
    }

    public class LossBarcode
    {
        public int Index { get; set; } = 0;

        public string Barcode { get; set; } = string.Empty;

        public int Tower { get; set; } = 0;

        public string TowerDisplay => EnumHelper.GetDescription(typeof(TowerEnum), Tower);

        public int Quantity { get; set; } = 0;

        public string Remark => CanLoss ? "允许盘亏" : "禁止盘亏";

        public string Location { get; set; } = string.Empty;

        public string MaterialNo { get; set; } = string.Empty;

        public bool CanLoss => Tower == (int)TowerEnum.ReformShelf || Tower == (int)TowerEnum.SortingArea;
    }

    public class ProfitBarcode
    {
        public string QRCode { get; set; }
        public string UPN { get; set; }
        public string PartNumber { get; set; }
        public string SerialNo { get; set; }
        public int Qty { get; set; }
        public string materialJson { get; set; }
        public bool IsTypeT { get; set; } = false;
        public string MSD { get; set; }
        public string MsdOverdue { get; set; }
        public string IsLock { get; set; }
        public bool CanProfit { get; set; }
        public string Success => CanProfit ? "允许盘盈" : "禁止盘盈";
        public string Message { get; set; }

        public string DataCode { get; set; }

        public string Supplier { get; set; }

        public int MiniPacking { get; set; } = 0;

        public int ReelType
        {
            get
            {
                if (IsTypeT)
                {
                    return (int)ReelTypeEnum.T;
                }
                int materialType = (int)ReelTypeEnum.F;
                if (Qty > 0 && MiniPacking > 0)
                {
                    decimal offset = MiniPacking - Qty;
                    if ((Math.Abs(offset) / MiniPacking) * 1000 <= 3)
                    {
                        materialType = (int)ReelTypeEnum.F;
                    }
                    else if ((offset / MiniPacking) * 1000 > 3)
                    {
                        materialType = (int)ReelTypeEnum.S;
                    }
                    else if (offset / MiniPacking * 1000 < -3)
                    {
                        materialType = (int)ReelTypeEnum.T;
                    }
                    else
                    {
                        //do nothing
                    }
                }
                return materialType;
            }
        }

        public string ReelTypeDisplay => EnumHelper.GetDescription(typeof(ReelTypeEnum), ReelType);
    }
}
