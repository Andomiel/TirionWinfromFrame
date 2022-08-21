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
	public partial class FrmsysDictData : FrmBaseForm
	{
		public FrmsysDictData()
		{
			InitializeComponent();
		}
		private void FrmsysDictData_Load(object sender, EventArgs e)
        {

            InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new sysDictDataInfo());
        }
		private void Init()
		{
            txtdictTypeID.Properties.DataSource = GetDataTableUtils.SqlTable("字典类型");     
			repositoryItemTreeListtxtdictTypeID.DataSource= GetDataTableUtils.SqlTable("字典类型");  
			txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");  
			txteditorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxteditorId.DataSource= GetDataTableUtils.SqlTable("用户");
        }
		public override bool SaveFunction()
        {
            try
            {
                sysDictDataInfo info= (sysDictDataInfo)this.ControlDataToModel(new sysDictDataInfo());
                using (var db = new MESDB())
                {
                    db.sysDictDataInfo.AddOrUpdate(info);
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
				grdList.DataSource=con.sysDictDataInfo.ToList();
            }
            Init();
		}
	
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtdictTypeID.EditValue.ToString()))
			{
				"类型不能为空".ShowWarning();
				txtdictTypeID.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcode.EditValue.ToString()))
			{
				"编码不能为空".ShowWarning();
				txtcode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtvalue.EditValue.ToString()))
			{
				"值不能为空".ShowWarning();
				txtvalue.Focus();
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
				"editTime不能为空".ShowWarning();
				txteditTime.Focus();
				return false;
			}
			return true;
        }
		public override bool DelFunction()
        {
            try
            {
                sysDictDataInfo info = (sysDictDataInfo)this.ControlDataToModel(new sysDictDataInfo());
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