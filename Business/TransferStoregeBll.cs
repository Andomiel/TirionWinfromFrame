using DataBase;
using Entity;
using Entity.Dto;
using Entity.Enums;
using Entity.Enums.Transfer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TirionWinfromFrame.Commons;

namespace Business
{
    public class TransferStoregeBll
    {
        private static string DetailSql => $@"SELECT szm.ReelID,szm.Part_Number as PartNumber, szm.SerialNo, szm.WZ_SCCJ as Manufacturer,
                                                     szm.LockTowerNo,stm.Description as Tower,szm.LockMachineId,szm.LockLocation,szm.ABSide,szm.DateCode,
                                                     szm.SaveTime,szm.Qty,szm.ReelType 
                                                FROM smt_zd_material szm 
                                           LEFT JOIN smt_TowerMap stm
                                                  ON szm.LockTowerNo = stm.TowerNo
	                                       LEFT JOIN (SELECT DISTINCT UPN FROM smt_Material_Frozen) smf 
                                                  ON szm.ReelID = smf.UPN
                                           LEFT JOIN smt_bake sb
                                                  ON szm.ReelID = sb.UPN
                                               WHERE ISNULL(szm.Work_Order_No,'') = ''
                                                 AND szm.isSave = 1 
                                                 AND szm.isTake = 0
                                                 AND szm.Qty > 0
                                                 AND sb.UPN is null
                                                 AND smf.UPN is null
                                                 AND szm.isTakeCheck = 0 
                                                 AND szm.LockTowerNo <> 3 ";

        public static List<TransferQueryResult> QueryTransferDetail(MaterialQueryCondition condition)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DetailSql);
            if (condition.ExceedStart != 0 && condition.ExceedEnd != 0)
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
                sb.Append($" AND szm.SaveTime BETWEEN '{exceedDt1}' AND '{exceedDt2}' ");
            }
            else
            {
                if (condition.haveSaveTimeQuery)
                {
                    sb.Append($" AND szm.SaveTime BETWEEN '{condition.SaveTimeStart}' AND '{condition.SaveTimeEnd}' ");
                }
            }
            if (!string.IsNullOrWhiteSpace(condition.UPN))
            {
                sb.Append($" AND szm.ReelId = '{condition.UPN}' ");
            }
            if (!string.IsNullOrWhiteSpace(condition.PartNumber))
            {
                sb.Append($" AND szm.Part_Number = '{condition.PartNumber}' ");
            }
            if (!string.IsNullOrWhiteSpace(condition.Supplier))
            {
                sb.Append($" AND szm.WZ_SCCJ='{condition.Supplier}' ");
            }

            if (!string.IsNullOrWhiteSpace(condition.ABSide))
            {
                sb.Append($" AND szm.ABSide='{condition.ABSide}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.MachineId))
            {
                sb.Append($" AND szm.LockMachineID='{condition.MachineId}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.MSD))
            {
                sb.Append($" AND szm.MSD='{condition.MSD}'");
            }
            if (condition.TowerNo != -1)
            {
                sb.Append($" AND szm.LockTowerNo={condition.TowerNo}");
            }

            if (!string.IsNullOrWhiteSpace(condition.SerialNoStart))
            {
                sb.Append($" AND szm.SerialNo >= '{condition.SerialNoStart}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.SerialNoEnd))
            {
                sb.Append($" AND szm.SerialNo <= '{condition.SerialNoEnd}'");
            }
            if (!string.IsNullOrWhiteSpace(condition.MateType))
            {
                sb.Append($" AND szm.ReelType = '{condition.MateType}'");
            }
            var queryResult = DbHelper.GetDataTable(sb.ToString()).DataTableToList<TransferQueryResult>();
            if (condition.haveCycleQuery)
            {
                queryResult = queryResult.Where(p => (DateTime.Compare(p.DateCodeDate, condition.CycleStart) >= 0
                                                  && DateTime.Compare(p.DateCodeDate, condition.CycleEnd) <= 0)
                                                  || p.DateCodeDate.Year == 1900).ToList();
            }
            return queryResult;
        }

        public static int BuildTransferOrder(string orderNo, List<TransferQueryResult> barcodes, string userName, int targetArea, int sourceArea)
        {
            StringBuilder sb = new StringBuilder();
            string transferId = Guid.NewGuid().ToString("D");
            int transferType = targetArea == (int)TowerEnum.SortingArea ? (int)TransferTypeEnum.TransferOut : (int)TransferTypeEnum.TransferIn;
            sb.AppendLine($@"INSERT INTO Wms_TransferOrder
                    (BusinessId, TransferNo, SortingId, TransferType, SourceAreaId, TargetAreaId, OrderStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
                    VALUES('{transferId}', '{orderNo}', '', {transferType}, {sourceArea}, {targetArea}, {(int)TransferOrderStatusEnum.Saved}, '', getdate(), '{userName}', getdate(), '{userName}');");
            foreach (var item in barcodes)
            {
                sb.AppendLine($@"INSERT INTO Wms_TransferBarcode
                    (BusinessId, TransferOrderId, Barcode, MaterialNo, TransferQuantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser, TransferLocation)
                    VALUES('{Guid.NewGuid():D}', '{transferId}', '{item.ReelID}', '{item.PartNumber}', {item.Qty}, {(int)TransferBarcodeStatusEnum.Unfinished}, getdate(), '{userName}', getdate(), '{userName}', '{item.LockLocation}');");

                sb.AppendLine($" update smt_zd_material set Status = {(int)BarcodeStatusEnum.Locked}, Work_Order_No = '{transferId}', LockRequestID = ''  where  ReelID = '{item.ReelID}'; ");
            }

            return DbHelper.ExcuteWithTransaction(sb.ToString(), out _);
        }

        public static List<TransferQueryResult> GetBarcodesByImportUpns(List<string> barcodes)
        {
            string sql = $@"SELECT szm.ReelID,szm.Part_Number as PartNumber, szm.SerialNo, szm.WZ_SCCJ as Manufacturer,
                                                     szm.LockTowerNo,'' as Tower,szm.LockMachineId,szm.LockLocation,szm.ABSide,szm.DateCode,
                                                     szm.SaveTime,szm.Qty,szm.ReelType 
                                                FROM smt_zd_material szm  where ReelID in ( {string.Join(",", barcodes.Select(p => $"'{p}'"))} )";

            return DbHelper.GetDataTable(sql).DataTableToList<TransferQueryResult>();
        }
    }

    public class TransferQueryResult
    {
        public bool SelectFlag { get; set; } = false;
        public string ReelID { get; set; }
        /// <summary>
        /// 二维码
        /// </summary>
        public string Barcode { get; set; }
        public string PartNumber { get; set; }
        /// <summary>
        /// 料盘类型
        /// </summary>
        public string ReelType { get; set; }
        public string ReelTypeDes => EnumHelper.GetDescription(typeof(ReelTypeEnum), ReelType);
        public int LockTowerNo { get; set; }
        public string Tower { get; set; }
        public string LockLocation { get; set; }
        public string LockMachineId { get; set; }
        public string ABSide { get; set; }
        public string Location => GetLocation();
        public DateTime SaveTime { get; set; }
        public int Qty { get; set; }
        public string DateCode { get; set; }
        public DateTime DateCodeDate => QueryConditionConvert.DateCdoeToCycleDate(DateCode, ReelID);
        public string Manufacturer { get; set; }
        //4873250-B3788-21827-00003
        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNo { get; set; }
        private string GetLocation()
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

    public class TransferItemInOrder
    {
        public bool SelectFlag { get; set; } = false;
        public string ReelID { get; set; }
        public string PartNumber { get; set; }
        public int Qty { get; set; }
        public int TowerNo { get; set; }
    }

    /// <summary>
    /// 盘点单
    /// </summary>
    public class PandianItemOrder
    {
        public string OrderNo { get; set; }
        public string ReelID { get; set; }
        public string PartNumber { get; set; }
        public string Qty { get; set; }
    }
}
