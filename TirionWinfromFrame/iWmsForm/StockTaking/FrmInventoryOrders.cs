﻿using Business;
using DevExpress.XtraSplashScreen;
using Entity;
using Entity.DataContext;
using Entity.Dto;
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
using TirionWinfromFrame.iWmsForm.StockTaking;

namespace iWms.Form
{
    public partial class FrmInventoryOrders : FrmBaseForm
    {
        public FrmInventoryOrders()
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

        private BindingList<InventoryOrderDto> WorkOrders = new BindingList<InventoryOrderDto>();

        private BindingList<InventoryBarcodeDto> WorkOrderBarcodes = new BindingList<InventoryBarcodeDto>();

        private void BindCombox()
        {
            var towerItems = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(InventoryOrderTypeEnum));
            cbType.DataSource = towerItems;
            cbType.DisplayMember = "Description";
            cbType.ValueMember = "Value";

            cbOrderStatus.DataSource = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(InventoryOrderStatusEnum));
            cbOrderStatus.DisplayMember = "Description";
            cbOrderStatus.ValueMember = "Value";
        }

        private void FrmOutstocks_Load(object sender, EventArgs e)
        {
            cbOrderStatus.SelectedIndex = 0;

            GetOrders();
        }

        private readonly object lockQueryObj = new object();

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
            InventoryQueryCondition condition = new InventoryQueryCondition
            {
                OrderNo = tbOrderNo.Text.Trim(),
                OrderStatus = Convert.ToInt32(cbOrderStatus.SelectedValue),
                InventoryType = Convert.ToInt32(cbType.SelectedValue)
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

            var orders = InventoryBll.GetInventoryOrders(condition);

            WorkOrders.Clear();
            WorkOrderBarcodes.Clear();
            foreach (var item in orders)
            {
                WorkOrders.Add(item.Adapt<InventoryOrderDto>());
            }
        }

        private InventoryOrderDto selectedOrder = null;

        private void DgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedCells.Count == 0)
                {
                    return;
                }
                var row = dgvOrders.SelectedCells[0].OwningRow;
                var order = row.DataBoundItem as InventoryOrderDto;
                selectedOrder = order;

                var barcodes = InventoryBll.GetInventoryBarcodes(order.BusinessId);

                WorkOrderBarcodes.Clear();
                foreach (Wms_InventoryBarcode item in barcodes)
                {
                    WorkOrderBarcodes.Add(item.Adapt<InventoryBarcodeDto>());
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private readonly object lockOutstockObj = new object();

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockOutstockObj)
                {
                    if (selectedOrder == null)
                    {
                        "请至少选中一个盘点单".ShowTips();
                        return;
                    }
                    var order = InventoryBll.GetInventoryOrderByNo(selectedOrder.InventoryNo);
                    if (order.OrderStatus > (int)TransferOrderStatusEnum.Executing)
                    {
                        "当前盘点单状态不可执行".ShowTips();
                        return;
                    }
                    if (order.OrderStatus == (int)TransferOrderStatusEnum.Saved)
                    {
                        new InventoryBll().DeliveryCalculatedBarcodes(selectedOrder.BusinessId, selectedOrder.InventoryNo, -1, -1, AppInfo.LoginUserInfo.account, (int)OperateTypeEnum.InstockTaking);

                        "盘点任务下达成功！".ShowTips();
                    }

                    FrmInventoryDetail detail = new FrmInventoryDetail(selectedOrder);
                    detail.ShowDialog();

                    GetOrders();
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
                    var order = InventoryBll.GetInventoryOrderByNo(selectedOrder.InventoryNo);
                    if (order.OrderStatus != (int)InventoryOrderStatusEnum.Executing)
                    {
                        "【执行中】状态的盘点单才能【完成】！".ShowTips();
                        return;
                    }

                    int finished = (int)InventoryBarcodeStatusEnum.Executed;
                    var barcodes = InventoryBll.GetInventoryBarcodes(order.BusinessId);
                    if (barcodes.Any(p => p.OrderStatus < finished))
                    {
                        if ("盘点单中存在未盘点的upn，是否结束盘点，未盘点的料盘将会取消盘点".ShowYesNoAndWarning() != DialogResult.Yes)
                        {
                            return;
                        };
                    }

                    bool result = new InventoryBll().FinishDeliveryOrder(selectedOrder.BusinessId, selectedOrder.InventoryNo, AppInfo.LoginUserInfo.account);
                    if (result)
                    {
                        $"【{selectedOrder.InventoryNo}】盘点完成".ShowTips();
                    }
                    else
                    {
                        $"【{selectedOrder.InventoryNo}】完成失败".ShowTips();
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

        private readonly object lockExportObj = new object();

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

            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx",
                FilterIndex = 0,
                OverwritePrompt = true,
                InitialDirectory = "D:\\",
                FileName = $"盘点单{selectedOrder.InventoryNo}-{DateTime.Now:yyyyMMddHHmmssfff}"
            };
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var data = WorkOrderBarcodes.Select(p => new
            {
                OrderNo = selectedOrder.InventoryNo,
                OrderTime = selectedOrder.CreateTime,
                FinishedTime = selectedOrder.LastUpdateTime,
                OrderStatus = selectedOrder.OrderStatusDisplay,
                Source = selectedOrder.InventoryAreaDisplay,
                Destination = selectedOrder.SubArea,
                p.MaterialNo,
                p.Barcode,
                p.OriginQuantity,
                p.RealQuantity
            }).ToList();

            List<HeadColumn> headColumns = new List<HeadColumn>
            {
                new HeadColumn("OrderNo","盘点单号", 4200),
                new HeadColumn("OrderTime","下达时间", 4000),
                new HeadColumn("FinishedTime","完成时间", 4000),
                new HeadColumn("OrderStatus","单据状态", 3000),
                new HeadColumn("Source","盘点库区", 2200),
                new HeadColumn("Destination","二级库区", 2200),
                new HeadColumn("MaterialNo","物料代码", 2200),
                new HeadColumn("Barcode","UPN", 7168),
                new HeadColumn("OriginQuantity","原始数量", 2200),
                new HeadColumn("RealQuantity","实际数量", 2200),
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
            cbType.SelectedIndex = 0;
            dtCreate.EditValue = null;
            dtFinish.EditValue = null;
            GetOrders();
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
                        "请至少选中一行数据！".ShowTips();
                        return;
                    }
                    var order = InventoryBll.GetInventoryOrderByNo(selectedOrder.InventoryNo);
                    if (order.OrderStatus > (int)InventoryOrderStatusEnum.Executing)
                    {
                        $"当前盘点单{EnumHelper.GetDescription(typeof(InventoryOrderStatusEnum), selectedOrder.OrderStatus)}，无法取消！".ShowTips();
                        return;
                    }

                    int unfinished = (int)InventoryBarcodeStatusEnum.Executed;
                    var barcodes = InventoryBll.GetInventoryBarcodes(order.BusinessId);
                    var unfinishedBarcodes = barcodes.Where(p => p.OrderStatus < unfinished).Select(p => p.Barcode).Distinct().ToList();
                    //if (unfinishedBarcodes.Count > 0)
                    //{
                    //    if ("存在未完成盘点的upn，是否确认取消".ShowYesNoAndTips() != DialogResult.Yes)
                    //    {
                    //        return;
                    //    }
                    //}

                    int result = InventoryBll.ModifyInventoryOrderStatus(selectedOrder.BusinessId, (int)TransferOrderStatusEnum.Cancelled, AppInfo.LoginUserInfo.account);
                    result += InventoryBll.ReleaseInventoryOrderBarcodes(selectedOrder.BusinessId, unfinishedBarcodes, AppInfo.LoginUserInfo.account);
                    new InventoryBll().ResetDeliveryOrder(selectedOrder.BusinessId, selectedOrder.InventoryNo, AppInfo.LoginUserInfo.account);
                    if (result == 0)
                    {
                        $"【{selectedOrder.InventoryNo}】取消失败".ShowTips();
                    }
                    else
                    {
                        $"【{selectedOrder.InventoryNo}】取消成功".ShowTips();
                    }
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
            var row = dgvUpns.Rows[e.RowIndex];
            var barcode = row.DataBoundItem as InventoryBarcodeDto;
            if (barcode.InventoryResult == "多料" || barcode.InventoryResult == "盘盈")
            {
                row.Cells["colResult"].Style.BackColor = Color.CornflowerBlue;
            }
            else if (barcode.InventoryResult == "缺料" || barcode.InventoryResult == "盘亏")
            {
                row.Cells["colResult"].Style.BackColor = Color.OrangeRed;
            }
            else if (barcode.InventoryResult == "正常")
            {
                row.Cells["colResult"].Style.BackColor = Color.LimeGreen;
            }
            else
            {
                //do nothing
            }
            ShowRowIndex(dgvUpns, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockCancelObj)
                {
                    if (selectedOrder == null)
                    {
                        "请选中一行数据".ShowTips();
                        return;
                    }

                    if (selectedOrder.OrderStatus < (int)InventoryOrderStatusEnum.Executing)
                    {
                        "盘点单未执行，无法进行料架复位，请先完成发料".ShowTips();
                        return;
                    }

                    new InventoryBll().ResetDeliveryOrder(selectedOrder.BusinessId, selectedOrder.InventoryNo, AppInfo.LoginUserInfo.account);
                    //额外做一次取消报警
                    string url = ConfigurationManager.AppSettings["lightShelfCancelAlarmUrl"];
                    if (string.IsNullOrWhiteSpace(url))
                    {
                        throw new OppoCoreException("缺少亮灯货架的取消报警服务地址配置");
                    }
                    foreach (string shelfNo in ShelfNos)
                    {
                        CancelAlarm(selectedOrder.InventoryNo, url, shelfNo);
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

        private void BtnProfit_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockFinishObj)
                {
                    FrmProfit profit = new FrmProfit();
                    profit.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void BtnLoss_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockFinishObj)
                {
                    FrmLoss loss = new FrmLoss();
                    loss.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }
    }
}
