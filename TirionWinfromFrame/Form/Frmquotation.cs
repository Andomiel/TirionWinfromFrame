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
using System.Data.Entity;
using CCWin.SkinClass;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;

namespace MES.Form
{
	public partial class Frmquotation : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmquotation()
		{
			InitializeComponent();
		}
		private void Frmquotation_Load(object sender, EventArgs e)
        {
            InitFrom(xtraTabControl1,grdList,grdListView,new []{layoutControlGroup1},new quotationInfo(),gridControl1,new []{ "txtquotationcode" , "txtquotationdate", "txttotalprice" });
            InitSearchDicData();
            repositoryItemtxtproductid.EditValueChanged += RepositoryItemtxtproductid_EditValueChanged;
        }

        private void RepositoryItemtxtproductid_EditValueChanged(object sender, EventArgs e)
        {
            using (var db=new MESDB())
            {
                LookUpEdit look=sender as LookUpEdit;
                int productid = look.EditValue.ToInt32();
                productInfo product = db.productInfo.Where(p => p.id == productid).FirstOrDefault();
                DataTable dt=gridControl1.DataSource as DataTable;
                gridView1.GetFocusedDataRow()["spec"] = product.spec;
                gridView1.GetFocusedDataRow()["unit"] = product.unit;
                gridView1.GetFocusedDataRow()["stockid"] = product.warehouse;
                gridView1.GetFocusedDataRow()["productcode"] = product.productcode;
                gridView1.GetFocusedDataRow()["productname"] = product.productname;
            }
        }

        public override void InitFormFunction()
        {
            gridView1.BestFitColumns();
        }

        /// <summary>
        /// 数据源初始化
        /// </summary>
        /// <returns></returns>
        private void Init()
		{


                repositoryItemtxtproductid.DataSource = GetDataTableUtils.SqlTable("产品");
                repositoryItemtxtunit.DataSource = GetDataTableUtils.SqlTable("计量单位");
                repositoryItemtxtstockid.DataSource = GetDataTableUtils.SqlTable("仓库");

			    txtcustomerid.Properties.DataSource = GetDataTableUtils.SqlTable("客户");     
				repositoryItemtxtcustomerid.DataSource= GetDataTableUtils.SqlTable("客户");  
				txtcustomertype.Properties.DataSource = GetDataTableUtils.SqlTable("客户类别");     
				repositoryItemtxtcustomertype.DataSource= GetDataTableUtils.SqlTable("客户类别");  
				txtcustomeruser.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
				repositoryItemtxtcustomeruser.DataSource= GetDataTableUtils.SqlTable("用户");  
				txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
				repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");  

                
		}
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
				fieldDictionary.Add("id","id");     
				fieldDictionary.Add("客户","customerid");     
				fieldDictionary.Add("报价日期","quotationdate");     
				fieldDictionary.Add("客户编码","customercode");     
				fieldDictionary.Add("客户类型","customertype");     
				fieldDictionary.Add("联系人","customeruser");     
				fieldDictionary.Add("制单人","creatorId");     
				fieldDictionary.Add("送货地址","deliveraddress");     
				fieldDictionary.Add("报价单号","quotationcode");     
				fieldDictionary.Add("备注","remark");     
        }

		public override void InitgrdListDataSource()
        {
            using (var con=new MESDB())
            {
				grdList.DataSource=con.quotationInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtcustomerid.EditValue.ToString()))
			{
				"客户不能为空".ShowWarning();
				txtcustomerid.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtquotationdate.EditValue.ToString()))
			{
				"报价日期不能为空".ShowWarning();
				txtquotationdate.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcustomercode.EditValue.ToString()))
			{
				"客户编码不能为空".ShowWarning();
                
				txtcustomercode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcustomertype.EditValue.ToString()))
			{
				"客户类型不能为空".ShowWarning();
				txtcustomertype.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcustomeruser.EditValue.ToString()))
			{
				"联系人不能为空".ShowWarning();
				txtcustomeruser.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcreatorId.EditValue.ToString()))
			{
				"制单人不能为空".ShowWarning();
				txtcreatorId.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtdeliveraddress.EditValue.ToString()))
			{
				"送货地址不能为空".ShowWarning();
				txtdeliveraddress.Focus();
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
            string code = "KH" + DateTime.Now.GetDateTimeCode();
            DataTable dt=gridControl1.DataSource as DataTable;
            try
            {
                quotationInfo info = (quotationInfo)this.ControlDataToModel(new quotationInfo());
                using (var db = new MESDB())
                {
                    using (var tran =db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<quotationdetailInfo>> dic =
                                dt.GetDataTableData<quotationdetailInfo>();
                            ///新增
                            if (info.id == 0)
                            {
                                info.quotationcode = code;
                                db.quotationInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtquotationcode.Text = code;
                                if (dt != null)
                                {
                                    List<quotationdetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a=>
                                    {
                                        num ++;
                                        a.quotationid = info.id;
                                        string codedetail = code+num;
                                        a.quotationdetailcode = codedetail;
                                        a.quotationcode = info.quotationcode;
                                    });
                                    db.quotationdetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            ///修改
                            else
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<quotationdetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        a.quotationid = info.id;
                                        string codedetail = code+num;
                                        a.quotationdetailcode = codedetail;
                                        a.quotationcode = info.quotationcode;
                                    });
                                    db.quotationdetailInfo.AddRange(detaiListAdd);

                                    List<quotationdetailInfo> detaiListEdit =
                                        dic["Edit"];
                                    detaiListEdit.ForEach((a) =>
                                    {
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<quotationdetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) =>
                                    {
                                        db.Entry(a).State = EntityState.Deleted;
                                    });
                                    db.SaveChanges();
                                }
                            }
                            tran.Commit();
                            gridControl1.DataSource = db.quotationdetailInfo.ToList().Where(p => p.quotationid == info.id); ; ;
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
                quotationInfo info = (quotationInfo)this.ControlDataToModel(new quotationInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    db.Database.ExecuteSqlCommand($"delete from quotationdetail where quotationid={info.id}");
                    gridControl1.DataSource = null;
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
                        grdList.DataSource = db.quotationInfo.SqlQuery("select * from quotation").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.quotationInfo.SqlQuery($"select * from quotation where {sql}").ToList();
                    }
                }
            }
        }

        public override void AddFunction()
        {
            txtquotationdate.DateTime=DateTime.Now;
            gridControl1.DataSource = new List<quotationdetailInfo>().ToDataTable();
        }

        private void txtcustomerid_EditValueChanged(object sender, EventArgs e)
        {
            using (var db=new MESDB())
            {
                if (txtcustomerid.EditValue != null)
                {
                    int id = txtcustomerid.EditValue.ToString().ToInt16();
                    customerInfo customer = db.customerInfo.Where(p => p.id == id)
                        .First();
                    if (customer != null)
                    {
                        txtcustomercode.Text = customer.customercode;
                        txtcustomertype.EditValue = customer.customertype;
                        txtcustomeruser.EditValue = customer.contactuser;
                        txtdeliveraddress.Text = customer.address;
                        
                    }
                }
            }
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
			quotationInfo info = grdListView.GetFocusedRow() as quotationInfo;
            if (info != null)
            {
                using (var db=new MESDB())
                {
                    gridControl1.DataSource = db.quotationdetailInfo.Where(p => p.quotationid == info.id).ToList().ToDataTable();
                    gridView1.BestFitColumns();
                }
            }
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
                !string.IsNullOrEmpty(gridView1.GetFocusedDataRow()["number"].ToString()))
            {
                gridView1.GetFocusedDataRow()["money"] = decimal.Multiply(
                    gridView1.GetFocusedDataRow()["unitprice"].ToDecimal(0),
                    gridView1.GetFocusedDataRow()["number"].ToDecimal(0));
                                                         ;
            }
            gridView1.BestFitColumns();
            
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
        }

        private void gridControl1_Validated(object sender, EventArgs e)
        {
            txttotalprice.Text = gridColumn17.SummaryItem.SummaryValue.ToString();
        }
    }
}