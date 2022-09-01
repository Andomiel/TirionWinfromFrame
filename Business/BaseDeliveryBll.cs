using DataBase;
using Entity;
using Entity.DataContext;
using Entity.Enums;
using Entity.Facade;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using TirionWinfromFrame.Commons;

namespace Business
{
    public abstract class BaseDeliveryBll
    {
        /// <summary>
        /// 出库类型
        /// </summary>
        protected abstract LightRecordTypeEnum OrderType { get; }

        /// <summary>
        /// 获取与当前要出库的单据关联的亮灯记录
        /// </summary>
        /// <param name="deliveryId">单据Id</param>
        /// <param name="towerNo">库区</param>
        /// <returns>与当前出库单据关联的亮灯记录，用于灭灯</returns>
        public static Wms_LightColorRecord GetCurrentOrderRecord(string deliveryId, int towerNo)
        {
            string sql = $" {Wms_LightColorRecord.GetSelectSql()} AND OrderId = '{deliveryId}' AND  LightArea = {towerNo} ";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_LightColorRecord>().FirstOrDefault();
        }

        public bool DeliveryCalculatedBarcodes(string deliveryId, string deliveryNo, int deliveryType, string userName)
        {
            StringBuilder sb = new StringBuilder();

            int sortingNo = GetSortNo(deliveryType);

            var barcodes = GetDeliveryBarcodesDetail(deliveryId, GetExecuteStatus());

            var group = barcodes.GroupBy(p => p.DeliveryAreaId);
            foreach (var item in group)
            {
                switch (item.Key)
                {
                    case (int)TowerEnum.SortingArea:
                        //do nothing
                        break;
                    case (int)TowerEnum.ASRS:
                        sb.AppendLine(DeliveryAsrsBarcodes(deliveryId, deliveryNo, sortingNo, userName, item.ToList()));
                        break;
                    case (int)TowerEnum.LightShelf:
                        sb.AppendLine(DeliveryLightShelfBarcodes(deliveryId, deliveryNo, userName, item.ToList()));
                        break;
                    case (int)TowerEnum.PalletArea:
                        //do nothing
                        sb.AppendLine(InsertDeliveryRecord(deliveryId, deliveryNo, item.Key, 99, userName));
                        break;
                    case (int)TowerEnum.ReformShelf:
                        sb.AppendLine(DeliveryReformShelfBarcodes(deliveryId, deliveryNo, userName, item.ToList()));
                        break;
                    default:
                        throw new OppoCoreException("计算的待发物料中存在不在预定义库区的物料");
                }
            }

            sb.AppendLine(GetDeliveredUpdateSql(deliveryId, sortingNo, userName));

            return DbHelper.ExcuteWithTransaction(sb.ToString(), out string _) > 0;
        }

        protected abstract int GetSortNo(int deliveryType);

        protected abstract int GetExecuteStatus();

        protected abstract List<DeliveryBarcodeLocation> GetDeliveryBarcodesDetail(string deliveryId, int targetStatus);

        protected abstract string GetDeliveredUpdateSql(string deliveryId, int sortingNo, string userName);

        protected string DeliveryAsrsBarcodes(string deliveryId, string deliveryNo, int sortNo, string userName, List<DeliveryBarcodeLocation> barcodes)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in barcodes)
            {
                sb.AppendLine($@"INSERT INTO tower01{item.ABSide}_smt_materialoperate
                        (ReelID, MaterialLockTower, OperateType,  Req_Timestamp) VALUES('{item.Barcode}', {item.DeliveryAreaId}, '1', getdate()); ");
                //更新分拣口
                sb.Append($"UPDATE smt_zd_material SET BoxID = '{sortNo}' WHERE reelid = '{item.Barcode}'; ");
            }

            //料仓也记录发料库区记录
            sb.AppendLine(InsertDeliveryRecord(deliveryId, deliveryNo, (int)TowerEnum.ASRS, sortNo, userName));

            return sb.ToString();
        }

        protected string InsertDeliveryRecord(string deliveryId, string deliveryNo, int towerNo, int targetColor, string userName)
        {
            return $@"INSERT INTO Wms_LightColorRecord
                (OrderType, LightArea, LightColor, OrderId, OrderNo, RecordStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
                VALUES({(int)OrderType}, {towerNo}, {targetColor}, '{deliveryId}', '{deliveryNo}', {(int)LightRecordStatusEnum.LightOn}, '', getdate(), '{userName}', getdate(), '{userName}');";
        }

        private string DeliveryLightShelfBarcodes(string deliveryId, string deliveryNo, string userName, List<DeliveryBarcodeLocation> barcodes)
        {
            string colorConfig = ConfigurationManager.AppSettings["ColorsForInductive"];
            if (string.IsNullOrWhiteSpace(colorConfig))
            {
                throw new OppoCoreException("缺少亮灯货架的可用颜色配置");
            }
            var allColors = colorConfig.Split(',').Select(p => Convert.ToInt32(p)).ToList();
            if (allColors.Count == 0)
            {
                throw new OppoCoreException("缺少亮灯货架的可用颜色配置");
            }
            string url = ConfigurationManager.AppSettings["InductiveShelfLightOff"];
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new OppoCoreException("缺少亮灯货架的服务地址配置");
            }

            int targetColor = GetLightColor((int)TowerEnum.LightShelf, allColors);
            LightShelfColor(true, url, targetColor, barcodes);

            return InsertDeliveryRecord(deliveryId, deliveryNo, (int)TowerEnum.LightShelf, targetColor, userName);
        }

        private static int GetLightColor(int towerNo, List<int> allColors)
        {
            string sql = $@"SELECT LightColor 
                  FROM Wms_LightColorRecord wlcr WHERE RecordStatus ={(int)LightRecordStatusEnum.LightOn} AND LightArea = {towerNo}; ";

            DataTable dt = DbHelper.GetDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    int currentColor = TypeParse.StrToInt(Convert.ToString(dataRow["LightColor"]), -1);
                    allColors.Remove(currentColor);
                }
            }
            if (allColors.Count == 0)
            {
                //理论上不可能
                throw new OppoCoreException($"{EnumHelper.GetDescription(typeof(TowerEnum), towerNo)}所有颜色已被用尽，无法再次分配亮灯颜色");
            }

            return allColors.First();
        }

        private static void LightShelfColor(bool isOn, string url, int targetColor, List<DeliveryBarcodeLocation> barcodes)
        {
            string onOrOff = "亮灯";
            LightShelfRequest request = new LightShelfRequest(targetColor);
            if (isOn)
            {
                foreach (var row in barcodes)
                {
                    request.data.Add(new LightMaterial(row.Barcode, row.Part_Number, row.DeliveryQuantity));
                }
            }
            else
            {
                request.action = 0;
                onOrOff = "灭灯";
                foreach (var row in barcodes)
                {
                    request.data.Add(new Material(row.Barcode));
                }
            }

            Dictionary<string, string> logDict = new Dictionary<string, string>(3);
            logDict.Add("url", url);

            string requestString = JsonConvert.SerializeObject(request);
            logDict.Add("request", requestString);

            string strResponse = WebClientHelper.Post(JsonConvert.SerializeObject(request), url, null);
            logDict.Add("response", strResponse);

            FileLog.Log($"操作亮灯货架{onOrOff}:{JsonConvert.SerializeObject(logDict)}");
            LightShelfResponse response = JsonConvert.DeserializeObject<LightShelfResponse>(strResponse);

            if (response == null || response.Code != 1)
            {
                string formattedMessage = Uri.UnescapeDataString(response.Msg);
                throw new OppoCoreException($"亮灯货架发料{onOrOff}失败:{formattedMessage}");
            }
        }

        private string DeliveryReformShelfBarcodes(string deliveryId, string deliveryNo, string userName, List<DeliveryBarcodeLocation> barcodes)
        {
            string colorConfig = ConfigurationManager.AppSettings["ColorsForTransformation"];
            if (string.IsNullOrWhiteSpace(colorConfig))
            {
                throw new OppoCoreException("缺少改造货架的可用颜色配置");
            }
            var allColors = colorConfig.Split(',').Select(p => Convert.ToInt32(p)).ToList();
            if (allColors.Count == 0)
            {
                throw new OppoCoreException("缺少改造货架的可用颜色配置");
            }
            string url = ConfigurationManager.AppSettings["TransformationShelfLightOff"];
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new OppoCoreException("缺少改造货架的服务地址配置");
            }

            int targetColor = GetLightColor((int)TowerEnum.ReformShelf, allColors);
            //改造货架三个灯，1，2，3
            int lightNumber = allColors.IndexOf(targetColor) + 1;

            LightReformShelf(url, targetColor, lightNumber, barcodes);

            return InsertDeliveryRecord(deliveryId, deliveryNo, (int)TowerEnum.ReformShelf, targetColor, userName);
        }

        private static void LightReformShelf(string url, int lightColor, int lightNumber, List<DeliveryBarcodeLocation> barcodes)
        {
            var locationGroup = barcodes.GroupBy(p => p.LockLocation);
            List<JsonData> jsonData = new List<JsonData>();
            foreach (var item in locationGroup)
            {
                string location = item.Key;

                jsonData.Add(new JsonData(location, lightColor.ToString(), lightNumber));
            }

            Dictionary<string, string> logDict = new Dictionary<string, string>(3);
            logDict.Add("url", url);

            ReformShelfRequest request = new ReformShelfRequest();
            request.jsonData = JsonConvert.SerializeObject(jsonData);
            string requestString = JsonConvert.SerializeObject(request);
            logDict.Add("request", requestString);

            string strResponse = WebClientHelper.Post(requestString, url, null);
            logDict.Add("response", strResponse);

            string onOrOff = lightColor == 0 ? "灭灯" : "亮灯";
            FileLog.Log($"操作亮灯货架{onOrOff}:{JsonConvert.SerializeObject(logDict)    }");
            ReformShelfResponse response = JsonConvert.DeserializeObject<ReformShelfResponse>(strResponse);

            if (response == null || !response.success)
            {
                throw new OppoCoreException($"改造货架发料{onOrOff}失败:{response.message}");
            }
        }

        public bool FinishDeliveryOrder(string deliveryId, string userName)
        {
            StringBuilder sb = new StringBuilder();

            var barcodes = GetDeliveryBarcodesDetail(deliveryId, GetFinishedStatus());

            var group = barcodes.GroupBy(p => p.DeliveryAreaId);
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
                        sb.AppendLine(LightOffLightShelf(deliveryId, userName, item.ToList()));
                        break;
                    case (int)TowerEnum.PalletArea:
                        //do nothing
                        break;
                    case (int)TowerEnum.ReformShelf:
                        sb.AppendLine(LightOffReformShelf(deliveryId, userName, item.ToList()));
                        break;
                    default:
                        throw new OppoCoreException("发料物料中存在不在预定义库区的物料");
                }
            }

            int refundStatus = GetExecuteStatus();
            var refundBarcodes = barcodes.Where(p => p.BarcodeStatus == refundStatus).Select(p => p.Barcode).Distinct().ToList();
            sb.AppendLine(GetReleaseBarcodeSql(deliveryId, userName, refundBarcodes));

            sb.AppendLine(GetFinshedUpdateSql(deliveryId, userName));
            sb.AppendLine(GetFinishedLightRecords(deliveryId, userName));

            return DbHelper.ExcuteWithTransaction(sb.ToString(), out string _) > 0;
        }

        protected abstract string GetReleaseBarcodeSql(string deliveryId, string userName, List<string> barcodes);

        protected abstract int GetFinishedStatus();

        protected abstract string GetFinshedUpdateSql(string deliveryId, string userName);

        protected string GetFinishedLightRecords(string deliveryId, string userName)
        {
            return $@"UPDATE Wms_LightColorRecord SET RecordStatus = {(int)LightRecordStatusEnum.LightOff}, 
                        LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' WHERE OrderId = '{deliveryId}';";
        }

        protected static string LightOffReformShelf(string deliveryId, string userName, List<DeliveryBarcodeLocation> barcodes)
        {
            string colorConfig = ConfigurationManager.AppSettings["ColorsForTransformation"];
            if (string.IsNullOrWhiteSpace(colorConfig))
            {
                throw new OppoCoreException("缺少改造货架的可用颜色配置");
            }
            var allColors = colorConfig.Split(',').Select(p => Convert.ToInt32(p)).ToList();
            if (allColors.Count == 0)
            {
                throw new OppoCoreException("缺少改造货架的可用颜色配置");
            }
            string url = ConfigurationManager.AppSettings["TransformationShelfLightOff"];
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new OppoCoreException("缺少改造货架的服务地址配置");
            }

            var currentRecord = GetCurrentOrderRecord(deliveryId, (int)TowerEnum.ReformShelf);
            if (currentRecord == null || currentRecord.RecordStatus != (int)LightRecordStatusEnum.LightOn)
            {
                throw new OppoCoreException("当前出库单的改造货架亮灯记录异常，无法关闭");
            }

            int targetColor = currentRecord.LightColor;
            //改造货架三个灯，1，2，3
            int lightNumber = allColors.IndexOf(targetColor) + 1;

            try
            {
                LightReformShelf(url, 0, lightNumber, barcodes);//0 灭灯
            }
            catch
            {
                //灭灯不看结果
            }

            return $@"UPDATE Wms_LightColorRecord
                SET RecordStatus = {(int)LightRecordStatusEnum.LightOff}, LastUpdateTime = getdate(), LastUpdateUser = '{userName}' WHERE Id = {currentRecord.Id};";
        }

        protected static string LightOffLightShelf(string deliveryId, string userName, List<DeliveryBarcodeLocation> barcodes)
        {
            string colorConfig = ConfigurationManager.AppSettings["ColorsForInductive"];
            if (string.IsNullOrWhiteSpace(colorConfig))
            {
                throw new OppoCoreException("缺少亮灯货架的可用颜色配置");
            }
            var allColors = colorConfig.Split(',').Select(p => Convert.ToInt32(p)).ToList();
            if (allColors.Count == 0)
            {
                throw new OppoCoreException("缺少亮灯货架的可用颜色配置");
            }
            string url = ConfigurationManager.AppSettings["InductiveShelfLightOff"];
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new OppoCoreException("缺少亮灯货架的服务地址配置");
            }

            var currentRecord = GetCurrentOrderRecord(deliveryId, (int)TowerEnum.LightShelf);
            if (currentRecord == null || currentRecord.RecordStatus != (int)LightRecordStatusEnum.LightOn)
            {
                throw new OppoCoreException("当前出库单的亮灯货架亮灯记录异常，无法关闭");
            }

            int targetColor = currentRecord.LightColor;
            try
            {
                LightShelfColor(false, url, targetColor, barcodes);
            }
            catch
            {
                //灭灯不看结果
            }

            return $@"UPDATE Wms_LightColorRecord
                SET RecordStatus = {(int)LightRecordStatusEnum.LightOff}, LastUpdateTime = getdate(), LastUpdateUser = '{userName}' WHERE Id = {currentRecord.Id};";
        }

        public static List<Wms_LightColorRecord> GetExecutingRecords()
        {
            string sql = $"{Wms_LightColorRecord.GetSelectSql()} AND RecordStatus = {(int)LightRecordStatusEnum.LightOn} ";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_LightColorRecord>();
        }

        public static List<Wms_InstockArea> GetExecutingAreas()
        {
            string sql = $"{Wms_InstockArea.GetSelectSql()} AND DetailStatus = {(int)InstockAreaBindingStatusEnum.Bound} ";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_InstockArea>();
        }
    }

    public class DeliveryBarcodeLocation
    {
        public string Barcode { get; set; }

        public int DeliveryAreaId { get; set; }

        public string LockLocation { get; set; }

        public string ABSide { get; set; }

        public string LockMachineID { get; set; }

        public string Part_Number { get; set; }

        public int DeliveryQuantity { get; set; }

        public int BarcodeStatus { get; set; }
    }
}
