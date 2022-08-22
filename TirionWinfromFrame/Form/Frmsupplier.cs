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
	public partial class Frmsupplier : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmsupplier()
		{
			InitializeComponent();
		}
		private void Frmsupplier_Load(object sender, EventArgs e)
        {
		
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new supplierInfo());
            InitSearchDicData();
        }
        /// <summary>
		/// 数据源初始化
		/// </summary>
		/// <returns></returns>
		private void Init()
		{
		
			


				txtmanufacturertype.Properties.DataSource = GetDataTableUtils.SqlTable("厂商类型");     
				repositoryItemtxtmanufacturertype.DataSource= GetDataTableUtils.SqlTable("厂商类型");  
				txtcontacts.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
				repositoryItemtxtcontacts.DataSource= GetDataTableUtils.SqlTable("用户");  
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
				fieldDictionary.Add("id","id");     
				fieldDictionary.Add("供应商名称","suppliername");     
				fieldDictionary.Add("厂商类型","manufacturertype");     
				fieldDictionary.Add("联系人","contacts");     
				fieldDictionary.Add("供应商地址","address");     
				fieldDictionary.Add("增值税税率","vatrate");     
				fieldDictionary.Add("纳税人识别号","taxpayeridentity");     
				fieldDictionary.Add("对方收款账号","bankaccount");     
				fieldDictionary.Add("供应商编号","suppliercode");     
				fieldDictionary.Add("应付款总额","payments");     
				fieldDictionary.Add("已结款总额","totalamountsettled");     
				fieldDictionary.Add("未结款总额","totaloutstandingamount");     
				fieldDictionary.Add("备注","remark");     
				fieldDictionary.Add("创建人","creatorId");     
				fieldDictionary.Add("创建时间","createTime");     
				fieldDictionary.Add("修改人","editorId");     
				fieldDictionary.Add("修改时间","editTime");     
        }
        /// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            try
            {
                supplierInfo info= (supplierInfo)this.ControlDataToModel(new supplierInfo());
                using (var db = new MESDB())
                {
                    db.supplierInfo.AddOrUpdate(info);
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
				grdList.DataSource=con.supplierInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtsuppliername.EditValue.ToString()))
			{
				"供应商名称不能为空".ShowWarning();
				txtsuppliername.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtmanufacturertype.EditValue.ToString()))
			{
				"厂商类型不能为空".ShowWarning();
				txtmanufacturertype.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcontacts.EditValue.ToString()))
			{
				"联系人不能为空".ShowWarning();
				txtcontacts.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtaddress.EditValue.ToString()))
			{
				"供应商地址不能为空".ShowWarning();
				txtaddress.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtvatrate.EditValue.ToString()))
			{
				"增值税税率不能为空".ShowWarning();
				txtvatrate.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txttaxpayeridentity.EditValue.ToString()))
			{
				"纳税人识别号不能为空".ShowWarning();
				txttaxpayeridentity.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtbankaccount.EditValue.ToString()))
			{
				"对方收款账号不能为空".ShowWarning();
				txtbankaccount.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtsuppliercode.EditValue.ToString()))
			{
				"供应商编号不能为空".ShowWarning();
				txtsuppliercode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtpayments.EditValue.ToString()))
			{
				"应付款总额不能为空".ShowWarning();
				txtpayments.Focus();
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
			if(string.IsNullOrEmpty(txtremark.EditValue.ToString()))
			{
				"备注不能为空".ShowWarning();
				txtremark.Focus();
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
				"修改人不能为空".ShowWarning();
				txteditorId.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txteditTime.Text))
			{
				"修改时间不能为空".ShowWarning();
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
                supplierInfo info = (supplierInfo)this.ControlDataToModel(new supplierInfo());
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
                        grdList.DataSource = db.supplierInfo.SqlQuery("select * from supplier").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.supplierInfo.SqlQuery($"select * from supplier where {sql}").ToList();
                    }
                }
            }
        }
	}
}