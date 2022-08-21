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
	public partial class FrmproductionBOM : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmproductionBOM()
		{
			InitializeComponent();
		}
		private void FrmproductionBOM_Load(object sender, EventArgs e)
        {
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new productionBOMInfo());
            InitSearchDicData();
        }
        /// <summary>
		/// 数据源初始化
		/// </summary>
		/// <returns></returns>
		private void Init()
		{
			txtmaterialid.Properties.DataSource = GetDataTableUtils.SqlTable("物料");     
			repositoryItemtxtmaterialid.DataSource= GetDataTableUtils.SqlTable("物料");  
			txtmaterialtype.Properties.DataSource = GetDataTableUtils.SqlTable("物料类别");     
			repositoryItemtxtmaterialtype.DataSource= GetDataTableUtils.SqlTable("物料类别");  
			txtunit.Properties.DataSource = GetDataTableUtils.SqlTable("计量单位");     
			repositoryItemtxtunit.DataSource= GetDataTableUtils.SqlTable("计量单位");  
			txtwarehouse.Properties.DataSource = GetDataTableUtils.SqlTable("仓库");     
			repositoryItemtxtwarehouse.DataSource= GetDataTableUtils.SqlTable("仓库");  
		}
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
			fieldDictionary.Add("工程BOM编号","projectBOMcode");     
			fieldDictionary.Add("生产BOM编号","productionBOMcode");     
			fieldDictionary.Add("物料编码","materialcode");     
			fieldDictionary.Add("物料名称","materialid");     
        }

		public override void InitgrdListDataSource()
        {
			 using (var con=new MESDB())///
            {
				grdList.DataSource=con.productionBOMInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtprojectBOMcode.EditValue.ToString()))
			{
				"工程BOM编号不能为空".ShowWarning();
				txtprojectBOMcode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductionBOMcode.EditValue.ToString()))
			{
				"生产BOM编号不能为空".ShowWarning();
				txtproductionBOMcode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtnumber.EditValue.ToString()))
			{
				"产品生产数量不能为空".ShowWarning();
				txtnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtmaterialcode.EditValue.ToString()))
			{
				"物料编码不能为空".ShowWarning();
				txtmaterialcode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtmaterialid.EditValue.ToString()))
			{
				"物料名称不能为空".ShowWarning();
				txtmaterialid.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtspec.EditValue.ToString()))
			{
				"规格型号不能为空".ShowWarning();
				txtspec.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtmaterialtype.EditValue.ToString()))
			{
				"物料类型不能为空".ShowWarning();
				txtmaterialtype.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtuintnumber.EditValue.ToString()))
			{
				"单位用量不能为空".ShowWarning();
				txtuintnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtneednumber.EditValue.ToString()))
			{
				"需求总量不能为空".ShowWarning();
				txtneednumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtunit.EditValue.ToString()))
			{
				"计量单位不能为空".ShowWarning();
				txtunit.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtunitprice.EditValue.ToString()))
			{
				"单价不能为空".ShowWarning();
				txtunitprice.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txttotalprice.EditValue.ToString()))
			{
				"总价不能为空".ShowWarning();
				txttotalprice.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtwarehouse.EditValue.ToString()))
			{
				"仓库不能为空".ShowWarning();
				txtwarehouse.Focus();
				return false;
			}
			return true;
        }
        /// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            try
            {
                productionBOMInfo info= (productionBOMInfo)this.ControlDataToModel(new productionBOMInfo());
                using (var db = new MESDB())
                {
                    db.productionBOMInfo.AddOrUpdate(info);
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
		/// 删除
		/// </summary>
		/// <returns></returns>
		public override bool DelFunction()
        {
            try
            {
                productionBOMInfo info = (productionBOMInfo)this.ControlDataToModel(new productionBOMInfo());
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
                        grdList.DataSource = db.productionBOMInfo.SqlQuery("select * from productionBOM").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.productionBOMInfo.SqlQuery($"select * from productionBOM where {sql}").ToList();
                    }
                }
            }
        }
	}
}