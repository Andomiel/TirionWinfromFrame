using Business;
using Commons;
using Entity.Dto;
using Mapster;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
        }

        private BindingList<LogDto> Logs = new BindingList<LogDto>();

        private readonly object lockButtonObj = new object();

        private void BtnQuery_Click(object sender, EventArgs e)
        {
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
                        MessageBox.Show("未查询到当前条件下的日志信息");
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
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvLogs.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvLogs.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvLogs.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
