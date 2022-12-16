using DataBase;
using Entity.DataContext;
using Entity.Enums;
using Entity.Enums.Transfer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TirionWinfromFrame.Commons;

namespace Business
{
    public class TransferBll : BaseDeliveryBll
    {
        protected override LightRecordTypeEnum OrderType => LightRecordTypeEnum.Transfer;

        public static List<Wms_TransferOrder> GetTransferOrders(TransferQueryCondition condition)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            if ((!string.IsNullOrWhiteSpace(condition.Upn)) || (!string.IsNullOrWhiteSpace(condition.MaterialNo)))
            {
                sb.AppendLine(@"SELECT wto.*
                        FROM Wms_TransferBarcode wtb 
                        left join Wms_TransferOrder wto on wtb.TransferOrderId = wto.BusinessId 
                        WHERE 1=1");
                if (!string.IsNullOrWhiteSpace(condition.Upn))
                {
                    sb.AppendLine(" AND wtb.Barcode = @Barcode ");
                    parameters.Add(new SqlParameter("@Barcode", condition.Upn));
                }
                else
                {
                    sb.AppendLine(" AND wtb.MaterialNo = @MaterialNo ");
                    parameters.Add(new SqlParameter("@MaterialNo", condition.MaterialNo));
                }
            }
            else
            {
                sb.AppendLine(@" SELECT wto.*
	                FROM  Wms_TransferOrder wto WHERE 1=1 ");
            }
            if (!string.IsNullOrWhiteSpace(condition.OrderNo))
            {
                sb.AppendLine(" AND wto.TransferNo = @TransferNo ");
                parameters.Add(new SqlParameter("@TransferNo", condition.OrderNo));
            }
            if (condition.TransferType >= 0)
            {
                sb.AppendLine(" AND wto.TransferType = @TransferType ");
                parameters.Add(new SqlParameter("@TransferType", condition.TransferType));
            }
            if (condition.OrderStatus >= 0)
            {
                sb.AppendLine(" AND wto.OrderStatus = @OrderStatus ");
                parameters.Add(new SqlParameter("@OrderStatus", condition.OrderStatus));
            }
            if (condition.HaveOrderTimeQuery)
            {
                sb.AppendLine(" AND wto.CreateTime >= @StartTime AND wto.CreateTime < @EndTime ");
                parameters.Add(new SqlParameter("@StartTime", condition.OrderTimeStart));
                parameters.Add(new SqlParameter("@EndTime", condition.OrderTimeEnd));
            }
            if (condition.HaveFinishedTimeQuery)
            {
                sb.AppendLine(" AND wto.LastUpdateTime >= @FinishStartTime AND wto.LastUpdateTime < @FinishEndTime ");
                parameters.Add(new SqlParameter("@FinishStartTime", condition.FinishedTimeStart));
                parameters.Add(new SqlParameter("@FinishEndTime", condition.FinishedTimeEnd));
            }
            sb.AppendLine("	ORDER BY wto.CreateTime DESC  ");

            var orders = DbHelper.GetDataTable(sb.ToString(), parameters.ToArray());

            return orders.DataTableToList<Wms_TransferOrder>();
        }

        public static Wms_TransferOrder GetTransferOrderByNo(string transferNo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Wms_TransferOrder.GetSelectSql());
            sb.AppendLine(" AND TransferNo = @TransferNo ");

            var orders = DbHelper.GetDataTable(sb.ToString(), new SqlParameter("@TransferNo", transferNo));
            if (orders == null || orders.Rows.Count == 0)
            {
                return null;
            }

            return orders.DataTableToList<Wms_TransferOrder>().First();
        }

        public static List<Wms_TransferBarcode> GetTransferBarcodes(string transferId)
        {
            string sql = $@"SELECT wtb.*
                        FROM Wms_TransferBarcode wtb WHERE wtb.TransferOrderId = '{transferId}' ";

            return DbHelper.GetDataTable(sql).DataTableToList<Wms_TransferBarcode>();
        }

        public static int ModifyTransferOrderStatus(string transferId, int targetStatus, string userName)
        {
            string sql = $@"UPDATE Wms_TransferOrder
                SET OrderStatus={targetStatus}, LastUpdateTime=getdate(), LastUpdateUser='{userName}'
                WHERE BusinessId = '{transferId}' ";
            return DbHelper.ExecuteNonQuery(sql);
        }

        public static int ReleaseTransferOrderBarcodes(List<string> barcodes)
        {
            if (barcodes == null || barcodes.Count == 0)
            {
                return 0;
            }
            string condition = string.Join(",", barcodes.Select(p => $"'{p}'").ToArray());
            string sql = $@"UPDATE smt_zd_material set Status = {(int)BarcodeStatusEnum.Saved}, isTake = 0  WHERE ReelID  in({condition}) ";
            return DbHelper.ExecuteNonQuery(sql);
        }

        protected override int GetSortNo(int deliveryType)
        {
            return 1;//紧急出料口
        }

        protected override List<DeliveryBarcodeLocation> GetDeliveryBarcodesDetail(string deliveryId, int targetStatus)
        {
            string sql = $@"SELECT wtb.Barcode, wto.SourceAreaId as DeliveryAreaId, wtb.TransferLocation as LockLocation, szm.ABSide, szm.LockMachineID, szm.Part_Number, wtb.TransferQuantity as DeliveryQuantity, wtb.OrderStatus as BarcodeStatus 
                        FROM Wms_TransferBarcode wtb 
                        LEFT JOIN smt_zd_material szm  on wtb.Barcode = szm.ReelID 
                        LEFT JOIN  Wms_TransferOrder wto on wtb.TransferOrderId = wto.BusinessId 
                        WHERE wtb.TransferOrderId = '{deliveryId}' AND wtb.OrderStatus <= {targetStatus} ;";

            return DbHelper.GetDataTable(sql).DataTableToList<DeliveryBarcodeLocation>();
        }

        protected override string GetDeliveredUpdateSql(string deliveryId, int sortingNo, string userName)
        {
            return $@"UPDATE Wms_TransferOrder
                SET OrderStatus={(int)TransferOrderStatusEnum.Executing}, LastUpdateTime=getdate(), LastUpdateUser='{userName}'
                WHERE BusinessId = '{deliveryId}'; ";
        }

        protected override string GetFinshedUpdateSql(string deliveryId, string userName)
        {
            return $@"UPDATE Wms_TransferOrder
                SET OrderStatus={(int)TransferOrderStatusEnum.Finished}, LastUpdateTime=getdate(), LastUpdateUser='{userName}'
                WHERE BusinessId = '{deliveryId}'; ";
        }

        protected override int GetExecuteStatus()
        {
            return (int)TransferBarcodeStatusEnum.Unfinished;
        }

        protected override int GetFinishedStatus()
        {
            return (int)TransferBarcodeStatusEnum.Finished;
        }

        protected override string GetReleaseBarcodeSql(string deliveryId, string userName, List<string> barcodes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in barcodes)
            {
                sb.AppendLine($@" update a set a.OrderStatus = {(int)TransferBarcodeStatusEnum.Cancelled}, a.LastUpdateTime=getdate(), a.LastUpdateUser='{userName}'
                    from Wms_TransferBarcode a
                    where a.TransferOrderId = '{deliveryId}' and a.Barcode = '{item}';");

                sb.AppendLine($" update smt_zd_material set Status = {(int)BarcodeStatusEnum.Saved}, isTake = 0, Work_Order_No = '', LockRequestID = ''  where  ReelID = '{item}'; ");
            }
            return sb.ToString();
        }

        public List<Wms_TransferOrder> GetExecutingOrders()
        {
            string sql = $"{Wms_TransferOrder.GetSelectSql()} AND OrderStatus = {(int)TransferOrderStatusEnum.Executing} ";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_TransferOrder>();
        }

        protected override int GetLargestStatus()
        {
            return (int)TransferBarcodeStatusEnum.Cancelled;
        }
    }

    public class TransferQueryCondition
    {
        public string OrderNo { get; set; }
        public int OrderStatus { get; set; }
        public int TransferType { get; set; }
        public string MaterialNo { get; set; }
        public string Upn { get; set; }
        public bool HaveOrderTimeQuery { get; set; } = false;
        public DateTime OrderTimeStart { get; set; }
        public DateTime OrderTimeEnd { get; set; }
        public bool HaveFinishedTimeQuery { get; set; } = false;
        public DateTime FinishedTimeStart { get; set; }
        public DateTime FinishedTimeEnd { get; set; }
    }
}
