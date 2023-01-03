using DataBase;
using Entity;
using Entity.DataContext;
using Entity.Dto;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TirionWinfromFrame.Commons;

namespace Business
{
    /// <summary>
    /// 入库单相关
    /// </summary>
    public static class WareHouseBLL
    {
        /// <summary>
        /// 锁定料塔
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static bool LockTower(string instockId, int areaId, string userName)
        {
            if (areaId != (int)TowerEnum.SortingArea)
            {
                string existSql = $@"SELECT wia.*, wio.InstockNo 
                    FROM Wms_InstockArea wia 
                    left join Wms_InstockOrder wio on wia.InstockId = wio.BusinessId 
                    WHERE  wia.AreaId = {areaId} AND wia.DetailStatus = {(int)InstockAreaBindingStatusEnum.Bound} ";
                var existOrders = DbHelper.GetDataTable(existSql);
                if (existOrders != null && existOrders.Rows.Count > 0)
                {
                    string existId = Convert.ToString(existOrders.Rows[0]["InstockId"]);
                    if (existId != instockId)
                    {
                        throw new OppoCoreException($"当前库区{EnumHelper.GetDescription(typeof(TowerEnum), areaId)}已被入库单{existOrders.Rows[0]["InstockNo"]}绑定");
                    }
                    else
                    {
                        return true;//已绑定
                    }
                }
            }

            string sql = $@"INSERT INTO Wms_InstockArea
                    (BusinessId, InstockId, AreaId, DetailStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
                    VALUES('{Guid.NewGuid():D}', '{instockId}', {areaId}, {(int)InstockAreaBindingStatusEnum.Bound}, getdate(), '{userName}', getdate(), '{userName}') ";
            return DbHelper.ExecuteNonQuery(sql) > 0;
        }

        /// <summary>
        /// 根据订单号解锁
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <returns></returns>
        public static bool UnlockTowerByOrder(string instockId, string userName)
        {
            string sql = $@"UPDATE Wms_InstockArea
                        SET  DetailStatus={(int)InstockAreaBindingStatusEnum.Unbound}, LastUpdateTime=getdate(), LastUpdateUser='{userName}'
                        WHERE InstockId='{instockId}' ";
            return DbHelper.Update(sql) > 0;
        }

        /// <summary>
        /// 解锁单个库区
        /// </summary>
        public static bool UnLockTower(string instockId, int towerNo, string userName)
        {
            string sql = $@"UPDATE Wms_InstockArea
                        SET  DetailStatus={(int)InstockAreaBindingStatusEnum.Unbound}, LastUpdateTime=getdate(), LastUpdateUser='{userName}'
                        WHERE InstockId='{instockId}' AND  AreaId={towerNo} ";
            return DbHelper.Update(sql) > 0;
        }

        public static IEnumerable<Wms_InstockOrder> GetInstockOrders(string orderNo, string upn, string materialNo, int orderType, int orderStatus, string operatorUser, DateTime? startTime, DateTime? endTime)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(upn))
            {
                sb.AppendLine(@"SELECT wio.*
                    FROM Wms_InstockBarcode wib  
                    left join Wms_InstockOrder wio on wib.InstockId = wio.BusinessId WHERE 1=1 ");
                sb.AppendLine(" AND wib.Barcode = @Barcode ");
                parameters.Add(new SqlParameter("@Barcode", upn));
            }
            else if (!string.IsNullOrWhiteSpace(materialNo))
            {
                sb.AppendLine(@"SELECT wio.*
	                FROM Wms_InstockDetail wid   
	                left join Wms_InstockOrder wio on wid.InstockId = wio.BusinessId  WHERE 1=1 ");
                sb.AppendLine(" AND wid.MaterialNo = @MaterialNo ");
                parameters.Add(new SqlParameter("@MaterialNo", materialNo));
            }
            else
            {
                sb.AppendLine(@" SELECT wio.*
	                FROM  Wms_InstockOrder wio WHERE 1=1 ");
            }
            if (!string.IsNullOrWhiteSpace(orderNo))
            {
                sb.AppendLine(" AND wio.InstockNo = @InstockNo ");
                parameters.Add(new SqlParameter("@InstockNo", orderNo));
            }
            if (orderType >= 0)
            {
                sb.AppendLine(" AND wio.InstockType = @InstockType ");
                parameters.Add(new SqlParameter("@InstockType", orderType));
            }
            if (orderStatus >= 0)
            {
                sb.AppendLine(" AND wio.OrderStatus = @OrderStatus ");
                parameters.Add(new SqlParameter("@OrderStatus", orderStatus));
            }
            if (!string.IsNullOrWhiteSpace(operatorUser))
            {
                sb.AppendLine(" AND wio.LastUpdateUser = @LastUpdateUser ");
                parameters.Add(new SqlParameter("@LastUpdateUser", operatorUser));
            }
            if (startTime.HasValue)
            {
                sb.AppendLine(" AND wio.LastUpdateTime >= @StartTime ");
                parameters.Add(new SqlParameter("@StartTime", startTime.Value.Date));
            }
            if (endTime.HasValue)
            {
                sb.AppendLine(" AND wio.LastUpdateTime <= @EndTime ");
                parameters.Add(new SqlParameter("@EndTime", endTime.Value.Date.AddDays(1).AddSeconds(-1)));
            }
            sb.AppendLine("	ORDER BY wio.CreateTime DESC  ");

            var orders = DbHelper.GetDataTable(sb.ToString(), parameters.ToArray());

            return orders.DataTableToList<Wms_InstockOrder>();
        }

        public static IEnumerable<Wms_InstockDetail> GetInstockDetails(string instockId)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Wms_InstockDetail.GetSelectSql());
            sb.AppendLine(" AND InstockId = @InstockId ");

            var details = DbHelper.GetDataTable(sb.ToString(), new SqlParameter("@InstockId", instockId));

            return details.DataTableToList<Wms_InstockDetail>();
        }

        public static DataTable GetInstockBarcodes(string instockId)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"
                SELECT wib.Barcode as Upn, szm.Part_Number as MaterialNo, wib.InstockQuantity as InnerQty, wib.LastUpdateUser as Operator, 
                szm.LockLocation as Location, wib.InstockAreaId as TowerNo, wib.CreateTime, wib.InstockDetailId 
                FROM Wms_InstockBarcode wib 
                left join smt_zd_material szm on wib.Barcode = szm.ReelID ");
            sb.AppendLine(" WHERE wib.InstockId = @InstockId ");

            var details = DbHelper.GetDataTable(sb.ToString(), new SqlParameter("@InstockId", instockId));

            return details;
        }

        public static bool UpdateOrderRemark(string orderNo, string remark, string operater)
        {
            string sql = "UPDATE Wms_InstockOrder SET LastUpdateUser = @LastUpdateUser, LastUpdateTime = GETDATE(), Remark =@Remark WHERE InstockNo =@InstockNo ";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@InstockNo", orderNo));
            parameters.Add(new SqlParameter("@LastUpdateUser", operater));
            parameters.Add(new SqlParameter("@Remark", remark));

            return DbHelper.ExecuteNonQuery(sql, parameters.ToArray()) > 0;
        }

        public static void FinishInstockOrder(string instockId, int finishStatus, int instockType, string userName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($@"UPDATE Wms_InstockOrder
                        SET OrderStatus={finishStatus}, LastUpdateTime=getdate(), LastUpdateUser='{userName}'
                        WHERE BusinessId='{instockId}'; ");
            sb.AppendLine(GetFeedBackSql(instockId, instockType));

            DbHelper.ExcuteWithTransaction(sb.ToString(), out string _);
        }

        public static void 

        private static string GetFeedBackSql(string instockId, int instockType)
        {
            return $@"INSERT INTO smt_InStockOrder_feedback
                        (OrderNo, Status, OrderType)
                        VALUES('{instockId}', 0, '{(InOrderTypeEnum)instockType}');";
        }

        public static IEnumerable<InstockAreaDto> GetBoundAreas()
        {
            string sql = $@"SELECT wia.*, wio.InstockNo 
                    FROM Wms_InstockArea wia 
                    left join Wms_InstockOrder wio on wia.InstockId = wio.BusinessId 
                    WHERE  wia.DetailStatus = {(int)InstockAreaBindingStatusEnum.Bound} ";
            return DbHelper.GetDataTable(sql).DataTableToList<InstockAreaDto>();
        }

        public static IEnumerable<MaterialCensusDto> CensusMaterials()
        {
            string sql = @"select Part_Number as MaterialNo,SUM(qty) as TotalCount from smt_zd_material
                where Status>0 and Status<3
                group by Part_Number";
            return DbHelper.GetDataTable(sql).DataTableToList<MaterialCensusDto>();
        }
    }
}
