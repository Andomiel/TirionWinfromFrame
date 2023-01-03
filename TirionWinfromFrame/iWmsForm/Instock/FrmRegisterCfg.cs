using Business;
using Commons;
using DevExpress.XtraSplashScreen;
using Entity;
using Entity.DataContext;
using Entity.Dto;
using Entity.Dto.Instock;
using Entity.Enums.General;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace iWms.Form
{
    public partial class FrmRegisterCfg : FrmBaseForm
    {
        public FrmRegisterCfg()
        {
            InitializeComponent();
            dgvConfigs.ScrollBars = ScrollBars.Both;
            dgvConfigs.Dock = DockStyle.Fill;
            dgvConfigs.AutoGenerateColumns = false;
            dgvConfigs.DataSource = Configs;
            dgvConfigs.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色


            List<EnumItem> enumItems = new List<EnumItem>
            {
                new EnumItem
                {
                    Name = string.Empty,
                    Value = -1,
                    Description = "全部"
                }
            };

            enumItems.AddRange(EnumHelper.GetEnumItems(typeof(RegisterStatusEnum)));
            //cbeStatus.SetComboxEditDataSource(enumItems, "Description", "Value");
            //cbeStatus.Properties.Items.AddEnum(typeof(RegisterStatusEnum));

            cbeStatus.Properties.Items.AddRange(enumItems.Select(p => p.Description).ToList());
            cbeStatus.SelectedIndex = 0;
        }

        private BindingList<CfgRegisterDto> Configs = new BindingList<CfgRegisterDto>();

        private readonly object lockButtonObj = new object();

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockButtonObj)
                {
                    GetConfigs();
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

        private void GetConfigs()
        {
            string condition = tbMaterialNo.Text.Trim();
            var cfgs = GeneralBusiness.GetAllRegisterCfg(condition, cbeStatus.SelectedIndex - 1);

            Configs.Clear();
            foreach (var item in cfgs)
            {
                Configs.Add(item.Adapt<CfgRegisterDto>());
            }
        }

        private void DgvLogs_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            ShowRowIndex(dgvConfigs, e);
            var row = dgvConfigs.Rows[e.RowIndex];
            var order = row.DataBoundItem as CfgRegisterDto;
            if (order.RecordStatus == (int)RegisterStatusEnum.Valid)
            {
                row.Cells["colStatus"].Style.BackColor = Color.LightGreen;
            }
            else
            {
                row.Cells["colStatus"].Style.BackColor = Color.Gray;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var diag = new FrmRegisterAdd(new CfgRegisterDto()))
            {
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    GetConfigs();
                }
            }
        }

        private void DgvConfigs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
            {
                //They clicked the header column, do nothing
                return;
            }

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                var row = dgvConfigs.Rows[e.RowIndex];
                var order = row.DataBoundItem as CfgRegisterDto;

                GeneralBusiness.DelRegisterCfg(order.Id);

                Configs.Remove(order);

                "删除配置成功".ShowTips();
            }
        }

        private void DgvConfigs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                //They clicked the header column, do nothing
                return;
            }
            var row = dgvConfigs.Rows[e.RowIndex];
            var order = row.DataBoundItem as CfgRegisterDto;

            using (var diag = new FrmRegisterAdd(order))
            {
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    GetConfigs();
                }
            }
        }
    }
}
