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
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace MES.Form
{
	public partial class Frmdeliversale : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmdeliversale()
		{
			InitializeComponent();
		}
		private void Frmdeliversale_Load(object sender, EventArgs e)
        {
            InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new deliversaleInfo(),gridControl1,new string[]{ "txtdeliversalecode" });
            InitSearchDicData();
            repositoryItemGridLookUpEditsalecode.EditValueChanged += RepositoryItemGridLookUpEditsalecode_EditValueChanged;
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
			txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");

			repositoryItemLookUpEditunit.DataSource=GetDataTableUtils.SqlTable("计量单位");
            repositoryItemLookUpEditwarehouse.DataSource = GetDataTableUtils.SqlTable("仓库");
        }
		/// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
		private void InitSearchDicData()
        {
			fieldDictionary.Add("客户编号","customercode");     
			fieldDictionary.Add("出货日期","deliverdate");     
			fieldDictionary.Add("出货单号","deliversalecode");     
        }

		public override void InitgrdListDataSource()
        {
			using (var con=new MESDB())
            {
				grdList.DataSource=con.deliversaleInfo.ToList();
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
			if(string.IsNullOrEmpty(txtcustomercode.EditValue.ToString()))
			{
				"客户编号不能为空".ShowWarning();
				txtcustomercode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtdeliverdate.Text.ToString()))
			{
				"出货日期不能为空".ShowWarning();
				txtdeliverdate.Focus();
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
			if(string.IsNullOrEmpty(txtdeliveraddress.EditValue.ToString()))
			{
				"送货地址不能为空".ShowWarning();
				txtdeliveraddress.Focus();
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
            string code = "SD" +DateTime.Now.GetDateTimeCode();

            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                deliversaleInfo info= (deliversaleInfo)this.ControlDataToModel(new deliversaleInfo());
                using (var db = new MESDB())
                {
                    using (var tran =db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<deliversaledetailInfo>> dic =
                                dt.GetDataTableData<deliversaledetailInfo>();
                            if (info.id == 0)//新增
                            {
                                info.deliversalecode = code;
                                db.deliversaleInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtdeliversalecode.Text = code;
                                if (dt != null)
                                {
                                    List<deliversaledetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        string codedetail = code+num;
                                        a.deliversalecode = info.deliversalecode;
                                        a.deliversaleid = info.id;
                                        a.deliversaledetailcode = codedetail;
                                    });
                                    db.deliversaledetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<deliversaledetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        a.deliversalecode = info.deliversalecode;
                                        a.deliversaleid = info.id;
                                        num++;
                                        string codedetail = code + num;
                                        a.deliversaledetailcode = codedetail;
                                    });
                                    db.deliversaledetailInfo.AddRange(detaiListAdd);

                                    List<deliversaledetailInfo> detaiListEdit =
                                        dic["Edit"];
                                   
                                    detaiListEdit.ForEach((a) =>
                                    {
                                        a.deliversalecode = info.deliversalecode;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<deliversaledetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) =>
                                    {
                                        db.Entry(a).State = EntityState.Deleted;
                                    });
                                    db.SaveChanges();
                                }
                            }
                            tran.Commit();
                            gridControl1.DataSource = db.deliversaledetailInfo.ToList().Where(p => p.deliversaleid == info.id); ; ;
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
                deliversaleInfo info = (deliversaleInfo)this.ControlDataToModel(new deliversaleInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    db.Database.ExecuteSqlCommand($"delete from deliversaledetail where deliversaleid={info.id}");
                    gridControl1.DataSource = null;
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
                        grdList.DataSource = db.deliversaleInfo.SqlQuery("select * from deliversale").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.deliversaleInfo.SqlQuery($"select * from deliversale where {sql}").ToList();
                    }
                }
            }
        }

        public override void EditFunction()
        {
            txtcustomerid.ReadOnly = true;
        }

        public override void AddFunction()
        {
            gridControl1.DataSource = new List<deliversaledetailInfo>().ToDataTable();
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            Initresgridcontrollookupedit();
            deliversaleInfo info = grdListView.GetFocusedRow() as deliversaleInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.deliversaledetailInfo.Where(p => p.deliversaleid == info.id).ToList().ToDataTable();
                    gridView1.BestFitColumns();
                }
            }
		}

        private void RepositoryItemGridLookUpEditsalecode_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {
                GridLookUpEdit look = sender as GridLookUpEdit;
                saledetailInfo detailInfo = look.Properties.View.GetFocusedDataRow().RowToModel<saledetailInfo>();
                gridView1.GetFocusedDataRow()["productname"] =db.productInfo.Where(p=>p.id== detailInfo.productid).ToList().First().productname ;
                gridView1.GetFocusedDataRow()["productcode"] = detailInfo.productcode;
                gridView1.GetFocusedDataRow()["productspec"] = detailInfo.productspec;
                gridView1.GetFocusedDataRow()["unit"] = detailInfo.unit;
                gridView1.GetFocusedDataRow()["warehouse"] = detailInfo.warehouse;
                gridView1.GetFocusedDataRow()["number"] = detailInfo.salenumber;
            }
        }
        private void Initresgridcontrollookupedit()
        {
            GridColumn col1 = new GridColumn() { Caption = "销售单号", FieldName = "salecode", Visible = true };

            GridColumn col7 = new GridColumn() { Caption = "产品名称", FieldName = "productid", Visible = true };
            RepositoryItemLookUpEdit resItemLookUpEdit = new RepositoryItemLookUpEdit();
            resItemLookUpEdit.DataSource = GetDataTableUtils.SqlTable("产品");
            resItemLookUpEdit.DisplayMember = "Name";
            resItemLookUpEdit.ValueMember = "ID";
            col7.ColumnEdit = resItemLookUpEdit;
            GridColumn col2 = new GridColumn() { Caption = "规格型号", FieldName = "productspec", Visible = true };
            GridColumn col3 = new GridColumn() { Caption = "数量", FieldName = "salenumber", Visible = true };
            GridColumn col31 = new GridColumn() { Caption = "计量单位", FieldName = "unit", Visible = true };
            RepositoryItemLookUpEdit resItemLookUpEditunit = new RepositoryItemLookUpEdit();
            resItemLookUpEditunit.DataSource = GetDataTableUtils.SqlTable("计量单位");
            resItemLookUpEditunit.DisplayMember = "Name";
            resItemLookUpEditunit.ValueMember = "ID";
            col31.ColumnEdit = resItemLookUpEditunit;

            GridColumn col5 = new GridColumn() { Caption = "单价", FieldName = "unitprice", Visible = true };
            GridColumn col6 = new GridColumn() { Caption = "金额", FieldName = "money", Visible = true };
            repositoryItemGridLookUpEdit1View.Columns.AddRange(new GridColumn[] {col1,  col7, col2, col3,col31, col5, col6 });
        }
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
			gridView1.AddNewRow();
        }
        private void toolStripMenuItemDel_Click(object sender, EventArgs e)
        {
			gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void txtcustomerid_EditValueChanged(object sender, EventArgs e)
        {
            Initresgridcontrollookupedit();
            using (var db = new MESDB())
            {

                if (txtcustomerid.EditValue != null)
                {
                    int id = txtcustomerid.EditValue.ToString().ToInt16();
                    repositoryItemGridLookUpEditsalecode.DataSource =
                        db.Database.SqlQuery<saledetailInfo>($"SELECT st.* FROM sale s left join saledetail st on s.id = st.saleid where s.customerid = {id}").ToDataTable();
                    customerInfo customer = db.customerInfo.Where(p => p.id == id)
                        .First();
                    if (customer != null)
                    {
                        txtcustomercode.Text = customer.customercode;
                        txtcustomertype.EditValue = customer.customertype;
                        txtcontactuser.EditValue = customer.contactuser;
                        txtdeliveraddress.Text = customer.address;
                    }
                }
            }
        }
    }
}