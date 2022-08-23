using Business;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmInStockNotice : FrmBaseForm
    {
        public FrmInStockNotice()
        {
            InitializeComponent();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtPath.Text = openFileDialog1.FileName;
        }

        private readonly object lockBtnObj = new object();

        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockBtnObj)
                {
                    if (string.IsNullOrWhiteSpace(txtPath.Text))
                    {
                        "请选择正确的入库单".ShowTips();
                        return;
                    }

                    DataTable dtFromExcel = NpoiHelper.ExcelToDataTable(txtPath.Text, "入库通知单", 0);
                    if (dtFromExcel == null || dtFromExcel.Rows.Count == 0)
                    {
                        "表格为空或者表格未关闭！".ShowTips();
                        return;
                    }

                    //入库单数据校验
                    string errorMsg = CheckData(dtFromExcel);
                    if (!string.IsNullOrWhiteSpace(errorMsg))
                    {
                        errorMsg.ShowTips();
                        return;
                    }
                    InOutStockStorageData.CreateInstockOrderFromExcel(dtFromExcel, AppInfo.LoginUserInfo.account);

                    "入库单导入成功！".ShowTips();
                    Close();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        /// <summary>
        /// 入库单数据校验
        /// </summary>
        /// <param name="dtFromExcel"></param>
        private string CheckData(DataTable dtFromExcel)
        {
            for (int i = 0; i < dtFromExcel.Rows.Count; i++)
            {
                string upn = dtFromExcel.Rows[i]["UPN"].ToString();
                string qty = dtFromExcel.Rows[i]["数量"].ToString();
                string materialCode = dtFromExcel.Rows[i]["物料代码"].ToString();
                //string lot = dtFromExcel.Rows[i]["打印日期"].ToString();//生产批次
                string error = $"第{i + 3}行附近存在以下数据问题";
                StringBuilder sb = new StringBuilder();
                if (string.IsNullOrWhiteSpace(upn))
                {
                    sb.AppendLine("UPN为空");
                }
                if (string.IsNullOrWhiteSpace(qty) || qty == "0")
                {
                    sb.AppendLine("数量为空");
                }
                if (string.IsNullOrWhiteSpace(materialCode))
                {
                    sb.AppendLine("料号为空");
                }
                //if (string.IsNullOrWhiteSpace(lot))
                //{
                //    sb.AppendLine("批次号不能为空.ShowTips();
                //}
                string msg = sb.ToString();
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    return $"{error}\r\n{msg}";
                }
            }
            return string.Empty;
        }

        private object lockDownloadObj = new object();

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockDownloadObj)
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
                    dialog.FilterIndex = 0;
                    dialog.OverwritePrompt = true;
                    dialog.InitialDirectory = "D:\\";
                    dialog.FileName = $"入库单模板.xlsx";
                    if (dialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    File.Copy(Path.Combine(Application.StartupPath, "template\\入库明细.xlsx"), dialog.FileName, true);
                    if (!string.IsNullOrWhiteSpace(dialog.FileName))
                    {
                        System.Diagnostics.Process.Start("explorer", "/select," + dialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void btnResharpBarcode_Click(object sender, EventArgs e)
        {
            if (txtPath.Text != "")
            {
                DataTable dtFromExcel = NpoiHelper.ExcelToDataTable(txtPath.Text, "入库通知单", 0);
                if (dtFromExcel == null || dtFromExcel.Rows.Count == 0)
                {
                    "表格为空或者表格未关闭！".ShowTips();
                    return;
                }


                int res = InOutStockStorageData.UpdateUpnInfoFromImportExcel(dtFromExcel);

                if (res > 0)
                {
                    "upn明细导入更新信息成功！".ShowTips();
                    this.Close();
                }
            }
            else
            {
                "请选择正确的入库通知单".ShowTips();
            }
        }
    }
}
