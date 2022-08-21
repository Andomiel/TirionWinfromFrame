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
	public partial class FrmsysDept : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmsysDept()
		{
			InitializeComponent();
		}
		private void FrmsysDept_Load(object sender, EventArgs e)
        {
		
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new sysDeptInfo());
            InitSearchDicData();
        }
        /// <summary>
		/// 数据源初始化
		/// </summary>
		/// <returns></returns>
		private void Init()
		{
		
			


				txtpid.Properties.DataSource = GetDataTableUtils.SqlTable("部门");     
				repositoryItemTreeListtxtpid.DataSource= GetDataTableUtils.SqlTable("部门");  
				txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
				repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");  
				txteditorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
				repositoryItemtxteditorId.DataSource= GetDataTableUtils.SqlTable("用户");  


		}
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
				fieldDictionary.Add("ID","id");     
				//fieldDictionary.Add("父ID","pid");     
				fieldDictionary.Add("名称","name");     
				fieldDictionary.Add("地址","address");     
				fieldDictionary.Add("电话","phone");     
				//fieldDictionary.Add("创建人","creatorId");     
				fieldDictionary.Add("创建时间","createTime");     
				//fieldDictionary.Add("编辑人","editorId");     
				fieldDictionary.Add("编辑时间","editTime");     
        }
        /// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            try
            {
                sysDeptInfo info= (sysDeptInfo)this.ControlDataToModel(new sysDeptInfo());
                using (var db = new MESDB())
                {
                    db.sysDeptInfo.AddOrUpdate(info);
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
				grdList.DataSource=con.sysDeptInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			//if(string.IsNullOrEmpty(txtpid.EditValue.ToString()))
			//{
			//	"父ID不能为空".ShowWarning();
			//	txtpid.Focus();
			//	return false;
			//}
			if(string.IsNullOrEmpty(txtname.EditValue.ToString()))
			{
				"名称不能为空".ShowWarning();
				txtname.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtaddress.EditValue.ToString()))
			{
				"地址不能为空".ShowWarning();
				txtaddress.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtphone.EditValue.ToString()))
			{
				"电话不能为空".ShowWarning();
				txtphone.Focus();
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
        /// <summary>
		/// 删除
		/// </summary>
		/// <returns></returns>
		public override bool DelFunction()
        {
            try
            {
                sysDeptInfo info = (sysDeptInfo)this.ControlDataToModel(new sysDeptInfo());
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
        /// <summary>
		/// 搜索
		/// </summary>
		/// <returns></returns>
        public override void SearchFunction()
        {
            FrmSearch frm = new FrmSearch(fieldDictionary);
            if (frm.ShowDialog()==DialogResult.OK)
            {
                string sql = frm.sql;
                using (var db = new MESDB())
                {
                    if (string.IsNullOrEmpty(sql))
                    {
                        grdList.DataSource = db.sysDeptInfo.SqlQuery("select * from sysDept").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.sysDeptInfo.SqlQuery($"select * from sysDept where {sql}").ToList();
                    }
                }
            }
        }
	}
}