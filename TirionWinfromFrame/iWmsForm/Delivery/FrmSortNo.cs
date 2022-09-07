using Business;
using DevExpress.XtraEditors;
using Entity.DataContext;
using Entity.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmSortNo : XtraForm
    {

        public FrmSortNo()
        {
            InitializeComponent();
            Load += FrmSortNo_Load;
        }

        private void FrmSortNo_Load(object sender, EventArgs e)
        {
            try
            {
                var orders = DeliveryBll.GetDeliveringOrders();
                string firstSet = ((int)SortNoEnum.FirstSet).ToString();
                string thirdSet = ((int)SortNoEnum.FreeFirst).ToString();
                string forthSet = ((int)SortNoEnum.FreeSecond).ToString();

                foreach (Wms_DeliveryOrder item in orders)
                {
                    if (item.SortingId == firstSet)
                    {
                        btnZero.BackColor = Color.Orange;
                        btnZero.Enabled = false;
                        btnZero.ToolTip = $"被{item.DeliveryNo}占用";
                    }
                    if (item.SortingId == thirdSet)
                    {
                        btnThird.BackColor = Color.Orange;
                        btnThird.Enabled = false;
                        btnZero.ToolTip = $"被{item.DeliveryNo}占用";
                    }
                    if (item.SortingId == forthSet)
                    {
                        btnForth.BackColor = Color.Orange;
                        btnForth.Enabled = false;
                        btnZero.ToolTip = $"被{item.DeliveryNo}占用";
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        public int SortNo { get; set; } = -1;

        private void btnZero_Click(object sender, EventArgs e)
        {
            SortNo = (int)SortNoEnum.FirstSet;
            this.DialogResult = DialogResult.OK;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            SortNo = (int)SortNoEnum.Emergency;
            this.DialogResult = DialogResult.OK;
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            SortNo = (int)SortNoEnum.Ng;
            this.DialogResult = DialogResult.OK;
        }

        private void btnThird_Click(object sender, EventArgs e)
        {
            SortNo = (int)SortNoEnum.FreeFirst;
            this.DialogResult = DialogResult.OK;
        }

        private void btnForth_Click(object sender, EventArgs e)
        {
            SortNo = (int)SortNoEnum.FreeSecond;
            this.DialogResult = DialogResult.OK;
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
