using Business;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Entity;
using Entity.DataContext;
using Entity.Dto.Delivery;
using Entity.Enums;
using Entity.Enums.General;
using Entity.Facade;
using Mapster;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmOutstocks : FrmBaseForm
    {
        public int pageSize = 10;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页

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

            dtOrderTime.CustomFormat = " ";
            dtFinishedTime.CustomFormat = " ";
        }


        private void dtp_MouseUp(object sender, MouseEventArgs e)
        {
            var thisDateTimePicker = sender as DateTimePicker;
            thisDateTimePicker.CustomFormat = "yyyy-MM-dd";
        }

        private List<Wms_DeliveryOrder> WorkOrders = new List<Wms_DeliveryOrder>();

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

            GetOrders();
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            try
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
                        var statusItem = statusList.FirstOrDefault(p => p.shelf_id == label.ToolTip);
                        if (statusItem != null)
                        {
                            if (statusItem.state == (int)LightShelfStatusEnum.Normal)
                            {
                                label.ForeColor = Color.Green;
                            }
                            else if (statusItem.state == (int)LightShelfStatusEnum.Delivering)
                            {
                                label.ForeColor = Color.Yellow;
                            }
                            else if (statusItem.state == (int)LightShelfStatusEnum.Error)
                            {
                                label.ForeColor = Color.Red;
                            }
                            else
                            {
                                label.ForeColor = Color.Blue;
                            }
                        }
                    }
                }
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
            Dictionary<string, string> logDict = new Dictionary<string, string>(3);
            logDict.Add("url", url);

            var request = new LightShelfBaseRequest();
            string requestString = JsonConvert.SerializeObject(request);
            logDict.Add("request", requestString);

            string strResponse = WebClientHelper.Post(JsonConvert.SerializeObject(request), url, null);
            logDict.Add("response", strResponse);

            FileLog.Log($"读取亮灯货架状态:{JsonConvert.SerializeObject(logDict)}");

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
            if (!string.IsNullOrWhiteSpace(dtOrderTime.CustomFormat))
            {
                condition.HaveOrderTimeQuery = true;
                condition.OrderTimeStart = dtOrderTime.Value.Date;
                condition.OrderTimeEnd = dtOrderTime.Value.Date.AddDays(1);
            }
            if (!string.IsNullOrWhiteSpace(dtFinishedTime.CustomFormat))
            {
                condition.HaveFinishedTimeQuery = true;
                condition.FinishedTimeStart = dtFinishedTime.Value.Date;
                condition.FinishedTimeEnd = dtFinishedTime.Value.Date.AddDays(1);
            }

            WorkOrders = DeliveryBll.GetDeliveryOrders(condition);

            currentPage = 1;
            recordCount = WorkOrders.Count;
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
                PagedWorkOrders.Clear();
                tpscurrentPage.Text = "0";//当前页
                tpspageCount.Text = "0";//总页数
                tpsrecordCount.Text = "0";//总记录数
                return;
            }
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord = pageSize * (currentPage - 1) + 1;
            int endRecord = pageSize * currentPage;

            if (currentPage >= pageCount) endRecord = recordCount;
            PagedWorkOrders.Clear();
            for (int i = beginRecord - 1; i < endRecord; i++)
            {
                PagedWorkOrders.Add(WorkOrders[i].Adapt<DeliveryOrderDto>());
            }
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
            selectedOrder = order;

            var details = DeliveryBll.GetDeliveryDetails(order.BusinessId);
            OrderBarcodes = DeliveryBll.GetDeliveryBarcodes(order.BusinessId);

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

        private readonly object lockOutstockObj = new object();

        private void BtnOutstock_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockOutstockObj)
                {
                    if (selectedOrder == null)
                    {
                        "请至少选中一行数据！".ShowTips();
                        return;
                    }
                    if (selectedOrder.OrderStatus < (int)DeliveryOrderStatusEnum.Calculated)
                    {
                        "当前单据尚未计算，没有要出库的物料信息！".ShowTips();
                        return;
                    }
                    if (selectedOrder.OrderStatus >= (int)DeliveryOrderStatusEnum.Delivering)
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
                    dgvOrders.UpdateCellValue(2, dgvOrders.CurrentRow.Index);

                    "出库任务下达成功！".ShowTips();
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
            if (records == null || records.Count == 0)
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
                if (currentRecords == null || currentRecords.Count() < 2)
                {
                    continue;
                }

                string area = EnumHelper.GetDescription(typeof(TowerEnum), item);
                List<string> orderNos = currentRecords.Select(p => p.OrderNo).Distinct().ToList();
                throw new OppoCoreException($"当前已有两个出库单据({string.Join(",", orderNos)})在库区{area}中执行，请等待");
            }
        }

        private void ValidateInstockOrderLimit()
        {
            var records = BaseDeliveryBll.GetExecutingAreas();
            if (records == null || records.Count == 0)
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

        private readonly object lockJumpObj = new object();

        private void BtnJump_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockJumpObj)
                {

                    "出库任务下达成功！".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private readonly object lockFinishObj = new object();

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockFinishObj)
                {
                    if (selectedOrder == null)
                    {
                        "请至少选中一行数据！".ShowTips();
                        return;
                    }

                    if (selectedOrder.OrderStatus != (int)DeliveryOrderStatusEnum.Delivering)
                    {
                        "【正在出库】状态的工单才能【拣料完成】！".ShowTips();
                        return;
                    }

                    int asrsArea = (int)TowerEnum.ASRS;
                    int unfinishStatus = (int)DeliveryBarcodeStatusEnum.Undeliver;
                    if (OrderBarcodes.Any(p => p.DeliveryAreaId == asrsArea && p.OrderStatus == unfinishStatus))
                    {
                        "智能仓中仍然有未出完的料，不可拣料完成".ShowTips();
                        return;
                    }

                    new DeliveryBll().FinishDeliveryOrder(selectedOrder.BusinessId, selectedOrder.DeliveryNo, AppInfo.LoginUserInfo.account);
                    selectedOrder.OrderStatus = (int)DeliveryOrderStatusEnum.Delivered;
                    dgvOrders.UpdateCellValue(2, dgvOrders.CurrentRow.Index);

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
                    if (selectedOrder == null)
                    {
                        "请选择要导出明细的出库单".ShowTips();
                        return;
                    }
                    if (WorkOrderDetails.Count == 0)
                    {
                        "暂无数据可导出，请查询后导出".ShowTips();
                        return;
                    }

                    var data = OrderBarcodes.Join(WorkOrderDetails, p => p.DeliveryDetailId, p => p.BusinessId, (b, d) => new
                    {
                        OrderNo = selectedOrder.DeliveryNo,
                        OrderTime = selectedOrder.CreateTime,
                        OrderTypeDes = selectedOrder.DeliveryTypeDisplay,
                        FinishedTime = selectedOrder.LastUpdateTime,
                        OrderStatus = selectedOrder.OrderStatusDisplay,
                        DestinationNo = selectedOrder.LineId,
                        MaterialNo = d.MaterialNo,
                        DeliveryCount = d.RequireCount,
                        MaterialName = string.Empty,
                        InventoryStatus = d.DeliveryStatusDisplay,
                        Barcode = b.Barcode,
                        InnerCount = b.DeliveryQuantity,
                        DeliveryOperator = b.CreateUser,
                    }).ToList();

                    var lackDetails = WorkOrderDetails.Where(p => p.Barcodes.Count == 0).ToList();
                    if (WorkOrderDetails.Any(p => p.Barcodes.Count == 0))
                    {
                        foreach (var item in lackDetails)
                        {
                            data.Add(new
                            {
                                OrderNo = selectedOrder.DeliveryNo,
                                OrderTime = selectedOrder.CreateTime,
                                OrderTypeDes = selectedOrder.DeliveryTypeDisplay,
                                FinishedTime = selectedOrder.LastUpdateTime,
                                OrderStatus = selectedOrder.OrderStatusDisplay,
                                DestinationNo = selectedOrder.LineId,
                                MaterialNo = item.MaterialNo,
                                DeliveryCount = item.RequireCount,
                                MaterialName = string.Empty,
                                InventoryStatus = item.DeliveryStatusDisplay,
                                Barcode = string.Empty,
                                InnerCount = 0,
                                DeliveryOperator = string.Empty,
                            });
                        }
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

        public void ExportToExcel<T>(List<T> data, List<HeadColumn> headColumns) where T : class
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            dialog.FilterIndex = 0;
            dialog.OverwritePrompt = true;
            dialog.InitialDirectory = "D:\\";
            dialog.FileName = $"出库单{selectedOrder.DeliveryNo}-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
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
            dtOrderTime.Value = DateTime.Today;
            dtOrderTime.CustomFormat = " ";
            dtFinishedTime.Value = DateTime.Today;
            dtFinishedTime.CustomFormat = " ";
            GetOrders();
        }

        private void BtnFrist_ButtonClick(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadPagedWorkOrder();
        }

        private void BtnPre_ButtonClick(object sender, EventArgs e)
        {
            currentPage -= 1;
            LoadPagedWorkOrder();
        }

        private void BtnNext_ButtonClick(object sender, EventArgs e)
        {
            currentPage += 1;
            LoadPagedWorkOrder();
        }

        private void BtnLast_ButtonClick(object sender, EventArgs e)
        {
            currentPage = pageCount;
            LoadPagedWorkOrder();
        }

        private readonly object lockCancelObj = new object();

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockCancelObj)
                {
                    if (selectedOrder == null)
                    {
                        "请至少选中一行数据".ShowTips();
                        return;
                    }

                    if (selectedOrder.OrderStatus == (int)DeliveryOrderStatusEnum.Delivering)
                    {
                        "工单在发料中，无法取消，可以在发料完成后取消出库，释放物料".ShowTips();
                        return;
                    }
                    if (selectedOrder.OrderStatus >= (int)DeliveryOrderStatusEnum.Reviewed)
                    {
                        "工单已复核或关闭，无法取消".ShowTips();
                        return;
                    }
                    //TODO:取消出库，关闭单据，同时，将所有占用的料全部释放
                    CancelDeliveryOrderBarcodes((int)DeliveryOrderStatusEnum.Closed);

                    selectedOrder.OrderStatus = (int)DeliveryOrderStatusEnum.Closed;
                    dgvOrders.UpdateCellValue(2, dgvOrders.CurrentRow.Index);
                    _ = "工单取消成功".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void CancelDeliveryOrderBarcodes(int targetStatus)
        {
            new DeliveryBll().ReleaseExistedDeliveryBarcode(selectedOrder.BusinessId, selectedOrder.DeliveryNo, targetStatus, AppInfo.LoginUserInfo.account, OrderBarcodes.Select(p => p.Barcode).Distinct().ToList());
            OrderBarcodes.Clear();
            foreach (var item in WorkOrderDetails)
            {
                item.Barcodes.Clear();
            }
        }

        private readonly object lockCalculateObj = new object();

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockCalculateObj)
                {
                    if (selectedOrder == null)
                    {
                        "请至少选中一行数据".ShowTips();
                        return;
                    }
                    if (selectedOrder.OrderStatus >= (int)DeliveryOrderStatusEnum.Delivering)
                    {
                        "已发料的工单不可重新计算发料".ShowTips();
                        return;
                    }
                    if (selectedOrder.OrderStatus >= (int)DeliveryOrderStatusEnum.Calculating)
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
                var inventoryBarcodes = DeliveryBll.GetBarcodesByMaterialNo(item.MaterialNo);
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

        private readonly object lockSpecialObj = new object();

        private void BtnSpecial_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockSpecialObj)
                {
                    if (selectedOrder == null)
                    {
                        "请选中一行数据".ShowTips();
                        return;
                    }

                    if (selectedOrder.OrderStatus >= (int)DeliveryOrderStatusEnum.Delivering)
                    {
                        "工单已开始发料，无法进行有料出库".ShowTips();
                        return;
                    }

                    new DeliveryBll().SpecialFinishDeliveryOrder(selectedOrder.BusinessId, AppInfo.LoginUserInfo.account, OrderBarcodes.Select(p => p.Barcode).ToList());
                    selectedOrder.OrderStatus = (int)DeliveryOrderStatusEnum.Delivered;
                    dgvOrders.UpdateCellValue(2, dgvOrders.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
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

                    FrmReviewNew reviewNew = new FrmReviewNew(order);
                    if (reviewNew.ShowDialog() == DialogResult.OK)
                    {
                        LoadOrderDetails();
                    }
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
                    row.Cells["colInventoryStatus"].Style.BackColor = Color.Orange;
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
                lock (lockSpecialObj)
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
                    if (selectedOrder == null)
                    {
                        "请选择要导出明细的出库单".ShowTips();
                        return;
                    }
                    if (WorkOrderDetails.Count == 0)
                    {
                        "暂无数据可导出，请查询后导出".ShowTips();
                        return;
                    }

                    var detailCount = OrderBarcodes.GroupBy(p => p.DeliveryDetailId).ToDictionary(p => p.Key, p => p.Sum(b => b.DeliveryQuantity));

                    var data = WorkOrderDetails.Select(p => new LackDetail()
                    {
                        RowNum = p.RowNum,
                        OrderNo = selectedOrder.DeliveryNo,
                        MaterialNo = p.MaterialNo,
                        RequireCount = p.RequireCount,
                        DeliveryCount = detailCount.ContainsKey(p.BusinessId) ? detailCount[p.BusinessId] : 0,
                    }).ToList();

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
                lock (lockSpecialObj)
                {
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
}
