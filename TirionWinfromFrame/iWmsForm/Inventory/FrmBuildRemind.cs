using DevExpress.XtraEditors;
using Entity.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmBuildRemind : XtraForm
    {
        public string txtRemark { get; set; }

        public FrmBuildRemind()
        {
            InitializeComponent();
            SetDefaultText();
        }

        public FrmBuildRemind(FrozenRemindBtnType frozenRemindBtnType)
        {
            InitializeComponent();
            SetDefaultText();
            if (frozenRemindBtnType == FrozenRemindBtnType.OnlyUpns)
            {
                btnBuildCondition.Enabled = false;
                btnBuildUpns.Enabled = true;
            }
            else if (frozenRemindBtnType == FrozenRemindBtnType.OnlyCondition)
            {
                btnBuildCondition.Enabled = true;
                btnBuildUpns.Enabled = false;
            }
            else { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnBuildCondition_Click(object sender, EventArgs e)
        {
            txtRemark = tbRemark.Text;
            if (!string.IsNullOrWhiteSpace(txtRemark) && txtRemark != DEFAULT_TEXT)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                "冻结原因必填".ShowTips();
            }
        }

        private void btnBuildUpns_Click(object sender, EventArgs e)
        {
            txtRemark = tbRemark.Text;
            if (!string.IsNullOrWhiteSpace(txtRemark) && txtRemark != DEFAULT_TEXT)
            {
                DialogResult = DialogResult.Yes;
            }
            else
            {
                "冻结原因必填".ShowTips();
            }
        }

        #region 备注框默认内容呈现
        private string DEFAULT_TEXT = "人工必须填写";
        private void SetDefaultText()
        {
            tbRemark.Text = DEFAULT_TEXT;
            tbRemark.ForeColor = Color.Gray;
        }

        private void tbRemark_Enter(object sender, EventArgs e)
        {
            if (tbRemark.Text == DEFAULT_TEXT)
            {
                tbRemark.Text = string.Empty;
                tbRemark.ForeColor = Color.Black;
            }
        }

        private void tbRemark_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbRemark.Text))
            {
                SetDefaultText();
            }
        }
        #endregion
    }
}
