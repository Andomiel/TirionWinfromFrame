using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;
using DevExpress.XtraLayout;
using MES.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using DevExpress.Data.Helpers;

namespace MES.Form
{
	public partial class FrmsysFunction : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmsysFunction()
		{
			InitializeComponent();
		}
		private void FrmsysFunction_Load(object sender, EventArgs e)
        {
		
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new sysFunctionInfo());
            InitSearchDicData();
        }
        /// <summary>
		/// 数据源初始化
		/// </summary>
		/// <returns></returns>
		private void Init()
		{
            txtpid.Properties.DataSource = GetDataTableUtils.SqlTable("角色功能");     
            repositoryItemTreeListtxtpid.DataSource= GetDataTableUtils.SqlTable("角色功能");
           // txtToolBtnList.Properties.DataSource = GetDataTableUtils.SqlTable("功能按钮");
           

        }
        //public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        //{
        //    sysFunctionInfo user = grdListView.GetFocusedRow() as sysFunctionInfo;
        //    if (user != null)
        //    {
        //        using (var db=new MESDB())
        //        {
        //            List<int> list = db.sysFunctionInfo.Where(p => p.pid == user.id).Select(p=>p.toolBtnID).ToList();
        //            string value = "";
        //            foreach (int item in list)
        //            {
        //                value += item + ",";
        //            }
        //            txtToolBtnList.EditValue = value;
        //            this.txtToolBtnList.RefreshEditValue();
        //        }
        //    }
        //}
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
			fieldDictionary.Add("ID","id");     
			//fieldDictionary.Add("父ID","pid");     
			fieldDictionary.Add("名称","name");     
			fieldDictionary.Add("权限编码","functionCode");     
        }
        /// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            try
            {
                sysFunctionInfo info= (sysFunctionInfo)this.ControlDataToModel(new sysFunctionInfo());
                using (var db = new MESDB())
                {
                    db.sysFunctionInfo.AddOrUpdate(info);
                    db.SaveChanges();
                    txtid.Text = info.id.ToString();
                    //db.Database.ExecuteSqlCommand($"delete from sysFunction where pid={info.id}");
                    //List<sysToolButtonInfo> list = db.sysToolButtonInfo.ToList();
                    //string sql = "";
                    //foreach (var item in txtToolBtnList.EditValue.ToString().Split(','))
                    //{
                    //    sysToolButtonInfo info1 = list.Where(p => p.id == item.ToInt16()).First();
                    //    sql += $"INSERT INTO sysFunction(pid,name,functionCode,toolBtnID) VALUES ({info.id},'{info1.btnName}','{info.functionCode+"-"+info1.btnCode}',{info1.id});";
                    //}
                    //db.Database.ExecuteSqlCommand(sql);
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
				grdList.DataSource=con.sysFunctionInfo.ToList().OrderBy(p=>p.pid);
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
			if(string.IsNullOrEmpty(txtfunctionCode.EditValue.ToString()))
			{
				"权限编码不能为空".ShowWarning();
				txtfunctionCode.Focus();
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
                sysFunctionInfo info = (sysFunctionInfo)this.ControlDataToModel(new sysFunctionInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    db.Database.ExecuteSqlCommand($"delete from sysFunction where pid={info.id}");
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
                        grdList.DataSource = db.sysFunctionInfo.SqlQuery("select * from sysFunction").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.sysFunctionInfo.SqlQuery($"select * from sysFunction where {sql}").ToList();
                    }
                }
            }
        }
	}
}