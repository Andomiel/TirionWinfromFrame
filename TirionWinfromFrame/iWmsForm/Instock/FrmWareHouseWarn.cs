using Business;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmWareHouseWarn : XtraForm
    {
        public string OrderNo { get; set; } = string.Empty;

        public FrmWareHouseWarn()
        {
            InitializeComponent();
            SetDefaultText();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRemark.Text) || txtRemark.Text == DEFAULT_TEXT)
            {
                "完成入库，备注信息必填".ShowTips();
                return;
            }
            //保存填写的信息，然后执行接下来的完成逻辑
            bool result = WareHouseBLL.UpdateOrderRemark(OrderNo, $"{AppInfo.LoginUserInfo.account}:{txtRemark.Text}", AppInfo.LoginUserInfo.account);
            if (result)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        #region 备注框默认内容呈现
        private string DEFAULT_TEXT = "请输入...";
        private void SetDefaultText()
        {
            txtRemark.Text = DEFAULT_TEXT;
            txtRemark.ForeColor = Color.Gray;
            txtOperater.Text = AppInfo.LoginUserInfo.username;
        }

        private void txtRemark_Enter(object sender, EventArgs e)
        {
            if (txtRemark.Text == DEFAULT_TEXT)
            {
                txtRemark.Text = string.Empty;
                txtRemark.ForeColor = Color.Black;
            }
        }

        private void txtRemark_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRemark.Text))
            {
                SetDefaultText();
            }
        }
        #endregion

        private void FrmWareHouseWarn_Click(object sender, EventArgs e)
        {
            btnCancel.Focus();
        }
    }
}
