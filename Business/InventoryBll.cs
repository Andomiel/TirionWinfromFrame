using BLL.Common;
using DataBase;
using Entity;
using Entity.DataContext;
using Entity.Dto;
using Entity.Enums;
using Entity.Enums.Inventory;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TirionWinfromFrame.Commons;

namespace Business
{
    public class InventoryBll : BaseDeliveryBll
    {
        protected override LightRecordTypeEnum OrderType => LightRecordTypeEnum.Inventory;

        public static List<Wms_InventoryOrder> GetInventoryOrders(InventoryQueryCondition condition)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            if ((!string.IsNullOrWhiteSpace(condition.Upn)) || (!string.IsNullOrWhiteSpace(condition.MaterialNo)))
            {
                sb.AppendLine(@"SELECT wio.*
                        FROM Wms_InventoryBarcode wib 
                        LEFT JOIN Wms_InventoryOrder wio ON wib.InventoryOrderId = wio.BusinessId 
                        WHERE 1=1");
                if (!string.IsNullOrWhiteSpace(condition.Upn))
                {
                    sb.AppendLine(" AND wib.Barcode = @Barcode ");
                    parameters.Add(new SqlParameter("@Barcode", condition.Upn));
                }
                else
                {
                    sb.AppendLine(" AND wib.MaterialNo = @MaterialNo ");
                    parameters.Add(new SqlParameter("@MaterialNo", condition.MaterialNo));
                }
            }
            else
            {
                sb.AppendLine(@" SELECT wio.*
	                FROM  Wms_InventoryOrder wio WHERE 1=1 ");
            }
            if (!string.IsNullOrWhiteSpace(condition.OrderNo))
            {
                sb.AppendLine(" AND wio.InventoryNo = @InventoryNo ");
                parameters.Add(new SqlParameter("@InventoryNo", condition.OrderNo));
            }
            if (condition.InventoryType >= 0)
            {
                sb.AppendLine(" AND wio.InventoryType = @InventoryType ");
                parameters.Add(new SqlParameter("@InventoryType", condition.InventoryType));
            }
            if (condition.OrderStatus >= 0)
            {
                sb.AppendLine(" AND wio.OrderStatus = @OrderStatus ");
                parameters.Add(new SqlParameter("@OrderStatus", condition.OrderStatus));
            }
            if (condition.HaveOrderTimeQuery)
            {
                sb.AppendLine(" AND wio.CreateTime >= @StartTime AND wio.CreateTime < @EndTime ");
                parameters.Add(new SqlParameter("@StartTime", condition.OrderTimeStart));
                parameters.Add(new SqlParameter("@EndTime", condition.OrderTimeEnd));
            }
            if (condition.HaveFinishedTimeQuery)
            {
                sb.AppendLine(" AND wio.LastUpdateTime >= @FinishStartTime AND wio.LastUpdateTime < @FinishEndTime ");
                parameters.Add(new SqlParameter("@FinishStartTime", condition.FinishedTimeStart));
                parameters.Add(new SqlParameter("@FinishEndTime", condition.FinishedTimeEnd));
            }
            sb.AppendLine("	ORDER BY wio.CreateTime DESC  ");

            var orders = DbHelper.GetDataTable(sb.ToString(), parameters.ToArray());

            return orders.DataTableToList<Wms_InventoryOrder>();
        }

        public static List<Wms_InventoryBarcode> GetInventoryBarcodes(string inventoryId)
        {
            string sql = $@"SELECT wib.*
                        FROM Wms_InventoryBarcode wib WHERE wib.InventoryOrderId = '{inventoryId}' ";

            return DbHelper.GetDataTable(sql).DataTableToList<Wms_InventoryBarcode>();
        }

        public static List<AvailableBarcode> GetAvailableBarcodesForInventory(MaterialQueryCondition condition)
        {
            StringBuilder sb = new StringBuilder($@"SELECT szm.ReelID as Barcode, szm.Part_Number as MaterialNo, szm.SerialNo, szm.WZ_SCCJ as Manufacturer,
                                                     szm.LockTowerNo, szm.LockMachineId, szm.LockLocation, szm.ABSide, szm.DateCode,
                                                     szm.SaveTime, szm.Qty as Quantity, szm.ReelType 
                                        FROM smt_zd_material szm 
                                        WHERE szm.Status = {(int)BarcodeStatusEnum.Saved}
                                                 AND szm.isSave = 1 
                                                 AND szm.isTake = 0
                                                 AND szm.Qty > 0");
            if (condition != null)
            {
                if (condition.TowerNo >= 0)
                {
                    sb.AppendLine($" AND szm.LockTowerNo = {condition.TowerNo} ");
                }
                if (!string.IsNullOrWhiteSpace(condition.ABSide))
                {
                    sb.AppendLine($" AND szm.ABSide = '{condition.ABSide}' ");
                }
                if (!string.IsNullOrWhiteSpace(condition.MachineId))
                {
                    sb.AppendLine($" AND szm.LockMachineId = '{condition.MachineId}' ");
                }
            }
            return DbHelper.GetDataTable(sb.ToString()).DataTableToList<AvailableBarcode>();
        }

        public static List<Wms_InventoryOrder> GetDeliveryOrdersByStatus(int inventoryStatus)
        {
            string sql = $"{Wms_InventoryOrder.GetSelectSql()} AND OrderStatus = {inventoryStatus} ";

            var orders = DbHelper.GetDataTable(sql);

            return orders.DataTableToList<Wms_InventoryOrder>();
        }

        public static int ModifyInventoryOrderStatus(string inventoryId, int targetStatus, string userName)
        {
            string sql = $@"UPDATE Wms_InventoryOrder
                SET OrderStatus={targetStatus}, LastUpdateTime=getdate(), LastUpdateUser='{userName}'
                WHERE BusinessId = '{inventoryId}' ";
            return DbHelper.ExecuteNonQuery(sql);
        }

        public static int ReleaseInventoryOrderBarcodes(List<string> barcodes)
        {
            if (barcodes == null || barcodes.Count == 0)
            {
                return 0;
            }
            string condition = string.Join(",", barcodes.Select(p => $"'{p}'").ToArray());
            string sql = $@"UPDATE smt_zd_material set Status = {(int)BarcodeStatusEnum.Saved} WHERE ReelID  in({condition}) ";
            return DbHelper.ExecuteNonQuery(sql);
        }

        protected override List<DeliveryBarcodeLocation> GetDeliveryBarcodesDetail(string deliveryId, int targetStatus)
        {
            string sql = $@"SELECT wib.Barcode, wib.DeliveryAreaId, szm.LockLocation, szm.ABSide, szm.LockMachineID, szm.Part_Number, wib.OriginQuantity as DeliveryQuantity, wib.OrderStatus  as BarcodeStatus
                        FROM Wms_InventoryBarcode wib 
                        left join smt_zd_material szm  on wib.Barcode = szm.ReelID 
                        WHERE wib.InventoryOrderId = '{deliveryId}' AND wib.OrderStatus <= {targetStatus} ;";

            return DbHelper.GetDataTable(sql).DataTableToList<DeliveryBarcodeLocation>();
        }

        protected override string GetDeliveredUpdateSql(string deliveryId, int sortingNo, string userName)
        {
            return $@"update Wms_InventoryOrder set OrderStatus = {(int)InventoryOrderStatusEnum.Executing}, 
                    LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}', SortingId = {sortingNo}  where BusinessId = '{deliveryId}'; ";
        }

        protected override int GetExecuteStatus()
        {
            return (int)InventoryBarcodeStatusEnum.Waiting;
        }

        protected override int GetFinishedStatus()
        {
            return (int)InventoryBarcodeStatusEnum.Executed;
        }

        protected override string GetFinshedUpdateSql(string deliveryId, string userName)
        {
            return $@"update Wms_InventoryOrder set OrderStatus = {(int)InventoryOrderStatusEnum.Finished}, 
                    LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}'  where BusinessId = '{deliveryId}'; ";
        }

        protected override int GetSortNo(int deliveryType)
        {
            return 1;//紧急出料口
        }

        protected override string GetReleaseBarcodeSql(string deliveryId, string userName, List<string> barcodes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in barcodes)
            {
                sb.AppendLine($@" update a set a.OrderStatus = {(int)InventoryBarcodeStatusEnum.Cancelled}, a.LastUpdateTime=getdate(), a.LastUpdateUser='{userName}'
                    from Wms_InventoryBarcode a
                    where a.InventoryOrderId = '{deliveryId}' and a.Barcode = '{item}';");

                sb.AppendLine($" update smt_zd_material set Status = {(int)BarcodeStatusEnum.Saved}, isTake = 0, Work_Order_No = '', LockRequestID = ''  where  ReelID = '{item}'; ");
            }
            return sb.ToString();
        }
    }

    public class InventoryQueryCondition
    {
        public string OrderNo { get; set; }
        public int OrderStatus { get; set; }
        public int InventoryType { get; set; }
        public string MaterialNo { get; set; }
        public string Upn { get; set; }
        public bool HaveOrderTimeQuery { get; set; } = false;
        public DateTime OrderTimeStart { get; set; }
        public DateTime OrderTimeEnd { get; set; }
        public bool HaveFinishedTimeQuery { get; set; } = false;
        public DateTime FinishedTimeStart { get; set; }
        public DateTime FinishedTimeEnd { get; set; }
    }

    public class AvailableBarcode
    {
        /// <summary>
        /// 二维码
        /// </summary>
        public string Barcode { get; set; }

        public string MaterialNo { get; set; }
        /// <summary>
        /// 料盘类型
        /// </summary>
        public string ReelType { get; set; }

        public string ReelTypeDes => EnumHelper.GetDescription(typeof(ReelTypeEnum), ReelType);

        public int LockTowerNo { get; set; }

        public string Tower => EnumHelper.GetDescription(typeof(TowerEnum), LockTowerNo);

        public string LockLocation { get; set; }

        public string LockMachineId { get; set; }

        public string ABSide { get; set; }

        public string Location
        {
            get
            {
                string location;
                switch (LockTowerNo)
                {
                    case 1:
                        location = $"{ABSide}-{LockLocation}";
                        break;
                    case 2:
                        location = $"{LockMachineId}-{LockLocation}";
                        break;
                    default:
                        location = LockLocation;
                        break;
                }
                return location;
            }
        }

        public DateTime SaveTime { get; set; }

        public int Quantity { get; set; }

        public string DateCode { get; set; }

        public DateTime DateCodeDate => QueryConditionConvert.DateCdoeToCycleDate(DateCode, Barcode);

        public string Manufacturer { get; set; }
        //4873250-B3788-21827-00003
        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNo { get; set; }

    }
}
