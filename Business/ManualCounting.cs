using DataBase;
using Entity;
using Entity.Enums;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using TirionWinfromFrame.Commons;

namespace Business
{
    public class ManualCounting
    {
        public static bool SaveCounting(ManualCountingRecord record)
        {
            string querySql = $" SELECT * FROM smt_zd_material Where ReelID='{record.UPN}' ";
            DataTable dt = DbHelper.GetDataTable(querySql);
            int count = dt.Rows.Count;
            bool result;
            if (count == 0)
            {
                string sql = $@"insert into smt_zd_material(Reelid,Part_Number,Qty,DateCode,Lot,FactoryCode,WZ_SCCJ,MSD,ReelType,SerialNo,QRCode,CameraString, MinPacking, isSave, isTake, isTakeCheck, Status, LockTowerNo) 
                                            values (@rtnID,@partno,@qty,@dc,@lot,@supplier,@supplier,@msd,@materialType,@serialNo,@qrcode,@cameraString,@miniPacking, 1, 0, 0, {(int)BarcodeStatusEnum.Saved}, {(int)TowerEnum.SortingArea})";
                string partNumber = string.Empty;
                string dc = string.Empty;
                string supplier = string.Empty;
                string lot = string.Empty;
                var barcodeElements = record.UPN.Split('-');
                if (barcodeElements.Length > 3)
                {
                    //规则：第一个“-”以前的内容
                    partNumber = barcodeElements[0];
                    //第二个“-”和第三个“-”之间的内容
                    //（A代表10月，B代表十一月，C代表十二月）
                    dc = FormatDateCode(barcodeElements[2]);
                    //规则：第一个“-”和第二个“-”之间的内容，
                    //去除最后一位（总位数可能4位或5位
                    supplier = barcodeElements[1].Substring(0, barcodeElements[1].Length - 1);
                    //流水号,这里用批次号来算,:第三个“-”到第一个“*”之间
                    lot = barcodeElements[3];
                }
                var arr = record.QRCode.Split('*');
                int miniPacking = TypeParse.StrToInt(arr[6], 0);

                result = DbHelper.ExecuteNonQuery(
                   sql,
                   new SqlParameter("@rtnID", record.UPN),
                   new SqlParameter("@partno", partNumber),
                   new SqlParameter("@qty", record.Qty),
                   new SqlParameter("@dc", dc),
                   new SqlParameter("@lot", lot),
                   new SqlParameter("@serialNo", record.SerialNo),
                   new SqlParameter("@supplier", supplier),
                   new SqlParameter("@msd", record.MSD),
                   new SqlParameter("@materialType", GetReelType(record.Qty, miniPacking)),
                   new SqlParameter("@qrcode", record.QRCode),
                   new SqlParameter("@cameraString", record.QRCode),
                   new SqlParameter("@miniPacking", miniPacking)) > 0;
            }
            else
            {
                string updateSql = $" UPDATE smt_zd_material SET LockTowerNo = {(int)TowerEnum.SortingArea}, LockLocation = '', LockMachineID = '', Qty = {record.Qty}, isSave = 1, isTake=0, isTakeCheck = 0, Status = {(int)BarcodeStatusEnum.Saved} WHERE ReelId='{record.UPN}' ";
                return DbHelper.Update(updateSql) > 0;
            }
            return result;
        }

        public static string FormatDateCode(string originCode)
        {
            string formattedCode = "20000101";
            if (string.IsNullOrWhiteSpace(originCode))
            {
                return formattedCode;
            }
            if (int.TryParse(originCode, out int convertCode) && convertCode < 1900)
            {
                return formattedCode;
            }
            return originCode;
        }

        private static string GetReelType(int qty, int miniPackage)
        {
            string materialType = "F";

            if (qty > 0 && miniPackage > 0)
            {
                decimal offset = miniPackage - qty;
                if ((Math.Abs(offset) / miniPackage) * 1000 <= 3)
                {
                    materialType = "F";
                }
                else if ((offset / miniPackage) * 1000 > 3)
                {
                    materialType = "S";
                }
                else if (offset / miniPackage * 1000 < -3)
                {
                    materialType = "T";
                }
                else
                {
                    //do nothing
                }
            }
            return materialType;
        }

        public static ManualCountResult SyncCounting(ManualCountingRecord record)
        {
            MaterialInfoResponse materialInfo = new MaterialInfoResponse();
            if (!string.IsNullOrWhiteSpace(record.materialJson))
            {
                materialInfo = JsonConvert.DeserializeObject<MaterialInfoResponse>(record.materialJson);
            }
            XtaryBackQtyRequest request = new XtaryBackQtyRequest();
            request.upn = record.QRCode;
            request.qty = record.Qty;
            request.reelSize = string.Empty;
            request.status = string.Empty;
            request.thickness = string.Empty;
            request.minPacking = materialInfo.MinPacking;
            request.cycle = string.Empty;
            request.batch = materialInfo.BatchId;
            request.storeId = materialInfo.StoreId;
            request.reelType = record.IsTypeT ? ReelTypeEnum.T.ToString() : string.Empty;
            request.matType = materialInfo.InvMatType;
            request.msd = record.MSD;
            request.msdOverdue = string.Empty;
            request._lock = materialInfo.HoldFlag;
            XtaryBackQtyResponse response = CallMesWmsApiBll.CallXtrayBackQty(request);
            ManualCountResult result = new ManualCountResult();
            if (response != null && !string.IsNullOrWhiteSpace(response.Result))
            {
                result.Result = response.Result;
                result.Message = response.Message;
                result.MSD = response.Data.msd;
                result.MsdOverdue = response.Data.msdOverdue;
                result.LockState = response.Data._lock;
            }
            else
            {
                result.Result = "NG";
                result.Message = "接口调用失败";
                result.MSD = materialInfo.MSD;
                result.MsdOverdue = string.Empty;
                result.LockState = materialInfo.HoldFlag;
            }
            return result;
        }
    }

    public class ManualCountingRecord
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
        public bool IsSuccess { get; set; }
        public string Success => IsSuccess ? "退料成功" : "退料失败";
        public string Message { get; set; }

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

    public class ManualCountResult
    {
        /// <summary>
        /// 退料结果，OK,NG或者其他
        /// </summary>
        public string Result { get; set; }
        public string Message { get; set; }
        public string MSD { get; set; }
        public string MsdOverdue { get; set; }
        public string LockState { get; set; }
    }
}
