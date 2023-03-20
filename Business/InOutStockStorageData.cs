using DataBase;
using Entity.DataContext;
using Entity.Dto;
using Entity.Enums;
using Entity.Enums.Instock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TirionWinfromFrame.Commons;

namespace Business
{
    public static class InOutStockStorageData
    {
        public static void CreateInstockOrderFromExcel(DataTable dt, string userName)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new OppoCoreException("表格中没有有效数据");
            }
            var order = new Wms_InstockOrder()
            {
                BusinessId = Guid.NewGuid().ToString("D"),
                CreateTime = DateTime.Now,
                CreateUser = userName,
                InstockNo = $"EXCEL{DateTime.Now:yyyyMMddHHmmss}",
                InstockType = (int)InOrderTypeEnum.Excel导入,
                LastUpdateTime = DateTime.Now,
                LastUpdateUser = userName,
                OrderStatus = (int)InstockOrderStatusEnum.Finished,
            };
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetInstockOrderInsertSql(order));

            List<Wms_InstockDetail> details = new List<Wms_InstockDetail>();

            foreach (DataRow item in dt.Rows)
            {
                string qrCode = Convert.ToString(item["二维码"]);
                string upn = Convert.ToString(item["UPN"]);
                var barcode = GetBarcodeInfo(qrCode);
                if (barcode.Barcode != upn)
                {
                    throw new OppoCoreException($"表格中Upn{upn}对应的二维码解析出来的Upn不正确");
                }
                int quantity = TypeParse.StrToInt(item["数量"], 0);
                var detail = details.FirstOrDefault(p => p.MaterialNo == barcode.MaterialNo);
                if (detail == null)
                {
                    detail = new Wms_InstockDetail()
                    {
                        BusinessId = Guid.NewGuid().ToString("D"),
                        CreateTime = DateTime.Now,
                        CreateUser = userName,
                        DetailStatus = (int)InstockDetailStatusEnum.Received,
                        InstockId = order.BusinessId,
                        LastUpdateTime = DateTime.Now,
                        LastUpdateUser = userName,
                        MaterialNo = barcode.MaterialNo,
                        RequireCount = quantity,
                    };
                    details.Add(detail);
                }
                else
                {
                    detail.RequireCount += quantity;
                }
                var instockBarcode = new Wms_InstockBarcode()
                {
                    InstockAreaId = (int)TowerEnum.SortingArea,
                    InstockDetailId = detail.BusinessId,
                    Barcode = Convert.ToString(item["UPN"]),
                    BusinessId = Guid.NewGuid().ToString("D"),
                    CreateTime = DateTime.Now,
                    CreateUser = userName,
                    InstockId = order.BusinessId,
                    InstockQuantity = quantity,
                    LastUpdateTime = DateTime.Now,
                    LastUpdateUser = userName,
                    OrderStatus = (int)InstockBarcodeStatusEnum.Received,
                };
                sb.AppendLine(GetInstockBarcodeInsertSql(instockBarcode));
                sb.AppendLine(GetTargetBarcodeInsertSql(order.InstockNo, barcode, item));
            }
            foreach (var item in details)
            {
                sb.AppendLine(GetInstockDetailInsertSql(item));
            }
            DbHelper.ExcuteWithTransaction(sb.ToString(), out string _);
        }

        private static string GetInstockOrderInsertSql(Wms_InstockOrder order)
        {
            return $@"INSERT INTO Wms_InstockOrder
                    (BusinessId, InstockNo, InstockType, OrderStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
                VALUES('{order.BusinessId}', '{order.InstockNo}', {order.InstockType}, {order.OrderStatus}, '{order.Remark}', getdate(), '{order.CreateUser}', getdate(), '{order.LastUpdateUser}');";
        }

        private static string GetInstockDetailInsertSql(Wms_InstockDetail detail)
        {
            return $@"INSERT INTO Wms_InstockDetail
                            (BusinessId, InstockId, MaterialNo, RequireCount, DetailStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
                            VALUES('{detail.BusinessId}', '{detail.InstockId}', '{detail.MaterialNo}', {detail.RequireCount}, {detail.DetailStatus}, getdate(), '{detail.CreateUser}', getdate(), '{detail.LastUpdateUser}');";
        }

        private static string GetInstockBarcodeInsertSql(Wms_InstockBarcode barcode)
        {
            return $@"INSERT INTO Wms_InstockBarcode
                (BusinessId, InstockId, InstockDetailId, InstockAreaId, Barcode, InstockQuantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
                VALUES('{barcode.BusinessId}', '{barcode.InstockId}', '{barcode.InstockDetailId}', {barcode.InstockAreaId}, '{barcode.Barcode}', {barcode.InstockQuantity}, {barcode.OrderStatus}, getdate(), '{barcode.CreateUser}', getdate(), '{barcode.LastUpdateUser}');";
        }

        private static string GetTargetBarcodeInsertSql(string instockOrderNo, AnalysisedBarcode barcode, DataRow row)
        {
            int quantity = TypeParse.StrToInt(row["数量"], 0);
            barcode.Quantity = quantity;

            return $@"DELETE FROM smt_zd_material WHERE ReelID = '{barcode.Barcode}';
                INSERT INTO smt_zd_material
                (ReelID, Part_Number, DateCode, lot, Qty, Work_Order_No, FactoryCode, SaveTime, LockTowerNo, isSave, isTake, BATCH, BatchNo, Status, WZ_SCCJ, MSD, InStockOrderNo, MinPacking, CameraString, ReelType, ReelSize, SerialNo, QRCode, BakeState)
                VALUES('{barcode.Barcode}', '{barcode.MaterialNo}', '{barcode.Dc}', '{barcode.Lot}', {barcode.Quantity}, '', '{barcode.Supplier}', getdate(), {(int)TowerEnum.SortingArea}, 1, 0, '{barcode.Lot}', '{row["流水号"]}', {(int)BarcodeStatusEnum.Saved}, '{barcode.Supplier}', '{barcode.Msd}', '{instockOrderNo}', {barcode.MiniPacking}, '{barcode.Qrcode}', '{barcode.ReelType}', '7', '{row["流水号"]}', '{barcode.Qrcode}', 0);";
        }

        private static AnalysisedBarcode GetBarcodeInfo(string qrcode)
        {
            string[] arr = qrcode.Split('*');
            if (arr.Length < 8 || arr.Length > 11)
            {
                throw new OppoCoreException($"当前表格中的二维码{qrcode}不符合解析规则");
            }
            AnalysisedBarcode barcode = new AnalysisedBarcode();

            //规则：二维码第一个*以前的内容
            barcode.Barcode = arr[0];
            var barcodeElements = barcode.Barcode.Split('-');
            if (barcodeElements.Length > 3)
            {
                //规则：第一个“-”以前的内容
                barcode.MaterialNo = barcodeElements[0];
                //第二个“-”和第三个“-”之间的内容
                //（A代表10月，B代表十一月，C代表十二月）
                barcode.Dc = barcodeElements[2];
                //规则：第一个“-”和第二个“-”之间的内容，
                //去除最后一位（总位数可能4位或5位
                barcode.Supplier = barcodeElements[1].Substring(0, barcodeElements[1].Length - 1);
                //流水号,这里用批次号来算,:第三个“-”到第一个“*”之间
                barcode.Lot = barcodeElements[3];
            }
            barcode.Msd = arr[2];
            barcode.MiniPacking = TypeParse.StrToInt(arr[6], 0);

            return barcode;
        }

        public static int UpdateUpnInfoFromImportExcel(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return 0;
            }
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendLine($"update smt_zd_material set QRCode='{dr["二维码"]}', DateCode='{dr["打印日期"]}', SerialNo='{dr["流水号"]}', ReelType='{dr["料盘规格"]}', WZ_SCCJ='{dr["厂商"]}', FactoryCode='{dr["厂商"]}' where ReelID='{dr["UPN"]}';");
            }
            return DbHelper.Update(sb.ToString());
        }

        private static string BuildInventoryFullSql(string condition, int startRow, int endRow, string orderBy)
        {
            return $@"With Barcodes AS
              (
            SELECT
                ROW_NUMBER() OVER(ORDER BY {orderBy}) RowNumber,  
                COUNT(1) OVER() AS TotalCount,
                s.qty as Qty,s.Part_Number as PartNumber,s.reelid as UPN,
                s.lot,s.XM_DH,s.WZ_SCCJ as Supplier,
                s.SerialNo, s.ReelType as UpnCate, s.DateCode,
                s.MinPacking, s.MSD, s.Status,
                s.LockTowerNo AS Tower,
                isnull(s.ABSide,'')+isnull(s.LockMachineID,'') as ABSide,s.SaveTime,
                s.LockLocation AS Location, 
                CASE WHEN smf.UPN is not null THEN '冻结' ELSE CASE s.BakeState WHEN 0 THEN '正常' WHEN 1 THEN '待烘烤' WHEN 2 THEN '烘烤中' END  END AS HoldState,
                '' AS HoldNo
            FROM smt_zd_material s
                LEFT JOIN (SELECT DISTINCT UPN FROM smt_Material_Frozen) smf ON s.ReelID = smf.UPN
            WHERE s.isTakeCheck=0 AND s.Status>0 {condition}
              ) 
            SELECT * FROM Barcodes
             WHERE Barcodes.RowNumber > {startRow} AND Barcodes.RowNumber <= {endRow}";
        }

        /// <summary>
        /// 查询正常物资信息
        /// </summary>
        public static IEnumerable<InventoryEntity> GetSmt_zd_MaterialInfo(MaterialQueryCondition condition, int startRow, int endRow, string orderBy)
        {
            string sql = BuildInventoryFullSql(BuildConditionSql(condition), startRow, endRow, orderBy);
            return DbHelper.GetDataTable(sql).DataTableToList<InventoryEntity>();
        }

        private static string BuildConditionSql(MaterialQueryCondition condition)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(condition.Supplier))
            {
                sb.Append($" AND s.WZ_SCCJ='{condition.Supplier}' ");
            }
            if (condition.HoldState == "冻结")
            {
                sb.Append(" AND smf.UPN is not null ");
            }
            else if (condition.HoldState == "正常")
            {
                sb.Append($" AND smf.UPN is null AND s.BakeState = {(int)BakeStateEnum.Normal} ");
            }
            else if (condition.HoldState == "待烘烤")
            {
                sb.Append($" AND smf.UPN is null AND s.BakeState = {(int)BakeStateEnum.WaitForBake} ");
            }
            else if (condition.HoldState == "烘烤中")
            {
                sb.Append($" AND smf.UPN is null AND s.BakeState = {(int)BakeStateEnum.Baking} ");
            }
            else
            {
                //do nothing
            }

            if (!string.IsNullOrWhiteSpace(condition.ABSide))
            {
                sb.Append($" AND s.ABSide='{condition.ABSide}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.MachineId))
            {
                sb.Append($" AND s.LockMachineID='{condition.MachineId}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.MSD))
            {
                sb.Append($" AND s.MSD='{condition.MSD}'");
            }
            if (condition.TowerNo != -1)
            {
                sb.Append($" AND s.LockTowerNo='{condition.TowerNo}'");
            }

            if (!string.IsNullOrWhiteSpace(condition.UPN))
            {
                string[] elements = condition.UPN.Split('-');
                if (elements.Length >= 4)
                {
                    sb.Append($" AND s.reelid = '{condition.UPN}' ");
                }
                else
                {
                    sb.Append($" AND s.reelid like '%{condition.UPN}%' ");
                }
            }

            if (!string.IsNullOrWhiteSpace(condition.PartNumber))
            {
                int materialNoLength = condition.PartNumber.Trim().Length;
                if (materialNoLength == 7 || materialNoLength == 12)
                {
                    sb.Append($" AND s.Part_Number = '{condition.PartNumber}'");
                }
                else
                {
                    sb.Append($" AND s.Part_Number like '%{condition.PartNumber}%'");
                }
            }
            if (!string.IsNullOrWhiteSpace(condition.SerialNoStart))
            {
                sb.Append($" AND s.SerialNo >= '{condition.SerialNoStart}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.SerialNoEnd))
            {
                sb.Append($" AND s.SerialNo <= '{condition.SerialNoEnd}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.MateType))
            {
                sb.Append($" AND s.ReelType = '{condition.MateType}'");
            }
            if (condition.ExceedStart != 0 || condition.ExceedEnd != 0)
            {
                DateTime today = DateTime.Today;
                DateTime exceedDt1;
                DateTime exceedDt2;
                if (condition.ExceedStart > condition.ExceedEnd)
                {
                    exceedDt1 = today.AddDays(-condition.ExceedStart);
                    exceedDt2 = today.AddDays(-condition.ExceedEnd); ;
                }
                else
                {
                    exceedDt2 = today.AddDays(-condition.ExceedStart);
                    exceedDt1 = today.AddDays(-condition.ExceedEnd); ;
                }
                exceedDt2 = exceedDt2.AddDays(1);
                sb.Append($" AND s.SaveTime BETWEEN '{exceedDt1}' AND '{exceedDt2}' ");
            }
            else
            {
                if (condition.haveSaveTimeQuery)
                {
                    sb.Append($" AND s.SaveTime BETWEEN '{condition.SaveTimeStart}' AND '{condition.SaveTimeEnd}' ");
                }
            }
            return sb.ToString();
        }

        public static IEnumerable<InventoryEntity> GetMaterialInfoExport(MaterialQueryCondition condition)
        {
            string conditionSql = BuildConditionSql(condition);

            string sql = $@"SELECT
                1 TotalCount,
                s.qty as Qty,s.Part_Number as PartNumber,s.reelid as UPN,
                s.lot,s.XM_DH,s.WZ_SCCJ as Supplier,
                s.SerialNo, s.ReelType as UpnCate, s.DateCode,
                s.MinPacking, s.MSD, s.Status,
                s.LockTowerNo AS Tower,
                isnull(s.ABSide,'')+isnull(s.LockMachineID,'') as ABSide,s.SaveTime,
                s.LockLocation AS Location, 
                CASE WHEN smf.UPN is not null THEN '冻结' ELSE CASE s.BakeState WHEN 0 THEN '正常' WHEN 1 THEN '待烘烤' WHEN 2 THEN '烘烤中' END  END AS HoldState,
                smf.FrozenNo AS HoldNo
            FROM smt_zd_material s
                LEFT JOIN  smt_Material_Frozen smf ON s.ReelID = smf.UPN
            WHERE s.isTakeCheck=0 AND s.Status>0 {conditionSql}";

            return DbHelper.GetDataTable(sql).DataTableToList<InventoryEntity>();
        }

        public static DataTable GetAllMaterial()
        {
            string sql = "select * from smt_zd_material WITH(NOLock)  where LockTowerNo=0 and isTakeCheck = 0  ";
            return DbHelper.GetDataTable(sql);
        }

        public static int UpdateQtyFromMes(string barcode, int qty, string materialType)
        {
            string sql = $" update smt_zd_material set Qty = {qty}, ReelType = '{materialType}' where ReelID = '{barcode}' ";
            return DbHelper.Update(sql);
        }
    }

    public class AnalysisedBarcode
    {
        public string Barcode { get; set; } = string.Empty;

        public string MaterialNo { get; set; } = string.Empty;

        public string Supplier { get; set; } = string.Empty;

        public int MiniPacking { get; set; } = 0;

        public string Lot { get; set; } = string.Empty;

        public string Dc { get; set; } = string.Empty;

        public string Msd { get; set; } = string.Empty;

        public string Qrcode { get; set; } = string.Empty;

        public int Quantity { get; set; } = 0;

        public string ReelType
        {
            get
            {

                if (Quantity > 0 && MiniPacking > 0)
                {
                    decimal offset = MiniPacking - Quantity;
                    if ((Math.Abs(offset) / MiniPacking) * 1000 <= 3)
                    {
                        return "F";
                    }
                    else if ((offset / MiniPacking) * 1000 > 3)
                    {
                        return "S";
                    }
                    else if (offset / MiniPacking * 1000 < -3)
                    {
                        return "T";
                    }
                    else
                    {
                        //do nothing
                        return string.Empty;
                    }
                }
                return string.Empty;
            }
        }
    }
}
