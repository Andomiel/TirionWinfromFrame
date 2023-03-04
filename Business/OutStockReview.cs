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
    public class ReviewBusiness
    {

        public static IEnumerable<OrderNeedMaterial> GetMaterialsByOutOrderNo(string orderNo)
        {
            string sql = $@" SELECT wdo.DeliveryNo as OrderNo, wdd.MaterialNo as PartNumber,wdd.RequireCount as NeedQty,
	                    wdd.RowNum as LineNumber, wdd.SlotNo 
                    FROM Wms_DeliveryDetail wdd 
                    left join Wms_DeliveryOrder wdo on wdd.DeliveryId = wdo.BusinessId 
                    WHERE wdo.DeliveryNo ='{orderNo}'
                    ORDER BY RowNum ASC ";
            return DbHelper.GetDataTable(sql).DataTableToList<OrderNeedMaterial>();
        }

        public static IEnumerable<ReviewSummary> GetSpareMaterial(string orderNo)
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
            return dt.DataTableToList<ReviewSummary>();
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
                IEnumerable<ReviewRecord> dtList = dt.DataTableToList<ReviewRecord>();
                return dtList.First();
            }
            else
            {
                return new ReviewRecord(upn);
            }
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
                else if (item.OrderStatus == (int)DeliveryBarcodeStatusEnum.Undeliver || item.OrderStatus == (int)DeliveryBarcodeStatusEnum.Delivered)
                {
                    sb.AppendLine($@" UPDATE Wms_DeliveryBarcode 
                        SET OrderStatus = {(int)DeliveryBarcodeStatusEnum.Cancelled}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' WHERE BusinessId ='{item.BusinessId}' ;");

                    sb.AppendLine($" update smt_zd_material set Status = {(int)BarcodeStatusEnum.Saved}, isTake = 0, isTakeCheck =0, LockTowerNo = 0, LockLocation = '', AbSide = '', Work_Order_No = '', LockRequestID = ''  where  ReelID = '{item.Barcode}'; ");
                }
                else
                {
                    //已复核，do nothing
                }
            }

            sb.AppendLine($@"update Wms_DeliveryOrder set OrderStatus = {(int)DeliveryOrderStatusEnum.Reviewed}, 
                    LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}'  where DeliveryNo = '{deliveryNo}'; ");

            return DbHelper.ExcuteWithTransaction(sb.ToString(), out string _);
        }

        private static IEnumerable<Wms_DeliveryBarcode> GetDeliveryBarcodes(string deliveryNo)
        {
            string sql = $@"SELECT wdb.* FROM Wms_DeliveryBarcode wdb  WITH(NOLock) 
              LEFT JOIN Wms_DeliveryOrder wdo  WITH(NOLock) ON wdb.DeliveryId = wdo.BusinessId 
              WHERE wdo.DeliveryNo = '{deliveryNo}' ";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_DeliveryBarcode>();
        }

        private static IEnumerable<Wms_DeliveryDetail> GetDeliveryDetails(string deliveryNo)
        {
            string sql = $@"SELECT wdd.* FROM Wms_DeliveryDetail wdd  WITH(NOLock) 
              LEFT JOIN Wms_DeliveryOrder wdo WITH(NOLock)  ON wdd.DeliveryId = wdo.BusinessId 
              WHERE wdo.DeliveryNo = '{deliveryNo}' ";
            return DbHelper.GetDataTable(sql).DataTableToList<Wms_DeliveryDetail>();
        }

        public static void InsertOutStockFeedBack(string orderNo)
        {
            string outStockOrderSql = $@" {Wms_DeliveryOrder.GetSelectSql()} AND DeliveryNo ='{orderNo}' ";
            var orders = DbHelper.GetDataTable(outStockOrderSql).DataTableToList<Wms_DeliveryOrder>();
            if (orders == null || !orders.Any())
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

        public static void ReviewBarcode(string deliveryNo, string userName, ReviewSummary barcode)
        {
            var allBarcodes = GetDeliveryBarcodes(deliveryNo);

            StringBuilder sb = new StringBuilder();
            int cancelledStatus = (int)DeliveryBarcodeStatusEnum.Cancelled;
            var currentBarcodes = allBarcodes.Where(p => p.Barcode == barcode.UPN && p.OrderStatus < cancelledStatus);
            if (currentBarcodes.Any())
            {
                var currentBarcode = currentBarcodes.First();
                foreach (var item in currentBarcodes)
                {
                    if (item.BusinessId != currentBarcode.BusinessId)
                    {
                        //多余的取消掉
                        sb.AppendLine($@" UPDATE Wms_DeliveryBarcode 
                        SET OrderStatus = {(int)DeliveryBarcodeStatusEnum.Cancelled}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' WHERE BusinessId ='{currentBarcode.BusinessId}' ;");
                    }
                }
                //已复核
                sb.AppendLine($@" UPDATE Wms_DeliveryBarcode 
                        SET OrderStatus = {(int)DeliveryBarcodeStatusEnum.Reviewed}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' WHERE BusinessId ='{currentBarcode.BusinessId}' ;");

                sb.AppendLine($@"update smt_zd_material set istake=1, isTakeCheck =1,
                 taketime = getdate(), LockTowerNo = '0',LockLocation = '',LockMachineID = '',ABSide='', Status='{(int)BarcodeStatusEnum.Delivered}', QRCode = '{barcode.QRCode}' where reelid = '{currentBarcode.Barcode}'; ");
            }
            else
            {
                var details = GetDeliveryDetails(deliveryNo);
                var detail = details.FirstOrDefault(p => p.MaterialNo == barcode.PartNumber && p.RowNum == TypeParse.StrToInt(barcode.LineNumber, 0));
                if (detail == null)
                {
                    throw new OppoCoreException($"复核的物料{barcode.UPN}对应的料号{barcode.PartNumber}和行号{barcode.LineNumber}在出库单明细中找不到对应项");
                }
                //新增
                sb.AppendLine($@"INSERT INTO Wms_DeliveryBarcode
                (BusinessId, DeliveryId, DeliveryDetailId, BoxNo, Barcode, OrigionBarcode, DeliveryAreaId, DeliveryQuantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
                VALUES('{Guid.NewGuid():D}', '{detail.DeliveryId}', '{detail.BusinessId}', '{barcode.ContainerNo}', '{barcode.UPN}', '', { barcode.TowerNo}, { barcode.RealQty}, { (int)DeliveryBarcodeStatusEnum.Reviewed}, getdate(), '{userName}', getdate(), '{userName}'); ");

                sb.AppendLine($@"update smt_zd_material set istake=1, isTakeCheck =1, 
                taketime = getdate(), LockTowerNo = '0',LockLocation = '',LockMachineID = '',ABSide='', Status='{(int)BarcodeStatusEnum.Delivered}', QRCode = '{barcode.QRCode}' where reelid = '{barcode.UPN}'; ");
            }
            DbHelper.ExcuteWithTransaction(sb.ToString(), out string _);
        }

        public static void ReleaseReviewedBarcode(string deliveryId, string userName, string barcode)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($@" UPDATE Wms_DeliveryBarcode 
                        SET OrderStatus = {(int)DeliveryBarcodeStatusEnum.Cancelled}, LastUpdateTime = GETDATE(), LastUpdateUser = '{userName}' WHERE DeliveryId ='{deliveryId}' and  Barcode = '{barcode}' ;");

            sb.AppendLine($" update smt_zd_material set Status = {(int)BarcodeStatusEnum.Saved}, isTake = 0, isTakeCheck =0, LockTowerNo = 0, LockLocation = '', AbSide = '', Work_Order_No = '', LockRequestID = ''  where  ReelID = '{barcode}'; ");
            DbHelper.ExcuteWithTransaction(sb.ToString(), out string _);
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

        private int _reviewedQuantity = 0;
        /// <summary>
        /// 已复核数量
        /// </summary>
        public int ReviewedQuantity
        {
            get { return _reviewedQuantity; }
            set
            {
                if (_reviewedQuantity != value)
                {
                    _reviewedQuantity = value;

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReviewedQuantity)));
                }
            }
        }

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
