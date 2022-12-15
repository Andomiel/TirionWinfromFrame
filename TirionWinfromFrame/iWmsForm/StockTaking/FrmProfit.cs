using Business;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
    public partial class FrmProfit : XtraForm
    {

        public FrmProfit()
        {
            InitializeComponent();

            gridViewRecord.AutoGenerateColumns = false;
            gridViewRecord.DataSource = ReviewRecords;
            gridViewRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色
        }

        private readonly BindingList<ProfitBarcode> ReviewRecords = new BindingList<ProfitBarcode>();

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            dialog.FilterIndex = 0;
            dialog.OverwritePrompt = true;
            dialog.InitialDirectory = "D:\\";
            dialog.FileName = $"盘亏-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (ReviewRecords == null || ReviewRecords.Count == 0)
            {
                "没有可以导出的数据".ShowTips();
                return;
            }

            List<HeadColumn> headColumns = new List<HeadColumn>
            {
                new HeadColumn("Index","序号",1200),
                new HeadColumn("MaterialNo","物料代码",2200),
                new HeadColumn("Barcode","UPN",7168),
                new HeadColumn("Quantity","数量" ,2200),
                new HeadColumn("TowerDisplay","库区",2600),
                new HeadColumn("Location","库位",2600),
                new HeadColumn("Remark","结果",2400),
            };
            string fileFullName = NpoiHelper.ExportToExcel(dialog.FileName, ReviewRecords.ToList(), headColumns);
            if (!string.IsNullOrWhiteSpace(fileFullName))
            {
                System.Diagnostics.Process.Start("explorer", "/select," + fileFullName);
            }
        }

        private void FrmReview_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
                this.Close();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                rtbText.Text = string.Empty;
                rtbText.Focus();
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private readonly object lockOperateObj = new object();

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockOperateObj)
                {
                    if (string.IsNullOrWhiteSpace(rtbText.Text.Trim()))
                    {
                        "请输入要盘盈的UPN列表".ShowTips();
                        return;
                    }
                    ReviewRecords.Clear();
                    foreach (var item in rtbText.Lines)
                    {
                        string barcode = item.Trim();
                        if (ReviewRecords.Any(p => p.QRCode == barcode))
                        {
                            continue;
                        }
                        var record = new ProfitBarcode()
                        {
                            QRCode = barcode,
                        };
                        try
                        {
                            barcode = ValidateBarcode(barcode);
                        }
                        catch (Exception ex)
                        {
                            record.CanProfit = false;
                            record.materialJson = ex.Message;
                            ReviewRecords.Add(record);
                            continue;
                        }
                        int scanIndex = record.QRCode.IndexOf('*');
                        record.UPN = record.QRCode.Substring(0, scanIndex);
                        var inventoryBarcode = GeneralBusiness.GetInventoryBarcode(record.UPN);
                        if (inventoryBarcode == null || inventoryBarcode.Rows.Count == 0)
                        {
                            string[] upnArr = record.UPN.Split('-');
                            record.PartNumber = upnArr[0];
                            if (upnArr.Length >= 2)
                            {
                                record.Supplier = upnArr[1].Substring(0, upnArr[1].Length - 1);
                            }
                            if (upnArr.Length >= 3)
                            {
                                record.DataCode = upnArr[2];
                            }
                            if (upnArr.Length >= 4)
                            {
                                record.SerialNo = upnArr[3];
                            }

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
                            if (response != null)
                            {
                                if (!string.IsNullOrWhiteSpace(response.InvQty))
                                {
                                    record.Qty = (int)Convert.ToDecimal(response.InvQty);
                                }
                                if (response.HoldFlag != null && response.HoldFlag.ToUpper().Equals("Y"))
                                {
                                    record.materialJson = "物料是锁定料";
                                    record.IsLock = "Y";
                                }
                            }
                            record.MsdOverdue = "N";
                            record.CanProfit = true;
                        }
                        else
                        {
                            var row = inventoryBarcode.Rows[0];

                            record.UPN = Convert.ToString(row["ReelID"]);
                            record.PartNumber = Convert.ToString(row["Part_Number"]);
                            record.Qty = TypeParse.StrToInt(row["Qty"], 0);
                            record.SerialNo = Convert.ToString(row["lot"]);
                            record.MiniPacking = TypeParse.StrToInt(row["MinPacking"], 0);
                            record.MSD = Convert.ToString(row["MSD"]);
                            record.MsdOverdue = "N";
                            record.CanProfit = false;
                            record.materialJson = "库内物料";
                        }

                        ReviewRecords.Add(record);
                    }
                    "筛选成功".ShowTips();
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

        private string ValidateBarcode(string barcode)
        {
            if (!barcode.Contains("*"))
            {
                throw new OppoCoreException("请输入二维码");
            }
            if (!barcode.EndsWith("*"))
            {
                throw new OppoCoreException("二维码结尾不是*号，请确认二维码完整性");
            }
            return BarcodeFormatter.FormatBarcode(barcode);
        }

        private void BtnProfit_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockOperateObj)
                {
                    var records = ReviewRecords.Where(p => p.CanProfit);
                    if (!records.Any())
                    {
                        "没有可盘盈的物料".ShowTips();
                        return;
                    }
                    ProfitAndLossBusiness.ProfitBarcodes(records, AppInfo.LoginUserInfo.account);

                    "盘盈成功".ShowTips();
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

}
