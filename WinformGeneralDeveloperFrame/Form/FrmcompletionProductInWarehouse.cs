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
	public partial class FrmcompletionProductInWarehouse : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmcompletionProductInWarehouse()
		{
			InitializeComponent();
		}
		private void FrmcompletionProductInWarehouse_Load(object sender, EventArgs e)
        {
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new completionProductInWarehouseInfo(),gridControl1,new []{"txtcode"});
            InitSearchDicData();
            repositoryItemTextEditwocode.KeyDown += RepositoryItemTextEditwocode_KeyDown;
        }

        private void RepositoryItemTextEditwocode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                using (var db = new MESDB())
                {
                    string code = gridView1.EditingValue.ToString();
                    if (!string.IsNullOrEmpty(code))
                    {
                        workorderInfo buyerdetailInfo = db.workorderInfo
                            .Where(p => p.wordordercode == code).FirstOrDefault();
                        if (buyerdetailInfo == null)
                        {
                            "单号不存在".ShowWarning();
                        }
                        else
                        {
                            gridView1.GetFocusedDataRow()["wocode"] = buyerdetailInfo.wordordercode;
                            gridView1.GetFocusedDataRow()["salecode"] = buyerdetailInfo.salecode;
                            gridView1.GetFocusedDataRow()["saledetailcode"] = buyerdetailInfo.saledetailcode;
                            gridView1.GetFocusedDataRow()["productid"] = buyerdetailInfo.productid;
                            gridView1.GetFocusedDataRow()["productcode"] = buyerdetailInfo.productcode;
                            gridView1.GetFocusedDataRow()["spec"] = buyerdetailInfo.spec;
                            gridView1.GetFocusedDataRow()["unit"] = buyerdetailInfo.unit;
                            gridView1.GetFocusedDataRow()["warehouse"] = buyerdetailInfo.warehouse;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 数据源初始化
        /// </summary>
        /// <returns></returns>
        private void Init()
		{
			txtdept.Properties.DataSource = GetDataTableUtils.SqlTable("部门");     
			repositoryItemtxtdept.DataSource= GetDataTableUtils.SqlTable("部门");  
			txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");
            repositoryItemLookUpEditwarehouse.DataSource = GetDataTableUtils.SqlTable("仓库");
            repositoryItemLookUpEditunit.DataSource = GetDataTableUtils.SqlTable("计量单位");
            repositoryItemLookUpEditproductid.DataSource = GetDataTableUtils.SqlTable("产品");
        }
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
			fieldDictionary.Add("入库单号","code");     
        }

		public override void InitgrdListDataSource()
        {
			 using (var con=new MESDB())///
            {
				grdList.DataSource=con.completionProductInWarehouseInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtintime.Text))
			{
				"入库日期不能为空".ShowWarning();
				txtintime.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtdept.EditValue.ToString()))
			{
				"入库单位不能为空".ShowWarning();
				txtdept.Focus();
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
				"制单时间不能为空".ShowWarning();
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
            string code = "MOI" + DateTime.Now.GetDateTimeCode();

            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                completionProductInWarehouseInfo info = (completionProductInWarehouseInfo)this.ControlDataToModel(new completionProductInWarehouseInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<completionProductInWarehouseDetailInfo>> dic =
                                dt.GetDataTableData<completionProductInWarehouseDetailInfo>();
                            if (info.id == 0) //新增
                            {
                                info.code = code;
                                db.completionProductInWarehouseInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtcode.Text = code;
                                if (dt != null)
                                {
                                    List<completionProductInWarehouseDetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        string codedetail = code + num;
                                        a.masterid = info.id;
                                        a.mastercode = info.code;
                                        a.detailcode = codedetail;
                                    });
                                    db.completionProductInWarehouseDetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<completionProductInWarehouseDetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        a.masterid = info.id;
                                        a.mastercode = info.code;
                                        num++;
                                        string codedetail = code + num;
                                        a.detailcode = codedetail;
                                    });
                                    db.completionProductInWarehouseDetailInfo.AddRange(detaiListAdd);

                                    List<completionProductInWarehouseDetailInfo> detaiListEdit =
                                        dic["Edit"];

                                    detaiListEdit.ForEach((a) =>
                                    {
                                        
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<completionProductInWarehouseDetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) => { db.Entry(a).State = EntityState.Deleted; });
                                    db.SaveChanges();
                                }
                            }

                            tran.Commit();
                            gridControl1.DataSource = db.completionProductInWarehouseDetailInfo.ToList().Where(p => p.masterid == info.id); ; ;
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
                completionProductInWarehouseInfo info = (completionProductInWarehouseInfo)this.ControlDataToModel(new completionProductInWarehouseInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    List<completionProductInWarehouseDetailInfo> list = db.completionProductInWarehouseDetailInfo
                        .Where(p => p.masterid == info.id).ToList();
                    db.completionProductInWarehouseDetailInfo.RemoveRange(list);
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
                        grdList.DataSource = db.completionProductInWarehouseInfo.SqlQuery("select * from completionProductInWarehouse").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.completionProductInWarehouseInfo.SqlQuery($"select * from completionProductInWarehouse where {sql}").ToList();
                    }
                }
            }
        }

        public override void AddFunction()
        {
            gridControl1.DataSource = new List<completionProductInWarehouseDetailInfo>().ToDataTable();
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            completionProductInWarehouseInfo info = grdListView.GetFocusedRow() as completionProductInWarehouseInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.completionProductInWarehouseDetailInfo.Where(p => p.masterid == info.id).ToList().ToDataTable();
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
    }
}