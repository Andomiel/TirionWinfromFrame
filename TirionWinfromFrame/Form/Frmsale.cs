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
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraRichEdit.Layout;

namespace MES.Form
{
	public partial class Frmsale : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmsale()///22
		{
			InitializeComponent();
		}
		private void Frmsale_Load(object sender, EventArgs e)
        {
		
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new saleInfo(),gridControl1,new string[]{ "txtsaleordercode" });
            InitSearchDicData();
            repositoryItemGridLookUpEdit1.EditValueChanged += RepositoryItemGridLookUpEdit1_EditValueChanged;	
        }


        /// <summary>
        /// 数据源初始化
        /// </summary>
        /// <returns></returns>
        private void Init()
		{
            txtcustomerid.Properties.DataSource = GetDataTableUtils.SqlTable("客户");     
			repositoryItemtxtcustomerid.DataSource= GetDataTableUtils.SqlTable("客户");  
			txtcustomertype.Properties.DataSource = GetDataTableUtils.SqlTable("客户类别");     
			repositoryItemtxtcustomertype.DataSource= GetDataTableUtils.SqlTable("客户类别");  
			txtcontactuser.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtcontactuser.DataSource= GetDataTableUtils.SqlTable("用户");  
			txtsalesman.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtsalesman.DataSource= GetDataTableUtils.SqlTable("用户");  
			txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtpreparedby.DataSource= GetDataTableUtils.SqlTable("用户");  
            repositoryItemtxtunit.DataSource = GetDataTableUtils.SqlTable("计量单位");
            repositoryItemtxtwarehouse.DataSource = GetDataTableUtils.SqlTable("仓库");
            txtcreatorId.Properties.DataSource= GetDataTableUtils.SqlTable("用户");
        }
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
			fieldDictionary.Add("销售单号","saleordercode");     
			fieldDictionary.Add("订单日期","orderdate");     
			fieldDictionary.Add("客户单号","customerordercode");     
			fieldDictionary.Add("业务员","salesman");     
			fieldDictionary.Add("完货日期","finishdate");     
			fieldDictionary.Add("制单人", "creatorId");     
        }

		public override void InitgrdListDataSource()
        {
			 using (var con=new MESDB())///
            {
				grdList.DataSource=con.saleInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
            if(string.IsNullOrEmpty(txtorderdate.EditValue.ToString()))
			{
				"订单日期不能为空".ShowWarning();
				txtorderdate.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcustomerid.EditValue.ToString()))
			{
				"客户不能为空".ShowWarning();
				txtcustomerid.Focus();
				return false;
			}
            if(string.IsNullOrEmpty(txtcustomertype.EditValue.ToString()))
			{
				"客户类型不能为空".ShowWarning();
				txtcustomertype.Focus();
				return false;
			}
            if(string.IsNullOrEmpty(txtcontactuser.EditValue.ToString()))
			{
				"联系人不能为空".ShowWarning();
				txtcontactuser.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcontactphone.EditValue.ToString()))
			{
				"联系电话不能为空".ShowWarning();
				txtcontactphone.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtdeliveraddress.EditValue.ToString()))
			{
				"送货地址不能为空".ShowWarning();
				txtdeliveraddress.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtsalesman.EditValue.ToString()))
			{
				"业务员不能为空".ShowWarning();
				txtsalesman.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtfinishdate.EditValue.ToString()))
			{
				"完货日期不能为空".ShowWarning();
				txtfinishdate.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcreatorId.EditValue.ToString()))
			{
				"制单人不能为空".ShowWarning();
				txtcreatorId.Focus();
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
            string code = "SO" + DateTime.Now.GetDateTimeCode();
            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                saleInfo info= (saleInfo)this.ControlDataToModel(new saleInfo());
                using (var db = new MESDB())
                {
                    using (var tran=db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<saledetailInfo>> dic =
                                dt.GetDataTableData<saledetailInfo>();
                            if (info.id == 0)//新增
                            {
                                info.saleordercode = code;
                                db.saleInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtsaleordercode.Text = code;
                                if (dt != null)
                                {
                                    List<saledetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        a.saleid = info.id;
                                        a.salecode = info.saleordercode;
                                        string codeD = code+num;
                                        a.saledetailcode = codeD;
                                    });
                                    db.saledetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<saledetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        a.saleid = info.id;
                                        a.salecode = info.saleordercode;
                                        string codeD = code+num;
                                        a.saledetailcode = codeD;
                                    });
                                    db.saledetailInfo.AddRange(detaiListAdd);

                                    List<saledetailInfo> detaiListEdit =
                                        dic["Edit"];
                                    detaiListEdit.ForEach((a) =>
                                    {
                                        a.salecode = info.saleordercode;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<saledetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) =>
                                    {
                                        db.Entry(a).State = EntityState.Deleted;
                                    });
                                    db.SaveChanges();
                                }
                            }
                            tran.Commit();
                            gridControl1.DataSource = db.saledetailInfo.ToList().Where(p => p.saleid == info.id); ; ;
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ex.Message.ShowError();
                            return false;
                        }
                        finally
                        {
                            tran.Dispose();
                        }
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
                saleInfo info = (saleInfo)this.ControlDataToModel(new saleInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    db.Database.ExecuteSqlCommand($"delete from saledetail where saleid={info.id}");
                    db.SaveChanges();
                }
                gridControl1.DataSource = null;
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
                        grdList.DataSource = db.saleInfo.SqlQuery("select * from sale").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.saleInfo.SqlQuery($"select * from sale where {sql}").ToList();
                    }
                }
            }
        }

        public override void EditFunction()
        {
            txtcustomerid.ReadOnly = true;
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            Initresgridcontrollookupedit();
            saleInfo info = grdListView.GetFocusedRow() as saleInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.saledetailInfo.Where(p => p.saleid == info.id).ToList().ToDataTable();
                    gridView1.BestFitColumns();
                    quotationInfo quotation = db.quotationInfo.Where(p => p.customeruser == info.customerid).ToList()
                        .FirstOrDefault();

                    repositoryItemGridLookUpEdit1.DataSource =
                        db.quotationdetailInfo.ToList().Where(p => p.quotationid == quotation.id);
                }
            }
		}
		public override void AddFunction()
        {
            txtorderdate.DateTime = DateTime.Now;
            gridControl1.DataSource = new List<saledetailInfo>().ToDataTable();
        }
		private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

		private void toolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (string.IsNullOrEmpty(gridView1.GetFocusedDataRow()["productid"].ToString()))
            {
                "请选择产品".ShowTips();
                return;
            }

            if (!string.IsNullOrEmpty(gridView1.GetFocusedDataRow()["unitprice"].ToString()) &&
                !string.IsNullOrEmpty(gridView1.GetFocusedDataRow()["salenumber"].ToString()))
            {
                gridView1.GetFocusedDataRow()["money"] = decimal.Multiply(
                    gridView1.GetFocusedDataRow()["unitprice"].ToDecimal(0),
                    gridView1.GetFocusedDataRow()["salenumber"].ToDecimal(0));
                ;
            }
            gridView1.BestFitColumns();
        }

        private void txtcustomerid_EditValueChanged(object sender, EventArgs e)
        {
            Initresgridcontrollookupedit();
            using (var db = new MESDB())
            {
                repositoryItemGridLookUpEdit1.DataSource = db.Database.SqlQuery<quotationdetailInfo>($"SELECT qt.* FROM quotation q left join quotationdetail qt on q.id = qt.quotationid where q.customerid = {txtcustomerid.EditValue}").ToDataTable();
                if (txtcustomerid.EditValue != null)
                {
                    int id = txtcustomerid.EditValue.ToString().ToInt16();
                    customerInfo customer = db.customerInfo.Find(id);
                    if (customer != null)
                    {
                        txtcustomercode.Text = customer.customercode;
                        txtcustomertype.EditValue = customer.customertype;
                        txtcontactuser.EditValue = customer.contactuser;
                        txtdeliveraddress.Text = customer.address;
                        txtcontactphone.Text = customer.phonenumber;
                    }
                }
            }
		}
        private void Initresgridcontrollookupedit()
        {
            GridColumn col1 = new GridColumn(){Caption = "产品",FieldName = "productid",Visible = false};
            GridColumn col7 = new GridColumn() { Caption = "产品名称", FieldName = "productname", Visible = true };
            GridColumn col2 = new GridColumn() { Caption = "规格", FieldName = "spec", Visible = true };
            GridColumn col3 = new GridColumn() { Caption = "报价数量", FieldName = "number", Visible = true };
            GridColumn col5 = new GridColumn() { Caption = "单价", FieldName = "unitprice", Visible = true };
            GridColumn col6 = new GridColumn() { Caption = "金额", FieldName = "money", Visible = true };
            GridColumn col4 = new GridColumn() { Caption = "id", FieldName = "id", Visible = false };
            repositoryItemGridLookUpEdit1View.Columns.AddRange(new GridColumn[]{col1, col7, col2,col3,col5,col6,col4});
        }

        private void RepositoryItemGridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {
                GridLookUpEdit look = sender as GridLookUpEdit;
                quotationdetailInfo quotationdetail = look.Properties.View.GetFocusedDataRow().RowToModel<quotationdetailInfo>();
                gridView1.GetFocusedDataRow()["productspec"] = quotationdetail.spec;
                gridView1.GetFocusedDataRow()["unit"] = quotationdetail.unit;
                gridView1.GetFocusedDataRow()["warehouse"] = quotationdetail.stockid;
                gridView1.GetFocusedDataRow()["productcode"] = quotationdetail.productcode;
                gridView1.GetFocusedDataRow()["productid"] = quotationdetail.productid;
                gridView1.GetFocusedDataRow()["unitprice"] = quotationdetail.unitprice;
                gridView1.GetFocusedDataRow()["salenumber"] = quotationdetail.number;
            }
        }
    }
}