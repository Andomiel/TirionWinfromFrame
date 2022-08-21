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
	public partial class Frmproduct : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmproduct()
		{
			InitializeComponent();
		}
		private void Frmproduct_Load(object sender, EventArgs e)
        {
		
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new productInfo());
            InitSearchDicData();
        }
        /// <summary>
		/// 数据源初始化
		/// </summary>
		/// <returns></returns>
		private void Init()
		{


			txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");
            repositoryItemtxtcreatorId.DataSource = GetDataTableUtils.SqlTable("用户");
            txteditorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");
            repositoryItemtxteditorId.DataSource = GetDataTableUtils.SqlTable("用户");
		    txtunit.Properties.DataSource = GetDataTableUtils.SqlTable("计量单位");     
			repositoryItemtxtunit.DataSource= GetDataTableUtils.SqlTable("计量单位");  
			txtwarehouse.Properties.DataSource = GetDataTableUtils.SqlTable("仓库");     
			repositoryItemtxtwarehouse.DataSource= GetDataTableUtils.SqlTable("仓库");  
			txtproducttype.Properties.DataSource = GetDataTableUtils.SqlTable("产品类别");     
			repositoryItemtxtproducttype.DataSource= GetDataTableUtils.SqlTable("产品类别");

            repositoryItemLookUpEditproductid.DataSource = GetDataTableUtils.SqlTable("产品");
            repositoryItemLookUpEditwarehouse.DataSource = GetDataTableUtils.SqlTable("仓库");
            gridColumn45.ColumnEdit = repositoryItemLookUpEditproductid;
            gridColumn34.ColumnEdit = repositoryItemtxtunit;
            gridColumn35.ColumnEdit = repositoryItemtxtwarehouse;
            gridColumn59.ColumnEdit = repositoryItemLookUpEditproductid;

			gridColumn49.ColumnEdit = repositoryItemtxtunit;
            gridColumn50.ColumnEdit = repositoryItemtxtwarehouse;

            gridColumn63.ColumnEdit = repositoryItemtxtunit;
            gridColumn64.ColumnEdit = repositoryItemtxtwarehouse;

		}
		/// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
		private void InitSearchDicData()
        {
				fieldDictionary.Add("产品名称","productname");     
				fieldDictionary.Add("仓库","warehouse");     
				fieldDictionary.Add("产品类别","producttype");     
				fieldDictionary.Add("产品编号","productcode");     
				fieldDictionary.Add("创建时间","createTime");     
        }
        /// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            try
            {
                productInfo info= (productInfo)this.ControlDataToModel(new productInfo());
                using (var db = new MESDB())
                {
                    db.productInfo.AddOrUpdate(info);
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
				grdList.DataSource=con.productInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtproductname.EditValue.ToString()))
			{
				"产品名称不能为空".ShowWarning();
				txtproductname.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtspec.EditValue.ToString()))
			{
				"规格不能为空".ShowWarning();
				txtspec.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtdefaultprice.EditValue.ToString()))
			{
				"默认单价不能为空".ShowWarning();
				txtdefaultprice.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtunit.EditValue.ToString()))
			{
				"计量单位不能为空".ShowWarning();
				txtunit.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtwarehouse.EditValue.ToString()))
			{
				"仓库不能为空".ShowWarning();
				txtwarehouse.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproducttype.EditValue.ToString()))
			{
				"产品类别不能为空".ShowWarning();
				txtproducttype.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductcode.EditValue.ToString()))
			{
				"产品编号不能为空".ShowWarning();
				txtproductcode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtstocknumber.EditValue.ToString()))
			{
				"库存不能为空".ShowWarning();
				txtstocknumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtstartnumber.EditValue.ToString()))
			{
				"期初数量不能为空".ShowWarning();
				txtstartnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtstartprice.EditValue.ToString()))
			{
				"期初总价不能为空".ShowWarning();
				txtstartprice.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductinnumber.EditValue.ToString()))
			{
				"生产入库数量不能为空".ShowWarning();
				txtproductinnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtsaleoutnumber.EditValue.ToString()))
			{
				"销售出库数量不能为空".ShowWarning();
				txtsaleoutnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcustomerreturnnumber.EditValue.ToString()))
			{
				"客户退货数量不能为空".ShowWarning();
				txtcustomerreturnnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtstockwarnnumber.EditValue.ToString()))
			{
				"库存预警数量不能为空".ShowWarning();
				txtstockwarnnumber.Focus();
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
                productInfo info = (productInfo)this.ControlDataToModel(new productInfo());
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
                        grdList.DataSource = db.productInfo.SqlQuery("select * from product").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.productInfo.SqlQuery($"select * from product where {sql}").ToList();
                    }
                }
            }
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            productInfo info = grdListView.GetFocusedRow() as productInfo;
			using (var db=new MESDB())
            {
                gridControl1.DataSource =
                    db.finishProductInInWarehouseDetailInfo.Where(p => p.productid == info.id).ToList();
				gridControl2.DataSource= db.saleOutWarehouseDetailInfo.Where(p => p.productid == info.id).ToList();
				gridControl3.DataSource=db.saleInWarehouseDetailInfo.Where(p => p.productID == info.id).ToList();
			}
        }
    }
}