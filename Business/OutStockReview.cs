using DataBase;
using Entity;
using Entity.DataContext;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using TirionWinfromFrame.Commons;

namespace Business
{
    public class OutStockReview
    {

        public static List<OrderNeedMaterial> GetMaterialsByOutOrderNo(string orderNo)
        {
            string sql = $@" SELECT wdo.DeliveryNo as OrderNo, wdd.MaterialNo as PartNumber,wdd.RequireCount as NeedQty,
	                    wdd.RowNum as LineNumber, wdd.SlotNo 
                    FROM Wms_DeliveryDetail wdd 
                    left join Wms_DeliveryOrder wdo on wdd.DeliveryId = wdo.BusinessId 
                    WHERE wdo.DeliveryNo ='{orderNo}'
                    ORDER BY RowNum ASC ";
            return DbHelper.GetDataTable(sql).DataTableToList<OrderNeedMaterial>();
        }

        public static List<ReviewSummary> GetSpareMaterial(string orderNo)
        {
            string sql = $@" SELECT wdb.Barcode as UPN, wdd.MaterialNo as PartNumber,
	                wdo.DeliveryNo as OrderNo, wdb.DeliveryQuantity as AllocateQty,
	                wdd.RequireCount as NeedQty, wdb.DeliveryAreaId as TowerNo,
	                0 as [Match],0 as [Source],
	                wdd.RowNum as LineNumber, wdd.SlotNo 
                FROM Wms_DeliveryBarcode wdb 
                LEFT JOIN Wms_DeliveryDetail wdd on wdb.DeliveryDetailId = wdd.BusinessId 
                LEFT JOIN Wms_DeliveryOrder wdo on wdd.DeliveryId = wdo.BusinessId 
               WHERE wdo.DeliveryNo ='{orderNo}' AND wdb.OrderStatus = {(int)DeliveryBarcodeStatusEnum.Delivered} ";
            DataTable dt = DbHelper.GetDataTable(sql);
            List<ReviewSummary> dtList = dt.DataTableToList<ReviewSummary>();
            return dtList;
        }

        public static ReviewRecord GetUpnInfoInZd(string upn)
        {
            string sql = $@" SELECT TOP 1 
                                    szm.ReelId,szm.QRCode,szm.Part_Number,szm.Qty,szm.LockTowerNo,
                                    szm.IsSave,szm.IsTake,szm.IsTakeCheck,st.Description as TowerDes,
                                    CASE WHEN smf.Upn IS NULL THEN 0 ELSE 1 END as HoldState,
                                    ISNULL(bake.Upn,'') as BakeUpn
                               FROM smt_zd_material szm
                          LEFT JOIN smt_bake bake ON szm.ReelId = bake.Upn
	                      LEFT JOIN (SELECT DISTINCT UPN FROM smt_Material_Frozen) smf ON szm.ReelID = smf.UPN
                          LEFT JOIN smt_TowerMap st ON szm.LockTowerNo = st.TowerNo
                              WHERE szm.ReelId = '{upn}'";
            DataTable dt = DbHelper.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                List<ReviewRecord> dtList = dt.DataTableToList<ReviewRecord>();
                return dtList[0];
            }
            else
            {
                return new ReviewRecord(upn);
            }
        }

        public static int UpdateAndInsertSpareMaterial(string orderNo, List<ReviewSummary> summaryList)
        {
            DateTime now = DateTime.Now;
            List<string> updatePrepareComplete = new List<string>();
            List<string> insertValues = new List<string>();
            List<ReviewSummary> updateReviewOks = new List<ReviewSummary>();
            List<string> resetZdUpns = new List<string>();
            List<string> needLockUpns = new List<string>();

            StringBuilder log = new StringBuilder();
            //拿到备料表中，所有栈板区的数据
            string exemptSql = $" SELECT UPN,Source FROM smt_prepare_material WHERE OrderNo='{orderNo}' AND Match=-1 ";
            var allArea3Data = DbHelper.GetDataTable(exemptSql).AsEnumerable();
            if (allArea3Data.Count() > 0)
            {
                var exemptUpns = allArea3Data.Select(p => p.Field<string>("UPN")).ToList();
                //备料表需要完结
                updatePrepareComplete.AddRange(exemptUpns);
                //其中，箱子需要重置库存状态
                var boxUpns = allArea3Data.Where(p => p.Field<int>("Source") == 1)?.Select(p => p.Field<string>("UPN")).ToList();
                if (boxUpns != null && boxUpns.Count > 0)
                {
                    resetZdUpns.AddRange(boxUpns);
                }
            }
            log.AppendLine($"1、栈板区操作{exemptSql}");

            foreach (ReviewSummary item in summaryList)
            {
                //复核时未扫码ReelID，需要直接完结prepare_Material表，并重置zd_material表
                if (item.Match == 0)
                {
                    updatePrepareComplete.Add(item.UPN);

                    string workOrderNo = GetBindOrderByUpn(item.UPN);
                    if (workOrderNo.Equals(orderNo))
                    {
                        resetZdUpns.Add(item.UPN);
                    }
                }
                ////不用复核的ReelID，直接完结prepare_Material表
                //else if (match == -1)
                //{
                //    updatePrepareComplete.Add(upn);
                //}
                //复核时扫码成功的，如果来源于 拣料和系统分配，prepare_Material表Match更新并完结，zd_material表状态更新
                //如果来源于 复核，prepare_Material表新增，zd_material表绑定工单，并状态更新
                else if (item.Match == 1)
                {
                    if (item.Source == 1 || item.Source == 3)
                    {
                        updateReviewOks.Add(item);
                    }
                    else if (item.Source == 2)
                    {
                        insertValues.Add($@"('{Guid.NewGuid()}','{item.UPN}','{item.PartNumber}','{orderNo}',{item.RealQty},{item.TowerNo},1,'{now}',2,1,'{item.ContainerNo}','{item.LineNumber}','{item.SlotNo}','{item.QRCode}')");
                        needLockUpns.Add(item.UPN);
                    }
                    else { }
                }
                else { }
            }

            StringBuilder sb = new StringBuilder();
            if (updatePrepareComplete.Count > 0)
            {
                sb.Append($@" UPDATE smt_prepare_material set IsComplete = 1, CompleteTime = '{now}' WHERE OrderNo='{orderNo}' AND UPN IN ('{string.Join("','", updatePrepareComplete)}');");
            }
            if (insertValues.Count > 0)
            {
                sb.Append($@" INSERT INTO smt_prepare_material(
                                               Id,UPN,PartNumber,OrderNo,Qty,
                                               TowerNo,IsComplete,CompleteTime,Source,
                                               Match,ContainerNo,LineNumber,SlotNo,QRCode) 
                                        VALUES {string.Join(",", insertValues)};");
            }
            if (updateReviewOks.Count > 0)
            {
                sb.Append($" UPDATE smt_zd_material SET isTakeCheck=1, isTake=1 WHERE ReelId in ('{string.Join("','", updateReviewOks.Select(p => p.UPN).ToList())}');");
                var group = updateReviewOks.GroupBy(p => p.ContainerNo).ToList();
                foreach (var gpItem in group)
                {
                    sb.Append($@" UPDATE smt_prepare_material set Match = 1, IsComplete = 1, CompleteTime = '{now}', ContainerNo='{gpItem.Key}' WHERE OrderNo='{orderNo}' AND UPN IN ('{string.Join("','", gpItem.Select(p => p.UPN).ToList())}');");
                }
            }
            if (resetZdUpns.Count > 0)
            {
                sb.Append($@" UPDATE smt_zd_material SET Work_Order_No='',isTake=0,isTakeDelivery=0, LightColor='0' WHERE ReelId in ('{string.Join("','", resetZdUpns)}');");
            }
            if (needLockUpns.Count > 0)
            {
                sb.Append($@" UPDATE smt_zd_material SET Work_Order_No='{orderNo}', isTakeCheck=1, isTake=1 WHERE ReelId in ('{string.Join("','", needLockUpns)}');");
            }
            sb.Append($" UPDATE smt_kanbanOrder SET isComplete=1, FinishedTime='{now}' WHERE wo='{orderNo}';");
            string error;
            int rowCount = DbHelper.ExcuteWithTransaction(sb.ToString(), out error);

            log.AppendLine($"2、复核完成整体数据操作{sb}；影响行数：{rowCount}；错误信息：{error}");
            FileLog.Log($"出库复核数据更新操作日志：{log}");
            return rowCount;
        }

        public static int FinishDeliveyOrderReview(string deliveryNo, string userName, List<ReviewSummary> barcodes)
        {
            var allBarcodes = GetDeliveryBarcodes(deliveryNo);

            StringBuilder sb = new StringBuilder();
            foreach (var item in allBarcodes)
            {
                if (item.OrderStatus == (int)DeliveryBarcodeStatusEnum.Cancelled)
                {
                    continue;
                }
                var reviewedBarcode = barcodes.FirstOrDefault(p => p.UPN == item.Barcode);
                if (reviewedBarcode == null)
                {
                    //不存在
                    if (item.OrderStatus == (int)DeliveryBarcodeStatusEnum.Undeliver)
                    {
                        sb.AppendLine($@" UPDATE Wms_DeliveryBarcode 
                        SET OrderStatus = {(int)DeliveryBarcodeStatusEnum.Cancelled}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' WHERE BusinessId ='{item.BusinessId}' ;");

                        sb.AppendLine($" update smt_zd_material set Status = {(int)BarcodeStatusEnum.Saved}, isTake = 0,  Work_Order_No = '', LockRequestID = ''  where  ReelID = '{item.Barcode}'; ");
                    }
                    else if (item.OrderStatus == (int)DeliveryBarcodeStatusEnum.Delivered)
                    {
                        //未复核，此时移入理料区
                        sb.AppendLine($@" UPDATE Wms_DeliveryBarcode 
                        SET OrderStatus = {(int)DeliveryBarcodeStatusEnum.Cancelled}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' WHERE BusinessId ='{item.BusinessId}' ;");

                        sb.AppendLine($" update smt_zd_material set Status = {(int)BarcodeStatusEnum.Saved}, isTake = 0,  Work_Order_No = '', LockRequestID = ''  where  ReelID = '{item.Barcode}'; ");
                    }
                    else
                    {
                        //已复核，do nothing
                    }
                }
                else
                {
                    if (reviewedBarcode.Match == 0)
                    {
                        //未复核，此时移入理料区
                        sb.AppendLine($@" UPDATE Wms_DeliveryBarcode 
                        SET OrderStatus = {(int)DeliveryBarcodeStatusEnum.Cancelled}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' WHERE BusinessId ='{item.BusinessId}' ;");

                        sb.AppendLine($" update smt_zd_material set Status = {(int)BarcodeStatusEnum.Saved}, isTake = 0, LockTowerNo = 0, LockLocation = '', AbSide = '', Work_Order_No = '', LockRequestID = ''  where  ReelID = '{item.Barcode}'; ");
                    }
                    else
                    {
                        //已复核
                        sb.AppendLine($@" UPDATE Wms_DeliveryBarcode 
                        SET OrderStatus = {(int)DeliveryBarcodeStatusEnum.Reviewed}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' WHERE BusinessId ='{item.BusinessId}' ;");

                        sb.AppendLine($@"update smt_zd_material set istake=1, isTakeCheck =1, isReturnCheck = 0,
                           isSave = 1, taketime = getdate(), LockTowerNo = '0',LockLocation = '',LockMachineID = '',ABSide='', Status='{(int)BarcodeStatusEnum.Delivered}' where reelid = '{item.Barcode}'; ");
                    }
                    barcodes.Remove(reviewedBarcode);
                }
            }
            //剩余的记录，只剩本次复核新增的
            var details = GetDeliveryDetails(deliveryNo);
            foreach (var item in barcodes)
            {
                var detail = details.FirstOrDefault(p => p.MaterialNo == item.PartNumber && p.RowNum == TypeParse.StrToInt(item.LineNumber, 0));
                if (detail == null)
                {
                    throw new OppoCoreException($"复核的物料{item.UPN}对应的料号{item.PartNumber}和行号{item.LineNumber}在出库单明细中找不到对应项");
                }
                sb.AppendLine($@"INSERT INTO Wms_DeliveryBarcode
                (BusinessId, DeliveryId, DeliveryDetailId, BoxNo, Barcode, OrigionBarcode, DeliveryAreaId, DeliveryQuantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
                VALUES('{Guid.NewGuid():D}', '{detail.DeliveryId}', '{detail.BusinessId}', '{item.ContainerNo}', '{item.UPN}', '', {item.TowerNo}, {item.RealQty}, {(int)DeliveryBarcodeStatusEnum.Reviewed}, getdate(), '{userName}', getdate(), '{userName}');");

                sb.AppendLine($@"update smt_zd_material set istake=1, isTakeCheck =1, isReturnCheck = 0,
                isSave = 1, taketime = getdate(), LockTowerNo = '0',LockLocation = '',LockMachineID = '',ABSide='', Status='{(int)BarcodeStatusEnum.Delivered}' where reelid = '{item.UPN}'; ");
            }

            sb.AppendLine($@"update Wms_DeliveryOrder set OrderStatus = {(int)DeliveryOrderStatusEnum.Reviewed}, 
                    LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}'  where DeliveryNo = '{deliveryNo}'; ");

            return DbHelper.ExcuteWithTransaction(sb.ToString(), out string _);
        }


        public static int TempDeliveyOrderReview(string deliveryNo, string userName, List<ReviewSummary> barcodes)
        {
            var allBarcodes = GetDeliveryBarcodes(deliveryNo);
            var details = GetDeliveryDetails(deliveryNo);

            StringBuilder sb = new StringBuilder();
            foreach (var item in barcodes)
            {
                var originBarcode = allBarcodes.FirstOrDefault(p => p.Barcode == item.UPN);
                if (originBarcode == null)
                {
                    var detail = details.FirstOrDefault(p => p.MaterialNo == item.PartNumber && p.RowNum == TypeParse.StrToInt(item.LineNumber, 0));
                    if (detail == null)
                    {
                        throw new OppoCoreException($"复核的物料{item.UPN}对应的料号{item.PartNumber}和行号{item.LineNumber}在出库单明细中找不到对应项");
                    }
                    sb.AppendLine($@"INSERT INTO Wms_DeliveryBarcode
                        (BusinessId, DeliveryId, DeliveryDetailId, BoxNo, Barcode, OrigionBarcode, DeliveryAreaId, DeliveryQuantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
                        VALUES('{Guid.NewGuid():D}', '{detail.DeliveryId}', '{detail.BusinessId}', '{item.ContainerNo}', '{item.UPN}', '', {item.TowerNo}, {item.RealQty}, {(int)DeliveryBarcodeStatusEnum.Reviewed}, getdate(), '{userName}', getdate(), '{userName}');");
                }
                else
                {
                    sb.AppendLine($@" UPDATE Wms_DeliveryBarcode 
                        SET OrderStatus = {(int)DeliveryBarcodeStatusEnum.Reviewed}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' WHERE BusinessId ='{originBarcode.BusinessId}' ;");

                    allBarcodes.Remove(originBarcode);
                }
                sb.AppendLine($@"update smt_zd_material set istake=1, isTakeCheck =0, isReturnCheck = 0,
                        isSave = 1, taketime = getdate(), LockTowerNo = '0',LockLocation = '',LockMachineID = '',ABSide='', Status='{(int)BarcodeStatusEnum.Locked}' where reelid = '{item.UPN}'; ");
            }
            //以前复核的，本次暂存，不在列表里了，那么要去除
            var removeBarcodes = allBarcodes.Where(p => p.OrderStatus == (int)DeliveryBarcodeStatusEnum.Reviewed).ToList();
            List<string> upns = removeBarcodes.Select(p => $"'{p.Barcode}'").ToList();
            string joinCondition = string.Join(",", upns);

            sb.AppendLine($@" UPDATE Wms_DeliveryBarcode 
                        SET OrderStatus = {(int)DeliveryBarcodeStatusEnum.Cancelled}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' WHERE Barcode IN ({joinCondition}) ;");
            sb.AppendLine($@"update smt_zd_material set istake=0, isTakeCheck =0, isReturnCheck = 0,
                        isSave = 1, taketime = '', LockTowerNo = '0',LockLocation = '',LockMachineID = '',ABSide='', Status='{(int)BarcodeStatusEnum.Saved}' where reelid IN ({joinCondition}) ; ");


            return DbHelper.ExcuteWithTransaction(sb.ToString(), out string _);
        }

        private static List<Wms_DeliveryBarcode> GetDeliveryBarcodes(string deliveryNo)
        {
            string sql = $@"SELECT wdb.* FROM Wms_DeliveryBarcode wdb 
              LEFT JOIN Wms_DeliveryOrder wdo ON wdb.DeliveryId = wdo.BusinessId 
              WHERE wdo.DeliveryNo = '{deliveryNo}' ";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_DeliveryBarcode>();
        }

        private static List<Wms_DeliveryDetail> GetDeliveryDetails(string deliveryNo)
        {
            string sql = $@"SELECT wdd.* FROM Wms_DeliveryDetail wdd 
              LEFT JOIN Wms_DeliveryOrder wdo ON wdd.DeliveryId = wdo.BusinessId 
              WHERE wdo.DeliveryNo = '{deliveryNo}' ";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_DeliveryDetail>();
        }

        private static string GetBindOrderByUpn(string upn)
        {
            string sql = $" SELECT Work_Order_No FROM smt_zd_material WHERE ReelId = '{upn}' ";
            return Convert.ToString(DbHelper.ExecuteScalar(sql));
        }

        public static List<ReviewResultItem> GetResults(string orderNo)
        {
            string sql = $@" SELECT spm.OrderNo,spm.PartNumber,kbo.woQty as NeedQty,
                                    spm.UPN,spm.Qty,spm.TowerNo,st.Description as TowerDes,
                                    spm.Source,spm.Match,spm.LineNumber
                               FROM smt_prepare_material spm
                          LEFT JOIN smt_kanbanOrder kbo
                                 ON kbo.wo = spm.OrderNo 
                                AND kbo.LockSeq_ID = spm.PartNumber
                                AND kbo.LineNumber = spm.LineNumber
                          LEFT JOIN smt_TowerMap st 
                                 ON st.TowerNo = spm.TowerNo
                              WHERE spm.OrderNo = '{orderNo}' AND spm.Match=1 ";
            DataTable dt = DbHelper.GetDataTable(sql);
            List<ReviewResultItem> reviewResults = dt.DataTableToList<ReviewResultItem>();
            var resultGroups = reviewResults.GroupBy(p => new { p.OrderNo, p.PartNumber, p.LineNumber }).ToList();
            foreach (var group in resultGroups)
            {
                int total = group.Sum(p => p.Qty);
                group.ToList().ForEach(p => p.TotalQty = total);
            }
            return reviewResults.OrderBy(p => p.OrderNo).ThenBy(p => p.LineNumber).ToList();
        }

        public static void InsertOutStockFeedBack(string orderNo)
        {
            string outStockOrderSql = $@" {Wms_DeliveryOrder.GetSelectSql()} AND DeliveryNo ='{orderNo}' ";
            var orders = DbHelper.GetDataTable(outStockOrderSql).DataTableToList<Wms_DeliveryOrder>();
            if (orders == null || orders.Count == 0)
            {
                return;
            }
            var order = orders.First();
            string type = ((OutOrderTypeEnum)order.DeliveryType).ToString();
            string destNo = order.LineId;
            string feedBackInsert = $@" Insert INTO smt_OutStockOrder_feedback
                                       (OrderNo,Status,OrderType,DestinationNo) VALUES 
                                       ('{order.BusinessId}',0,'{type}','{destNo}')";
            DbHelper.Insert(feedBackInsert);
        }
    }

    public class OrderNeedMaterial
    {
        /// <summary>
        /// 工单
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string PartNumber { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public string LineNumber { get; set; }
        public string SlotNo { get; set; }
        /// <summary>
        /// 需求数量
        /// </summary>
        public int NeedQty { get; set; }
    }

    public class OutStockDdlItem
    {
        public string DeliveryId { get; set; } = string.Empty;

        /// <summary>
        /// 出库工单号
        /// </summary>
        public string OrderNo { get; set; } = string.Empty;
        /// <summary>
        /// 工单类型
        /// </summary>
        public int Type2 { get; set; } = -1;
        /// <summary>
        /// 工单目的地
        /// </summary>
        public string DestinationNo { get; set; } = string.Empty;
        /// <summary>
        /// 工单类型描述
        /// </summary>
        public string TypeDes => EnumHelper.GetDescription(typeof(OutOrderTypeEnum), Type2);
    }

    public class ReviewResultItem
    {
        public string OrderNo { get; set; }

        public string PartNumber { get; set; }

        public int NeedQty { get; set; }

        public string UPN { get; set; }

        public int Qty { get; set; }

        public int TotalQty { get; set; }

        public string Result => Match == (int)PrepareReviewMatchEnum.Not ? ""
                                : (TotalQty == NeedQty ? "正常"
                                    : (TotalQty > NeedQty ? "超发"
                                        : "短发"));

        public string TowerDes => EnumHelper.GetDescription(typeof(TowerEnum), TowerNo);

        public int TowerNo { get; set; }

        public int Source { get; set; }
        public int Match { get; set; }

        public string LineNumber { get; set; }

        public string Remark => $"{EnumHelper.GetDescription(typeof(PrepareSourceEnum), Source)}{EnumHelper.GetDescription(typeof(PrepareReviewMatchEnum), Match)}";
    }

    public class ReviewRecord
    {
        public ReviewRecord()
        {
            ScanTime = DateTime.Now;
        }


        public ReviewRecord(string upn)
        {
            ReelId = upn;
            Part_Number = upn.Split('-')[0];
            ScanTime = DateTime.Now;
        }

        public string UPN => ReelId;

        public string QRCode { get; set; }

        public string ReelId { get; set; }

        public string Part_Number { get; set; } = string.Empty;

        public int Qty { get; set; } = 0;

        public int LockTowerNo { get; set; } = 0;

        public string TowerDes { get; set; } = string.Empty;

        public bool IsSave { get; set; } = false;

        public bool IsTake { get; set; } = false;

        public bool IsTakeCheck { get; set; } = false;

        public int HoldState { get; set; } = 0;

        public string BakeUpn { get; set; } = string.Empty;

        private string _status = string.Empty;
        public string Status
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_status))
                {
                    if (IsSave && !IsTakeCheck)
                    {
                        if (HoldState == 1)
                        {
                            return "物料冻结";
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(BakeUpn))
                            {
                                return "正常出库";
                            }
                            else
                            {
                                return "物料在烘烤区";
                            }
                        }
                    }
                    else
                    {
                        return "UPN不在库中";
                    }
                }
                else
                {
                    return _status;
                }
            }
            set
            {
                _status = value;
            }
        }

        public bool IsOk => IsSave && !IsTakeCheck && HoldState != 1 && string.IsNullOrWhiteSpace(BakeUpn);

        public DateTime ScanTime { get; set; }

        public string BoxNo { get; set; } = string.Empty;

        public string OriginalCode { get; set; } = string.Empty;
    }

    public class ReviewSummary : INotifyPropertyChanged
    {
        public string OrderNo { get; set; }
        public int TowerNo { get; set; }

        public string TowerDes => EnumHelper.GetDescription(typeof(TowerEnum), TowerNo);
        ///// <summary>
        ///// 序号，以料号为单位
        ///// </summary>
        //public int Index { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string PartNumber { get; set; }
        /// <summary>
        /// 行号
        /// </summary>
        public string LineNumber { get; set; }
        /// <summary>
        /// 槽位
        /// </summary>
        public string SlotNo { get; set; }
        /// <summary>
        /// 需求数量
        /// </summary>
        public int NeedQty { get; set; }

        private string _upn = string.Empty;
        /// <summary>
        /// 已分配UPN
        /// </summary>
        public string UPN
        {
            get { return _upn; }
            set
            {
                if (_upn != value)
                {
                    _upn = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UPN)));
                }
            }
        }

        private int _allocateQty = 0;
        /// <summary>
        /// 待分配数量
        /// </summary>
        public int AllocateQty
        {
            get { return _allocateQty; }
            set
            {
                if (_allocateQty != value)
                {
                    _allocateQty = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AllocateQty)));
                }
            }
        }

        private int _match = 0;
        /// <summary>
        /// 是否复核
        /// </summary>
        public int Match
        {
            get { return _match; }
            set
            {
                if (_match != value)
                {
                    _match = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Match)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MatchDes)));
                }
            }
        }

        public string MatchDes => Match == 1 ? "已复核" : "未复核";

        private int _realQty = 0;
        /// <summary>
        /// 实际数量
        /// </summary>
        public int RealQty
        {
            get { return _realQty; }
            set
            {
                if (_realQty != value)
                {
                    _realQty = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RealQty)));
                }
            }
        }
        public int Source { get; set; }

        private string _containerNo = string.Empty;

        public string ContainerNo
        {
            get { return _containerNo; }
            set
            {
                if (_containerNo != value)
                {
                    _containerNo = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ContainerNo)));
                }
            }
        }
        public string SourceDes => EnumHelper.GetDescription(typeof(PrepareSourceEnum), Source);

        private string _qrCode = string.Empty;
        /// <summary>
        /// 二维码
        /// </summary>
        public string QRCode
        {
            get { return _qrCode; }
            set
            {
                if (_qrCode != value)
                {
                    _qrCode = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QRCode)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
