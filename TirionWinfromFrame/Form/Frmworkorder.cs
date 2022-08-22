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
using CCWin.SkinClass;

namespace MES.Form
{
	public partial class Frmworkorder : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmworkorder()
		{
			InitializeComponent();
		}
		private void Frmworkorder_Load(object sender, EventArgs e)
        {
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new workorderInfo(),gridControl1,new []{ "txtwordordercode", "txtsalecode" });
            InitSearchDicData();
        }
        /// <summary>
		/// 数据源初始化
		/// </summary>
		/// <returns></returns>
		private void Init()
		{
			txtworkordertype.Properties.DataSource = GetDataTableUtils.SqlTable("工单类型");     
			repositoryItemtxtworkordertype.DataSource= GetDataTableUtils.SqlTable("工单类型");  
			txtproductdept.Properties.DataSource = GetDataTableUtils.SqlTable("部门");     
			repositoryItemtxtproductdept.DataSource= GetDataTableUtils.SqlTable("部门");  
			txtproductid.Properties.DataSource = GetDataTableUtils.SqlTable("产品");     
			repositoryItemtxtproductid.DataSource= GetDataTableUtils.SqlTable("产品");  
			txtunit.Properties.DataSource = GetDataTableUtils.SqlTable("计量单位");     
			repositoryItemtxtunit.DataSource= GetDataTableUtils.SqlTable("计量单位");  
			txtwarehouse.Properties.DataSource = GetDataTableUtils.SqlTable("仓库");     
			repositoryItemtxtwarehouse.DataSource= GetDataTableUtils.SqlTable("仓库");  
			txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");
            txtproducttype.Properties.DataSource = GetDataTableUtils.SqlTable("产品类别");
            repositoryItemLookUpEditmaterialid.DataSource = GetDataTableUtils.SqlTable("物料");
            repositoryItemLookUpEditmaterialtype.DataSource = GetDataTableUtils.SqlTable("物料类别");
        }
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
			fieldDictionary.Add("id","id");     
			fieldDictionary.Add("工单号","wordordercode");     
			fieldDictionary.Add("销售单号","salecode");     
			fieldDictionary.Add("销售明细单号","saledetailcode");     
			fieldDictionary.Add("工单类型","workordertype");     
			fieldDictionary.Add("生产日期","productdate");     
			fieldDictionary.Add("生产单位","productdept");     
			fieldDictionary.Add("产品编号","productcode");     
			fieldDictionary.Add("产品名称","productid");     
			fieldDictionary.Add("规格型号","spec");     
			fieldDictionary.Add("生产数量","productnumber");     
			fieldDictionary.Add("计量单位","unit");     
			fieldDictionary.Add("完工日期","finishdate");     
			fieldDictionary.Add("交货日期","deliverdate");     
			fieldDictionary.Add("仓库","warehouse");     
			fieldDictionary.Add("制单人","creatorId");     
			fieldDictionary.Add("制单日期","createTime");     
			fieldDictionary.Add("备注","remark");     
        }

		public override void InitgrdListDataSource()
        {
            using (var con=new MESDB())
            {
				grdList.DataSource=con.workorderInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			//if(string.IsNullOrEmpty(txtwordordercode.EditValue.ToString()))
			//{
			//	"工单号不能为空".ShowWarning();
			//	txtwordordercode.Focus();
			//	return false;
			//}
			//if(string.IsNullOrEmpty(txtsalecode.EditValue.ToString()))   
			//{
			//	"销售单号不能为空".ShowWarning();
			//	txtsalecode.Focus();
			//	return false;
			//}
			//if(string.IsNullOrEmpty(txtsaledetailcode.EditValue.ToString()))
			//{
			//	"销售明细单号不能为空".ShowWarning();
			//	txtsaledetailcode.Focus();
			//	return false;
			//}
			if(string.IsNullOrEmpty(txtworkordertype.EditValue.ToString()))
			{
				"工单类型不能为空".ShowWarning();
				txtworkordertype.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductdate.EditValue.ToString()))
			{
				"生产日期不能为空".ShowWarning();
				txtproductdate.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductdept.EditValue.ToString()))
			{
				"生产单位不能为空".ShowWarning();
				txtproductdept.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductcode.EditValue.ToString()))
			{
				"产品编号不能为空".ShowWarning();
				txtproductcode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductid.EditValue.ToString()))
			{
				"产品名称不能为空".ShowWarning();
				txtproductid.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtspec.EditValue.ToString()))
			{
				"规格型号不能为空".ShowWarning();
				txtspec.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductnumber.EditValue.ToString()))
			{
				"生产数量不能为空".ShowWarning();
				txtproductnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtunit.EditValue.ToString()))
			{
				"计量单位不能为空".ShowWarning();
				txtunit.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtfinishdate.EditValue.ToString()))
			{
				"完工日期不能为空".ShowWarning();
				txtfinishdate.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtdeliverdate.EditValue.ToString()))
			{
				"交货日期不能为空".ShowWarning();
				txtdeliverdate.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtwarehouse.EditValue.ToString()))
			{
				"仓库不能为空".ShowWarning();
				txtwarehouse.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcreatorId.EditValue.ToString()))
			{
				"制单人不能为空".ShowWarning();
				txtcreatorId.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcreateTime.Text))
			{
				"制单日期不能为空".ShowWarning();
				txtcreateTime.Focus();
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
                workorderInfo info= (workorderInfo)this.ControlDataToModel(new workorderInfo());
                
				using (var db = new MESDB())
                {
                    if (info.id == 0) //新增
                    {
                        string code = "GD" + DateTime.Now.GetDateTimeCode();
                        info.wordordercode = code;
						db.workorderInfo.Add(info);
                        db.SaveChanges();
					}
                    else
                    {
                        db.Entry(info).State = EntityState.Modified;
                        db.SaveChanges();
					}
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
                workorderInfo info = (workorderInfo)this.ControlDataToModel(new workorderInfo());
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
                        grdList.DataSource = db.workorderInfo.SqlQuery("select * from workorder").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.workorderInfo.SqlQuery($"select * from workorder where {sql}").ToList();
                    }
                }
            }
        }

        public override void AddFunction()
        {
            gridControl1.DataSource = null;
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
			using (var db = new MESDB())
            {
                productBOMInfo info = db.productBOMInfo.Find(txtbomid.EditValue);
                List<productBOMdetailInfo> boMdetailInfo =
                    db.productBOMdetailInfo.Where(p => p.productBOMid == info.id).ToList();
                List<productionBOMInfo> list = new List<productionBOMInfo>();
                foreach (var item in boMdetailInfo)
                {
                    productionBOMInfo info1 = new productionBOMInfo()
                    {
                        number = txtproductnumber.Text.ToDecimal(1),
                        materialcode = item.materialcode,
                        materialid = item.materialid,
                        materialtype = item.materialtype,
                        spec = item.materialspec,
                        uintnumber = item.unitusenumber,
                        neednumber = item.unitusenumber * txtproductnumber.Text.ToDecimal(1),
                        unit = item.unit,
                        unitprice = item.unitprice,
                        totalprice = item.unitprice * txtproductnumber.Text.ToDecimal(1) * item.unitusenumber,
                        warehouse = item.warehouse,
                        remark = item.remark
                    };
                    list.Add(info1);
                }

                gridControl1.DataSource = list;

            }
		}

        private void txtsaledetailcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                using (var db=new MESDB())
                {
                    var list= db.saledetailInfo
                        .Where(p => p.saledetailcode == txtsaledetailcode.Text.ToUpper()).ToList();
                    if (list.Count > 0)
                    {
                        saledetailInfo info = list[0];
                        txtsalecode.Text = info.salecode;
                        txtproductid.EditValue = info.productid;
                        txtproductcode.Text = info.productcode;
                        txtspec.Text = info.productspec;
                        txtproductnumber.Text = info.salenumber.ToString();
                        txtunit.EditValue = info.unit;
                        txtdeliverdate.DateTime = info.deliverdate;
                        txtwarehouse.EditValue = info.warehouse;
                        txtbomid.Properties.DataSource = db.productBOMInfo.Where(p => p.productid == info.productid)
                            .Select(p => new { ID=p.productid,Name=p.version}).ToList();
                    }
                }
            }
        }

        private void txtproductid_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {
                productInfo info = db.productInfo.Find(txtproductid.EditValue);
                var list = db.productBOMInfo.Where(p => p.productid == info.id)
                    .Select(p => new {ID = p.id, Name = p.version}).ToList();
                txtbomid.Properties.DataSource = list;
                txtproducttype.EditValue = info.producttype;
                txtproductcode.Text = info.productcode;
                txtunit.EditValue = info.unit;
                txtwarehouse.EditValue = info.warehouse;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtproductid.Text) && !string.IsNullOrEmpty(txtbomid.Text))
            {
                using (var db = new MESDB())
                {
                    productBOMInfo info = db.productBOMInfo.Find(txtbomid.EditValue);
                    List<productBOMdetailInfo> boMdetailInfo =
                        db.productBOMdetailInfo.Where(p => p.productBOMid == info.id).ToList();
                    List<productionBOMInfo> list = new List<productionBOMInfo>();
                    foreach (var item in boMdetailInfo)
                    {
                        productionBOMInfo info1 = new productionBOMInfo()
                        {
							number = txtproductnumber.Text.ToDecimal(1),
							materialcode = item.materialcode,
							materialid = item.materialid,
							materialtype = item.materialtype,
							spec = item.materialspec,
                            uintnumber=item.unitusenumber,
                            neednumber=item.unitusenumber * txtproductnumber.Text.ToDecimal(1),
							unit=item.unit,
                            unitprice=item.unitprice,
							totalprice = item.unitprice * txtproductnumber.Text.ToDecimal(1)* item.unitusenumber,
							warehouse = item.warehouse,
							remark = item.remark
						};
						list.Add(info1);
                    }

                    gridControl1.DataSource = list;

                }
            }
        }
    }
}