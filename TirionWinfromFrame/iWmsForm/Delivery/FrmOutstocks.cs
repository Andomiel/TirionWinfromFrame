using Business;
using Commons;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Entity;
using Entity.DataContext;
using Entity.Dto.Delivery;
using Entity.Enums;
using Entity.Enums.General;
using Entity.Facade;
using Mapster;
using MES;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;
using TirionWinfromFrame.iWmsForm;

namespace iWms.Form
{
    public partial class FrmOutstocks : FrmBaseForm
    {
        public int pageSize = 10;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 1;    //当前页

        private Timer statusTimer;

        public FrmOutstocks()
        {
            InitializeComponent();
            BindCombox();

            dgvOrders.ScrollBars = ScrollBars.Both;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = PagedWorkOrders;
            dgvOrders.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色

            dgvDetails.ScrollBars = ScrollBars.Both;
            dgvDetails.Dock = DockStyle.Fill;
            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = WorkOrderDetails;
            dgvDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色

            dgvUpns.ScrollBars = ScrollBars.Both;
            dgvUpns.Dock = DockStyle.Fill;
            dgvUpns.AutoGenerateColumns = false;
            dgvUpns.DataSource = WorkOrderBarcodes;
            dgvUpns.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色
        }

        private BindingList<DeliveryOrderDto> PagedWorkOrders = new BindingList<DeliveryOrderDto>();

        private BindingList<DeliveryDetailDto> WorkOrderDetails = new BindingList<DeliveryDetailDto>();

        private BindingList<DeliveryBarcodeDto> WorkOrderBarcodes = new BindingList<DeliveryBarcodeDto>();

        private List<Wms_DeliveryBarcode> OrderBarcodes = new List<Wms_DeliveryBarcode>();

        private void BindCombox()
        {
            cbOrderType.DataSource = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(OutOrderTypeEnum));
            cbOrderType.DisplayMember = "Description";
            cbOrderType.ValueMember = "Value";

            cbOrderStatus.DataSource = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(DeliveryOrderStatusEnum));
            cbOrderStatus.DisplayMember = "Description";
            cbOrderStatus.ValueMember = "Value";
        }

        private void FrmOutstocks_Load(object sender, EventArgs e)
        {
            cbOrderType.SelectedIndex = 0;
            cbOrderStatus.SelectedIndex = 0;

            ReleaseTimer();

            statusTimer = new Timer
            {
                Interval = 30 * 1000
            };
            statusTimer.Tick += StatusTimer_Tick;
            statusTimer.Start();

            SetHighPrivilege();
            GetOrders();
        }

        //private delegate void RefreshLightStatusDelegate(LabelControl label, string tooltipText, Color foreColor);

        //private void RefreshLightStatus(LabelControl label, string tooltipText, Color foreColor)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.Invoke(new RefreshLightStatusDelegate(RefreshLightStatus));
        //    }
        //    else
        //    {
        //        label.ToolTip = tooltipText;
        //        label.ForeColor = foreColor;
        //    }
        //}

        private void InvokeMethod()
        {
            Action invokeAction = new Action(InvokeMethod);
            if (this.InvokeRequired)
            {
                this.Invoke(invokeAction);
            }
            else
            {
                var statusList = GetLightShelfStatus();
                if (statusList == null || statusList.Count == 0)
                {
                    return;
                }

                foreach (Control item in tlpLight.Controls)
                {
                    if (item is LabelControl)
                    {
                        var label = item as LabelControl;
                        string labelIndex = Convert.ToString(label.Tag);
                        var statusItem = statusList.FirstOrDefault(p => p.shelf_id == labelIndex);
                        if (statusItem != null)
                        {
                            label.ToolTip = $"{statusItem.shelf_id}{EnumHelper.GetDescription(typeof(LightShelfStatusEnum), statusItem.state)}";
                            Color foreColor = Color.Black;
                            if (statusItem.state == (int)LightShelfStatusEnum.Normal)
                            {
                                label.ForeColor = Color.Green;
                            }
                            else if (statusItem.state == (int)LightShelfStatusEnum.TimeOut)
                            {
                                label.ForeColor = Color.Yellow;
                            }
                            else if (statusItem.state == (int)LightShelfStatusEnum.Error)
                            {
                                label.ForeColor = Color.Red;
                            }
                            else if (statusItem.state == (int)LightShelfStatusEnum.Appending)
                            {
                                label.ForeColor = Color.Blue;
                            }
                            else if (statusItem.state == (int)LightShelfStatusEnum.Delivering)
                            {
                                label.ForeColor = Color.Purple;
                            }
                            else if (statusItem.state == (int)LightShelfStatusEnum.OffLine)
                            {
                                label.ForeColor = Color.Gray;
                            }
                            else
                            {
                                label.ForeColor = Color.Black;
                            }
                        }
                    }
                }
            }
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                InvokeMethod();
            }
            catch (Exception ex)
            {
                FileLog.Log($"刷新料架状态出错:{ex.GetDeepException()}");
            }
        }

        private List<LightShelfStatus> GetLightShelfStatus()
        {
            string url = ConfigurationManager.AppSettings["lightShelfStatusUrl"];
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new OppoCoreException("缺少亮灯货架的状态明细服务地址配置");
            }

            //Ping pingSender = new Ping();
            //PingReply reply = pingSender.Send(new Uri(url).Host, 10);//第一个参数为ip地址，第二个参数为ping的时间
            //if (reply.Status != IPStatus.Success)
            //{
            //    return new List<LightShelfStatus>();
            //}
            //Dictionary<string, string> logDict = new Dictionary<string, string>(3);
            //logDict.Add("url", url);

            var request = new LightShelfBaseRequest();
            string requestString = JsonConvert.SerializeObject(request);
            //logDict.Add("request", requestString);

            string strResponse = WebClientHelper.Post(requestString, url, null);
            //logDict.Add("response", strResponse);

            //FileLog.Log($"读取亮灯货架状态:{JsonConvert.SerializeObject(logDict)}");

            LightShelfStatusResponse response = JsonConvert.DeserializeObject<LightShelfStatusResponse>(strResponse);
            return response?.data;
        }

        private void ReleaseTimer()
        {
            if (statusTimer != null)
            {
                statusTimer.Stop();
                //statusTimer.Tick -= StatusTimer_Tick;
                statusTimer.Dispose();
                statusTimer = null;
            }
        }


        private readonly object lockQueryObj = new object();

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockQueryObj)
                {
                    GetOrders();
                    if (PagedWorkOrders.Count == 0)
                    {
                        WorkOrderDetails.Clear();
                    }
                    if (WorkOrderDetails.Count == 0)
                    {
                        WorkOrderBarcodes.Clear();
                    }

                    dgvOrders.ClearSelection();
                    dgvDetails.ClearSelection();
                    dgvUpns.ClearSelection();
                    selectedOrder = null;
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void GetOrders()
        {
            DeliveryQueryCondition condition = new DeliveryQueryCondition
            {
                OrderNo = tbOrderNo.Text.Trim(),
                OrderType = Convert.ToInt32(cbOrderType.SelectedValue),
                OrderStatus = Convert.ToInt32(cbOrderStatus.SelectedValue),
                Destination = tbDestination.Text.Trim(),
                MaterialNo = tbMaterialNo.Text.Trim(),
                Upn = tbUpn.Text.Trim(),
                Operator = tbOperator.Text.Trim()
            };

            condition.HaveOrderTimeQuery = dtCreate.EditValue != null;
            if (condition.HaveOrderTimeQuery)
            {
                condition.OrderTimeStart = dtCreate.DateTime.Date;
                condition.OrderTimeEnd = dtCreate.DateTime.Date.AddDays(1);
            }

            condition.HaveFinishedTimeQuery = dtFinish.EditValue != null; ;
            if (condition.HaveFinishedTimeQuery)
            {
                condition.FinishedTimeStart = dtFinish.DateTime.Date;
                condition.FinishedTimeEnd = dtFinish.DateTime.Date.AddDays(1);
            }

            PagedWorkOrders.Clear();

            int startRow = (currentPage - 1) * pageSize;
            var orders = DeliveryBll.GetDeliveryOrders(condition, startRow, startRow + pageSize);

            foreach (var item in orders)
            {
                PagedWorkOrders.Add(item);
            }

            recordCount = 0;
            if (orders != null && orders.Any())
            {
                recordCount = orders.First().TotalCount;
            }
            pageCount = (recordCount / pageSize);
            if (recordCount % pageSize > 0)
            {
                pageCount += 1;
            }
            LoadPagedWorkOrder();
        }

        private void LoadPagedWorkOrder()
        {
            if (pageCount == 0)
            {
                tpscurrentPage.Text = "0";//当前页
                tpspageCount.Text = "0";//总页数
                tpsrecordCount.Text = "0";//总记录数
                return;
            }
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            tpscurrentPage.Text = currentPage.ToString();//当前页
            tpspageCount.Text = pageCount.ToString();//总页数
            tpsrecordCount.Text = recordCount.ToString();//总记录数
        }

        private void DgvOrders_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var row = dgvOrders.Rows[e.RowIndex];
                var order = row.DataBoundItem as DeliveryOrderDto;
                if (order.OrderStatus == (int)DeliveryOrderStatusEnum.Reviewed)
                {
                    row.Cells["colOrderStatus"].Style.BackColor = Color.LightGreen;
                }
                else if (order.OrderStatus == (int)DeliveryOrderStatusEnum.Received)
                {
                    //do nothing
                }
                else
                {
                    row.Cells["colOrderStatus"].Style.BackColor = Color.Yellow;
                }
                ShowRowIndex(dgvOrders, e);
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private DeliveryOrderDto selectedOrder = null;

        private void DgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                LoadOrderDetails();
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void LoadOrderDetails()
        {
            if (dgvOrders.SelectedCells.Count == 0)
            {
                return;
            }
            var row = dgvOrders.SelectedCells[0].OwningRow;
            var order = row.DataBoundItem as DeliveryOrderDto;
            if (order.DeliveryNo == selectedOrder?.DeliveryNo)
            {
                return;
            }
            selectedOrder = order;

            var details = DeliveryBll.GetDeliveryDetails(order.BusinessId);
            OrderBarcodes = DeliveryBll.GetDeliveryBarcodes(order.BusinessId).ToList();

            WorkOrderDetails.Clear();
            WorkOrderBarcodes.Clear();

            foreach (Wms_DeliveryDetail item in details)
            {
                if (WorkOrderDetails.Any(p => p.BusinessId == item.BusinessId))
                {
                    continue;
                }
                var detail = item.Adapt<DeliveryDetailDto>();
                detail.OrderStatus = selectedOrder.OrderStatus;
                detail.Barcodes = OrderBarcodes.Where(p => p.DeliveryDetailId == detail.BusinessId).ToList();
                WorkOrderDetails.Add(detail);
            }
        }

        private void DgvDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var row = dgvDetails.Rows[e.RowIndex];
                var order = row.DataBoundItem as DeliveryDetailDto;
                if (order.DeliveryStatusDisplay.Contains("充足") || order.DeliveryStatusDisplay.Contains("正常"))
                {
                    row.Cells["colInventoryStatus"].Style.BackColor = Color.LightGreen;
                }
                else if (order.DeliveryStatusDisplay.Contains("不足") || order.DeliveryStatusDisplay.Contains("短发"))
                {
                    row.Cells["colInventoryStatus"].Style.BackColor = Color.Red;
                }
                else if (order.DeliveryStatusDisplay.Contains("超领") || order.DeliveryStatusDisplay.Contains("超发"))
                {
                    row.Cells["colInventoryStatus"].Style.BackColor = Color.Yellow;
                }
                else
                {
                    //do nothing
                }
                ShowRowIndex(dgvDetails, e);
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void DgvDetails_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetails.SelectedCells.Count == 0)
                {
                    return;
                }
                var row = dgvDetails.SelectedCells[0].OwningRow;
                var detail = row.DataBoundItem as DeliveryDetailDto;

                WorkOrderBarcodes.Clear();
                foreach (Wms_DeliveryBarcode item in detail.Barcodes)
                {
                    WorkOrderBarcodes.Add(item.Adapt<DeliveryBarcodeDto>());
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void BtnOutstock_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockOrderObj)
                {
                    if (selectedOrder == null)
                    {
                        "请选中一行数据！".ShowTips();
                        return;
                    }
                    var order = DeliveryBll.GetDeliveryOrderByNo(selectedOrder.DeliveryNo);
                    if (order.OrderStatus < (int)DeliveryOrderStatusEnum.Calculated)
                    {
                        "当前单据尚未计算，没有要出库的物料信息！".ShowTips();
                        return;
                    }
                    if (order.OrderStatus >= (int)DeliveryOrderStatusEnum.Delivering)
                    {
                        "不可重复执行出库！".ShowTips();
                        return;
                    }
                    ValidateDeliveryOrderLimit();
                    //ValidateInstockOrderLimit();

                    FrmSortNo sortDiag = new FrmSortNo();
                    if (sortDiag.ShowDialog() != DialogResult.OK)
                    { return; }

                    new DeliveryBll().DeliveryCalculatedBarcodes(selectedOrder.BusinessId, selectedOrder.DeliveryNo, selectedOrder.OrderType, sortDiag.SortNo, AppInfo.LoginUserInfo.account);
                    selectedOrder.OrderStatus = (int)DeliveryOrderStatusEnum.Delivering;

                    Task.Run(() => { CallMesWmsApiBll.SaveLogs(order.DeliveryNo, "执行出库", $"{AppInfo.LoginUserInfo.username}({AppInfo.LoginUserInfo.account})", string.Empty); });
                    "出库任务下达成功！".ShowTips();

                    GetOrders();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
            finally
            {
                GetOrders();
            }
        }

        private void ValidateDeliveryOrderLimit()
        {
            var records = BaseDeliveryBll.GetExecutingRecords();
            if (records == null || !records.Any())
            {
                return;
            }
            var recordGroup = records.GroupBy(p => p.LightArea);
            var barcodeAreas = OrderBarcodes.Select(p => p.DeliveryAreaId).Distinct().ToList();

            foreach (int item in barcodeAreas)
            {
                if (item == (int)TowerEnum.SortingArea)
                {
                    continue;
                }
                var currentRecords = recordGroup.FirstOrDefault(p => p.Key == item);
                if (currentRecords == null || currentRecords.Count() < 3)
                {
                    continue;
                }

                string area = EnumHelper.GetDescription(typeof(TowerEnum), item);
                List<string> orderNos = currentRecords.Select(p => p.OrderNo).Distinct().ToList();
                throw new OppoCoreException($"当前已有3个出库单据({string.Join(",", orderNos)})在库区{area}中执行，请等待");
            }
        }

        private void ValidateInstockOrderLimit()
        {
            var records = BaseDeliveryBll.GetExecutingAreas();
            if (records == null || !records.Any())
            {
                return;
            }
            var recordGroup = records.GroupBy(p => p.AreaId);
            var barcodeAreas = OrderBarcodes.Select(p => p.DeliveryAreaId).Distinct().ToList();

            foreach (int item in barcodeAreas)
            {
                if (item == (int)TowerEnum.SortingArea)
                {
                    continue;
                }
                var currentRecords = recordGroup.FirstOrDefault(p => p.Key == item);
                if (currentRecords == null || currentRecords.Count() == 0)
                {
                    continue;
                }

                string area = EnumHelper.GetDescription(typeof(TowerEnum), item);
                throw new OppoCoreException($"当前已有入库单据在库区{area}中执行，请等待");
            }
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockOrderObj)
                {
                    if (selectedOrder == null)
                    {
                        "请选中一行数据！".ShowTips();
                        return;
                    }
                    var order = DeliveryBll.GetDeliveryOrderByNo(selectedOrder.DeliveryNo);
                    if (order.OrderStatus != (int)DeliveryOrderStatusEnum.Delivering)
                    {
                        "【正在出库】状态的工单才能【拣料完成】！".ShowTips();
                        return;
                    }

                    int asrsArea = (int)TowerEnum.ASRS;
                    int unfinishStatus = (int)DeliveryBarcodeStatusEnum.Undeliver;
                    var barcodes = DeliveryBll.GetDeliveryBarcodes(selectedOrder.BusinessId);
                    if (barcodes.Any(p => p.DeliveryAreaId == asrsArea && p.OrderStatus == unfinishStatus))
                    {
                        "智能仓中仍然有未出完的料，不可拣料完成".ShowTips();
                        return;
                    }

                    new DeliveryBll().FinishDeliveryOrder(selectedOrder.BusinessId, selectedOrder.DeliveryNo, AppInfo.LoginUserInfo.account);
                    selectedOrder.OrderStatus = (int)DeliveryOrderStatusEnum.Delivered;

                    Task.Run(() => { CallMesWmsApiBll.SaveLogs(order.DeliveryNo, "标记完成出库", $"{AppInfo.LoginUserInfo.username}({AppInfo.LoginUserInfo.account})", string.Empty); });
                    $"出库单:{selectedOrder.DeliveryNo}捡料完成".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
            finally
            {
                GetOrders();
            }
        }

        private readonly object lockExportObj = new object();

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockExportObj)
                {
                    var workOrders = PagedWorkOrders.Where(p => p.IsSelected).ToList();
                    if (workOrders.Count == 0)
                    {
                        "请选择要导出明细的出库单".ShowTips();
                        return;
                    }

                    Dictionary<string, List<ExportOrder>> data = new Dictionary<string, List<ExportOrder>>();
                    foreach (var order in workOrders)
                    {
                        List<ExportOrder> dataItem = new List<ExportOrder>();

                        var details = DeliveryBll.GetDeliveryDetails(order.BusinessId);
                        var barcodes = DeliveryBll.GetDeliveryBarcodes(order.BusinessId);
                        var barcodesGroup = barcodes.GroupBy(p => p.DeliveryDetailId).ToDictionary(p => p.Key, p => p.ToList());
                        foreach (var detail in details)
                        {
                            var detailDto = detail.Adapt<DeliveryDetailDto>();
                            detailDto.OrderStatus = order.OrderStatus;

                            if (barcodesGroup.ContainsKey(detail.BusinessId))
                            {
                                var detailBarcodes = barcodesGroup[detail.BusinessId];
                                detailDto.Barcodes = detailBarcodes;

                                foreach (var barcode in detailBarcodes)
                                {
                                    dataItem.Add(new ExportOrder
                                    {
                                        OrderNo = selectedOrder.DeliveryNo,
                                        OrderTime = selectedOrder.CreateTime,
                                        OrderTypeDes = selectedOrder.DeliveryTypeDisplay,
                                        FinishedTime = selectedOrder.LastUpdateTime,
                                        OrderStatus = selectedOrder.OrderStatusDisplay,
                                        DestinationNo = selectedOrder.LineId,
                                        MaterialNo = detail.MaterialNo,
                                        DeliveryCount = detail.RequireCount,
                                        MaterialName = string.Empty,
                                        InventoryStatus = detailDto.DeliveryStatusDisplay,
                                        Barcode = barcode.Barcode,
                                        InnerCount = barcode.DeliveryQuantity,
                                        DeliveryOperator = barcode.CreateUser,
                                    });
                                }
                            }
                            else
                            {
                                dataItem.Add(new ExportOrder
                                {
                                    OrderNo = selectedOrder.DeliveryNo,
                                    OrderTime = selectedOrder.CreateTime,
                                    OrderTypeDes = selectedOrder.DeliveryTypeDisplay,
                                    FinishedTime = selectedOrder.LastUpdateTime,
                                    OrderStatus = selectedOrder.OrderStatusDisplay,
                                    DestinationNo = selectedOrder.LineId,
                                    MaterialNo = detail.MaterialNo,
                                    DeliveryCount = detail.RequireCount,
                                    MaterialName = string.Empty,
                                    InventoryStatus = detailDto.DeliveryStatusDisplay,
                                    Barcode = string.Empty,
                                    InnerCount = 0,
                                    DeliveryOperator = string.Empty,
                                });
                            }
                        }

                        data.Add(order.DeliveryNo, dataItem);
                    }

                    List<HeadColumn> headColumns = new List<HeadColumn>
                        {
                            new HeadColumn("OrderNo","出库单号", 4200),
                            new HeadColumn("OrderTime","下达时间", 4000),
                            new HeadColumn("OrderTypeDes","单据类型", 3000),
                            new HeadColumn("FinishedTime","完成时间", 4000),
                            new HeadColumn("OrderStatus","单据状态", 3000),
                            new HeadColumn("DestinationNo","目的地", 2200),
                            new HeadColumn("MaterialNo","物料代码", 2200),
                            new HeadColumn("MaterialName","物料名称", 4000),
                            new HeadColumn("DeliveryCount","需求数量", 2200),
                            new HeadColumn("InventoryStatus","库存状态", 3000),
                            new HeadColumn("Barcode","UPN", 7168),
                            new HeadColumn("InnerCount","盘内数量", 2200),
                            new HeadColumn("DeliveryOperator","操作人", 3000),
                        };
                    ExportToExcel(data, headColumns);
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        public void ExportToExcel<T>(Dictionary<string, List<T>> data, List<HeadColumn> headColumns) where T : class
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            dialog.FilterIndex = 0;
            dialog.OverwritePrompt = true;
            dialog.InitialDirectory = "D:\\";
            if (data.Count == 1)
            {
                dialog.FileName = $"出库单{data.First().Key}-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
            }
            else
            {
                dialog.FileName = $"出库单-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
            }
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileFullName = NpoiHelper.ExportToExcel(dialog.FileName, data, headColumns);
            if (!string.IsNullOrWhiteSpace(fileFullName))
            {
                System.Diagnostics.Process.Start("explorer", "/select," + fileFullName);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            cbOrderType.SelectedIndex = 0;
            cbOrderStatus.SelectedIndex = 0;
            tbOrderNo.Text = string.Empty;
            tbUpn.Text = string.Empty;
            tbMaterialNo.Text = string.Empty;
            tbDestination.Text = string.Empty;
            tbOperator.Text = string.Empty;
            dtCreate.EditValue = null;
            dtFinish.EditValue = null;
            GetOrders();
        }

        private void BtnFrist_ButtonClick(object sender, EventArgs e)
        {
            currentPage = 1;
            GetOrders();
        }

        private void BtnPre_ButtonClick(object sender, EventArgs e)
        {
            currentPage -= 1;
            GetOrders();
        }

        private void BtnNext_ButtonClick(object sender, EventArgs e)
        {
            currentPage += 1;
            GetOrders();
        }

        private void BtnLast_ButtonClick(object sender, EventArgs e)
        {
            currentPage = pageCount;
            GetOrders();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockOrderObj)
                {
                    if (selectedOrder == null)
                    {
                        "请选中一行数据".ShowTips();
                        return;
                    }
                    var order = DeliveryBll.GetDeliveryOrderByNo(selectedOrder.DeliveryNo);
                    if (order.OrderStatus == (int)DeliveryOrderStatusEnum.Delivering)
                    {
                        "工单在发料中，无法取消，可以在发料完成后取消出库，释放物料".ShowTips();
                        return;
                    }
                    if (order.OrderStatus >= (int)DeliveryOrderStatusEnum.Reviewed)
                    {
                        "工单已复核或关闭，无法取消".ShowTips();
                        return;
                    }
                    //TODO:取消出库，关闭单据，同时，将所有占用的料全部释放
                    CancelDeliveryOrderBarcodes((int)DeliveryOrderStatusEnum.Closed);

                    selectedOrder.OrderStatus = (int)DeliveryOrderStatusEnum.Closed;
                    dgvOrders.UpdateCellValue(2, dgvOrders.CurrentRow.Index);

                    Task.Run(() => { CallMesWmsApiBll.SaveLogs(order.DeliveryNo, "取消工单发料", $"{AppInfo.LoginUserInfo.username}({AppInfo.LoginUserInfo.account})", string.Empty); }); SplashScreenManager.ShowForm(typeof(WaitForm1));
                    try
                    {
                        //尤其注意，这里使用的是出库单的Id
                        var feedback = CallMesWmsApiBll.FeedbackOrder(order.BusinessId, ((OutOrderTypeEnum)order.DeliveryType).ToString(), order.LineId.ToUpper());
                        feedback.Message.ShowTips();
                    }
                    finally
                    {
                        SplashScreenManager.CloseForm();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void CancelDeliveryOrderBarcodes(int targetStatus)
        {
            var barcodes = DeliveryBll.GetDeliveryBarcodes(selectedOrder.BusinessId);
            new DeliveryBll().ReleaseExistedDeliveryBarcode(selectedOrder.BusinessId, selectedOrder.DeliveryNo, targetStatus, AppInfo.LoginUserInfo.account, barcodes.Select(p => p.Barcode).Distinct().ToList());
            OrderBarcodes.Clear();
            foreach (var item in WorkOrderDetails)
            {
                item.Barcodes.Clear();
            }
        }

        private static readonly object lockOrderObj = new object();

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockOrderObj)
                {
                    if (selectedOrder == null)
                    {
                        "请选中一行数据".ShowTips();
                        return;
                    }
                    var order = DeliveryBll.GetDeliveryOrderByNo(selectedOrder.DeliveryNo);
                    if (order.OrderStatus >= (int)DeliveryOrderStatusEnum.Delivering)
                    {
                        "已发料的工单不可重新计算发料".ShowTips();
                        return;
                    }
                    if (order.OrderStatus >= (int)DeliveryOrderStatusEnum.Calculating)
                    {
                        var dialogResult = "当前工单已经经过计算，是否重新计算".ShowYesNoAndTips();
                        if (dialogResult != DialogResult.Yes)
                        {
                            return;
                        }
                        CancelDeliveryOrderBarcodes((int)DeliveryOrderStatusEnum.Received);
                    }

                    var sortingResult = "计算时是否涵盖理料区物料？".ShowYesNoAndTips();
                    bool isContainSorting = sortingResult == DialogResult.Yes;

                    if (!DeliveryBll.LockOrderWhenCalculate(selectedOrder.BusinessId, AppInfo.LoginUserInfo.account))
                    {
                        "计算时锁定工单失败".ShowTips();
                        return;
                    }
                    BuildDeliveryFromWorkOrder(isContainSorting);

                    selectedOrder.OrderStatus = (int)DeliveryOrderStatusEnum.Calculated;
                    dgvOrders.UpdateCellValue(2, dgvOrders.CurrentRow.Index);

                    Task.Run(() => { CallMesWmsApiBll.SaveLogs(order.DeliveryNo, "执行发料计算", $"{AppInfo.LoginUserInfo.username}({AppInfo.LoginUserInfo.account})", string.Empty); });
                    _ = "工单计算发料成功".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void BuildDeliveryFromWorkOrder(bool isContainSorting)
        {
            List<Wms_DeliveryDetail> deliveryDetails = new List<Wms_DeliveryDetail>();
            List<string> alreadyInBarcodes = new List<string>();

            foreach (DeliveryDetailDto item in WorkOrderDetails)
            {
                int remainCount = item.RequireCount;
                var inventoryBarcodes = DeliveryBll.GetBarcodesByMaterialNo(item.MaterialNo).ToList();
                //TODO:here there should be a private method for certain purpose
                inventoryBarcodes.RemoveAll(p => alreadyInBarcodes.Contains(p.ReelID));
                if (!isContainSorting)
                {
                    int removeArea = (int)TowerEnum.SortingArea;
                    inventoryBarcodes.RemoveAll(p => p.LockTowerNo == removeArea);
                }
                foreach (SMTZDMaterial barcode in inventoryBarcodes)
                {
                    if (remainCount <= 0)
                    {
                        break;
                    }
                    var deliveryBarcode = new Wms_DeliveryBarcode()
                    {
                        Barcode = barcode.ReelID,
                        BusinessId = Guid.NewGuid().ToString("D"),
                        CreateTime = DateTime.Now,
                        CreateUser = AppInfo.LoginUserInfo.account,
                        DeliveryDetailId = item.BusinessId,
                        LastUpdateTime = DateTime.Now,
                        LastUpdateUser = AppInfo.LoginUserInfo.account,
                        OrderStatus = (int)DeliveryBarcodeStatusEnum.Undeliver,
                        DeliveryAreaId = barcode.LockTowerNo,
                        DeliveryId = selectedOrder.BusinessId,
                        DeliveryQuantity = (int)barcode.Qty,
                        DeliveryLocation = barcode.LockLocation
                    };
                    alreadyInBarcodes.Add(barcode.ReelID);

                    OrderBarcodes.Add(deliveryBarcode);
                    item.Barcodes.Add(deliveryBarcode);

                    remainCount -= deliveryBarcode.DeliveryQuantity;
                }
                //if (remainCount > 0)
                //{
                //    throw new OppoCoreException($"当前工单[{selectedOrder.DeliveryNo}]物料项[{item.MaterialNo}]需求数量[{item.RequireCount}]无法满足，发料计算中止.ShowTips();
                //}
                if (item.Barcodes.Any(P => P.DeliveryQuantity >= item.RequireCount))
                {
                    var items = item.Barcodes.Where(p => p.DeliveryQuantity < item.RequireCount).ToList();
                    foreach (var barcode in items)
                    {
                        item.Barcodes.Remove(barcode);
                        OrderBarcodes.Remove(barcode);
                    }
                }
            }

            _ = DeliveryBll.CreateDeliveryBarcodes(selectedOrder.BusinessId, AppInfo.LoginUserInfo.account, OrderBarcodes);
        }

        private void BtnSpecial_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockOrderObj)
                {
                    if (selectedOrder == null)
                    {
                        "请选中一行数据".ShowTips();
                        return;
                    }
                    var order = DeliveryBll.GetDeliveryOrderByNo(selectedOrder.DeliveryNo);
                    if (order.OrderStatus >= (int)DeliveryOrderStatusEnum.Delivering)
                    {
                        "工单已开始发料，无法进行有料出库".ShowTips();
                        return;
                    }

                    new DeliveryBll().SpecialFinishDeliveryOrder(selectedOrder.BusinessId, AppInfo.LoginUserInfo.account, OrderBarcodes.Select(p => p.Barcode).ToList());
                    selectedOrder.OrderStatus = (int)DeliveryOrderStatusEnum.Delivered;
                    dgvOrders.UpdateCellValue(2, dgvOrders.CurrentRow.Index);

                    Task.Run(() => { CallMesWmsApiBll.SaveLogs(selectedOrder.DeliveryNo, "标记有料出库", $"{AppInfo.LoginUserInfo.username}({AppInfo.LoginUserInfo.account})", string.Empty); });
                    "工单有料出库完成".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void dgvUpns_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var row = dgvUpns.Rows[e.RowIndex];
                var barcodeDto = row.DataBoundItem as DeliveryBarcodeDto;
                if (barcodeDto.ExecuteResult == (int)ExecuteResultEnum.Failed)
                {
                    row.Cells["colLocation"].Style.BackColor = Color.Orange;
                }
                else
                {
                    //do nothing
                }
                ShowRowIndex(dgvDetails, e);
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockOrderObj)
                {
                    if (selectedOrder == null)
                    {
                        "请选中一行数据".ShowTips();
                        return;
                    }

                    if (selectedOrder.OrderStatus <= (int)DeliveryOrderStatusEnum.Delivering)
                    {
                        "工单未发料，无法进行料架复位，请先完成发料".ShowTips();
                        return;
                    }

                    //var records = BaseDeliveryBll.GetExecutingRecords();
                    //var otherNos = new List<string>();
                    //if (records != null && records.Count > 0)
                    //{
                    //    int sortArea = (int)TowerEnum.SortingArea;
                    //    var recordNos = records.Where(p => p.LightArea > sortArea && p.OrderNo != selectedOrder.DeliveryNo).Select(p => p.OrderNo).Distinct().ToList();
                    //    string numString = string.Join(",", recordNos);
                    //    var comfirmResult = $"当前有其他工单{numString}正在执行发料，是否一并复位(不建议)？".ShowYesNoCancelAndTips();
                    //    if (comfirmResult == DialogResult.Cancel)
                    //    {
                    //        return;
                    //    }
                    //    else if (comfirmResult == DialogResult.OK)
                    //    {
                    //        otherNos = recordNos;
                    //    }
                    //    else
                    //    {
                    //        //do nothing
                    //    }
                    //}

                    new DeliveryBll().ResetDeliveryOrder(selectedOrder.BusinessId, selectedOrder.DeliveryNo, AppInfo.LoginUserInfo.account);
                    //额外做一次取消报警
                    string url = ConfigurationManager.AppSettings["lightShelfCancelAlarmUrl"];
                    if (string.IsNullOrWhiteSpace(url))
                    {
                        throw new OppoCoreException("缺少亮灯货架的取消报警服务地址配置");
                    }
                    foreach (string shelfNo in ShelfNos)
                    {
                        CancelAlarm(selectedOrder.DeliveryNo, url, shelfNo);
                    }

                    Task.Run(() => { CallMesWmsApiBll.SaveLogs(selectedOrder.DeliveryNo, "执行工单复位", $"{AppInfo.LoginUserInfo.username}({AppInfo.LoginUserInfo.account})", string.Empty); });
                    "复位成功，请检查料架和工单操作日志".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        private List<string> ShelfNos => new List<string>
            {
                "01",
                "02",
                "03",
                "04",
                "05",
                "06",
                "07",
                "08",
                "09",
                "10",
                "11",
                "12",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18",
                "19",
                "20",
                "21"
            };


        private string CancelAlarm(string deliveryNo, string url, string shelfNo)
        {
            Dictionary<string, string> logDict = new Dictionary<string, string>(3);
            logDict.Add("url", url);

            CancelAlarmRequest request = new CancelAlarmRequest() { shelf_id = $"SWHY0{shelfNo}" };
            string requestString = JsonConvert.SerializeObject(request);
            logDict.Add("request", requestString);

            string strResponse = WebClientHelper.Post(JsonConvert.SerializeObject(request), url, null);
            logDict.Add("response", strResponse);

            FileLog.Log($"操作亮灯货架取消报警:{JsonConvert.SerializeObject(logDict)}");

            Task.Run(() => { CallMesWmsApiBll.SaveLogs(deliveryNo, $"操作亮灯货架取消报警", $"url:{url}{Environment.NewLine}request:{requestString}", strResponse); });

            return strResponse;
        }

        private void BtnLack_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockExportObj)
                {
                    var workOrders = PagedWorkOrders.Where(p => p.IsSelected).ToList();
                    if (workOrders.Count == 0)
                    {
                        "请选择要导出明细的出库单".ShowTips();
                        return;
                    }

                    Dictionary<string, List<LackDetail>> data = new Dictionary<string, List<LackDetail>>();

                    foreach (var order in workOrders)
                    {
                        List<LackDetail> dataItem = new List<LackDetail>();

                        var details = DeliveryBll.GetDeliveryDetails(order.BusinessId);
                        var barcodes = DeliveryBll.GetDeliveryBarcodes(order.BusinessId);

                        int targetStatus = (int)DeliveryBarcodeStatusEnum.Reviewed;
                        if (order.OrderStatus <= (int)DeliveryOrderStatusEnum.Delivered)
                        {
                            barcodes = barcodes.Where(p => p.OrderStatus < targetStatus);
                        }
                        else
                        {
                            barcodes = barcodes.Where(p => p.OrderStatus == targetStatus);
                        }

                        var detailCount = barcodes.GroupBy(p => p.DeliveryDetailId).ToDictionary(p => p.Key, p => p.Sum(b => b.DeliveryQuantity));

                        foreach (var detail in details)
                        {
                            dataItem.Add(new LackDetail()
                            {
                                RowNum = detail.RowNum,
                                OrderNo = selectedOrder.DeliveryNo,
                                MaterialNo = detail.MaterialNo,
                                RequireCount = detail.RequireCount,
                                DeliveryCount = detailCount.ContainsKey(detail.BusinessId) ? detailCount[detail.BusinessId] : 0,
                            });
                        }

                        data.Add(order.DeliveryNo, dataItem);
                    }

                    List<HeadColumn> headColumns = new List<HeadColumn>
                        {
                            new HeadColumn("RowNum","序号", 2200),
                            new HeadColumn("OrderNo","出库单号", 4200),
                            new HeadColumn("MaterialNo","物料代码", 2200),
                            new HeadColumn("RequireCount","需求数量", 2200),
                            new HeadColumn("DeliveryCount","分配数量", 2200),
                            new HeadColumn("InventoryStatus","是否充足", 2000),
                            new HeadColumn("LackCount","欠料数量", 2200),
                        };
                    ExportToExcel(data, headColumns);
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void btnClearAlarm_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockOrderObj)
                {
                    //额外做一次取消报警
                    string url = ConfigurationManager.AppSettings["lightShelfCancelAlarmUrl"];
                    if (string.IsNullOrWhiteSpace(url))
                    {
                        throw new OppoCoreException("缺少亮灯货架的取消报警服务地址配置");
                    }
                    string logKey = "clearAlarm";
                    foreach (string shelfNo in ShelfNos)
                    {
                        CancelAlarm(logKey, url, shelfNo);
                    }

                    "取消报警成功，请等待30s刷新状态".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        private void FrmOutstocks_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleaseTimer();
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1)
                {
                    return;
                }
                if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    return;
                }
                string action = dgvOrders.Columns[e.ColumnIndex].Name;//操作类型
                if (action == "colReview")
                {
                    var row = dgvOrders.SelectedCells[0].OwningRow;
                    var order = row.DataBoundItem as DeliveryOrderDto;
                    if (string.IsNullOrWhiteSpace(order.OperationText))
                    {
                        return;
                    }
                    if (order.OrderStatus >= (int)DeliveryOrderStatusEnum.Reviewed)
                    {
                        $"出库单{order.DeliveryNo}{order.OrderStatusDisplay}，不可复核".ShowTips();
                        return;
                    }
                    string reviewLock = DeliveryBll.GetDeliveryOrderLock(order.BusinessId);
                    //string ip = DnsHelper.GetIP();
                    if (!string.IsNullOrWhiteSpace(reviewLock))
                    {
                        $"出库单{order.DeliveryNo}已在被其他人在{reviewLock}复核，请与其确认".ShowTips();
                        return;
                    }

                    FrmReviewNew reviewNew = new FrmReviewNew(order);
                    if (reviewNew.ShowDialog() == DialogResult.OK)
                    {
                        GetOrders();
                    }
                }
                else if (action == "colOrderNo")
                {
                    var row = dgvOrders.SelectedCells[0].OwningRow;
                    var order = row.DataBoundItem as DeliveryOrderDto;
                    System.Diagnostics.Process.Start($"http://172.16.255.19/iwms-79-8086/?logKey={order.DeliveryNo}");
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void SetHighPrivilege()
        {
            using (var db = new MESDB())
            {
                var roles = db.Database.SqlQuery<int>($@"SELECT distinct roleId 
                FROM[dbo].[sysUserRole] c 
                where c.userId = {AppInfo.LoginUserInfo.id}").ToListAsync().Result;

                if (roles == null || roles.Count == 0)
                {
                    btnClearOrders.Visible = false;
                }
                else if (roles.Contains(1))
                {
                    btnClearOrders.Visible = true;
                }
                else
                {
                    btnClearOrders.Visible = false;
                }
            }
        }

        private void BtnClearOrders_Click(object sender, EventArgs e)
        {
            FrmClearOrders detail = new FrmClearOrders();
            detail.ShowDialog();

            GetOrders();
        }
    }

    public class LackDetail
    {
        public int RowNum { get; set; } = 0;

        public string OrderNo { get; set; } = string.Empty;

        public string MaterialNo { get; set; } = string.Empty;

        public int RequireCount { get; set; } = 0;

        public int DeliveryCount { get; set; } = 0;

        public string InventoryStatus => DeliveryCount >= RequireCount ? "充足" : "欠料";

        public int LackCount => DeliveryCount >= RequireCount ? 0 : DeliveryCount - RequireCount;

    }

    public class ExportOrder
    {
        public string OrderNo { get; set; } = string.Empty;
        public DateTime OrderTime { get; set; } = new DateTime(1900, 1, 1);
        public string OrderTypeDes { get; set; } = string.Empty;
        public DateTime FinishedTime { get; set; } = new DateTime(1900, 1, 1);
        public string OrderStatus { get; set; } = string.Empty;
        public string DestinationNo { get; set; } = string.Empty;
        public string MaterialNo { get; set; } = string.Empty;
        public int DeliveryCount { get; set; } = 0;
        public string MaterialName { get; set; } = string.Empty;
        public string InventoryStatus { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public int InnerCount { get; set; } = 0;
        public string DeliveryOperator { get; set; } = string.Empty;
    }
}
