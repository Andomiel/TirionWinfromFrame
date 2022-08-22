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
namespace MES.Form
{
	public partial class Frmcustomer : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmcustomer()
		{
			InitializeComponent();
		}
		private void Frmcustomer_Load(object sender, EventArgs e)
        {
		
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new customerInfo());
            InitSearchDicData();
        }
        /// <summary>
		/// 数据源初始化
		/// </summary>
		/// <returns></returns>
		private void Init()
		{
			txtcustomertype.Properties.DataSource = GetDataTableUtils.SqlTable("客户类别");     
			repositoryItemtxtcustomertype.DataSource= GetDataTableUtils.SqlTable("客户类别");  
			txtcontactuser.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtcontactuser.DataSource= GetDataTableUtils.SqlTable("用户");  
		}
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
				fieldDictionary.Add("id","id");     
				fieldDictionary.Add("客户名称","customername");     
				fieldDictionary.Add("客户类别","customertype");     
				fieldDictionary.Add("联系人","contactuser");     
				fieldDictionary.Add("客户地址","address");     
				fieldDictionary.Add("期初应收款","startreceipt");     
				fieldDictionary.Add("客户编号","customercode");     
				fieldDictionary.Add("应收款总额","totalreceivables");     
				fieldDictionary.Add("已结款总额","totalamountsettled");     
				fieldDictionary.Add("未结款总额","totaloutstandingamount");     
				fieldDictionary.Add("备注","remark");     
        }
        /// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            try
            {
                customerInfo info= (customerInfo)this.ControlDataToModel(new customerInfo());
                using (var db = new MESDB())
                {
                    db.customerInfo.AddOrUpdate(info);
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
				grdList.DataSource=con.customerInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtcustomername.EditValue.ToString()))
			{
				"客户名称不能为空".ShowWarning();
				txtcustomername.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcustomertype.EditValue.ToString()))
			{
				"客户类别不能为空".ShowWarning();
				txtcustomertype.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcontactuser.EditValue.ToString()))
			{
				"联系人不能为空".ShowWarning();
				txtcontactuser.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtaddress.EditValue.ToString()))
			{
				"客户地址不能为空".ShowWarning();
				txtaddress.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtstartreceipt.EditValue.ToString()))
			{
				"期初应收款不能为空".ShowWarning();
				txtstartreceipt.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcustomercode.EditValue.ToString()))
			{
				"客户编号不能为空".ShowWarning();
				txtcustomercode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txttotalreceivables.EditValue.ToString()))
			{
				"应收款总额不能为空".ShowWarning();
				txttotalreceivables.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txttotalamountsettled.EditValue.ToString()))
			{
				"已结款总额不能为空".ShowWarning();
				txttotalamountsettled.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txttotaloutstandingamount.EditValue.ToString()))
			{
				"未结款总额不能为空".ShowWarning();
				txttotaloutstandingamount.Focus();
				return false;
			}
			//if(string.IsNullOrEmpty(txtremark.EditValue.ToString()))
			//{
			//	"备注不能为空".ShowWarning();
			//	txtremark.Focus();
			//	return false;
			//}
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
                customerInfo info = (customerInfo)this.ControlDataToModel(new customerInfo());
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
                        grdList.DataSource = db.customerInfo.SqlQuery("select * from customer").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.customerInfo.SqlQuery($"select * from customer where {sql}").ToList();
                    }
                }
            }
        }
	}
}