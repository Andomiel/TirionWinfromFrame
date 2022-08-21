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
	public partial class Frmmaterial : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmmaterial()
		{
			InitializeComponent();
		}
		private void Frmmaterial_Load(object sender, EventArgs e)
        {
		
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new materialInfo());
            InitSearchDicData();
        }
        /// <summary>
		/// 数据源初始化
		/// </summary>
		/// <returns></returns>
		private void Init()
		{
		
			


				txtunit.Properties.DataSource = GetDataTableUtils.SqlTable("计量单位");     
				repositoryItemtxtunit.DataSource= GetDataTableUtils.SqlTable("计量单位");  
				txtmaterialtype.Properties.DataSource = GetDataTableUtils.SqlTable("物料类别");     
				repositoryItemtxtmaterialtype.DataSource= GetDataTableUtils.SqlTable("物料类别");  
				txtwarehouse.Properties.DataSource = GetDataTableUtils.SqlTable("仓库");     
				repositoryItemtxtwarehouse.DataSource= GetDataTableUtils.SqlTable("仓库");  


		}
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
				fieldDictionary.Add("物料名称","name");     
				fieldDictionary.Add("物料编码","code");     
				fieldDictionary.Add("规格型号","spec");     
				fieldDictionary.Add("计量单位","unit");     
				fieldDictionary.Add("参考单价","referprice");     
				fieldDictionary.Add("物料类别","materialtype");     
				fieldDictionary.Add("仓库","warehouse");     
				fieldDictionary.Add("采购入库总量","POinnumber");     
				fieldDictionary.Add("退货出库总量","salereturnnumber");     
				fieldDictionary.Add("生产领料总量","YDProductConsume");     
				fieldDictionary.Add("生产退料总量","productmaterialreturn");     
				fieldDictionary.Add("库存数量","stocknumber");     
				fieldDictionary.Add("库存预警数量","stockwarnnumber");     
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
                materialInfo info= (materialInfo)this.ControlDataToModel(new materialInfo());
                using (var db = new MESDB())
                {
                    db.materialInfo.AddOrUpdate(info);
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
				grdList.DataSource=con.materialInfo.ToList();
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
				"物料名称不能为空".ShowWarning();
				txtname.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcode.EditValue.ToString()))
			{
				"物料编码不能为空".ShowWarning();
				txtcode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtspec.EditValue.ToString()))
			{
				"规格型号不能为空".ShowWarning();
				txtspec.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtunit.EditValue.ToString()))
			{
				"计量单位不能为空".ShowWarning();
				txtunit.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtreferprice.EditValue.ToString()))
			{
				"参考单价不能为空".ShowWarning();
				txtreferprice.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtmaterialtype.EditValue.ToString()))
			{
				"物料类别不能为空".ShowWarning();
				txtmaterialtype.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtwarehouse.EditValue.ToString()))
			{
				"仓库不能为空".ShowWarning();
				txtwarehouse.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtPOinnumber.EditValue.ToString()))
			{
				"采购入库总量不能为空".ShowWarning();
				txtPOinnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtsalereturnnumber.EditValue.ToString()))
			{
				"退货出库总量不能为空".ShowWarning();
				txtsalereturnnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtYDProductConsume.EditValue.ToString()))
			{
				"生产领料总量不能为空".ShowWarning();
				txtYDProductConsume.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductmaterialreturn.EditValue.ToString()))
			{
				"生产退料总量不能为空".ShowWarning();
				txtproductmaterialreturn.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtstocknumber.EditValue.ToString()))
			{
				"库存数量不能为空".ShowWarning();
				txtstocknumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtstockwarnnumber.EditValue.ToString()))
			{
				"库存预警数量不能为空".ShowWarning();
				txtstockwarnnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtremark.EditValue.ToString()))
			{
				"备注不能为空".ShowWarning();
				txtremark.Focus();
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
                materialInfo info = (materialInfo)this.ControlDataToModel(new materialInfo());
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
                        grdList.DataSource = db.materialInfo.SqlQuery("select * from material").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.materialInfo.SqlQuery($"select * from material where {sql}").ToList();
                    }
                }
            }
        }
	}
}