using DataBase;
using Entity;
using Entity.Enums;
using Entity.Enums.Instock;
using Entity.Enums.Inventory;
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
            sb.AppendLine($@"INSERT INTO Wms_InventoryOrder
(BusinessId, InventoryNo, InventoryType, InventoryQuantity, InventoryArea, SubArea, SortingId, OrderStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
VALUES('{orderId}', '{orderNo}', {(int)InventoryOrderTypeEnum.Numeric}, 0, 0, 'mixed', '', {(int)InventoryOrderStatusEnum.Finished}, '盘亏创建', getdate(), '{userName}', getdate(), '{userName}');");

            foreach (var barcode in barcodes)
            {
                sb.AppendLine($@"INSERT INTO ASRS.dbo.Wms_InventoryBarcode
(BusinessId, InventoryOrderId, MaterialNo, Barcode, OriginQuantity, RealQuantity, OriginLocation, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser, ExecuteResult)
VALUES('{Guid.NewGuid():D}', '{orderId}', '{barcode.MaterialNo}', '{barcode.Barcode}', {barcode.Quantity}, 0, '{barcode.Location}', {(int)InventoryBarcodeStatusEnum.Confirmed}, getdate(), '{userName}', getdate(), '{userName}', 0);");

                sb.AppendLine($@"update smt_zd_material set isTakeCheck =1, isReturnCheck = 0,
                isSave = 1, taketime = getdate(), LockTowerNo = '0',LockLocation = '',LockMachineID = '',ABSide='', Status='{(int)BarcodeStatusEnum.Delivered}' where reelid = '{barcode.Barcode}'; ");
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
            sb.AppendLine($@"INSERT INTO Wms_InventoryOrder
(BusinessId, InventoryNo, InventoryType, InventoryQuantity, InventoryArea, SubArea, SortingId, OrderStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
VALUES('{orderId}', '{orderNo}', {(int)InventoryOrderTypeEnum.Numeric}, 0, 0, 'mixed', '', {(int)InventoryOrderStatusEnum.Finished}, '盘盈创建', getdate(), '{userName}', getdate(), '{userName}');");

            foreach (var barcode in barcodes)
            {
                sb.AppendLine($@"INSERT INTO ASRS.dbo.Wms_InventoryBarcode
(BusinessId, InventoryOrderId, MaterialNo, Barcode, OriginQuantity, RealQuantity, OriginLocation, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser, ExecuteResult)
VALUES('{Guid.NewGuid():D}', '{orderId}', '{barcode.PartNumber}', '{barcode.UPN}', 0, {barcode.Qty}, '', {(int)InventoryBarcodeStatusEnum.Confirmed}, getdate(), '{userName}', getdate(), '{userName}', 0);");

                sb.AppendLine($"DELETE FROM smt_zd_material WHERE ReelID = '{barcode.UPN}';");
                sb.AppendLine($@"insert into smt_zd_material(Reelid, Part_Number, Qty, DateCode, Lot, FactoryCode, WZ_SCCJ, MSD, ReelType, SerialNo, QRCode, CameraString, MinPacking, isSave, isTake, isTakeCheck, Status, LockTowerNo)
                                            values('{barcode.UPN}', '{barcode.PartNumber}', {barcode.Qty}, '{barcode.DataCode}', '{barcode.SerialNo}', '{barcode.Supplier}', '{barcode.Supplier}', '{barcode.MSD}', '{barcode.ReelType}', '{barcode.SerialNo}', '{barcode.QRCode}', '', '{barcode.MiniPacking}', 1, 0, 0, { (int)BarcodeStatusEnum.Saved}, { (int)TowerEnum.SortingArea}); ");
            }

            DbHelper.ExcuteWithTransaction(sb.ToString(), out string _);
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
