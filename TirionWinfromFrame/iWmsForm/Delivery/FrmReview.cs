using Business;
using Entity;
using Entity.DataContext;
using Entity.Enums;
using Entity.Facade;
using Mapster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmReview : FrmBaseForm
    {

        public FrmReview()
        {
            InitializeComponent();

            List<EnumItem> orderTypeItems = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(OutOrderTypeEnum));
            cbOrderType.DataSource = orderTypeItems;
            cbOrderType.DisplayMember = "Description";
            cbOrderType.ValueMember = "Value";

            lblDestination.Text = string.Empty;
            HideBoxScan();
            gridViewRecord.AutoGenerateColumns = false;
            gridViewRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色

            gridViewSummary.AutoGenerateColumns = false;
            gridViewSummary.MergeColumnNames.AddRange(new List<string> { "LineNumber", "PartNumber", "NeedQty" });
            gridViewSummary.MergeFocusNames.AddRange(new List<string> { "LineNumber" });
            gridViewSummary.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色
        }

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
            lblWarning.Text = string.Empty;
            lblWarning.Visible = false;
            lblWarningTitle.Visible = false;

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
            if (gridViewRecord.DataSource != null)
            {
                //重复扫码验证
                var records = gridViewRecord.DataSource as List<ReviewRecord>;
                reviewRecord = records.FirstOrDefault(p => p.UPN.Equals(upn));

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
                    int index = records.FindIndex(p => p.UPN == reviewRecord.UPN);
                    if (index >= 0 && index < records.Count)
                    {
                        gridViewRecord.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
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
            var selectItem = (OutStockDdlItem)cbOrderNo.SelectedItem;
            if (selectItem == null)
            {
                return;
            }

            List<OrderNeedMaterial> needMaterials = OutStockReview.GetMaterialsByOutOrderNo(selectItem.OrderNo).ToList();
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
            var summaryList = gridViewSummary.DataSource as List<ReviewSummary>;
            var allSamePnList = summaryList.Where(p => p.PartNumber.Equals(reviewRecord.Part_Number)).ToList();
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

            ReviewSummary matchRow = summaryList.FirstOrDefault(p => p.UPN.Equals(upn));
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
                summaryList.RemoveAll(p => p.PartNumber == newReview.PartNumber && p.LineNumber == newReview.LineNumber && string.IsNullOrWhiteSpace(p.UPN));
                summaryList.Add(newReview);
            }
            AddBindRecord(reviewRecord);
            gridViewSummary.DataSource = summaryList.OrderBy(p => p.LineNumber).ThenBy(p => p.PartNumber).ToList();
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
            var selectItem = (OutStockDdlItem)cbOrderNo.SelectedItem;
            string orderNo = selectItem.OrderNo;
            int orderType = selectItem.Type2;
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
            List<ReviewRecord> records = gridViewRecord.DataSource as List<ReviewRecord>;
            if (records == null)
            {
                records = new List<ReviewRecord>();
            }
            var recordHave = records.FirstOrDefault(p => p.UPN == record.UPN);
            if (recordHave != null)
            {
                records.Remove(recordHave);
            }

            records.Add(record);
            gridViewRecord.DataSource = records.OrderByDescending(p => p.ScanTime).ToList();
        }

        private void SetTypeLable(string des)
        {
            if (!string.IsNullOrWhiteSpace(des))
            {
                lblDestination.Text = $"目的地：{des}";
            }
        }

        private void CbOrderNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedItem = ((sender as ComboBox).SelectedItem) as OutStockDdlItem;

            tbOriginal.Text = string.Empty;
            tbScan.Text = string.Empty;
            txtBoxScan.Text = string.Empty;

            string selectOrderNo = selectedItem.OrderNo;
            if (string.IsNullOrWhiteSpace(selectOrderNo))
            {
                gridViewRecord.DataSource = null;
                gridViewSummary.DataSource = null;
                return;
            }

            if (selectedItem.Type2 == (int)OutOrderTypeEnum.DBCK)
            {
                ShowBoxScan();
            }
            else
            {
                HideBoxScan();
            }

            List<ReviewSummary> summaryList = OutStockReview.GetSpareMaterial(selectOrderNo).ToList();
            var details = DeliveryBll.GetDeliveryDetails(selectedItem.DeliveryId);
            foreach (Wms_DeliveryDetail item in details)
            {
                var summary = summaryList.FirstOrDefault(p => p.LineNumber == item.RowNum.ToString() && p.PartNumber == item.MaterialNo);
                if (summary == null)
                {
                    summary = new ReviewSummary()
                    {
                        AllocateQty = 0,
                        NeedQty = item.RequireCount,
                        ContainerNo = string.Empty,
                        LineNumber = item.RowNum.ToString(),
                        Match = 0,
                        OrderNo = selectOrderNo,
                        PartNumber = item.MaterialNo,
                        QRCode = string.Empty,
                        RealQty = 0,
                        SlotNo = item.SlotNo,
                        Source = 0,
                        TowerNo = -1,
                        UPN = string.Empty
                    };
                    summaryList.Add(summary);
                }
            }

            gridViewSummary.DataSource = summaryList.OrderBy(p => p.LineNumber).ThenBy(p => p.PartNumber).ToList();
            SetTypeLable(selectedItem.DestinationNo);
            btnComplete.Enabled = true;
            btnCancel.Enabled = true;
            btnExport.Enabled = true;
            cbOrderType.Enabled = false;
            cbOrderNo.Enabled = false;
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

                    var selectItem = (OutStockDdlItem)cbOrderNo.SelectedItem;
                    if (selectItem == null)
                    {
                        return;
                    }

                    List<ReviewSummary> summaryList = gridViewSummary.DataSource as List<ReviewSummary>;
                    if (summaryList == null || summaryList.Count == 0 || !summaryList.Any(p => p.Match == 1))
                    {
                        "本工单还没有复核，校验执行发料的数据为空！".ShowTips();
                        return;
                    }

                    var remainMaterials = summaryList.Where(p => p.Match == 1 || (p.Match == 0 && string.IsNullOrWhiteSpace(p.UPN)))
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

                    var remainBarcodes = summaryList.Where(p => p.Match == 0 && !string.IsNullOrWhiteSpace(p.UPN)).Select(p => p.UPN).Distinct().ToList();
                    if (remainBarcodes.Count > 0)
                    {
                        if ($"本工单还有{remainBarcodes.Count}条已出库UPN未复核，这些UPN将会被转移到理料区！".ShowYesNoAndTips() != DialogResult.OK)
                        {
                            return;
                        }
                    }

                    bool canOperate = true;
                    if (selectItem.Type2 == (int)OutOrderTypeEnum.FLCK)
                    {
                        //辅料出库，MES接口校验执行发料（单号+所有UPN）
                        var mesCheckList = summaryList.Where(p => p.Match == 1).ToList();

                        CheckResultResponse result = OrderReviewCallApi.CheckFromMesExecuteDispatch(mesCheckList, AppInfo.LoginUserInfo.account, AppInfo.LoginUserInfo.account);
                        canOperate = result.Result;
                    }

                    if (canOperate)
                    {
                        string orderNo = selectItem.OrderNo;
                        var finishedList = summaryList.Where(p => !string.IsNullOrWhiteSpace(p.UPN)).ToList();
                        if (OutStockReview.FinishDeliveyOrderReview(orderNo, AppInfo.LoginUserInfo.account, finishedList) <= 0)
                        {
                            "更新数据异常，请重新提交".ShowTips();
                        }
                        else
                        {
                            "复核完成".ShowTips();
                            //出库完成后，插入mes反馈队列
                            OutStockReview.InsertOutStockFeedBack(orderNo);
                            FrmReviewResult frm = new FrmReviewResult(orderNo);
                            frm.ShowDialog();
                            gridViewRecord.DataSource = null;
                            gridViewSummary.DataSource = null;

                            // kook 2021/12/18
                            // 复核完成后，将出库单号下拉框放开，允许用户可以重新选择工单
                            cbOrderNo.Enabled = true;
                            cbOrderNo.ResetText();
                            tbScan.Text = string.Empty;
                            tbScan.Enabled = false;
                            btnComplete.Enabled = false;
                            btnCancel.Enabled = false;
                            btnExport.Enabled = false;
                            lblDestination.Text = string.Empty;
                            HideBoxScan();
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

        private void gridViewRecord_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = gridViewRecord.Rows[e.RowIndex];
            if (row.Cells["rStatus"].Value.ToString().Equals("正常出库"))
            {
                row.Cells["rStatus"].Style.BackColor = Color.LightGreen;
            }
            else
            {
                row.Cells["rStatus"].Style.BackColor = Color.Red;
            }
        }

        private void gridViewSummary_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = gridViewSummary.Rows[e.RowIndex];
            if (Convert.ToBoolean(row.Cells["Match"].Value))
            {
                row.Cells["MatchDes"].Style.BackColor = Color.LightGreen;
            }
            else
            {
                row.Cells["MatchDes"].Style.BackColor = Color.Orange;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if ("取消本次复核操作吗？".ShowYesNoCancelAndTips() == DialogResult.Cancel)
            {
                return;
            }
            gridViewRecord.DataSource = null;
            gridViewSummary.DataSource = null;
            cbOrderType.Enabled = true;
            cbOrderNo.Enabled = true;
            cbOrderNo.ResetText();
            tbScan.Text = string.Empty;
            tbScan.Enabled = false;
            btnComplete.Enabled = false;
            btnCancel.Enabled = false;
            btnExport.Enabled = false;
            lblDestination.Text = string.Empty;
            lblWarning.Visible = false;
            lblWarningTitle.Visible = false;
            HideBoxScan();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var selectItem = (OutStockDdlItem)cbOrderNo.SelectedItem;

            if (cbOrderNo.SelectedIndex < 0 || string.IsNullOrWhiteSpace(selectItem?.OrderNo))
            {
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            dialog.FilterIndex = 0;
            dialog.OverwritePrompt = true;
            dialog.InitialDirectory = "D:\\";
            dialog.FileName = $"{selectItem.OrderNo}-Review-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            List<ReviewSummary> data;
            if (gridViewSummary.DataSource == null)
            {
                "没有可以导出的数据".ShowTips();
                return;
            }
            else
            {
                data = gridViewSummary.DataSource as List<ReviewSummary>;
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
            string fileFullName = NpoiHelper.ExportToExcel(dialog.FileName, data, headColumns);
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
                cbOrderType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            PlayResultWaves(true);
        }

        private void cbOrderType_SelectedValueChanged(object sender, EventArgs e)
        {
            List<OutStockDdlItem> cbItems = new List<OutStockDdlItem> { new OutStockDdlItem() };
            var selectItem = cbOrderType.SelectedValue as EnumItem;

            int? selectedValue = selectItem?.Value;
            if (selectedValue == null)
            {
                selectedValue = Convert.ToInt32(cbOrderType.SelectedValue);
            }
            if (selectedValue > -1)
            {
                var itemList = DeliveryBll.GetOrdersForReview(selectedValue.Value);
                foreach (var item in itemList)
                {
                    cbItems.Add(item.Adapt<OutStockDdlItem>());
                }
            }

            cbOrderNo.DataSource = cbItems;
            cbOrderNo.DisplayMember = "OrderNo";
            cbOrderNo.ValueMember = "OrderNo";
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
    }
}
