using Commons;
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

            return $@"DELETE FROM smt_zd_material WHERE ReelID = '{barcode.Barcode}' AND isTake = 1;
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

        private static void InsertBaseData(List<string> deleteUpns, List<string> insertValues)
        {
            string sqlDelete = $@" DELETE FROM smt_BasicInfoByMes WHERE ReelId IN ('{string.Join("','", deleteUpns)}');";
            string sqlInsert = $@" INSERT INTO smt_BasicInfoByMes(ReelId,Part_Number,WZ_MC,WZ_GGXH,WZ_JLDW,WZ_JSZB,
                                                    WZ_SCCJ,WZ_HGSL,WZ_SFJY,WZ_JYZT,WZ_JYFS,WZ_SCPCH,WZ_YXRQ,WZ_ZSXBH,type2,Qty,SSXM) 
                                               VALUES {string.Join(",", insertValues)}";

            DbHelper.Delete(sqlDelete);
            DbHelper.Insert(sqlInsert);
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
                tm.Description as TowerDes,s.ABSide,s.SaveTime,
                CASE WHEN ISNULL(s.LockMachineID,'')='' OR s.LockTowerNo=4 THEN s.LockLocation ELSE s.LockMachineID+'-'+s.LockLocation END AS Location, 
                CASE WHEN smf.UPN is not null THEN '冻结' ELSE CASE s.BakeState WHEN 0 THEN '正常' WHEN 1 THEN '待烘烤' WHEN 2 THEN '烘烤中' END  END AS HoldState
            FROM smt_zd_material s
                LEFT JOIN (SELECT DISTINCT UPN FROM smt_Material_Frozen) smf ON s.ReelID = smf.UPN
                LEFT JOIN smt_TowerMap tm on tm.TowerNo = s.LockTowerNo 
            WHERE s.isTakeCheck=0 AND s.Status>0 {condition}
              ) 
            SELECT * FROM Barcodes
             WHERE Barcodes.RowNumber > {startRow} AND Barcodes.RowNumber <= {endRow}";
        }

        /// <summary>
        /// 查询正常物资信息
        /// </summary>
        public static List<InventoryEntity> GetSmt_zd_MaterialInfo(MaterialQueryCondition condition, int startRow, int endRow, string orderBy)
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
                sb.Append($" AND s.reelid like '%{condition.UPN}%' ");
            }

            if (!string.IsNullOrWhiteSpace(condition.PartNumber))
            {
                sb.Append($" AND s.Part_Number like '%{condition.PartNumber}%'");
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
            //sb.Append(" ORDER BY s.LockTowerNo ");

            string sql = BuildInventoryFullSql(sb.ToString(), startRow, endRow, orderBy);
            List<InventoryEntity> queryResult = DbHelper.GetDataTable(sql).DataTableToList<InventoryEntity>();
            //if (condition.haveCycleQuery)
            //{
            //    queryResult = queryResult.Where(p => (DateTime.Compare(p.DateCodeDate, condition.CycleStart) >= 0
            //                                      && DateTime.Compare(p.DateCodeDate, condition.CycleEnd) <= 0)
            //                                      || p.DateCodeDate.Year == 1900).ToList();
            //}

            return queryResult;
        }

        public static int UpdateSmt_zd_MaterialPanDian(string pdCode, string strReelid)
        {
            //时间
            string updateTime = System.DateTime.Now.ToString();
            string sql = string.Format("update smt_zd_material set PandianCode='{0}' where ReelID in {1}", pdCode, strReelid);
            return DbHelper.Update(sql);
        }

        //盘点下达
        public static int UpdatePandianDan(string pdCode, string strReelid)
        {
            //时间
            string updateTime = System.DateTime.Now.ToString();
            string sql = string.Format("update smt_pandianDan set State='1' where PDCode='{0}' and  WZ_TM = '{1}'", pdCode, strReelid);
            return DbHelper.Update(sql);
        }

        //盘点取消
        public static int CancelPandianDan(string pdCode, string strReelid)
        {
            //时间
            string updateTime = System.DateTime.Now.ToString();
            string sql = string.Format("update smt_pandianDan set State='0' where PDCode='{0}' and  WZ_TM = '{1}'", pdCode, strReelid);
            return DbHelper.Update(sql);
        }

        //盘点执行中
        public static int ExecutePandianDan(string pdCode, string strReelid)
        {
            //时间
            string updateTime = System.DateTime.Now.ToString();
            string sql = string.Format("update smt_pandianDan set State='1',checkState='0' where PDCode='{0}' and  WZ_TM = '{1}'", pdCode, strReelid);
            return DbHelper.Update(sql);
        }

        //盘点审核
        public static int checkPandianDan(string pdCode, string strReelid)
        {
            //时间
            string updateTime = System.DateTime.Now.ToString();
            string sql = string.Format("update smt_pandianDan set checkState='1', State='2' where PDCode='{0}' and  WZ_TM = '{1}'", pdCode, strReelid);
            return DbHelper.Update(sql);
        }
        //盘点审核完成，数据插入material_NewNum
        public static int Insertmaterial_NewNum(int qty, string strReelid, string type = "")
        {
            //时间
            string updateTime = System.DateTime.Now.ToString();
            string sql = "delete from material_NewNum where ReelID='" + strReelid + "'";
            DbHelper.Delete(sql);
            if (string.IsNullOrEmpty(type))
            {
                sql = "insert into material_NewNum (ReelID,Num,addtime) values ('" + strReelid + "'," + qty + ",'" + updateTime + "')";
                return DbHelper.Insert(sql);
            }
            else
            {
                sql = "insert into material_NewNum (ReelID,Num,addtime,type) values ('" + strReelid + "'," + qty + ",'" + updateTime + "','" + type + "')";
                return DbHelper.Insert(sql);
            }


        }

        //盘点复盘
        public static int FuPandianDan(string pdCode, string strReelid)
        {
            //时间
            string updateTime = System.DateTime.Now.ToString();
            string sql = string.Format("update smt_pandianDan set PDCount=PDCount+1,State='0' where PDCode='{0}' and  WZ_TM = '{1}'", pdCode, strReelid);
            return DbHelper.Update(sql);
        }

        //修改盘点的账面数量
        public static int ModifyPandianDan(string strReelid, string qty, int resultType, string ID)
        {
            //时间
            string updateTime = System.DateTime.Now.ToString();
            string sql = string.Format("update smt_pandianDan set Qty='{0}',PDCount=1,PDState=1,resultType={1} where ID = '{2}'", qty, resultType, ID);
            return DbHelper.Update(sql);
        }

        //修改库存数量
        public static int ModifySmt_zd_Material(string strReelid, string Quality)
        {
            //时间
            string updateTime = System.DateTime.Now.ToString();
            string sql = string.Format("update smt_zd_material set qty='{0}' where reelid = '{1}' and issave=1 and istake=0", Quality, strReelid);
            return DbHelper.Update(sql);
        }

        //校验库存是否有重复的
        public static DataTable getCFData(string RK_RKDHArray)
        {
            string sql = "select distinct RK_RKDH from smt_InStockOrder where RK_RKDH in (" + RK_RKDHArray + ") order by RK_RKDH";
            return DbHelper.GetDataTable(sql);
        }

        public static DataTable GetAllMaterial()
        {
            string sql = "select * from smt_zd_material where isTakeCheck=0 ";
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
