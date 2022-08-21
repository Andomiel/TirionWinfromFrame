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
	public partial class FrmproductMaterialInWarehouse : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmproductMaterialInWarehouse()
		{
			InitializeComponent();
		}
		private void FrmproductMaterialInWarehouse_Load(object sender, EventArgs e)
        {
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new productMaterialInWarehouseInfo(),gridControl1,new []{"txtcode"});
            InitSearchDicData();
            repositoryItemTextEditproductionMaterialReturnDetailCode.KeyDown += RepositoryItemTextEditproductionMaterialReturnDetailCode_KeyDown;
        }

        private void RepositoryItemTextEditproductionMaterialReturnDetailCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                using (var db = new MESDB())
                {
                    string code = gridView1.EditingValue.ToString();
                    if (!string.IsNullOrEmpty(code))
                    {
                        productionMaterialReturnDetailInfo buyerdetailInfo = db.productionMaterialReturnDetailInfo
                            .Where(p => p.detailcode == code).FirstOrDefault();
                        if (buyerdetailInfo == null)
                        {
                            "单号不存在".ShowWarning();
                        }
                        else
                        {
                            gridView1.GetFocusedDataRow()["productionMaterialReturnDetailCode"] = buyerdetailInfo.detailcode;
                            gridView1.GetFocusedDataRow()["productionMaterialReturnCode"] = buyerdetailInfo.mastercode;
                            gridView1.GetFocusedDataRow()["wocode"] = buyerdetailInfo.wocode;
                            gridView1.GetFocusedDataRow()["materialid"] = buyerdetailInfo.materialid;
                            gridView1.GetFocusedDataRow()["materialcode"] = buyerdetailInfo.materialcode;
                            gridView1.GetFocusedDataRow()["materialspec"] = buyerdetailInfo.materialspec;
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
            repositoryItemLookUpEditmaterialid.DataSource = GetDataTableUtils.SqlTable("物料");
            repositoryItemLookUpEditwarehouse.DataSource = GetDataTableUtils.SqlTable("仓库");
            repositoryItemLookUpEditunit.DataSource = GetDataTableUtils.SqlTable("计量单位");
            
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
				grdList.DataSource=con.productMaterialInWarehouseInfo.ToList();
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
				"退料单位不能为空".ShowWarning();
				txtdept.Focus();
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
            string code = "MMR" + DateTime.Now.GetDateTimeCode();

            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                productMaterialInWarehouseInfo info = (productMaterialInWarehouseInfo)this.ControlDataToModel(new productMaterialInWarehouseInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<productMaterialInWarehouseDetailInfo>> dic =
                                dt.GetDataTableData<productMaterialInWarehouseDetailInfo>();
                            if (info.id == 0) //新增
                            {
                                info.code = code;
                                db.productMaterialInWarehouseInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtcode.Text = code;
                                if (dt != null)
                                {
                                    List<productMaterialInWarehouseDetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        string codedetail = code + num;
                                        a.masterid = info.id;
                                        a.masercode = info.code;
                                        a.detailcode = codedetail;
                                    });
                                    db.productMaterialInWarehouseDetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<productMaterialInWarehouseDetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        a.masterid = info.id;
                                        a.masercode = info.code;
                                        num++;
                                        string codedetail = code+ num;
                                        a.detailcode = codedetail;
                                    });
                                    db.productMaterialInWarehouseDetailInfo.AddRange(detaiListAdd);

                                    List<productMaterialInWarehouseDetailInfo> detaiListEdit =
                                        dic["Edit"];

                                    detaiListEdit.ForEach((a) =>
                                    {
                                        //a.buyercode = info.buyercode;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<productMaterialInWarehouseDetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) => { db.Entry(a).State = EntityState.Deleted; });
                                    db.SaveChanges();
                                }
                            }
                            tran.Commit();
                            gridControl1.DataSource = db.productMaterialInWarehouseDetailInfo.ToList().Where(p => p.masterid == info.id); ; ;
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
                productMaterialInWarehouseInfo info = (productMaterialInWarehouseInfo)this.ControlDataToModel(new productMaterialInWarehouseInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    List<productMaterialInWarehouseDetailInfo> list = db.productMaterialInWarehouseDetailInfo
                        .Where(p => p.masterid == info.id).ToList();
                    db.productMaterialInWarehouseDetailInfo.RemoveRange(list);
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
                        grdList.DataSource = db.productMaterialInWarehouseInfo.SqlQuery("select * from productMaterialInWarehouse").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.productMaterialInWarehouseInfo.SqlQuery($"select * from productMaterialInWarehouse where {sql}").ToList();
                    }
                }
            }
        }

        public override void AddFunction()
        {
            gridControl1.DataSource = new List<productMaterialInWarehouseDetailInfo>().ToDataTable();
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            productMaterialInWarehouseInfo info = grdListView.GetFocusedRow() as productMaterialInWarehouseInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.productMaterialInWarehouseDetailInfo.Where(p => p.masterid == info.id).ToList().ToDataTable();
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