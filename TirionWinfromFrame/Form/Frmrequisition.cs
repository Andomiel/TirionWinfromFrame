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
	public partial class Frmrequisition : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmrequisition()
		{
			InitializeComponent();
		}
		private void Frmrequisition_Load(object sender, EventArgs e)
        {
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new requisitionInfo(),gridControl1,new []{ "txtrequisitioncode" , "txttotalprice" });
            InitSearchDicData();
            repositoryItemLookUpEditmaterialid.EditValueChanged += RepositoryItemLookUpEditmaterialid_EditValueChanged;
        }

        private void RepositoryItemLookUpEditmaterialid_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {
                LookUpEdit lookUpEdit = sender as LookUpEdit;
                int materialid = lookUpEdit.EditValue.ToString().ToInt16();
                materialInfo material = db.materialInfo.Find(materialid);
                if (material != null)
                {
                    gridView1.GetFocusedDataRow()["materialcode"] = material.code;
                    gridView1.GetFocusedDataRow()["materialspec"] = material.spec;
                    gridView1.GetFocusedDataRow()["materialunit"] = material.unit;
                    gridView1.GetFocusedDataRow()["unitprice"] = material.referprice;
                    gridView1.GetFocusedDataRow()["warehouse"] = material.warehouse;
                }
            }
        }

        /// <summary>
        /// 数据源初始化
        /// </summary>
        /// <returns></returns>
        private void Init()
		{
				txtdeptid.Properties.DataSource = GetDataTableUtils.SqlTable("部门");     
				repositoryItemtxtdeptid.DataSource= GetDataTableUtils.SqlTable("部门");  
				txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
				repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");

                repositoryItemLookUpEditmaterialid.DataSource = GetDataTableUtils.SqlTable("物料");
                repositoryItemLookUpEditwarehouse.DataSource = GetDataTableUtils.SqlTable("仓库");
                repositoryItemLookUpEditmaterialunit.DataSource = GetDataTableUtils.SqlTable("计量单位");

        }
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
				fieldDictionary.Add("请购单编号","requisitioncode");     
        }

		public override void InitgrdListDataSource()
        {
			 using (var con=new MESDB())///
            {
				grdList.DataSource=con.requisitionInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
            if(string.IsNullOrEmpty(txtdeptid.EditValue.ToString()))
			{
				"请购部门不能为空".ShowWarning();
				txtdeptid.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtrequisitiondate.EditValue.ToString()))
			{
				"请购日期不能为空".ShowWarning();
				txtrequisitiondate.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtdeliverdate.ToString()))
			{
				"交货日期不能为空".ShowWarning();
				txtdeliverdate.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcreatorId.EditValue.ToString()))
			{
				"制单人不能为空".ShowWarning();
				txtcreatorId.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txttotalprice.EditValue.ToString()))
			{
				"金额不能为空".ShowWarning();
				txttotalprice.Focus();
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
            string code = "QG" + DateTime.Now.GetDateTimeCode();
            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                requisitionInfo info = (requisitionInfo)this.ControlDataToModel(new requisitionInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<requisitiondetailInfo>> dic =
                                dt.GetDataTableData<requisitiondetailInfo>();
                            if (info.id == 0)//新增
                            {
                                info.requisitioncode = code;
                                db.requisitionInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtrequisitioncode.Text = code;
                                if (dt != null)
                                {
                                    List<requisitiondetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        a.requisitionid = info.id;
                                        a.requisitioncode = info.requisitioncode;
                                        string codeD = code+num;
                                        a.requisitiondetailcode = codeD;
                                    });
                                    db.requisitiondetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<requisitiondetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        a.requisitionid = info.id;
                                        a.requisitioncode = info.requisitioncode;
                                        string codeD = code+num;
                                        a.requisitiondetailcode = codeD;
                                    });
                                    db.requisitiondetailInfo.AddRange(detaiListAdd);

                                    List<requisitiondetailInfo> detaiListEdit =
                                        dic["Edit"];
                                    detaiListEdit.ForEach((a) =>
                                    {
                                        a.requisitionid = info.id;
                                        a.requisitioncode = info.requisitioncode;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<requisitiondetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) =>
                                    {
                                        db.Entry(a).State = EntityState.Deleted;
                                    });
                                    db.SaveChanges();
                                }
                            }
                            tran.Commit();
                            gridControl1.DataSource = db.requisitiondetailInfo.ToList().Where(p => p.requisitionid == info.id); ; ;
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
                requisitionInfo info = (requisitionInfo)this.ControlDataToModel(new requisitionInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    List<requisitiondetailInfo> list = db.requisitiondetailInfo
                        .Where(p => p.requisitionid == info.id).ToList();
                    db.requisitiondetailInfo.RemoveRange(list);
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
                        grdList.DataSource = db.requisitionInfo.SqlQuery("select * from requisition").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.requisitionInfo.SqlQuery($"select * from requisition where {sql}").ToList();
                    }
                }
            }
        }

        public override void AddFunction()
        {
            txtrequisitiondate.DateTime=DateTime.Now;
            gridControl1.DataSource = new List<requisitiondetailInfo>().ToDataTable();
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            requisitionInfo info = grdListView.GetFocusedRow() as requisitionInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.requisitiondetailInfo.Where(p => p.requisitionid == info.id).ToList().ToDataTable();
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

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            txttotalprice.Text = gridColumn18.SummaryItem.SummaryValue.ToString();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridView1.GetFocusedDataRow()["unitprice"].ToString()) &&
                !string.IsNullOrEmpty(gridView1.GetFocusedDataRow()["requisitionnumber"].ToString()))
            {
                gridView1.GetFocusedDataRow()["money"] = decimal.Multiply(
                    gridView1.GetFocusedDataRow()["unitprice"].ToDecimal(0),
                    gridView1.GetFocusedDataRow()["requisitionnumber"].ToDecimal(0));
                ;
            }
            gridView1.BestFitColumns();
        }

        private void gridControl1_Validated(object sender, EventArgs e)
        {
            txttotalprice.Text = gridColumn18.SummaryItem.SummaryValue.ToString();
        }
    }
}