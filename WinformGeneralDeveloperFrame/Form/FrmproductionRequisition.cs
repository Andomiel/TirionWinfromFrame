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
using CCWin.SkinClass;
using DevExpress.XtraEditors;

namespace MES.Form
{
	public partial class FrmproductionRequisition : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmproductionRequisition()
		{
			InitializeComponent();
		}
		private void FrmproductionRequisition_Load(object sender, EventArgs e)
        {
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new productionRequisitionInfo(),gridControl1,new string[]{ "txtcode" });
            InitSearchDicData();
            repositoryItemLookUpEditmaterialid.EditValueChanged += RepositoryItemLookUpEditmaterialid_EditValueChanged;
        }

        private void RepositoryItemLookUpEditmaterialid_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            DataRowView data=lookUpEdit.GetSelectedDataRow() as DataRowView;
            using (var db=new MESDB())
            {
                int id = data.Row["ID"].ToInt32();
                int BOMid = data.Row["BOMid"].ToInt32();
                productBOMdetailInfo productBoMdetail = db.productBOMdetailInfo.Where(p =>
                    p.materialid ==  id&& p.productBOMid == BOMid).ToList().First();
                gridView1.GetFocusedDataRow()["materialcode"] = productBoMdetail.materialcode;
                gridView1.GetFocusedDataRow()["materialspec"] = productBoMdetail.materialspec;
                gridView1.GetFocusedDataRow()["materialtype"] = productBoMdetail.materialtype;
                gridView1.GetFocusedDataRow()["unitnumber"] = productBoMdetail.unitusenumber;

                gridView1.GetFocusedDataRow()["productnumber"] = txtnumber.Text;
                gridView1.GetFocusedDataRow()["unit"] = productBoMdetail.unit;
                gridView1.GetFocusedDataRow()["warehouse"] = productBoMdetail.warehouse;
               // gridView1.GetFocusedDataRow()["unitnumber"] = productBoMdetail.materialcode;

            }
        }

        /// <summary>
        /// ??????????????????
        /// </summary>
        /// <returns></returns>
        private void Init()
		{
			txtproductID.Properties.DataSource = GetDataTableUtils.SqlTable("??????");     
			repositoryItemtxtproductID.DataSource= GetDataTableUtils.SqlTable("??????");  
			txtunit.Properties.DataSource = GetDataTableUtils.SqlTable("????????????");     
			repositoryItemtxtunit.DataSource= GetDataTableUtils.SqlTable("????????????");  
			txtpickingdept.Properties.DataSource = GetDataTableUtils.SqlTable("??????");     
			repositoryItemTreeListtxtpickingdept.DataSource= GetDataTableUtils.SqlTable("??????");  
			txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("??????");     
			repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("??????");

            repositoryItemLookUpEditwarehouse.DataSource = GetDataTableUtils.SqlTable("??????");
            repositoryItemLookUpEditunit.DataSource = GetDataTableUtils.SqlTable("????????????");
            repositoryItemLookUpEditmaterialid.DataSource = GetDataTableUtils.SqlTable("??????");
            repositoryItemLookUpEditmaterialtype.DataSource = GetDataTableUtils.SqlTable("????????????");
			
        }
		/// <summary>
		/// ????????????
		/// </summary>
		/// <returns></returns>
		private void InitSearchDicData()
        {
			fieldDictionary.Add("????????????","code");     
			fieldDictionary.Add("?????????","wocode");     
			fieldDictionary.Add("????????????","salecode");     
        }

		public override void InitgrdListDataSource()
        {
			 using (var con=new MESDB())///
            {
				grdList.DataSource=con.productionRequisitionInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// ??????????????????
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtwocode.EditValue.ToString()))
			{
				"?????????????????????".ShowWarning();
				txtwocode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtpickingtime.Text))
			{
				"????????????????????????".ShowWarning();
				txtpickingtime.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductID.EditValue.ToString()))
			{
				"??????????????????".ShowWarning();
				txtproductID.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductcode.EditValue.ToString()))
			{
				"????????????????????????".ShowWarning();
				txtproductcode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductspec.EditValue.ToString()))
			{
				"????????????????????????".ShowWarning();
				txtproductspec.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtnumber.EditValue.ToString()))
			{
				"????????????????????????".ShowWarning();
				txtnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtunit.EditValue.ToString()))
			{
				"????????????????????????".ShowWarning();
				txtunit.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtpickingdept.EditValue.ToString()))
			{
				"????????????????????????".ShowWarning();
				txtpickingdept.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcreatorId.EditValue.ToString()))
			{
				"?????????????????????".ShowWarning();
				txtcreatorId.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcreateTime.Text))
			{
				"????????????????????????".ShowWarning();
				txtcreateTime.Focus();
				return false;
			}
			return true;
        }
        /// <summary>
		/// ??????
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            string code = "MOO" + DateTime.Now.GetDateTimeCode();

            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                productionRequisitionInfo info = (productionRequisitionInfo)this.ControlDataToModel(new productionRequisitionInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<productionRequisitionDetailInfo>> dic =
                                dt.GetDataTableData<productionRequisitionDetailInfo>();
                            if (info.id == 0) //??????
                            {
                                info.code = code;
                                db.productionRequisitionInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtcode.Text = code;
                                if (dt != null)
                                {
                                    List<productionRequisitionDetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        string codedetail = code + num;
                                        a.masterid = info.id;
                                        a.mastercode = info.code;
                                        a.wocode = info.wocode;
                                        a.detailcode = codedetail;
                                    });
                                    db.productionRequisitionDetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //??????
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<productionRequisitionDetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        a.masterid = info.id;
                                        a.mastercode = info.code;
                                        num++;
                                        string codedetail = code+ num;
                                        a.detailcode = codedetail;
                                        a.wocode = info.wocode;
                                    });
                                    db.productionRequisitionDetailInfo.AddRange(detaiListAdd);

                                    List<productionRequisitionDetailInfo> detaiListEdit =
                                        dic["Edit"];

                                    detaiListEdit.ForEach((a) =>
                                    {
                                        //a.buyercode = info.buyercode;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<productionRequisitionDetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) => { db.Entry(a).State = EntityState.Deleted; });
                                    db.SaveChanges();
                                }
                            }

                            tran.Commit();
                            gridControl1.DataSource = db.productionRequisitionDetailInfo.ToList().Where(p => p.masterid == info.id); ; ;
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
		/// ??????
		/// </summary>
		/// <returns></returns>
		public override bool DelFunction()
        {
            try
            {
                productionRequisitionInfo info = (productionRequisitionInfo)this.ControlDataToModel(new productionRequisitionInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    List<productionRequisitionDetailInfo> list = db.productionRequisitionDetailInfo
                        .Where(p => p.masterid == info.id).ToList();
                    db.productionRequisitionDetailInfo.RemoveRange(list);
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
		/// ??????
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
                        grdList.DataSource = db.productionRequisitionInfo.SqlQuery("select * from productionRequisition").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.productionRequisitionInfo.SqlQuery($"select * from productionRequisition where {sql}").ToList();
                    }
                }
            }
        }

        public override void EditFunction()
        {
            using (var db = new MESDB())
            {
                var list = db.workorderInfo.Where(p => p.wordordercode == txtwocode.Text.ToUpper().Trim()).ToList();
                {
                    workorderInfo info = list.First();

                    repositoryItemLookUpEditmaterialid.DataSource = GetDataTableUtils.SqlTableBySql(
                        $"SELECT B.id ID,B.name Name,b.code Code,a.productBOMid BOMid FROM [dbo].[productBOMdetail] A LEFT JOIN [dbo].material B ON A.materialid = B.id where a.productBOMid = {info.bomid}");
                }
            }
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            productionRequisitionInfo info = grdListView.GetFocusedRow() as productionRequisitionInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.productionRequisitionDetailInfo.Where(p => p.masterid== info.id).ToList().ToDataTable();
                    gridView1.BestFitColumns();
                }
            }
        }

        public override void AddFunction()
        {
            txtpickingdept.EditValue = AppInfo.LoginUserInfo.deptId;
            gridControl1.DataSource = new List<productionRequisitionDetailInfo>().ToDataTable();
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
		}

        private void toolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
		}
        private void txtwocode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                using (var db = new MESDB())
                {
                    var list = db.workorderInfo.Where(p => p.wordordercode == txtwocode.Text.ToUpper().Trim()).ToList();
                    if (list.Count == 0)
                    {
                        "?????????????????????".ShowTips();
                    }
                    else
                    {
                        workorderInfo info = list.First();
                        txtsalecode.Text = info.salecode;
                        txtproductID.EditValue = info.productid;
                        txtproductcode.Text = info.productcode;
                        txtproductspec.Text = info.spec;
                        txtnumber.EditValue = info.productnumber;
                        txtunit.EditValue = info.unit;

                        repositoryItemLookUpEditmaterialid.DataSource = GetDataTableUtils.SqlTableBySql($"SELECT B.id ID,B.name Name,b.code Code,a.productBOMid BOMid FROM [dbo].[productBOMdetail] A LEFT JOIN [dbo].material B ON A.materialid = B.id where a.productBOMid = {info.bomid}");

                    }
                }
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.C)
            {
                Clipboard.SetDataObject(gridView1.GetFocusedRowCellValue(gridView1.FocusedColumn));
                e.Handled = true;
            }
        }
    }
}