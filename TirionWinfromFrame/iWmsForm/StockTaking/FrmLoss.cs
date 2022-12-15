using Business;
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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmLoss : XtraForm
    {

        public FrmLoss()
        {
            InitializeComponent();

            grdList.DataSource = ReviewRecords;
        }

        private readonly BindingList<LossBarcode> ReviewRecords = new BindingList<LossBarcode>();

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
                        "请输入要盘亏的UPN列表".ShowTips();
                        return;
                    }
                    int index = 1;
                    ReviewRecords.Clear();
                    foreach (var item in rtbText.Lines)
                    {
                        string upn = item.Trim();
                        if (string.IsNullOrWhiteSpace(upn))
                        {
                            continue;
                        }
                        if (upn.Split('-').Length < 3)
                        {
                            continue;
                        }
                        if (ReviewRecords.Any(p => p.Barcode == upn))
                        {
                            continue;
                        }
                        var inventoryBarcode = GeneralBusiness.GetInventoryBarcode(upn);
                        if (inventoryBarcode == null || inventoryBarcode.Rows.Count == 0)
                        {
                            continue;
                        }
                        var row = inventoryBarcode.Rows[0];
                        var barcode = new LossBarcode()
                        {
                            Index = index++,
                            Barcode = upn,
                            Quantity = TypeParse.StrToInt(row["Qty"], 0),
                            Tower = TypeParse.StrToInt(row["LockTowerNo"], -1),
                            Location = Convert.ToString(row["LockLocation"]),
                            MaterialNo = Convert.ToString(row["Part_Number"]),
                        };
                        ReviewRecords.Add(barcode);
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

        private void BtnLoss_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockOperateObj)
                {
                    var records = ReviewRecords.Where(p => p.CanLoss);
                    if (!records.Any())
                    {
                        "没有可盘亏的".ShowTips();
                        return;
                    }
                    ProfitAndLossBusiness.LossBarcodes(records, AppInfo.LoginUserInfo.account);

                    "盘亏成功".ShowTips();
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
