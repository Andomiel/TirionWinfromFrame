using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WinformGeneralDeveloperFrame;
using WinformGeneralDeveloperFrame.Commons;

namespace MES.Form
{
	public partial class FrmsysDataBase : FrmBaseForm
	{
        private string _strConnectionString = "Server={0};Database={1};User Id = {2}; Password={3};Connect Timeout = 2";
        public sysDataBase dbEntity;

        public FrmsysDataBase()
		{
			InitializeComponent();
		}

        private void grdList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var dr = this.grdListView.GetFocusedRow();
            if (dr != null)
            {
                xtraTabControl1.SelectedTabPageIndex = 1;
                sysDataBase info = dr as sysDataBase;
                txtConnName.Text = info.name;
                txtDataBaseName.Text = info.databasename;
                txtConnUrl.Text = info.connecturl;
                txtServerName.Text = info.serverip;
                txtUserName.Text = info.username;
                txtPassWord.Text = info.passsword;
            }
        }

        private void txtConnName_Leave(object sender, EventArgs e)
        {
            using (var con = new DB())
            {
                if (con.sysDataBase.Where(p => p.name.Equals(txtConnName.Text)).Count() > 0)
                {
                    txtConnName.Focus();
                    "连接名已存在！".ShowWarning();
                }
            }
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (sqlConnectCheck(string.Format(_strConnectionString, txtServerName.Text, txtDataBaseName.Text,
                    txtUserName.Text, txtPassWord.Text)))
                {
                    txtConnUrl.Text = string.Format(_strConnectionString, txtServerName.Text, txtDataBaseName.Text,
                        txtUserName.Text, txtPassWord.Text);
                    "连接成功".ShowTips();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput())
                {
                    dbEntity = new sysDataBase()
                    {
                        databasename = txtDataBaseName.Text,
                        name = txtConnName.Text,
                        serverip = txtServerName.Text,
                        connecturl = string.Format(_strConnectionString, txtServerName.Text, txtDataBaseName.Text,
                            txtUserName.Text, txtPassWord.Text),
                        username = txtUserName.Text,
                        passsword = txtPassWord.Text,
                    };
                    using (var con = new DB())
                    {
                        con.sysDataBase.AddOrUpdate(dbEntity);
                        con.SaveChanges();
                        "保存成功".ShowTips();
                        using (var db = new DB())
                        {
                            grdList.DataSource = db.sysDataBase.ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ShowError();
            }
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private  bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtConnName.Text))
            {
                "连接名不能为空".ShowWarning();
                txtConnName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtServerName.Text))
            {
                "主机不能为空".ShowWarning();
                txtServerName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDataBaseName.Text))
            {
                "数据库不能为空".ShowWarning();
                txtDataBaseName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                "用户名不能为空".ShowWarning();
                txtUserName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassWord.Text))
            {
                "密码不能为空".ShowWarning();
                txtPassWord.Focus();
                return false;
            }
            return true;
        }
        public bool sqlConnectCheck(string connectionString)
        {
            bool connectFlag = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connectFlag = true;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ShowWarning();
            }
            return connectFlag;
        }

        private void FrmsysDataBase_Load(object sender, EventArgs e)
        {
            using (var db = new DB())
            {
                grdList.DataSource = db.sysDataBase.ToList();
            }
        }
    }
}