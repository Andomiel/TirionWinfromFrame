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
	public partial class Frmreturnsale : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmreturnsale()
		{
			InitializeComponent();
		}
		private void Frmreturnsale_Load(object sender, EventArgs e)
        {
		
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new returnsaleInfo(),gridControl1,new string[]{ "txtreturnsalecode" });
            InitSearchDicData();
            repositoryItemGridLookUpEditdeliversalecode.EditValueChanged += RepositoryItemGridLookUpEditdeliversalecode_EditValueChanged;
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
            repositoryItemLookUpEditunit.DataSource = GetDataTableUtils.SqlTable("计量单位");
            repositoryItemLookUpEditwarehouse.DataSource = GetDataTableUtils.SqlTable("仓库");
        }
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
				fieldDictionary.Add("退货单号","returnsalecode");     
        }

		public override void InitgrdListDataSource()
        { 
            using (var con=new MESDB())
            {
				grdList.DataSource=con.returnsaleInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtreturndate.Text))
			{
				"退货日期不能为空".ShowWarning();
				txtreturndate.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcustomercode.EditValue.ToString()))
			{
				"客户编号不能为空".ShowWarning();
				txtcustomercode.Focus();
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
            string code = "SD" + DateTime.Now.GetDateTimeCode();
            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                returnsaleInfo info = (returnsaleInfo)this.ControlDataToModel(new returnsaleInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<returnsaledetailInfo>> dic =
                                dt.GetDataTableData<returnsaledetailInfo>();
                            if (info.id == 0)//新增
                            {
                                info.returnsalecode = code;
                                db.returnsaleInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtreturnsalecode.Text = code;
                                if (dt != null)
                                {
                                    List<returnsaledetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        a.returnsalecode = info.returnsalecode;
                                        a.returnsaleid = info.id;
                                        string coded = code+num;
                                        a.returnsaledetailcode = coded;
                                    });
                                    db.returnsaledetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<returnsaledetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        a.returnsalecode = info.returnsalecode;
                                        a.returnsaleid = info.id;
                                        string coded = code+num;
                                        a.returnsaledetailcode = coded;
                                    });
                                    db.returnsaledetailInfo.AddRange(detaiListAdd);

                                    List<returnsaledetailInfo> detaiListEdit =
                                        dic["Edit"];
                                    detaiListEdit.ForEach((a) =>
                                    {
                                        a.returnsalecode = info.returnsalecode;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<returnsaledetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) =>
                                    {
                                        db.Entry(a).State = EntityState.Deleted;
                                    });
                                    db.SaveChanges();
                                }
                            }
                            tran.Commit();
                            gridControl1.DataSource = db.returnsaledetailInfo.ToList().Where(p => p.returnsaleid == info.id); ; ;
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
                returnsaleInfo info = (returnsaleInfo)this.ControlDataToModel(new returnsaleInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    db.Database.ExecuteSqlCommand($"delete from returnsaledetail where returnsaleid={info.id}");
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
                        grdList.DataSource = db.returnsaleInfo.SqlQuery("select * from returnsale").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.returnsaleInfo.SqlQuery($"select * from returnsale where {sql}").ToList();
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
            gridControl1.DataSource = new List<returnsaledetailInfo>().ToDataTable();
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            Initresgridcontrollookupedit();
            returnsaleInfo info = grdListView.GetFocusedRow() as returnsaleInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.returnsaledetailInfo.Where(p => p.returnsaleid == info.id).ToList().ToDataTable();
                    gridView1.BestFitColumns();
                }
            }
        }

        private void Initresgridcontrollookupedit()
        {

            GridColumn col11 = new GridColumn() { Caption = "出货单号", FieldName = "deliversalecode", Visible = true };

            GridColumn col1 = new GridColumn() { Caption = "销售单号", FieldName = "salecode", Visible = true };

            GridColumn col7 = new GridColumn() { Caption = "产品名称", FieldName = "productname", Visible = true };

            GridColumn col2 = new GridColumn() { Caption = "规格型号", FieldName = "productspec", Visible = true };
            GridColumn col3 = new GridColumn() { Caption = "数量", FieldName = "number", Visible = true };
            GridColumn col31 = new GridColumn() { Caption = "计量单位", FieldName = "unit", Visible = true };
            RepositoryItemLookUpEdit resItemLookUpEditunit = new RepositoryItemLookUpEdit();
            resItemLookUpEditunit.DataSource = GetDataTableUtils.SqlTable("计量单位");
            resItemLookUpEditunit.DisplayMember = "Name";
            resItemLookUpEditunit.ValueMember = "ID";
            col31.ColumnEdit = resItemLookUpEditunit;

            GridColumn col5 = new GridColumn() { Caption = "仓库", FieldName = "warehouse", Visible = true };
            RepositoryItemLookUpEdit resItemLookUpEditwarehouse = new RepositoryItemLookUpEdit();
            resItemLookUpEditwarehouse.DataSource = GetDataTableUtils.SqlTable("仓库");
            resItemLookUpEditwarehouse.DisplayMember = "Name";
            resItemLookUpEditwarehouse.ValueMember = "ID";
            col5.ColumnEdit = resItemLookUpEditwarehouse;

            gridView2.Columns.AddRange(new GridColumn[] { col11,col1, col7, col2, col3, col31, col5 });
        }
        private void txtcustomerid_EditValueChanged(object sender, EventArgs e)
        {
            Initresgridcontrollookupedit();
            using (var db = new MESDB())
            {

                if (txtcustomerid.EditValue != null)
                {
                    int id = txtcustomerid.EditValue.ToString().ToInt16();
                    repositoryItemGridLookUpEditdeliversalecode.DataSource =
                        db.Database.SqlQuery<deliversaledetailInfo>($"SELECT dt.*FROM deliversale d left join deliversaledetail dt on d.id = dt.deliversaleid where d.customerid = {id} ").ToDataTable();
                    customerInfo customer = db.customerInfo.Where(p => p.id == id)
                        .First();
                    if (customer != null)
                    {
                        txtcustomercode.Text = customer.customercode;
                        txtcustomertype.EditValue = customer.customertype;
                        txtcontactuser.EditValue = customer.contactuser;
                        txtcontactphone.Text = customer.phonenumber;
                    }
                }
            }
        }

        private void RepositoryItemGridLookUpEditdeliversalecode_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {
                GridLookUpEdit look = sender as GridLookUpEdit;
                deliversaledetailInfo detailInfo = look.Properties.View.GetFocusedDataRow().RowToModel<deliversaledetailInfo>();
                gridView1.GetFocusedDataRow()["deliversalecode"] = detailInfo.deliversalecode; 
                gridView1.GetFocusedDataRow()["salecode"] = detailInfo.salecode; 
                gridView1.GetFocusedDataRow()["productcode"] = detailInfo.productcode;
                gridView1.GetFocusedDataRow()["productspec"] = detailInfo.productspec;
                gridView1.GetFocusedDataRow()["productname"] = detailInfo.productname;
                gridView1.GetFocusedDataRow()["unit"] = detailInfo.unit;
                gridView1.GetFocusedDataRow()["warehouse"] = detailInfo.warehouse;
                gridView1.GetFocusedDataRow()["returnnumber"] = detailInfo.number;
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
    }
}