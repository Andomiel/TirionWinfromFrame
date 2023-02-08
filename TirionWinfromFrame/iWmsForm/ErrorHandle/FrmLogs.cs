using Business;
using Commons;
using DevExpress.XtraSplashScreen;
using Entity.Dto;
using Mapster;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmLogs : FrmBaseForm
    {
        public FrmLogs()
        {
            InitializeComponent();
            dgvLogs.ScrollBars = ScrollBars.Both;
            dgvLogs.Dock = DockStyle.Fill;
            dgvLogs.AutoGenerateColumns = false;
            dgvLogs.DataSource = Logs;
            dgvLogs.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色
        }

        private BindingList<LogDto> Logs = new BindingList<LogDto>();

        private readonly object lockButtonObj = new object();

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockButtonObj)
                {
                    string condition = tbKey.Text.Trim();
                    DateTime dt = dtpTime.Value;
                    if (string.IsNullOrWhiteSpace(condition))
                    {
                        throw new OppoCoreException("请输入查询条件");
                    }
                    var logs = CallMesWmsApiBll.GetLogs(condition, dt.Date);

                    Logs.Clear();
                    if (logs == null || logs.List == null)
                    {
                        "未查询到当前条件下的日志信息".ShowTips();
                        return;
                    }
                    foreach (var item in logs.List)
                    {
                        Logs.Add(item.Adapt<LogDto>());
                    }
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

        private void DgvLogs_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvLogs.SelectedRows.Count == 0)
                {
                    return;
                }
                var row = dgvLogs.SelectedRows[0];
                var order = row.DataBoundItem as LogDto;

                pgLog.SelectedObject = order;
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void DgvLogs_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ShowRowIndex(dgvLogs, e);
        }

        private void BtnTxt_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockButtonObj)
                {
                    if (dgvLogs.SelectedRows.Count == 0)
                    {
                        "请选择一条要导出文件的日志".ShowTips();
                        return;
                    }
                    var row = dgvLogs.SelectedRows[0];
                    var log = row.DataBoundItem as LogDto;

                    ExportToText(tbKey.Text.Trim(), log);
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

        private void ExportToText(string title, LogDto log)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "文本文件(*.txt)|*.txt",
                FilterIndex = 0,
                OverwritePrompt = true,
                InitialDirectory = "D:\\",
                FileName = title
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileFullName = dialog.FileName;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(log.LogTitle);
            sb.AppendLine(log.LogTime.ToString());
            sb.AppendLine(log.RequestBody);
            sb.AppendLine($"response:{log.ResponseBody}");

            using (FileStream fs = new FileStream(fileFullName, FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(sb.ToString());
                sw.Close();
            }

            if (!string.IsNullOrWhiteSpace(fileFullName))
            {
                System.Diagnostics.Process.Start("explorer", "/select," + fileFullName);
            }
        }
    }
}
