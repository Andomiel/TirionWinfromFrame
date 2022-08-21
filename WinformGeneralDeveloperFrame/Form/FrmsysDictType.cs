using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformGeneralDeveloperFrame;
using WinformGeneralDeveloperFrame.Commons;
using DevExpress.XtraLayout;
using MES.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity;
namespace MES.Form
{
	public partial class FrmsysDictType : FrmBaseForm
	{
		public FrmsysDictType()
		{
			InitializeComponent();
		}
		private void FrmsysDictType_Load(object sender, EventArgs e)
        {
            InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new sysDictTypeInfo());
        }
		private void Init()
		{
            txtpid.Properties.DataSource = GetDataTableUtils.SqlTable("字典类型");     
			repositoryItemTreeListtxtpid.DataSource= GetDataTableUtils.SqlTable("字典类型");  
			txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");  
			txteditorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxteditorId.DataSource= GetDataTableUtils.SqlTable("用户");  

		}
		public override bool SaveFunction()
        {
            try
            {
                sysDictTypeInfo info= (sysDictTypeInfo)this.ControlDataToModel(new sysDictTypeInfo());
                using (var db = new MESDB())
                {
                    db.sysDictTypeInfo.AddOrUpdate(info);
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
			using (var con=new MESDB())///
            {
				grdList.DataSource=con.sysDictTypeInfo.ToList().OrderBy(p=>p.pid);
            }
            Init();
        }

		public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtname.EditValue.ToString()))
			{
				"名称不能为空".ShowWarning();
				txtname.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtsort.EditValue.ToString()))
			{
				"排序不能为空".ShowWarning();
				txtsort.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcreatorId.EditValue.ToString()))
			{
				"创建人不能为空".ShowWarning();
				txtcreatorId.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcreateTime.Text))
			{
				"创建时间不能为空".ShowWarning();
				txtcreateTime.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txteditorId.EditValue.ToString()))
			{
				"编辑人不能为空".ShowWarning();
				txteditorId.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txteditTime.Text))
			{
				"编辑时间不能为空".ShowWarning();
				txteditTime.Focus();
				return false;
			}
			return true;
        }
		public override bool DelFunction()
        {
            try
            {
                sysDictTypeInfo info = (sysDictTypeInfo)this.ControlDataToModel(new sysDictTypeInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
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