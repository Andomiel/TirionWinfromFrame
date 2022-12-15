using DataBase;
using Entity;
using Entity.Enums;
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

                    sb.AppendLine($@"update smt_zd_material set Status={(int)BarcodeStatusEnum.Delivered} ");
                }
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
}
