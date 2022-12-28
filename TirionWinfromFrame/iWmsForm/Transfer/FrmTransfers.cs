using Business;
using Entity;
using Entity.DataContext;
using Entity.Dto;
using Entity.Enums;
using Entity.Enums.Transfer;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmTransfers : FrmBaseForm
    {
        public FrmTransfers()
        {
            InitializeComponent();
            BindCombox();

            dtOrderTime.Value = DateTime.Now.Date;
            dtFinishedTime.Value = DateTime.Now.Date;

            dgvOrders.ScrollBars = ScrollBars.Both;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = WorkOrders;
            dgvOrders.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色

            dgvUpns.ScrollBars = ScrollBars.Both;
            dgvUpns.Dock = DockStyle.Fill;
            dgvUpns.AutoGenerateColumns = false;
            dgvUpns.DataSource = WorkOrderBarcodes;
            dgvUpns.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色
        }

        private BindingList<TransferOrderDto> WorkOrders = new BindingList<TransferOrderDto>();

        private BindingList<TransferBarcodeDto> WorkOrderBarcodes = new BindingList<TransferBarcodeDto>();

        private void BindCombox()
        {
            var towerItems = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(TransferTypeEnum));
            cbType.DataSource = towerItems;
            cbType.DisplayMember = "Description";
            cbType.ValueMember = "Value";

            cbOrderStatus.DataSource = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(TransferOrderStatusEnum));
            cbOrderStatus.DisplayMember = "Description";
            cbOrderStatus.ValueMember = "Value";
        }

        private void FrmOutstocks_Load(object sender, EventArgs e)
        {
            cbOrderStatus.SelectedIndex = 0;

            GetOrders();
        }

        private static readonly object lockQueryObj = new object();

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockQueryObj)
                {
                    GetOrders();
                    if (WorkOrders.Count == 0)
                    {
                        WorkOrderBarcodes.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void GetOrders()
        {
            TransferQueryCondition condition = new TransferQueryCondition
            {
                OrderNo = tbOrderNo.Text.Trim(),
                OrderStatus = Convert.ToInt32(cbOrderStatus.SelectedValue),
                TransferType = Convert.ToInt32(cbType.SelectedValue)
            };

            condition.MaterialNo = tbMaterialNo.Text.Trim();
            condition.Upn = tbUpn.Text.Trim();

            condition.HaveOrderTimeQuery = true;
            condition.OrderTimeStart = dtOrderTime.Value.Date;
            condition.OrderTimeEnd = dtOrderTime.Value.Date.AddDays(1);

            condition.HaveFinishedTimeQuery = true;
            condition.FinishedTimeStart = dtFinishedTime.Value.Date;
            condition.FinishedTimeEnd = dtFinishedTime.Value.Date.AddDays(1);

            var orders = TransferBll.GetTransferOrders(condition);

            WorkOrders.Clear();
            WorkOrderBarcodes.Clear();
            foreach (var item in orders)
            {
                WorkOrders.Add(item.Adapt<TransferOrderDto>());
            }
        }

        private TransferOrderDto selectedOrder = null;

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedCells.Count == 0)
                {
                    return;
                }
                var row = dgvOrders.SelectedCells[0].OwningRow;
                var order = row.DataBoundItem as TransferOrderDto;
                selectedOrder = order;

                var barcodes = TransferBll.GetTransferBarcodes(order.BusinessId);

                WorkOrderBarcodes.Clear();
                foreach (Wms_TransferBarcode item in barcodes)
                {
                    WorkOrderBarcodes.Add(item.Adapt<TransferBarcodeDto>());
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private static readonly object lockOutstockObj = new object();

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockOutstockObj)
                {
                    if (selectedOrder == null)
                    {
                        "请至少选中一个移库单".ShowTips();
                        return;
                    }
                    var order = TransferBll.GetTransferOrderByNo(selectedOrder.TransferNo);
                    if (order.OrderStatus > (int)TransferOrderStatusEnum.Executing)
                    {
                        "当前移库单状态不可执行".ShowTips();
                        return;
                    }

                    if (order.TargetAreaId == (int)TowerEnum.SortingArea)//移出判定亮灯
                    {
                        ValidateDeliveryOrderLimit();
                        //ValidateInstockOrderLimit();
                    }
                    else//移入
                    {
                        ValidateDeliveryOrderForTranferIn();
                        //ValidateInstockOrderForTransferIn();
                    }

                    new TransferBll().DeliveryCalculatedBarcodes(selectedOrder.BusinessId, selectedOrder.TransferNo, -1, -1, AppInfo.LoginUserInfo.account);

                    "移库任务下达成功！".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void ValidateDeliveryOrderLimit()
        {
            var records = BaseDeliveryBll.GetExecutingRecords();
            if (records == null || !records.Any())
            {
                return;
            }
            var recordGroup = records.Where(p => p.LightArea == selectedOrder.SourceAreaId).ToList();
            if (recordGroup.Count >= 2)
            {
                string area = EnumHelper.GetDescription(typeof(TowerEnum), selectedOrder.SourceAreaId);
                List<string> orderNos = recordGroup.Select(p => p.OrderNo).Distinct().ToList();
                throw new OppoCoreException($"当前已有两个出库单据({string.Join(",", orderNos)})在库区{area}中执行，请等待");
            }
        }

        private void ValidateInstockOrderLimit()
        {
            var records = BaseDeliveryBll.GetExecutingAreas();
            if (records == null || !records.Any())
            {
                return;
            }
            var recordGroup = records.Where(p => p.AreaId == selectedOrder.SourceAreaId).ToList();
            if (recordGroup != null && recordGroup.Count > 0)
            {
                string area = EnumHelper.GetDescription(typeof(TowerEnum), selectedOrder.SourceAreaId);
                throw new OppoCoreException($"当前已有入库单据在库区{area}中执行，请等待");
            }
        }

        private void ValidateDeliveryOrderForTranferIn()
        {
            var records = BaseDeliveryBll.GetExecutingRecords();
            if (records == null || !records.Any())
            {
                return;
            }
            var recordGroup = records.Where(p => p.LightArea == selectedOrder.TargetAreaId).ToList();
            if (recordGroup.Count > 0)
            {
                string area = EnumHelper.GetDescription(typeof(TowerEnum), selectedOrder.SourceAreaId);
                List<string> orderNos = recordGroup.Select(p => p.OrderNo).Distinct().ToList();
                throw new OppoCoreException($"当前有出库单据({string.Join(",", orderNos)})在库区{area}中执行，请等待");
            }
        }

        private void ValidateInstockOrderForTransferIn()
        {
            var records = BaseDeliveryBll.GetExecutingAreas();
            if (records == null || !records.Any())
            {
                return;
            }
            var recordGroup = records.Where(p => p.AreaId == selectedOrder.TargetAreaId).ToList();
            if (recordGroup != null && recordGroup.Count > 0 && recordGroup.Any(p => p.InstockId != selectedOrder.BusinessId))
            {
                string area = EnumHelper.GetDescription(typeof(TowerEnum), selectedOrder.SourceAreaId);
                throw new OppoCoreException($"当前已有入库单据在库区{area}中执行，请等待");
            }
        }

        private static readonly object lockFinishObj = new object();

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

                    //if (selectedOrder.OrderStatus != (int)TransferOrderStatusEnum.Executing)
                    //{
                    //    "【正在移库】状态的移库单才能【完成】！".ShowTips();
                    //    return;
                    //}
                    int asrsArea = (int)TowerEnum.ASRS;
                    int unfinished = (int)TransferBarcodeStatusEnum.Unfinished;
                    var barcodes = TransferBll.GetTransferBarcodes(selectedOrder.BusinessId);
                    if (selectedOrder.SourceAreaId == asrsArea && barcodes.Any(p => p.OrderStatus == unfinished))
                    {
                        "此移库单是从智能仓移出，目前仍然有未出完的料，不可移库完成".ShowTips();
                        return;
                    }

                    if (barcodes.Any(p => p.OrderStatus == unfinished))
                    {
                        if ("移库单中存在未移库的upn，确认完成将未移库的upn释放".ShowYesNoAndTips() != DialogResult.Yes)
                        {
                            return;
                        }
                    }

                    bool result = new TransferBll().FinishDeliveryOrder(selectedOrder.BusinessId, selectedOrder.TransferNo, AppInfo.LoginUserInfo.account);
                    if (result)
                    {
                        $"【{selectedOrder.TransferNo}】移库完成".ShowTips();
                    }
                    else
                    {
                        $"【{selectedOrder.TransferNo}】完成失败".ShowTips();
                    }
                    GetOrders();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void Dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            dgv.ClearSelection();
        }

        private static readonly object lockExportObj = new object();

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockExportObj)
                {
                    if (WorkOrderBarcodes.Count == 0)
                    {
                        "暂无数据可导出，请查询后导出".ShowTips();
                        return;
                    }

                    ExportToExcel();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        public void ExportToExcel()
        {
            if (selectedOrder == null)
            {
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            dialog.FilterIndex = 0;
            dialog.OverwritePrompt = true;
            dialog.InitialDirectory = "D:\\";
            dialog.FileName = $"导出移库单{selectedOrder.TransferNo}-{DateTime.Now:yyyyMMddHHmmssfff}";
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var data = WorkOrderBarcodes.Select(p => new
            {
                OrderNo = selectedOrder.TransferNo,
                OrderTime = selectedOrder.CreateTime,
                FinishedTime = selectedOrder.LastUpdateTime,
                OrderStatus = selectedOrder.OrderStatusDisplay,
                Source = selectedOrder.SourceAreaDisplay,
                Destination = selectedOrder.TargetAreaDisplay,
                p.MaterialNo,
                p.Barcode,
                p.Qty
            }).ToList();

            List<HeadColumn> headColumns = new List<HeadColumn>
            {
                new HeadColumn("OrderNo","移库单号", 4200),
                new HeadColumn("OrderTime","下达时间", 4000),
                new HeadColumn("FinishedTime","完成时间", 4000),
                new HeadColumn("OrderStatus","单据状态", 3000),
                new HeadColumn("Source","来源库区", 2200),
                new HeadColumn("Destination","目的库区", 2200),
                new HeadColumn("MaterialNo","物料代码", 2200),
                new HeadColumn("Barcode","UPN", 7168),
                new HeadColumn("Qty","盘内数量", 2200),
            };
            string fileFullName = NpoiHelper.ExportToExcel(dialog.FileName, data, headColumns);
            if (!string.IsNullOrWhiteSpace(fileFullName))
            {
                System.Diagnostics.Process.Start("explorer", "/select," + fileFullName);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbOrderStatus.SelectedIndex = 0;
            tbOrderNo.Text = string.Empty;
            tbUpn.Text = string.Empty;
            tbMaterialNo.Text = string.Empty;
            cbType.SelectedIndex = 0;
            dtOrderTime.Value = DateTime.Today;
            dtFinishedTime.Value = DateTime.Today;
            GetOrders();
        }

        private static readonly object lockCancelObj = new object();

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockCancelObj)
                {
                    if (selectedOrder == null)
                    {
                        "请至少选中一行数据！".ShowTips();
                        return;
                    }

                    if (selectedOrder.OrderStatus < (int)TransferOrderStatusEnum.Finished)
                    {
                        "未完成的移库单才能【取消】！".ShowTips();
                        return;
                    }

                    int unfinished = (int)TransferBarcodeStatusEnum.Unfinished;
                    var unfinishedBarcodes = WorkOrderBarcodes.Where(p => p.BarcodeStatus == unfinished).Select(p => p.Barcode).Distinct().ToList();
                    if (unfinishedBarcodes.Count > 0)
                    {
                        if ("存在未完成移库的upn，是否确认取消".ShowYesNoAndWarning() != DialogResult.Yes)
                        {
                            return;
                        }
                    }

                    int result = TransferBll.ModifyTransferOrderStatus(selectedOrder.BusinessId, (int)TransferOrderStatusEnum.Cancelled, AppInfo.LoginUserInfo.account);
                    TransferBll.ReleaseTransferOrderBarcodes(unfinishedBarcodes);
                    if (result == 0)
                    {
                        $"【{selectedOrder.TransferNo}】取消失败".ShowTips();
                    }
                    else
                    {
                        $"【{selectedOrder.TransferNo}】取消成功".ShowTips();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }
    }
}
