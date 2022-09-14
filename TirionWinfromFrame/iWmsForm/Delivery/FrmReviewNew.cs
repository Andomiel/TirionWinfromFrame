﻿using Business;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Entity;
using Entity.DataContext;
using Entity.Dto.Delivery;
using Entity.Enums;
using Entity.Facade;
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
    public partial class FrmReviewNew : XtraForm
    {

        public FrmReviewNew(DeliveryOrderDto deliveryOrder)
        {
            InitializeComponent();
            SelectedOrder = deliveryOrder;

            lblOrderType.Text = SelectedOrder.DeliveryTypeDisplay;
            lblOrderNo.Text = SelectedOrder.DeliveryNo;
            lblDestination.Text = SelectedOrder.LineId;

            gridViewRecord.AutoGenerateColumns = false;
            gridViewRecord.DataSource = ReviewRecords;

            gridViewSummary.AutoGenerateColumns = false;
            gridViewSummary.MergeColumnNames.AddRange(new List<string> { "LineNumber", "PartNumber", "NeedQty" });
            gridViewSummary.MergeFocusNames.AddRange(new List<string> { "LineNumber" });
            gridViewSummary.DataSource = ReviewSummaries;
        }

        private readonly DeliveryOrderDto SelectedOrder;

        private readonly BindingList<ReviewRecord> ReviewRecords = new BindingList<ReviewRecord>();

        private readonly BindingList<ReviewSummary> ReviewSummaries = new BindingList<ReviewSummary>();

        private void ShowBoxScan()
        {
            cbBoxScan.Visible = true;
            cbBoxScan.Checked = true;
            txtBoxScan.Visible = true;
            txtBoxScan.Enabled = true;

            cbOriginal.Visible = true;
            cbOriginal.Checked = true;
            tbOriginal.Visible = true;
            tbOriginal.Enabled = true;
        }

        private void HideBoxScan()
        {
            cbBoxScan.Visible = false;
            txtBoxScan.Text = string.Empty;
            txtBoxScan.Visible = false;
            txtBoxScan.Enabled = false;

            cbOriginal.Visible = false;
            tbOriginal.Text = string.Empty;
            tbOriginal.Visible = false;
            tbOriginal.Enabled = false;
        }

        private void txtBoxScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string boxNo = txtBoxScan.Text;
                if (string.IsNullOrWhiteSpace(boxNo))
                {
                    return;
                }
                if (boxNo.Contains('*') || boxNo.Contains('-') || boxNo.Contains('/'))
                {
                    txtBoxScan.Text = string.Empty;
                    return;
                }
                tbScan.Focus();
            }
        }

        private void tbScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    string scanText = tbScan.Text;
                    //int starCount = scanText.ToCharArray().Count(p => p.Equals('*'));
                    //if (starCount < 6 || starCount > 9)
                    //{
                    //    tbScan.Text = string.Empty;
                    //    return;
                    //}
                    tbScan.Text = BarcodeFormatter.FormatBarcode(scanText);
                    if (cbOriginal.Visible && cbOriginal.Checked)
                    {
                        tbOriginal.Focus();
                    }
                    else
                    {
                        ScanOperate();
                        PlayResultWaves(true);
                    }
                }
            }
            catch (Exception ex)
            {
                tbScan.Text = string.Empty;
                PlayResultWaves(false);
                ex.GetDeepException().ShowError();
            }
        }

        private void PlayResultWaves(bool isSuccess)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            string wave = "Error.wav";
            if (isSuccess)
            {
                wave = "Success.wav";
            }
            player.SoundLocation = $"{Application.StartupPath}\\Waves\\{wave}";
            player.Load();//同步播放，可使用异步
            player.Play();
        }

        private void tbOriginal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (cbOriginal.Checked && string.IsNullOrWhiteSpace(tbOriginal.Text.Trim()))
                    {
                        "已选择原厂条码，必须录入原厂条码".ShowTips();
                        return;
                    }
                    ScanOperate();
                    PlayResultWaves(true);
                }
            }
            catch (Exception ex)
            {
                PlayResultWaves(false);
                ex.GetDeepException().ShowError();
            }
        }

        private void ScanOperate()
        {
            CollapseWarning();

            string scanText = tbScan.Text;
            int starCount = scanText.ToCharArray().Count(p => p.Equals('*'));
            if (starCount < 6 || starCount > 9)
            {
                "请扫描二维码".ShowTips();
                return;
            }

            int scanIndex = scanText.IndexOf('*');

            string upn = scanText.Substring(0, scanIndex);
            if (string.IsNullOrWhiteSpace(upn))
            {
                return;
            }
            tbScan.SelectAll();

            ReviewRecord reviewRecord = null;
            if (ReviewRecords != null)
            {
                //重复扫码验证
                reviewRecord = ReviewRecords.FirstOrDefault(p => p.UPN.Equals(upn));

                if (reviewRecord != null)
                {
                    //匹配到了扫码记录，需要重新查询，更新状态
                    if (reviewRecord.Status.Equals("正常出库"))
                    {
                        ShowWarning(upn, 3);
                        ResetBarcodeText();
                        PlayResultWaves(false);
                        return;
                    }
                    reviewRecord = OutStockReview.GetUpnInfoInZd(upn);
                    reviewRecord.ScanTime = DateTime.Now;

                    AddBindRecord(reviewRecord);
                }
            }

            if (reviewRecord == null)
            {
                reviewRecord = OutStockReview.GetUpnInfoInZd(upn);
                reviewRecord.BoxNo = txtBoxScan.Text;
                reviewRecord.OriginalCode = tbOriginal.Text;
                if (!reviewRecord.IsOk)
                {
                    AddBindRecord(reviewRecord);
                    ResetBarcodeText();
                    PlayResultWaves(false);
                    return;
                }
            }

            List<OrderNeedMaterial> needMaterials = OutStockReview.GetMaterialsByOutOrderNo(SelectedOrder.DeliveryNo);
            List<OrderNeedMaterial> needAndThisPn = needMaterials.Where(p => p.PartNumber == reviewRecord.Part_Number).ToList();
            var needMaterial = needAndThisPn.FirstOrDefault();
            if (needMaterial == null)
            {
                reviewRecord.Status = "无此料号";
                AddBindRecord(reviewRecord);
                ShowWarning(reviewRecord.UPN, 1);
                ResetBarcodeText();
                PlayResultWaves(false);
                return;
            }

            //备料和扫码的比较 及 构建数据
            var allSamePnList = ReviewSummaries.Where(p => p.PartNumber.Equals(reviewRecord.Part_Number)).ToList();
            string lineNumber = string.Empty;
            string slotNo = string.Empty;
            if (needAndThisPn.Count > 0)
            {
                foreach (var pnByLineNumber in needAndThisPn)
                {
                    int nowSum = allSamePnList.Where(p => p.LineNumber == pnByLineNumber.LineNumber
                                                       && p.Match == (int)PrepareReviewMatchEnum.Done)
                                              .Sum(p => p.RealQty);
                    bool exceeded = nowSum >= pnByLineNumber.NeedQty;
                    if (!exceeded)
                    {
                        lineNumber = pnByLineNumber.LineNumber;
                        slotNo = pnByLineNumber.SlotNo;
                        break;
                    }
                }
                if (string.IsNullOrWhiteSpace(lineNumber))
                {
                    reviewRecord.Status = "已超发过最小包装数";
                    AddBindRecord(reviewRecord);
                    ShowWarning(reviewRecord.UPN, 2);
                    ResetBarcodeText();
                    PlayResultWaves(false);
                    return;
                }
            }

            //调用若干MES和WMS接口
            CheckResultResponse checkResult = CheckByApi(reviewRecord.Qty);
            if (!checkResult.Result)
            {
                reviewRecord.Status = checkResult.ErrMessage;
                reviewRecord.ScanTime = DateTime.Now;
                AddBindRecord(reviewRecord);
                ShowWarning(reviewRecord.UPN, 4, checkResult.ErrMessage);
                ResetBarcodeText();
                PlayResultWaves(false);
                return;
            }

            ReviewSummary matchRow = ReviewSummaries.FirstOrDefault(p => p.UPN.Equals(upn));
            if (matchRow != null)
            {
                matchRow.Match = (int)PrepareReviewMatchEnum.Done;
                matchRow.RealQty = reviewRecord.Qty;
                matchRow.ContainerNo = txtBoxScan.Text;
            }
            else
            {
                if (reviewRecord.IsTakeCheck)
                {
                    AddBindRecord(reviewRecord);
                    ResetBarcodeText();
                    PlayResultWaves(false);
                    return;
                }

                ReviewSummary newReview = new ReviewSummary
                {
                    UPN = reviewRecord.UPN,
                    TowerNo = reviewRecord.LockTowerNo,
                    AllocateQty = reviewRecord.Qty,
                    RealQty = reviewRecord.Qty,
                    Match = (int)PrepareReviewMatchEnum.Done,
                    Source = (int)PrepareSourceEnum.ReviewNew,
                    ContainerNo = txtBoxScan.Text,
                    QRCode = reviewRecord.QRCode
                };

                if (allSamePnList?.Count > 0)
                {
                    newReview.OrderNo = allSamePnList[0].OrderNo;
                    newReview.PartNumber = allSamePnList[0].PartNumber;
                    newReview.NeedQty = allSamePnList[0].NeedQty;
                    newReview.LineNumber = lineNumber;
                    newReview.SlotNo = slotNo;
                }
                else
                {
                    newReview.OrderNo = needMaterial.OrderNo;
                    newReview.PartNumber = needMaterial.PartNumber;
                    newReview.NeedQty = needMaterial.NeedQty;
                    newReview.LineNumber = needMaterial.LineNumber;
                    newReview.SlotNo = needMaterial.SlotNo;
                }
                var removeItems = ReviewSummaries.Where(p => p.PartNumber == newReview.PartNumber && p.LineNumber == newReview.LineNumber && string.IsNullOrWhiteSpace(p.UPN)).ToList();
                foreach (var item in removeItems)
                {
                    ReviewSummaries.Remove(item);
                }
                ReviewSummaries.Add(newReview);
            }
            AddBindRecord(reviewRecord);
            ResetBarcodeText();
        }


        private void ResetBarcodeText()
        {
            tbScan.Text = string.Empty;
            tbOriginal.Text = string.Empty;
            tbScan.Focus();
        }

        private CheckResultResponse CheckByApi(int quantity)
        {
            string orderNo = SelectedOrder.DeliveryNo;
            int orderType = SelectedOrder.DeliveryType;
            FileLog.Log($"CheckByApi[{orderType}]");
            string upn = tbScan.Text.Split('*')[0];

            CheckResultResponse result = new CheckResultResponse();
            if (orderType != (int)OutOrderTypeEnum.FLCK)
            {
                //UPN同步接口
                result = OrderReviewCallApi.CheckFromMaterialInfo(tbScan.Text);
            }
            else
            {
                //MES校验接口
                result = OrderReviewCallApi.CheckFromMesCheckUpn(tbScan.Text, orderNo);
            }

            if (!result.Result)
            {
                return result;
            }

            if (orderType == (int)OutOrderTypeEnum.JLDCK || orderType == (int)OutOrderTypeEnum.SCLL)
            {
                //MSD过期校验
                result = OrderReviewCallApi.CheckFromMSDExpired(upn);
            }
            if (!result.Result)
            {
                return result;
            }

            if (orderType == (int)OutOrderTypeEnum.DBCK || orderType == (int)OutOrderTypeEnum.ZF)
            {
                //总装MES物料退料接口
                result = OrderReviewCallApi.CheckFromMesMaterialBack(upn, quantity);
            }

            if (!result.Result)
            {
                return result;
            }

            if (orderType == (int)OutOrderTypeEnum.JLDCK || orderType == (int)OutOrderTypeEnum.DBCK)
            {
                //验证物料是否散料测试
                if (orderType == (int)OutOrderTypeEnum.JLDCK && upn.StartsWith("96"))
                {
                    FileLog.Log($"当前UPN{{{upn}}}为96开头的物料，不做散料测试");
                }
                else
                {
                    result = OrderReviewCallApi.CheckMatStatusAccordingUpn(upn);
                }
            }

            if (!result.Result)
            {
                return result;
            }
            if (orderType == (int)OutOrderTypeEnum.DBCK && cbOriginal.Checked)
            {
                //总装MES-IQC比对接口
                result = OrderReviewCallApi.CheckFromMesIqcCompare(upn, tbOriginal.Text);
            }
            if (!result.Result)
            {
                return result;
            }
            return result;
        }

        private void AddBindRecord(ReviewRecord record)
        {
            var recordHave = ReviewRecords.FirstOrDefault(p => p.UPN == record.UPN);
            if (recordHave != null)
            {
                ReviewRecords.Remove(recordHave);
            }

            ReviewRecords.Insert(0, record);
        }

        private void SetTypeLable(string des)
        {
            if (!string.IsNullOrWhiteSpace(des))
            {
                lblDestination.Text = $"目的地：{des}";
            }
        }

        private void InitOrderControl()
        {
            tbOriginal.Text = string.Empty;
            tbScan.Text = string.Empty;
            txtBoxScan.Text = string.Empty;

            if (SelectedOrder.DeliveryType == (int)OutOrderTypeEnum.DBCK)
            {
                ShowBoxScan();
            }
            else
            {
                HideBoxScan();
            }

            if (SelectedOrder == null)
            {
                throw new OppoCoreException("当前选中的出库单信息为空");
            }

            var details = DeliveryBll.GetDeliveryDetails(SelectedOrder.BusinessId);
            var barcodes = DeliveryBll.GetDeliveryBarcodes(SelectedOrder.BusinessId);
            foreach (Wms_DeliveryDetail item in details)
            {
                var detailBarcodes = barcodes.Where(p => p.DeliveryDetailId == item.BusinessId && p.OrderStatus > (int)DeliveryBarcodeStatusEnum.Undeliver).ToList();
                if (detailBarcodes == null || detailBarcodes.Count == 0)
                {
                    var summary = new ReviewSummary()
                    {
                        AllocateQty = 0,
                        NeedQty = item.RequireCount,
                        ContainerNo = string.Empty,
                        LineNumber = item.RowNum.ToString(),
                        Match = 0,
                        OrderNo = SelectedOrder.DeliveryNo,
                        PartNumber = item.MaterialNo,
                        QRCode = string.Empty,
                        RealQty = 0,
                        SlotNo = item.SlotNo,
                        Source = 0,
                        TowerNo = -1,
                        UPN = string.Empty
                    };
                    ReviewSummaries.Add(summary);
                }
                else
                {
                    foreach (var barcode in detailBarcodes)
                    {
                        ReviewSummary newReview = new ReviewSummary
                        {
                            UPN = barcode.Barcode,
                            TowerNo = barcode.DeliveryAreaId,
                            AllocateQty = barcode.DeliveryQuantity,
                            RealQty = barcode.DeliveryQuantity,
                            ContainerNo = txtBoxScan.Text,
                            QRCode = string.Empty,
                        };
                        newReview.OrderNo = SelectedOrder.DeliveryNo;
                        newReview.PartNumber = item.MaterialNo;
                        newReview.NeedQty = item.RequireCount;
                        newReview.LineNumber = item.RowNum.ToString();
                        newReview.SlotNo = item.SlotNo;
                        if (barcode.OrderStatus == (int)DeliveryBarcodeStatusEnum.Delivered)
                        {
                            newReview.Match = (int)PrepareReviewMatchEnum.Not;
                            newReview.Source = (int)PrepareSourceEnum.Recommend;
                        }
                        else
                        {
                            //已复核
                            newReview.Match = (int)PrepareReviewMatchEnum.Done;
                            newReview.Source = (int)PrepareSourceEnum.Recommend;//TODO:这里怎么判定它的来源呢
                        }
                        ReviewSummaries.Add(newReview);
                    }
                }
            }

            SetTypeLable(SelectedOrder.LineId);
            btnComplete.Enabled = true;
            btnExport.Enabled = true;
            tbScan.Enabled = true;
            if (cbBoxScan.Visible && cbBoxScan.Checked)
            {
                txtBoxScan.Focus();
            }
            else
            {
                tbScan.Focus();
            }
        }

        private readonly object lockFinishObj = new object();

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockFinishObj)
                {
                    if ("确认提交本次复核结果？".ShowYesNoAndTips() == DialogResult.Cancel)
                    {
                        return;
                    }

                    if (ReviewSummaries == null || ReviewSummaries.Count == 0 || !ReviewSummaries.Any(p => p.Match == 1))
                    {
                        "本工单还没有复核，校验执行发料的数据为空！".ShowTips();
                        return;
                    }

                    var remainMaterials = ReviewSummaries.Where(p => p.Match == 1 || (p.Match == 0 && string.IsNullOrWhiteSpace(p.UPN)))
                        .GroupBy(p => new { p.PartNumber, p.LineNumber, p.NeedQty })
                        .Where(p => p.Key.NeedQty > p.Sum(c => c.RealQty))
                        .Select(p => p.Key.PartNumber).Distinct().ToList();
                    if (remainMaterials.Count > 0)
                    {
                        if ($"本工单仍然有以下物料:{string.Join(",", remainMaterials)}处于短拣状态，是否继续！".ShowYesNoAndTips() != DialogResult.Yes)
                        {
                            return;
                        }
                    }

                    var remainBarcodes = ReviewSummaries.Where(p => p.Match == 0 && !string.IsNullOrWhiteSpace(p.UPN)).Select(p => p.UPN).Distinct().ToList();
                    if (remainBarcodes.Count > 0)
                    {
                        if ($"本工单还有{remainBarcodes.Count}条已出库UPN未复核，这些UPN将会被转移到理料区！".ShowYesNoAndTips() != DialogResult.OK)
                        {
                            return;
                        }
                    }

                    bool canOperate = true;
                    if (SelectedOrder.DeliveryType == (int)OutOrderTypeEnum.FLCK)
                    {
                        //辅料出库，MES接口校验执行发料（单号+所有UPN）
                        var mesCheckList = ReviewSummaries.Where(p => p.Match == 1).ToList();

                        CheckResultResponse result = OrderReviewCallApi.CheckFromMesExecuteDispatch(mesCheckList, AppInfo.LoginUserInfo.account, AppInfo.LoginUserInfo.account);
                        canOperate = result.Result;
                    }

                    if (canOperate)
                    {
                        string orderNo = SelectedOrder.DeliveryNo;
                        var finishedList = ReviewSummaries.Where(p => !string.IsNullOrWhiteSpace(p.UPN)).ToList();
                        if (OutStockReview.FinishDeliveyOrderReview(orderNo, AppInfo.LoginUserInfo.account, finishedList) <= 0)
                        {
                            "更新数据异常，请重新提交".ShowTips();
                        }
                        else
                        {
                            "复核完成，即将进行单据回传".ShowTips();
                            //出库完成后，插入mes反馈队列
                            //OutStockReview.InsertOutStockFeedBack(orderNo);

                            SplashScreenManager.ShowForm(typeof(WaitForm1));
                            try
                            {
                                var feedback = CallMesWmsApiBll.FeedbackOrder(SelectedOrder.DeliveryNo, ((OutOrderTypeEnum)SelectedOrder.DeliveryType).ToString(), SelectedOrder.LineId);
                                feedback.Message.ShowTips();
                            }
                            finally
                            {
                                SplashScreenManager.CloseForm();
                            }

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            FrmReviewResult frm = new FrmReviewResult(orderNo);
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        "MES接口校验执行发料失败，请查看调用日志".ShowTips();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void ShowWarning(string upn, int type, string waringContent = "")
        {
            switch (type)
            {
                case 1:
                    lblWarning.Text = $"本出库单无该料号，不准出库，请拿走，（复核总表将不汇总）\r\n\r\nUPN:{upn}";
                    break;
                case 2:
                    lblWarning.Text = $"该料号已超发，此盘物料不能出库（复核总表将不汇总）\r\n\r\nUPN:{upn}";
                    break;
                case 3:
                    lblWarning.Text = $"{upn}\r\n重复扫码";
                    break;
                case 4:
                    lblWarning.Text = waringContent;
                    break;
            }
            lblWarning.Visible = true;
            lblWarningTitle.Visible = true;
        }

        private void CollapseWarning()
        {
            lblWarning.Text = string.Empty;
            lblWarning.Visible = true;
            lblWarningTitle.Visible = true;
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            dialog.FilterIndex = 0;
            dialog.OverwritePrompt = true;
            dialog.InitialDirectory = "D:\\";
            dialog.FileName = $"{SelectedOrder.DeliveryNo}-Review-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (ReviewSummaries == null || ReviewSummaries.Count == 0)
            {
                "没有可以导出的数据".ShowTips();
                return;
            }

            List<HeadColumn> headColumns = new List<HeadColumn>
            {
                new HeadColumn("OrderNo","工单号",4200),
                new HeadColumn("PartNumber","物料代码",2200),
                new HeadColumn("NeedQty","需求数量",2200),
                new HeadColumn("UPN","UPN",7168),
                new HeadColumn("RealQty","出库数量" ,2200),
                new HeadColumn("TowerDes","库区",2600),
                new HeadColumn("SourceDes","来源",2600),
                new HeadColumn("MatchDes","结果",2400),
                new HeadColumn("QRCode","二维码",15000),
            };
            string fileFullName = NpoiHelper.ExportToExcel(dialog.FileName, ReviewSummaries.ToList(), headColumns);
            if (!string.IsNullOrWhiteSpace(fileFullName))
            {
                System.Diagnostics.Process.Start("explorer", "/select," + fileFullName);
            }
        }

        private void cbBoxScan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBoxScan.Checked)
            {
                txtBoxScan.Enabled = true;
            }
            else
            {
                txtBoxScan.Enabled = false;
                txtBoxScan.Text = string.Empty;
            }
        }

        private void cbOriginal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOriginal.Checked)
            {
                tbOriginal.Enabled = true;
            }
            else
            {
                tbOriginal.Enabled = false;
                tbOriginal.Text = string.Empty;
            }
        }

        private void FrmReview_Load(object sender, EventArgs e)
        {
            try
            {
                InitOrderControl();
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
                this.Close();
            }
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            PlayResultWaves(true);
        }

        private void btnNotify_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockFinishObj)
                {

                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void gridViewRecord_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var row = gridViewRecord.Rows[e.RowIndex];
                var record = row.DataBoundItem as ReviewRecord;
                if (record.Status.ToString().Equals("正常出库"))
                {
                    row.Cells["rStatus"].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    row.Cells["rStatus"].Style.BackColor = Color.Red;
                }
                ShowRowIndex(gridViewRecord, e);
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void ShowRowIndex(DataGridView dgv, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgv.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgv.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgv.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void gridViewSummary_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var row = gridViewSummary.Rows[e.RowIndex];
                var record = row.DataBoundItem as ReviewSummary;

                if (record.Match == 1)
                {
                    row.Cells["MatchDes"].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    row.Cells["MatchDes"].Style.BackColor = Color.Orange;
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void gridViewSummary_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {    //右键弹出菜单
                if (e.Button != MouseButtons.Right)
                {
                    return;
                }
                //容许用户添加行时，最后一行为未实际添加的行，所以不需考虑弹出菜单
                if (e.RowIndex < 0 || (gridViewSummary.AllowUserToAddRows && e.RowIndex == gridViewSummary.Rows.Count - 1))
                {
                    return;
                }
                //只有upn上允许弹窗
                if (e.ColumnIndex != 3)
                {
                    return;
                }
                gridViewSummary.Rows[e.RowIndex].Selected = true;
                //创建快捷菜单
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

                //删除当前行
                ToolStripMenuItem tsmiRemoveCurrentRow = new ToolStripMenuItem("删除本行");
                tsmiRemoveCurrentRow.Click += (obj, arg) =>
                {
                    var row = gridViewSummary.Rows[e.RowIndex];
                    var record = row.DataBoundItem as ReviewSummary;

                    ReviewSummaries.Remove(record);
                };
                contextMenuStrip.Items.Add(tsmiRemoveCurrentRow);

                ////清空全部数据
                //ToolStripMenuItem tsmiRemoveAll = new ToolStripMenuItem("清空数据");
                //tsmiRemoveAll.Click += (obj, arg) =>
                //{
                //    gridViewSummary.Rows.Clear();
                //};
                //contextMenuStrip.Items.Add(tsmiRemoveAll);

                contextMenuStrip.Show(gridViewSummary, new Point(e.X, e.Y));
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockFinishObj)
                {
                    var remainMaterials = ReviewSummaries.Where(p => p.Match == 1 || (p.Match == 0 && string.IsNullOrWhiteSpace(p.UPN)))
                        .GroupBy(p => new { p.PartNumber, p.LineNumber, p.NeedQty })
                        .Where(p => p.Key.NeedQty > p.Sum(c => c.RealQty))
                        .Select(p => p.Key.PartNumber).Distinct().ToList();
                    if (remainMaterials.Count > 0)
                    {
                        if ($"本工单仍然有以下物料:{string.Join(",", remainMaterials)}处于短拣状态，是否继续！".ShowYesNoAndTips() != DialogResult.Yes)
                        {
                            return;
                        }
                    }

                    string orderNo = SelectedOrder.DeliveryNo;
                    var reviewList = ReviewSummaries.Where(p => (!string.IsNullOrWhiteSpace(p.UPN)) && p.Match == 1).ToList();
                    if (reviewList.Count > 0)
                    {
                        OutStockReview.TempDeliveyOrderReview(orderNo, AppInfo.LoginUserInfo.account, reviewList);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }
    }
}