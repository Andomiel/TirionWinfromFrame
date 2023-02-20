using DataBase;
using Entity.DataContext;
using Entity.Dto.Balance;
using Entity.Enums;
using Entity.Enums.Instock;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TirionWinfromFrame.Commons;

namespace Business
{
    public static class BalanceBusiness
    {
        public static IEnumerable<Wms_BalanceOrder> GetBalanceOrders(BalanceQueryCondition condition)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            if ((!string.IsNullOrWhiteSpace(condition.Upn)) || (!string.IsNullOrWhiteSpace(condition.MaterialNo)))
            {
                sb.AppendLine(@"SELECT TOP 100 wbo.*
FROM Wms_BalanceBarcode wbb WITH(NOLock) 
LEFT JOIN Wms_BalanceOrder wbo WITH(NOLock) ON wbb.BalanceId = wbo.BusinessId 
WHERE 1=1");
                if (!string.IsNullOrWhiteSpace(condition.Upn))
                {
                    sb.AppendLine(" AND wbb.Barcode = @Barcode ");
                    parameters.Add(new SqlParameter("@Barcode", condition.Upn));
                }
                else
                {
                    sb.AppendLine(" AND wbb.Barcode Like @MaterialNo ");
                    parameters.Add(new SqlParameter("@MaterialNo", condition.MaterialNo));
                }
            }
            else
            {
                sb.AppendLine(@" SELECT TOP 100 wbo.*
	                FROM  Wms_BalanceOrder wbo WITH(NOLock) WHERE 1=1 ");
            }
            if (!string.IsNullOrWhiteSpace(condition.OrderNo))
            {
                sb.AppendLine(" AND wbo.InventoryNo = @InventoryNo ");
                parameters.Add(new SqlParameter("@InventoryNo", condition.OrderNo));
            }
            if (condition.OrderStatus >= 0)
            {
                sb.AppendLine(" AND wbo.OrderStatus = @OrderStatus ");
                parameters.Add(new SqlParameter("@OrderStatus", condition.OrderStatus));
            }
            if (condition.HaveOrderTimeQuery)
            {
                sb.AppendLine(" AND wbo.CreateTime >= @StartTime AND wbo.CreateTime < @EndTime ");
                parameters.Add(new SqlParameter("@StartTime", condition.OrderTimeStart));
                parameters.Add(new SqlParameter("@EndTime", condition.OrderTimeEnd));
            }
            if (condition.HaveFinishedTimeQuery)
            {
                sb.AppendLine(" AND wbo.LastUpdateTime >= @FinishStartTime AND wbo.LastUpdateTime < @FinishEndTime ");
                parameters.Add(new SqlParameter("@FinishStartTime", condition.FinishedTimeStart));
                parameters.Add(new SqlParameter("@FinishEndTime", condition.FinishedTimeEnd));
            }
            sb.AppendLine("	ORDER BY wbo.CreateTime DESC  ");

            var orders = DbHelper.GetDataTable(sb.ToString(), parameters.ToArray());

            return orders.DataTableToList<Wms_BalanceOrder>();
        }

        public static IEnumerable<Wms_BalanceBarcode> GetBalanceBarcodes(string balanceId)
        {
            string sql = $@"SELECT wbb.*
                        FROM Wms_BalanceBarcode wbb WITH(NOLock)  WHERE wbb.BalanceId = '{balanceId}' AND OrderStatus = {(int)BalanceBarcodeStatusEnum.Finished} ";

            return DbHelper.GetDataTable(sql).DataTableToList<Wms_BalanceBarcode>();
        }

        public static Wms_BalanceOrder GetBalanceOrderByNo(string balanceNo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Wms_BalanceOrder.GetSelectSql());
            sb.AppendLine(" AND BalanceNo = @BalanceNo ");

            var orders = DbHelper.GetDataTable(sb.ToString(), new SqlParameter("@BalanceNo", balanceNo));
            if (orders == null || orders.Rows.Count == 0)
            {
                return null;
            }

            return orders.DataTableToList<Wms_BalanceOrder>().First();
        }

        public static void InsertOrder(BalanceOrderDto order)
        {
            string sql = $@"INSERT INTO Wms_BalanceOrder
(BusinessId, BalanceNo, OrderStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
VALUES('{order.BusinessId}', '{order.BalanceNo}', {order.OrderStatus}, '{order.Remark}', getdate(), '{order.CreateUser}', getdate(), '{order.LastUpdateUser}')";
            DbHelper.ExecuteNonQuery(sql);
        }

        public static bool UpdateBalanceOrderStatus(string balanceId, int orderStatus, string userName)
        {
            string sql = $"UPDATE Wms_BalanceOrder set OrderStatus = {orderStatus}, LastUpdateTime = GETDATE(), LastUpdateUser ='{userName}' WHERE BusinessId = '{balanceId}' ";
            return DbHelper.ExecuteNonQuery(sql) > 0;
        }

        public static void InsertBarcode(BalanceBarcodeDto barcodeDto, string userName)
        {
            string sql = $@"INSERT INTO Wms_BalanceBarcode
(BusinessId, BalanceId, Barcode, AreaId, BalanceLocation, Quantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser, MaterialNo)
VALUES('{barcodeDto.BusinessId}', '{barcodeDto.BalanceId}', '{barcodeDto.Barcode}', {barcodeDto.AreaId}, '{barcodeDto.BalanceLocation}', {barcodeDto.Quantity}, {barcodeDto.OrderStatus}, getdate(), '{userName}', getdate(), '{userName}', '{barcodeDto.MaterialNo}')";
            DbHelper.ExecuteNonQuery(sql);
        }

        public static void UpdateBarcodeStatus(BalanceBarcodeDto barcodeDto, string userName)
        {
            string sql = $@"UPDATE Wms_BalanceBarcode set OrderStatus = {barcodeDto.OrderStatus}, LastUpdateTime = GETDATE(), LastUpdateUser ='{userName}' WHERE BusinessId = '{barcodeDto.BusinessId}' ";
            DbHelper.ExecuteNonQuery(sql);
        }

        public static Wms_BalanceOrder GetLastBalanceByCertainDate(DateTime date)
        {
            string sql = $@"SELECT TOP 1 *
FROM Wms_BalanceOrder wbo  WITH(NOLock) 
WHERE  OrderStatus = {(int)BalanceOrderStatusEnum.Finished} AND wbo.CreateTime >= '{date:yyyy-MM-dd}' AND wbo.CreateTime < '{date.AddDays(1):yyyy-MM-dd}'
ORDER BY CreateTime DESC  ";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_BalanceOrder>().FirstOrDefault();
        }

        public static Wms_BalanceOrder GetLasBalanceBeforeCertainDate(DateTime date)
        {
            string sql = $@"SELECT TOP 1 *
FROM Wms_BalanceOrder wbo  WITH(NOLock) 
WHERE  OrderStatus = {(int)BalanceOrderStatusEnum.Finished} AND wbo.CreateTime < '{date:yyyy-MM-dd}'
ORDER BY CreateTime DESC  ";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_BalanceOrder>().FirstOrDefault();
        }

        public static IEnumerable<BalanceMaterialDto> GetBalanceMaterials(string balanceId)
        {
            string sql = $@"SELECT MaterialNo, SUM(Quantity) as TotalQuantity 
FROM Wms_BalanceBarcode wbb  WITH(NOLock) 
WHERE wbb.BalanceId = '{balanceId}' AND wbb.OrderStatus = {(int)BalanceBarcodeStatusEnum.Finished} 
GROUP BY wbb.MaterialNo ";
            return DbHelper.GetDataTable(sql).DataTableToList<BalanceMaterialDto>();
        }

        public static IEnumerable<BalanceOrderMaterialDto> GetBalanceInstockMaterials(DateTime startTime, DateTime endTime)
        {
            string sql = $@"SELECT wio.InstockType as OrderType, wid.MaterialNo, SUM(wib.InstockQuantity) as TotalQuantity 
FROM Wms_InstockBarcode wib WITH(NOLock) 
left join Wms_InstockDetail wid WITH(NOLock)  on wib.InstockDetailId = wid.BusinessId 
left JOIN Wms_InstockOrder wio WITH(NOLock)  on wib.InstockId = wio.BusinessId 
WHERE wib.OrderStatus = {(int)InstockBarcodeStatusEnum.Received} AND wib.LastUpdateTime >='{startTime:yyyy-MM-dd HH:mm:ss}' AND wib.LastUpdateTime <='{endTime:yyyy-MM-dd HH:mm:ss}' 
GROUP BY wio.InstockType, wid.MaterialNo";
            return DbHelper.GetDataTable(sql).DataTableToList<BalanceOrderMaterialDto>();
        }

        public static IEnumerable<BalanceOrderMaterialDto> GetBalanceOutstockMaterials(DateTime startTime, DateTime endTime)
        {
            string sql = $@"SELECT wdo.DeliveryType as OrderType, wdd.MaterialNo, SUM(wdb.DeliveryQuantity) as TotalQuantity
FROM Wms_DeliveryBarcode wdb WITH(NOLock) 
left join Wms_DeliveryDetail wdd WITH(NOLock) on wdb.DeliveryDetailId = wdd.BusinessId 
left join Wms_DeliveryOrder wdo WITH(NOLock) on wdd.DeliveryId = wdo.BusinessId 
WHERE wdb.OrderStatus = {(int)DeliveryBarcodeStatusEnum.Reviewed} and wdb.LastUpdateTime >= '{startTime:yyyy-MM-dd HH:mm:ss}' and wdb.LastUpdateTime <= '{endTime:yyyy-MM-dd HH:mm:ss}'
GROUP BY wdo.DeliveryType, wdd.MaterialNo ";
            return DbHelper.GetDataTable(sql).DataTableToList<BalanceOrderMaterialDto>();
        }
    }
    public class BalanceQueryCondition
    {
        public string OrderNo { get; set; }
        public int OrderStatus { get; set; }
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
