﻿using Business;
using Entity.Enums;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmManualCounting : FrmBaseForm
    {
        public FrmManualCounting()
        {
            InitializeComponent();
            gridViewRecord.AutoGenerateColumns = false;
            gridViewRecord.DataSource = RefundRecord;
        }

        private readonly BindingList<ManualCountingRecord> RefundRecord = new BindingList<ManualCountingRecord>();

        private void TbScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    if (!tbScan.Text.Contains("*"))
                    {
                        "请扫二维码".ShowTips();
                        tbScan.Text = string.Empty;
                        return;
                    }
                    if (!tbScan.Text.EndsWith("*"))
                    {
                        "当前料盘二维码不以*号结束，请检查二维码".ShowTips();
                        tbScan.Text = string.Empty;
                        return;
                    }
                    tbScan.Text = BarcodeFormatter.FormatBarcode(tbScan.Text.Trim());
                    txtMaterialInfo.Text = string.Empty;
                    var result = CallMesWmsApiBll.CallMaterialInfoByUPN(tbScan.Text);
                    if (result != null && !string.IsNullOrWhiteSpace(result.InvQty))
                    {
                        tbQty.Text = Convert.ToDecimal(result.InvQty).ToString("0");
                        txtMaterialInfo.Text = JsonConvert.SerializeObject(result);
                    }
                    else
                    {
                        tbQty.Text = string.Empty;
                        txtMaterialInfo.Text = string.Empty;
                    }

                    if ("是否无需修改立即退料?".ShowYesNoAndTips() == DialogResult.Yes)
                    {
                        BtnSubmit_Click(btnSubmit, null);
                    }
                }
                catch (Exception ex)
                {
                    ex.GetDeepException().ShowError();
                    tbScan.Text = string.Empty;
                }
            }
        }

        //需要删除的重写
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V))
            {
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    tbScan.Text = iData.GetData(DataFormats.Text).ToString();
                }
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private object lockSubmitObj = new object();

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockSubmitObj)
                {
                    if (string.IsNullOrWhiteSpace(tbScan.Text))
                    {
                        return;
                    }

                    ManualCountingRecord record = new ManualCountingRecord();
                    record.QRCode = tbScan.Text;
                    record.Qty = TypeParse.StrToInt(tbQty.Text, 0);

                    int starCount = record.QRCode.ToCharArray().Count(p => p.Equals('*'));
                    if (starCount < 6 || starCount > 9)
                    {
                        "请扫描二维码".ShowTips();
                        RefundRecord.Insert(0, record);
                        ClearAndRefreshInput();
                        return;
                    }

                    if (record.Qty == 0)
                    {
                        "数量是0或空，不可进行点料".ShowTips();
                        RefundRecord.Insert(0, record);
                        ClearAndRefreshInput();
                        return;
                    }

                    int scanIndex = record.QRCode.IndexOf('*');
                    record.UPN = record.QRCode.Substring(0, scanIndex);
                    if (string.IsNullOrWhiteSpace(record.UPN))
                    {
                        return;
                    }
                    string[] upnArr = record.UPN.Split('-');
                    record.PartNumber = upnArr[0];
                    record.SerialNo = upnArr[3];

                    string[] qrcodeArr = record.QRCode.Split('*');
                    if (qrcodeArr.Length >= 3)
                    {
                        record.MSD = qrcodeArr[2];
                    }

                    if (string.IsNullOrWhiteSpace(qrcodeArr[6]))
                    {
                        record.MiniPacking = 0;
                    }
                    else
                    {
                        record.MiniPacking = Convert.ToInt32(qrcodeArr[6]);
                    }

                    MaterialInfoResponse response = CallMesWmsApiBll.CallMaterialInfoByUPN(record.QRCode);
                    if (response.HoldFlag != null && response.HoldFlag.ToUpper().Equals("Y"))
                    {
                        "物料是锁定料，不可进行点料".ShowTips();
                        //RefundRecord.Insert(0, record);
                        ClearAndRefreshInput();
                        return;
                    }
                    record.materialJson = txtMaterialInfo.Text;

                    record.IsTypeT = cbIsTypeT.Checked;
                    //直接同步
                    var syncResult = ManualCounting.SyncCounting(record);
                    ManualCounting.SaveCounting(record);
                    record.MSD = syncResult.MSD;
                    record.MsdOverdue = syncResult.MsdOverdue == "Y" ? "Y" : "N";
                    record.IsLock = syncResult.LockState == "Y" ? "Y" : "N";
                    record.Message = syncResult.Message;
                    record.IsSuccess = syncResult.Result == "OK";

                    RefundRecord.Insert(0, record);

                    ClearAndRefreshInput();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void ClearAndRefreshInput()
        {
            tbScan.Text = string.Empty;
            tbQty.Text = string.Empty;
            cbIsTypeT.Checked = false;
            tbScan.Focus();
        }

        private void tbQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void gridViewRecord_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (gridViewRecord == null || gridViewRecord.Rows.Count == 0)
                {
                    return;
                }
                var row = gridViewRecord.Rows[e.RowIndex];
                if (row == null)
                {
                    return;
                }
                if (Convert.ToString(row.Cells["MsdOverdue"].Value).Equals("Y"))
                {
                    row.Cells["MsdOverdue"].Style.BackColor = Color.Red;
                }
                else
                {
                    row.Cells["MsdOverdue"].Style.BackColor = Color.LightGreen;
                }

                if (Convert.ToString(row.Cells["IsLock"].Value).Equals("Y"))
                {
                    row.Cells["IsLock"].Style.BackColor = Color.Red;
                }
                else
                {
                    row.Cells["IsLock"].Style.BackColor = Color.LightGreen;
                }

                if (Convert.ToBoolean(row.Cells["IsSuccess"].Value))
                {
                    row.Cells["Success"].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    row.Cells["Success"].Style.BackColor = Color.Red;
                }

                var record = row.DataBoundItem as ManualCountingRecord;
                if (record.ReelType == (int)ReelTypeEnum.F)
                {
                    //row.Cells["colReelType"].Style.BackColor = ;
                }
                else
                {
                    row.Cells["colReelType"].Style.BackColor = Color.Orange;
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }
    }
}