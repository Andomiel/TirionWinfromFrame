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
        /// 数据源初始化
        /// </summary>
        /// <returns></returns>
        private void Init()
		{
			txtproductID.Properties.DataSource = GetDataTableUtils.SqlTable("产品");     
			repositoryItemtxtproductID.DataSource= GetDataTableUtils.SqlTable("产品");  
			txtunit.Properties.DataSource = GetDataTableUtils.SqlTable("计量单位");     
			repositoryItemtxtunit.DataSource= GetDataTableUtils.SqlTable("计量单位");  
			txtpickingdept.Properties.DataSource = GetDataTableUtils.SqlTable("部门");     
			repositoryItemTreeListtxtpickingdept.DataSource= GetDataTableUtils.SqlTable("部门");  
			txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");

            repositoryItemLookUpEditwarehouse.DataSource = GetDataTableUtils.SqlTable("仓库");
            repositoryItemLookUpEditunit.DataSource = GetDataTableUtils.SqlTable("计量单位");
            repositoryItemLookUpEditmaterialid.DataSource = GetDataTableUtils.SqlTable("物料");
            repositoryItemLookUpEditmaterialtype.DataSource = GetDataTableUtils.SqlTable("物料类别");
			
        }
		/// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
		private void InitSearchDicData()
        {
			fieldDictionary.Add("领料单号","code");     
			fieldDictionary.Add("工单号","wocode");     
			fieldDictionary.Add("销售单号","salecode");     
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
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtwocode.EditValue.ToString()))
			{
				"工单号不能为空".ShowWarning();
				txtwocode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtpickingtime.Text))
			{
				"领料日期不能为空".ShowWarning();
				txtpickingtime.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductID.EditValue.ToString()))
			{
				"产品不能为空".ShowWarning();
				txtproductID.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductcode.EditValue.ToString()))
			{
				"产品编号不能为空".ShowWarning();
				txtproductcode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductspec.EditValue.ToString()))
			{
				"规格型号不能为空".ShowWarning();
				txtproductspec.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtnumber.EditValue.ToString()))
			{
				"生产数量不能为空".ShowWarning();
				txtnumber.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtunit.EditValue.ToString()))
			{
				"计量单位不能为空".ShowWarning();
				txtunit.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtpickingdept.EditValue.ToString()))
			{
				"领料部门不能为空".ShowWarning();
				txtpickingdept.Focus();
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
                            if (info.id == 0) //新增
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
                            else //更新
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
		/// 删除
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
                        "工单号不存在！".ShowTips();
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