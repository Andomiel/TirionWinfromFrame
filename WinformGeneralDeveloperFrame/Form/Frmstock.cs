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
using System.Data.Entity.Migrations;
using System.Data.Entity;
using MES;
using MES.Entity;

namespace ERP.Form
{
	public partial class Frmstock : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmstock()
		{
			InitializeComponent();
		}
		private void Frmstock_Load(object sender, EventArgs e)
        {
		
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new stockInfo());
            InitSearchDicData();
        }
        /// <summary>
		/// 数据源初始化
		/// </summary>
		/// <returns></returns>
		private void Init()
		{
		
			




		}
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
				fieldDictionary.Add("仓库名称","name");     
        }
        /// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            try
            {
                stockInfo info= (stockInfo)this.ControlDataToModel(new stockInfo());
                using (var db = new MESDB())
                {
                    db.stockInfo.AddOrUpdate(info);
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
				grdList.DataSource=con.stockInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtname.EditValue.ToString()))
			{
				"仓库名称不能为空".ShowWarning();
				txtname.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtaddress.EditValue.ToString()))
			{
				"仓库地址不能为空".ShowWarning();
				txtaddress.Focus();
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
                stockInfo info = (stockInfo)this.ControlDataToModel(new stockInfo());
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
                        grdList.DataSource = db.stockInfo.SqlQuery("select * from stock").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.stockInfo.SqlQuery($"select * from stock where {sql}").ToList();
                    }
                }
            }
        }
	}
}