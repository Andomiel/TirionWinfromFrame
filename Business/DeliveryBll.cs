using DataBase;
using Entity.DataContext;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TirionWinfromFrame.Commons;

namespace Business
{
    public class DeliveryBll : BaseDeliveryBll
    {
        protected override LightRecordTypeEnum OrderType => LightRecordTypeEnum.Delivery;

        public static List<Wms_DeliveryOrder> GetDeliveryOrders(DeliveryQueryCondition condition)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(condition.Upn))
            {
                sb.AppendLine(@"SELECT wdo.*
                        FROM Wms_DeliveryBarcode wdb 
                        left join Wms_DeliveryOrder wdo on wdb.DeliveryId = wdo.BusinessId 
                        WHERE wdb.Barcode  = @Barcode ");
                parameters.Add(new SqlParameter("@Barcode", condition.Upn));
            }
            else if (!string.IsNullOrWhiteSpace(condition.MaterialNo))
            {
                sb.AppendLine(@"SELECT wdo.*
                        FROM Wms_DeliveryDetail wdd 
                        left join Wms_DeliveryOrder wdo on wdd.DeliveryId = wdo.BusinessId 
                        WHERE wdd.MaterialNo = @MaterialNo ");
                parameters.Add(new SqlParameter("@MaterialNo", condition.MaterialNo));
            }
            else
            {
                sb.AppendLine(@" SELECT wdo.*
                        FROM Wms_DeliveryOrder wdo  WHERE 1=1 ");
            }
            if (!string.IsNullOrWhiteSpace(condition.OrderNo))
            {
                sb.AppendLine(" AND wdo.DeliveryNo = @DeliveryNo ");
                parameters.Add(new SqlParameter("@DeliveryNo", condition.OrderNo));
            }
            if (condition.OrderType >= 0)
            {
                sb.AppendLine(" AND wdo.DeliveryType = @DeliveryType ");
                parameters.Add(new SqlParameter("@DeliveryType", condition.OrderType));
            }
            if (condition.OrderStatus >= 0)
            {
                sb.AppendLine(" AND wdo.OrderStatus = @OrderStatus ");
                parameters.Add(new SqlParameter("@OrderStatus", condition.OrderStatus));
            }
            if (!string.IsNullOrWhiteSpace(condition.Operator))
            {
                sb.AppendLine(" AND wdo.LastUpdateUser = @LastUpdateUser ");
                parameters.Add(new SqlParameter("@LastUpdateUser", condition.Operator));
            }
            if (condition.HaveOrderTimeQuery)
            {
                sb.AppendLine(" AND wdo.CreateTime >= @StartTime AND wdo.CreateTime < @EndTime ");
                parameters.Add(new SqlParameter("@StartTime", condition.OrderTimeStart));
                parameters.Add(new SqlParameter("@EndTime", condition.OrderTimeEnd));
            }
            if (condition.HaveFinishedTimeQuery)
            {
                sb.AppendLine(" AND wdo.LastUpdateTime >= @FinishStartTime AND wdo.LastUpdateTime < @FinishEndTime ");
                parameters.Add(new SqlParameter("@FinishStartTime", condition.FinishedTimeStart));
                parameters.Add(new SqlParameter("@FinishEndTime", condition.FinishedTimeEnd));
            }
            sb.AppendLine("	ORDER BY wdo.CreateTime DESC  ");

            var orders = DbHelper.GetDataTable(sb.ToString(), parameters.ToArray());

            return orders.DataTableToList<Wms_DeliveryOrder>();
        }

        public static Wms_DeliveryOrder GetDeliveryOrderByNo(string deliveryNo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Wms_DeliveryOrder.GetSelectSql());
            sb.AppendLine(" AND DeliveryNo = @DeliveryNo ");

            var orders = DbHelper.GetDataTable(sb.ToString(), new SqlParameter("@DeliveryNo", deliveryNo));
            if (orders == null || orders.Rows.Count == 0)
            {
                return null;
            }

            return orders.DataTableToList<Wms_DeliveryOrder>().First();
        }

        public static List<Wms_DeliveryDetail> GetDeliveryDetails(string deliveryId)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Wms_DeliveryDetail.GetSelectSql());
            sb.AppendLine(" AND DeliveryId = @DeliveryId ");

            var details = DbHelper.GetDataTable(sb.ToString(), new SqlParameter("@DeliveryId", deliveryId));

            return details.DataTableToList<Wms_DeliveryDetail>();
        }

        public static List<Wms_DeliveryBarcode> GetDeliveryBarcodes(string deliveryId)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Wms_DeliveryBarcode.GetSelectSql());
            sb.AppendLine($" AND DeliveryId = @DeliveryId AND OrderStatus < {(int)DeliveryBarcodeStatusEnum.Cancelled}");

            var details = DbHelper.GetDataTable(sb.ToString(), new SqlParameter("@DeliveryId", deliveryId));

            return details.DataTableToList<Wms_DeliveryBarcode>();
        }

        public static List<Wms_DeliveryOrder> GetDeliveryOrderByStatus(int deliveryStatus)
        {
            string sql = $"{Wms_DeliveryOrder.GetSelectSql()} AND OrderStatus = {deliveryStatus} ";

            var orders = DbHelper.GetDataTable(sql);

            return orders.DataTableToList<Wms_DeliveryOrder>();
        }

        public bool ReleaseExistedDeliveryBarcode(string deliveryId, string deliveryNo, int targetStatus, string userName, List<string> barcodes)
        {
            try
            {
                var unfinishedBarcodes = GetDeliveryBarcodesDetail(deliveryId, GetFinishedStatus());

                var group = unfinishedBarcodes.GroupBy(p => p.DeliveryAreaId);
                foreach (var item in group)
                {
                    switch (item.Key)
                    {
                        case (int)TowerEnum.SortingArea:
                            //do nothing
                            break;
                        case (int)TowerEnum.ASRS:
                            //do nothing
                            break;
                        case (int)TowerEnum.LightShelf:
                            LightOffLightShelf(deliveryId, deliveryNo, userName, item.ToList());
                            break;
                        case (int)TowerEnum.PalletArea:
                            //do nothing
                            break;
                        case (int)TowerEnum.ReformShelf:
                            LightOffReformShelf(deliveryId, userName, item.ToList());
                            break;
                        default:
                            throw new OppoCoreException("发料物料中存在不在预定义库区的物料");
                    }
                }
            }
            catch (Exception ex)
            {
                FileLog.Log($"取消灭灯时报错：{ex.GetDeepException()}");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"update Wms_DeliveryOrder set OrderStatus = {targetStatus}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' where BusinessId = '{deliveryId}'; ");

            sb.AppendLine(GetReleaseBarcodeSql(deliveryId, userName, barcodes));

            return DbHelper.ExcuteWithTransaction(sb.ToString(), out _) > 0;
        }

        protected override string GetReleaseBarcodeSql(string deliveryId, string userName, List<string> barcodes)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($@" update a set a.OrderStatus = {(int)DeliveryBarcodeStatusEnum.Cancelled}, a.LastUpdateTime=getdate(), a.LastUpdateUser='{userName}'
                    from Wms_DeliveryBarcode a
                    where a.DeliveryId = '{deliveryId}' and a.OrderStatus = {(int)DeliveryBarcodeStatusEnum.Undeliver};");
            foreach (var item in barcodes)
            {
                sb.AppendLine($" update smt_zd_material set Status = {(int)BarcodeStatusEnum.Saved}, isTake = 0, Work_Order_No = '', LockRequestID = ''  where  ReelID = '{item}'; ");
            }
            return sb.ToString();
        }

        public void SpecialFinishDeliveryOrder(string deliveryId, string userName, List<string> barcodes)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetFinshedUpdateSql(deliveryId, userName));

            foreach (var item in barcodes)
            {
                sb.AppendLine($@" update a set a.OrderStatus = {(int)DeliveryBarcodeStatusEnum.Cancelled}
                    from Wms_DeliveryBarcode a
                    where a.DeliveryId = '{deliveryId}' and a.Barcode = '{item}';");

                sb.AppendLine($" update smt_zd_material set Status = {(int)BarcodeStatusEnum.Saved}, isTake = 0, Work_Order_No = '', LockRequestID = ''  where  ReelID = '{item}'; ");
            }

            sb.AppendLine(GetFinishedLightRecords(deliveryId, userName));

            DbHelper.ExcuteWithTransaction(sb.ToString(), out string _);
        }

        public static bool LockOrderWhenCalculate(string deliveryId, string userName)
        {
            string sql = $"update Wms_DeliveryOrder set OrderStatus = {(int)DeliveryOrderStatusEnum.Calculating}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' where BusinessId = '{deliveryId}'; ";

            return DbHelper.Update(sql) > 0;
        }

        public static List<SMTZDMaterial> GetBarcodesByMaterialNo(string materialNo)
        {
            string sql = $@"SELECT szm.*  from smt_zd_material szm 
                     LEFT JOIN (SELECT DISTINCT UPN FROM smt_Material_Frozen) smf ON szm.ReelID = smf.UPN
                        WHERE szm.Status ={(int)BarcodeStatusEnum.Saved} AND szm.isSave = 1 AND  szm.isTake = 0 AND szm.BakeState =0
                         AND smf.UPN is NULL 
                                AND szm.Part_Number = '{materialNo}' 
                        ORDER BY szm.LockTowerNo DESC, szm.SaveTime, szm.Qty ASC; ";

            return DbHelper.GetDataTable(sql).DataTableToList<SMTZDMaterial>();
        }

        public static bool CreateDeliveryBarcodes(string deliveryId, string userName, List<Wms_DeliveryBarcode> barcodes)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"update Wms_DeliveryOrder set OrderStatus = {(int)DeliveryOrderStatusEnum.Calculated}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' where BusinessId = '{deliveryId}'; ");

            foreach (var item in barcodes)
            {
                sb.AppendLine($@" INSERT INTO Wms_DeliveryBarcode
                    (BusinessId, DeliveryId, DeliveryDetailId, BoxNo, Barcode, OrigionBarcode, DeliveryAreaId, DeliveryQuantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
                    VALUES('{item.BusinessId}', '{item.DeliveryId}', '{item.DeliveryDetailId}', '', '{item.Barcode}', '', {item.DeliveryAreaId}, {item.DeliveryQuantity}, {item.OrderStatus}, getdate(), '{item.CreateUser}', getdate(), '{item.LastUpdateUser}');");

                sb.AppendLine($" update smt_zd_material set Status = {(int)BarcodeStatusEnum.Locked}, Work_Order_No = '{deliveryId}', LockRequestID = ''  where  ReelID = '{item.Barcode}'; ");
            }

            return DbHelper.ExcuteWithTransaction(sb.ToString(), out string _) > 0;
        }


        protected override int GetSortNo(int deliveryType)
        {
            string sql = $@" SELECT TOP 1 wdo.SortingId FROM Wms_DeliveryOrder wdo WHERE OrderStatus = {(int)DeliveryOrderStatusEnum.Delivering}; ";
            int currentNo = TypeParse.StrToInt(Convert.ToString(DbHelper.ExecuteScalar(sql)), -1);
            if (deliveryType == (int)DeliveryOrderTypeEnum.FirstSet)
            {
                if (currentNo == (int)SortNoEnum.FirstSet)
                {
                    throw new OppoCoreException("当前工单为首盘料工单，首盘料出料口当前被占用，无法出库，请等待");
                }
                return (int)SortNoEnum.FirstSet;
            }
            if (currentNo == (int)SortNoEnum.FreeFirst)
            {
                return (int)SortNoEnum.FreeSecond;
            }
            else
            {
                return (int)SortNoEnum.FreeFirst;
            }
        }


        protected override List<DeliveryBarcodeLocation> GetDeliveryBarcodesDetail(string deliveryId, int targetStatus)
        {
            string sql = $@"SELECT wdb.Barcode, wdb.DeliveryAreaId, szm.LockLocation, szm.ABSide, szm.LockMachineID, szm.Part_Number, wdb.DeliveryQuantity, wdb.OrderStatus as BarcodeStatus   
                        FROM Wms_DeliveryBarcode wdb 
                        left join smt_zd_material szm on wdb.Barcode = szm.ReelID 
                        WHERE wdb.DeliveryId = '{deliveryId}' AND wdb.OrderStatus <= {targetStatus}";

            return DbHelper.GetDataTable(sql).DataTableToList<DeliveryBarcodeLocation>();
        }


        protected override string GetDeliveredUpdateSql(string deliveryId, int sortingNo, string userName)
        {
            return $@"update Wms_DeliveryOrder set OrderStatus = {(int)DeliveryOrderStatusEnum.Delivering}, 
                    LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}', SortingId = {sortingNo}  where BusinessId = '{deliveryId}'; ";
        }

        protected override string GetFinshedUpdateSql(string deliveryId, string userName)
        {
            return $@"update Wms_DeliveryOrder set OrderStatus = {(int)DeliveryOrderStatusEnum.Delivered}, 
                    LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}'  where BusinessId = '{deliveryId}'; ";
        }

        protected override int GetExecuteStatus()
        {
            return (int)DeliveryBarcodeStatusEnum.Undeliver;
        }

        protected override int GetFinishedStatus()
        {
            return (int)DeliveryBarcodeStatusEnum.Delivered;
        }

        public static List<Wms_DeliveryOrder> GetOrdersForReview(int deliveryType)
        {
            string sql = $"SELECT * FROM Wms_DeliveryOrder wdo WHERE wdo.OrderStatus = {(int)DeliveryOrderStatusEnum.Delivered} AND DeliveryType = {deliveryType}";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_DeliveryOrder>();
        }

        public static List<Wms_DeliveryOrder> GetDeliveringOrders()
        {
            string sql = $@" SELECT TOP 2 * FROM Wms_DeliveryOrder wdo WHERE OrderStatus = {(int)DeliveryOrderStatusEnum.Delivering}; ";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_DeliveryOrder>();
        }
    }

    public class DeliveryQueryCondition
    {
        public string OrderNo { get; set; }
        public int OrderType { get; set; }
        public int OrderStatus { get; set; }
        public string Destination { get; set; }
        public string MaterialNo { get; set; }
        public string Upn { get; set; }
        public bool HaveOrderTimeQuery { get; set; } = false;
        public DateTime OrderTimeStart { get; set; }
        public DateTime OrderTimeEnd { get; set; }
        public bool HaveFinishedTimeQuery { get; set; } = false;
        public DateTime FinishedTimeStart { get; set; }
        public DateTime FinishedTimeEnd { get; set; }

        public string Operator { get; set; }
    }

}
