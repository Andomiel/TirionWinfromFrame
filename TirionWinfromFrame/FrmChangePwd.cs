using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commons;
using DevExpress.XtraEditors;
using MES;
using MES.Entity;
using TirionWinfromFrame.Commons;

namespace TirionWinfromFrame
{
    public partial class FrmChangePwd : XtraForm
    {

        public FrmChangePwd()
        {
            InitializeComponent();
            Load += FrmChangePwd_Load;
        }

        private void FrmChangePwd_Load(object sender, EventArgs e)
        {
            txtName.Text = AppInfo.LoginUserInfo.username;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput())
                {
                    using (var con = new MESDB())
                    {
                        AppInfo.LoginUserInfo.password = MD5Utils.GetMD5_32(txtOriginPwd.Text.Trim());
                        con.sysUserInfo.AddOrUpdate(AppInfo.LoginUserInfo);
                        con.SaveChanges();
                        "保存成功".ShowTips();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }

        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtOriginPwd.Text))
            {
                "原密码不能为空".ShowWarning();
                txtOriginPwd.Focus();
                return false;
            }
            if (!AppInfo.LoginUserInfo.password.Equals(MD5Utils.GetMD5_32(txtOriginPwd.Text.Trim())))
            {
                "原密码不正确".ShowWarning();
                txtOriginPwd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNewPwd.Text))
            {
                "新密码不能为空".ShowWarning();
                txtNewPwd.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtConfirmPwd.Text))
            {
                "确认密码不能为空".ShowWarning();
                txtConfirmPwd.Focus();
                return false;
            }
            if (txtNewPwd.Text != txtConfirmPwd.Text)
            {
                "两次输入的新密码不一致".ShowWarning();
                txtNewPwd.Focus();
                return false;
            }
            if (txtNewPwd.Text == txtOriginPwd.Text)
            {
                "要修改的新密码与原密码相同".ShowWarning();
                txtNewPwd.Focus();
                return false;
            }
            return true;
        }

    }
}
