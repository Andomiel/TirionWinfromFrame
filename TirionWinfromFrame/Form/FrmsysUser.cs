using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;
using DevExpress.XtraLayout;
using MES;
using MES.Entity;

namespace MES.Form
{
	public partial class FrmsysUser : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
        public FrmsysUser()
		{
			InitializeComponent();
		}
		private void FrmsysUser_Load(object sender, EventArgs e)
        {
            InitSearchDicData();
			InitFrom(xtraTabControl1, grdList, grdListView, new LayoutControlGroup[] { layoutControlGroup1 }, new sysUserInfo());
		}
		private void Init()
		{

			txtdeptId.Properties.DataSource = GetDataTableUtils.SqlTable("部门");
			repositoryItemtxtdeptId.DataSource = GetDataTableUtils.SqlTable("部门");
			txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");
			repositoryItemtxtcreatorId.DataSource = GetDataTableUtils.SqlTable("用户");
			txteditorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");
			repositoryItemtxteditorId.DataSource = GetDataTableUtils.SqlTable("用户");

        }
        private void InitSearchDicData()
        {
            fieldDictionary.Add("用户名", "username");
            fieldDictionary.Add("工号", "account");
        }
		public override bool SaveFunction()
		{
			try
			{
				sysUserInfo info = (sysUserInfo)this.ControlDataToModel(new sysUserInfo());
				using (var db = new MESDB())
				{
                    if (info.id == 0) //新增
                    {
                        info.password = MD5Utils.GetMD5_32("123456");
                        db.sysUserInfo.Add(info);
						
                    }
                    else
                    {
						db.Set<sysUserInfo>().Attach(info);
                        db.Entry(info).State = EntityState.Modified;
                        db.Entry<sysUserInfo>(info).Property("password").IsModified = false;
					}
                    db.SaveChanges();
					txtid.Text = info.id.ToString();
				}
			}
			catch (Exception ex)
			{
				ex.Message.ShowError();
				return false;
			}
			return true;
		}
		public override void InitgrdListDataSource()
		{
			using (var con = new MESDB())///
			{
				grdList.DataSource = con.sysUserInfo.ToList();
			}
            Init();
		}

		public override bool CheckInput()
		{
			if (string.IsNullOrEmpty(txtaccount.EditValue.ToString()))
			{
				"工号不能为空".ShowWarning();
				txtaccount.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtusername.EditValue.ToString()))
			{
				"用户名不能为空".ShowWarning();
				txtusername.Focus();
				return false;
			}
			//if (string.IsNullOrEmpty(txtpassword.EditValue.ToString()))
			//{
			//	"密码不能为空".ShowWarning();
			//	txtpassword.Focus();
			//	return false;
			//}
			if (string.IsNullOrEmpty(txtemail.EditValue.ToString()))
			{
				"邮件不能为空".ShowWarning();
				txtemail.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtmobilephone.EditValue.ToString()))
			{
				"电话不能为空".ShowWarning();
				txtmobilephone.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtdeptId.EditValue.ToString()))
			{
				"部门不能为空".ShowWarning();
				txtdeptId.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtisEnabled.EditValue.ToString()))
			{
				"有效不能为空".ShowWarning();
				txtisEnabled.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtcreatorId.EditValue.ToString()))
			{
				"创建人不能为空".ShowWarning();
				txtcreatorId.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtcreateTime.Text))
			{
				"创建时间不能为空".ShowWarning();
				txtcreateTime.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txteditorId.EditValue.ToString()))
			{
				"编辑人不能为空".ShowWarning();
				txteditorId.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txteditTime.Text))
			{
				"编辑时间不能为空".ShowWarning();
				txteditTime.Focus();
				return false;
			}
			return true;
		}
        public override void SearchFunction()
        {
            FrmSearch frm = new FrmSearch(fieldDictionary);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string sql = frm.sql;
                using (var db = new MESDB())
                {
                    if (string.IsNullOrEmpty(sql))
                    {
                        grdList.DataSource = db.sysUserInfo.SqlQuery("select * from sysUser").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.sysUserInfo.SqlQuery($"select * from sysUser where {sql}").ToList();
                    }
                }
            }
        }

        private void txtaccount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtid.Text))
            {
				using (var con = new MESDB())
                {
                    if (con.sysUserInfo.Where(p => p.account.Equals(txtaccount.Text)).Count() > 0)
                    {
                        txtaccount.Focus();
                        "工号已存在！".ShowWarning();
                    }
                }
			}
        }
        public override bool DelFunction()
        {
            try
            {
                sysUserInfo info = (sysUserInfo)this.ControlDataToModel(new sysUserInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ShowError();
                return false;
            }
            return true;
        }
	}
}