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
        public string TxtRemark { get; set; }

        public FrmBuildRemind()
        {
            InitializeComponent();

            lblUser.Text = AppInfo.LoginUserInfo.account;
        }

        public FrmBuildRemind(FrozenRemindBtnType frozenRemindBtnType)
        {
            InitializeComponent();
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnBuildCondition_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            TxtRemark = $"{AppInfo.LoginUserInfo.account}:{meReason.Text.Trim()}:{meRange.Text.Trim()}";
            if (TxtRemark.Length >= 255)
            {
                "总备注超出255个长度，将被截断".ShowTips();
                TxtRemark = TxtRemark.Substring(0, 254);
            }

            DialogResult = DialogResult.OK;

        }

        private void BtnBuildUpns_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            TxtRemark = $"{AppInfo.LoginUserInfo.account}:{meReason.Text.Trim()}:{meRange.Text.Trim()}";
            if (TxtRemark.Length >= 255)
            {
                "总备注超出255个长度，将被截断".ShowTips();
                TxtRemark = TxtRemark.Substring(0, 254);
            }
            DialogResult = DialogResult.Yes;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(meReason.Text.Trim()))
            {
                "冻结原因必填".ShowTips();
                meReason.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(meRange.Text.Trim()))
            {
                "物料范围必填".ShowTips();
                meRange.Focus();
                return false;
            }
            return true;
        }
    }
}
