using Business;
using DevExpress.XtraSplashScreen;
using Entity;
using Entity.DataContext;
using Entity.Dto;
using Entity.Dto.Balance;
using Entity.Enums;
using Entity.Enums.General;
using Entity.Enums.Inventory;
using Entity.Enums.Transfer;
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
using System.Threading.Tasks;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;
using TirionWinfromFrame.iWmsForm.Report;
using TirionWinfromFrame.iWmsForm.StockTaking;

namespace iWms.Form
{
    public partial class FrmBalanceOrders : FrmBaseForm
    {
        public FrmBalanceOrders()
        {
            InitializeComponent();
            BindCombox();

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

        private BindingList<BalanceOrderDto> WorkOrders = new BindingList<BalanceOrderDto>();

        private BindingList<BalanceBarcodeDto> WorkOrderBarcodes = new BindingList<BalanceBarcodeDto>();

        private void BindCombox()
        {
            cbOrderStatus.DataSource = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(BalanceOrderStatusEnum));
            cbOrderStatus.DisplayMember = "Description";
            cbOrderStatus.ValueMember = "Value";
        }

        private void FrmOutstocks_Load(object sender, EventArgs e)
        {
            cbOrderStatus.SelectedIndex = 0;

            GetOrders();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockButtonObj)
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
            BalanceQueryCondition condition = new BalanceQueryCondition
            {
                OrderNo = tbOrderNo.Text.Trim(),
                OrderStatus = Convert.ToInt32(cbOrderStatus.SelectedValue),
            };

            condition.MaterialNo = tbMaterialNo.Text.Trim();
            condition.Upn = tbUpn.Text.Trim();

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

            var orders = BalanceBusiness.GetBalanceOrders(condition);

            WorkOrders.Clear();
            WorkOrderBarcodes.Clear();
            foreach (var item in orders)
            {
                WorkOrders.Add(item.Adapt<BalanceOrderDto>());
            }
        }

        private BalanceOrderDto selectedOrder = null;

        private void DgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedCells.Count == 0)
                {
                    return;
                }
                var row = dgvOrders.SelectedCells[0].OwningRow;
                var order = row.DataBoundItem as BalanceOrderDto;
                selectedOrder = order;

                var barcodes = BalanceBusiness.GetBalanceBarcodes(order.BusinessId);

                WorkOrderBarcodes.Clear();
                foreach (Wms_BalanceBarcode item in barcodes)
                {
                    WorkOrderBarcodes.Add(item.Adapt<BalanceBarcodeDto>());
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockButtonObj)
                {
                    if (selectedOrder == null)
                    {
                        "请至少选中一个单".ShowTips();
                        return;
                    }
                    var order = BalanceBusiness.GetBalanceOrderByNo(selectedOrder.BalanceNo);
                    if (order.OrderStatus > (int)BalanceOrderStatusEnum.Executing)
                    {
                        "当前清账单状态不可执行".ShowTips();
                        return;
                    }

                    FrmBalanceDetail detail = new FrmBalanceDetail(selectedOrder);
                    detail.ShowDialog();

                    GetOrders();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private readonly object lockButtonObj = new object();

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockButtonObj)
                {
                    if (selectedOrder == null)
                    {
                        "请至少选中一行数据！".ShowTips();
                        return;
                    }
                    var order = BalanceBusiness.GetBalanceOrderByNo(selectedOrder.BalanceNo);
                    if (order.OrderStatus != (int)BalanceOrderStatusEnum.Executing)
                    {
                        "【执行中】状态的清账单才能【完成】！".ShowTips();
                        return;
                    }

                    order.OrderStatus = (int)BalanceOrderStatusEnum.Finished;
                    bool result = BalanceBusiness.UpdateBalanceOrderStatus(order.BusinessId, order.OrderStatus, AppInfo.LoginUserInfo.account);
                    if (result)
                    {
                        $"【{selectedOrder.BalanceNo}】清账完成".ShowTips();
                    }
                    else
                    {
                        $"【{selectedOrder.BalanceNo}】完成失败".ShowTips();
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

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockButtonObj)
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

            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Excel Office2007及以上(*.xlsx)|*.xlsx",
                FilterIndex = 0,
                OverwritePrompt = true,
                InitialDirectory = "D:\\",
                FileName = $"清账单{selectedOrder.BalanceNo}-{DateTime.Now:yyyyMMddHHmmssfff}"
            };
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var data = WorkOrderBarcodes.Select(p => new
            {
                OrderNo = selectedOrder.BalanceNo,
                OrderTime = selectedOrder.CreateTime,
                FinishedTime = selectedOrder.LastUpdateTime,
                OrderStatus = selectedOrder.OrderStatusDisplay,
                MaterialNo = p.Barcode.Split('-')[0],
                p.Barcode,
                p.Quantity
            }).ToList();

            List<HeadColumn> headColumns = new List<HeadColumn>
            {
                new HeadColumn("OrderNo","清账单号", 4200),
                new HeadColumn("OrderTime","下达时间", 4000),
                new HeadColumn("FinishedTime","完成时间", 4000),
                new HeadColumn("OrderStatus","单据状态", 3000),
                new HeadColumn("MaterialNo","物料代码", 2200),
                new HeadColumn("Barcode","UPN", 7168),
                new HeadColumn("Quantity","原始数量", 2200),
            };
            string fileFullName = NpoiHelper.ExportToExcel(dialog.FileName, data, headColumns);
            if (!string.IsNullOrWhiteSpace(fileFullName))
            {
                System.Diagnostics.Process.Start("explorer", "/select," + fileFullName);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            cbOrderStatus.SelectedIndex = 0;
            tbOrderNo.Text = string.Empty;
            tbUpn.Text = string.Empty;
            tbMaterialNo.Text = string.Empty;
            dtCreate.EditValue = null;
            dtFinish.EditValue = null;
            GetOrders();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockButtonObj)
                {
                    if (selectedOrder == null)
                    {
                        "请至少选中一行数据！".ShowTips();
                        return;
                    }
                    var order = BalanceBusiness.GetBalanceOrderByNo(selectedOrder.BalanceNo);
                    if (order.OrderStatus > (int)BalanceOrderStatusEnum.Executing)
                    {
                        $"当前清账单{EnumHelper.GetDescription(typeof(BalanceOrderStatusEnum), order.OrderStatus)}，无法取消！".ShowTips();
                        return;
                    }

                    bool result = BalanceBusiness.UpdateBalanceOrderStatus(order.BusinessId, (int)BalanceOrderStatusEnum.Closed, AppInfo.LoginUserInfo.account);
                    if (result)
                    {
                        $"【{selectedOrder.BalanceNo}】取消成功".ShowTips();
                    }
                    else
                    {
                        $"【{selectedOrder.BalanceNo}】取消失败".ShowTips();
                    }
                    GetOrders();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void dgvOrders_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ShowRowIndex(dgvOrders, e);
        }

        private void dgvUpns_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ShowRowIndex(dgvUpns, e);
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockButtonObj)
                {
                    int finishStatus = (int)BalanceOrderStatusEnum.Finished;
                    var order = WorkOrders.FirstOrDefault(p => p.OrderStatus < finishStatus && p.CreateTime.Date == DateTime.Today);
                    if (order != null)
                    {
                        if ($"今天存在未完成的清账单{order.BalanceNo}，将打开此单据执行页面".ShowTips() == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else
                    {
                        order = new BalanceOrderDto()
                        {
                            BalanceNo = $"BN{DateTime.Now:yyyyMMdd}{DateTime.Now:fff}",
                            BusinessId = Guid.NewGuid().ToString("D"),
                            CreateTime = DateTime.Now,
                            CreateUser = AppInfo.LoginUserInfo.account,
                            LastUpdateTime = DateTime.Now,
                            LastUpdateUser = AppInfo.LoginUserInfo.account,
                            OrderStatus = (int)BalanceOrderStatusEnum.Executing,
                        };
                        BalanceBusiness.InsertOrder(order);
                    }

                    FrmBalanceDetail detail = new FrmBalanceDetail(order);
                    detail.ShowDialog();

                    GetOrders();
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

        private void BtnReport_Click(object sender, EventArgs e)
        {
            lock (lockButtonObj)
            {
                if (dtCreate.EditValue == null)
                {
                    $"请选择要生成对账报表的日期".ShowTips();
                    dtCreate.Focus();
                    return;
                }

                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Excel Office2007及以上(*.xlsx)|*.xlsx",
                    FilterIndex = 0,
                    OverwritePrompt = true,
                    InitialDirectory = "D:\\",
                    FileName = $"对账单-{dtCreate.DateTime:yyyyMMdd}"
                };

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                SplashScreenManager.ShowForm(typeof(WaitForm1));
                try
                {
                    DateTime currentDate = dtCreate.DateTime.Date;
                    var currentBalance = BalanceBusiness.GetLastBalanceByCertainDate(currentDate);
                    var lastBalance = BalanceBusiness.GetLasBalanceBeforeCertainDate(currentDate);
                    if (lastBalance == null)
                    {
                        $"没有{currentDate}之前的清账记录，无以生成对账单，请先保持清账记录之后再对账".ShowTips();
                        return;
                    }

                    var lastMaterials = BalanceBusiness.GetBalanceMaterials(lastBalance.BusinessId);
                    var currentMaterials = new List<BalanceMaterialDto>();
                    if (currentBalance != null)
                    {
                        currentMaterials.AddRange(BalanceBusiness.GetBalanceMaterials(currentBalance.BusinessId));
                    }

                    var data = BuildReportData(currentBalance, lastBalance, currentMaterials, lastMaterials);

                    List<HeadColumn> headColumns = new List<HeadColumn>
                        {
                            new HeadColumn("LastDate","日期", 4200),
                            new HeadColumn("MaterialNo","物料代码", 3000),
                            new HeadColumn("MaterialName","物料名称", 4000),
                            new HeadColumn("LastQuantity","昨日结存", 2200),
                            new HeadColumn("ManualInQuantity","手工点料", 2200),
                            new HeadColumn("AllocateInQuantity","调拨入库", 2200),
                            new HeadColumn("SelfMadeInQuantity","自制收货", 2200),
                            new HeadColumn("OtherInQuantity","杂项入库", 2200),
                            new HeadColumn("RefundInQuantity","生产退料", 2200),
                            new HeadColumn("ProfitInQuantity","盘盈", 2200),
                            new HeadColumn("JldOutQuantity","拣料单出库", 2200),
                            new HeadColumn("AllocateOutQuantity","调拨出库", 2200),
                            new HeadColumn("OtherOutQuantity","杂项出库", 2200),
                            new HeadColumn("ProduceOutQuantity","生产领料", 2200),
                            new HeadColumn("FlOutQuantity","辅料出库", 2200),
                            new HeadColumn("LossOutQuantity","盘亏", 2200),
                            new HeadColumn("CurrentBalance","当日结存", 2200),
                            new HeadColumn("TodayBalance","今日实盘", 2200),
                            new HeadColumn("Balance","对账差异", 2200),
                            new HeadColumn("Remark","备注", 2200),
                        };
                    string fileFullName = NpoiHelper.ExportToExcel(dialog.FileName, data, headColumns);
                    if (!string.IsNullOrWhiteSpace(fileFullName))
                    {
                        System.Diagnostics.Process.Start("explorer", "/select," + fileFullName);
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
        }

        private IEnumerable<BalanceReportDto> BuildReportData(Wms_BalanceOrder currentBalance, Wms_BalanceOrder lastBalance, IEnumerable<BalanceMaterialDto> currentMaterials, IEnumerable<BalanceMaterialDto> lastMaterials)
        {
            string remark = string.Empty;
            if (currentBalance == null)
            {
                remark = "今日未清账";
            }
            DateTime startTime = lastBalance.LastUpdateTime;
            DateTime endTime = DateTime.Now;
            if (currentBalance != null)
            {
                endTime = currentBalance.LastUpdateTime;
            }

            var instockMaterials = BalanceBusiness.GetBalanceInstockMaterials(startTime, endTime);
            var outstockMaterials = BalanceBusiness.GetBalanceOutstockMaterials(startTime, endTime);

            foreach (BalanceMaterialDto item in lastMaterials)
            {
                var report = new BalanceReportDto() { LastDate = lastBalance.CreateTime.Date, MaterialNo = item.MaterialNo, LastQuantity = item.TotalQuantity };
                var currentMaterial = currentMaterials.FirstOrDefault(p => p.MaterialNo == item.MaterialNo);
                if (currentMaterial != null)
                {
                    report.TodayBalance = currentMaterial.TotalQuantity;
                }
                report.ManualInQuantity = GetMaterialQuantity(instockMaterials, item.MaterialNo, (int)InOrderTypeEnum.ManualCount);
                report.AllocateInQuantity = GetMaterialQuantity(instockMaterials, item.MaterialNo, (int)InOrderTypeEnum.DBRK);
                report.SelfMadeInQuantity = GetMaterialQuantity(instockMaterials, item.MaterialNo, (int)InOrderTypeEnum.CPGD);
                report.OtherInQuantity = GetMaterialQuantity(instockMaterials, item.MaterialNo, (int)InOrderTypeEnum.ZX);
                report.RefundInQuantity = GetMaterialQuantity(instockMaterials, item.MaterialNo, (int)InOrderTypeEnum.SCTL);
                report.JldOutQuantity = GetMaterialQuantity(outstockMaterials, item.MaterialNo, (int)OutOrderTypeEnum.JLDCK);
                report.AllocateOutQuantity = GetMaterialQuantity(outstockMaterials, item.MaterialNo, (int)OutOrderTypeEnum.DBCK);
                report.OtherOutQuantity = GetMaterialQuantity(outstockMaterials, item.MaterialNo, (int)OutOrderTypeEnum.ZF);
                report.ProduceOutQuantity = GetMaterialQuantity(outstockMaterials, item.MaterialNo, (int)OutOrderTypeEnum.SCLL);
                report.FlOutQuantity = GetMaterialQuantity(outstockMaterials, item.MaterialNo, (int)OutOrderTypeEnum.FLCK);
                report.Remark = remark;

                yield return report;
            }

            foreach (BalanceMaterialDto item in currentMaterials)
            {
                var report = new BalanceReportDto() { LastDate = lastBalance.CreateTime.Date, MaterialNo = item.MaterialNo, LastQuantity = 0 };
                var lastMaterial = lastMaterials.FirstOrDefault(p => p.MaterialNo == item.MaterialNo);
                if (lastMaterial != null)
                {
                    continue;
                }
                report.ManualInQuantity = GetMaterialQuantity(instockMaterials, item.MaterialNo, (int)InOrderTypeEnum.ManualCount);
                report.AllocateInQuantity = GetMaterialQuantity(instockMaterials, item.MaterialNo, (int)InOrderTypeEnum.DBRK);
                report.SelfMadeInQuantity = GetMaterialQuantity(instockMaterials, item.MaterialNo, (int)InOrderTypeEnum.CPGD);
                report.OtherInQuantity = GetMaterialQuantity(instockMaterials, item.MaterialNo, (int)InOrderTypeEnum.ZX);
                report.RefundInQuantity = GetMaterialQuantity(instockMaterials, item.MaterialNo, (int)InOrderTypeEnum.SCTL);
                report.JldOutQuantity = GetMaterialQuantity(outstockMaterials, item.MaterialNo, (int)OutOrderTypeEnum.JLDCK);
                report.AllocateOutQuantity = GetMaterialQuantity(outstockMaterials, item.MaterialNo, (int)OutOrderTypeEnum.DBCK);
                report.OtherOutQuantity = GetMaterialQuantity(outstockMaterials, item.MaterialNo, (int)OutOrderTypeEnum.ZF);
                report.ProduceOutQuantity = GetMaterialQuantity(outstockMaterials, item.MaterialNo, (int)OutOrderTypeEnum.SCLL);
                report.FlOutQuantity = GetMaterialQuantity(outstockMaterials, item.MaterialNo, (int)OutOrderTypeEnum.FLCK);
                report.Remark = remark;

                yield return report;
            }
        }

        private int GetMaterialQuantity(IEnumerable<BalanceOrderMaterialDto> materials, string materialNo, int orderType)
        {
            var material = materials.FirstOrDefault(p => p.MaterialNo == materialNo && p.OrderType == orderType);
            if (material == null)
            {
                return 0;
            }
            return material.TotalQuantity;
        }
    }
}
