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
namespace MES.Form
{
	public partial class FrmbuyerOutWarehouse : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmbuyerOutWarehouse()
		{
			InitializeComponent();
		}
		private void FrmbuyerOutWarehouse_Load(object sender, EventArgs e)
        {
			InitFrom(xtraTabControl1,grdList,grdListView,new []{layoutControlGroup1},new buyerOutWarehouseInfo(),gridControl1,new []{ "txtcode" });
            InitSearchDicData();
            repositoryItemTextEditbuyerreturndetailcode.KeyDown += RepositoryItemTextEditbuyerreturndetailcode_KeyDown;
        }

        private void RepositoryItemTextEditbuyerreturndetailcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                using (var db = new MESDB())
                {
                    string code = gridView1.EditingValue.ToString();
                    if (!string.IsNullOrEmpty(code))
                    {
                        buyerreturndetailInfo buyerdetailInfo = db.buyerreturndetailInfo
                            .Where(p => p.returnbuyerdetailcode == code).FirstOrDefault();
                        if (buyerdetailInfo == null)
                        {
                            "单号不存在".ShowWarning();
                        }
                        else
                        {
                            gridView1.GetFocusedDataRow()["buyerdetailcode"] = buyerdetailInfo.buyerdetailcode;
                            gridView1.GetFocusedDataRow()["buyercode"] = buyerdetailInfo.buyercode;
                            gridView1.GetFocusedDataRow()["buyerreturncode"] = buyerdetailInfo.returnbuyercode;
                            gridView1.GetFocusedDataRow()["buyerreturndetailcode"] = buyerdetailInfo.returnbuyerdetailcode;
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
			txtsupplierid.Properties.DataSource = GetDataTableUtils.SqlTable("供应商");     
			repositoryItemtxtsupplierid.DataSource= GetDataTableUtils.SqlTable("供应商");  
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
			fieldDictionary.Add("采购退货出库单号","code");     
        }

		public override void InitgrdListDataSource()
        {
			 using (var con=new MESDB())///
            {
				grdList.DataSource=con.buyerOutWarehouseInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtouttime.Text))
			{
				"出库日期不能为空".ShowWarning();
				txtouttime.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtsupplierid.EditValue.ToString()))
			{
				"供应商不能为空".ShowWarning();
				txtsupplierid.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtsuppliercode.EditValue.ToString()))
			{
				"供应商编码不能为空".ShowWarning();
				txtsuppliercode.Focus();
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
            string  code = "CGO" + DateTime.Now.GetDateTimeCode();

            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                buyerOutWarehouseInfo info = (buyerOutWarehouseInfo)this.ControlDataToModel(new buyerOutWarehouseInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<buyerOutWarehouseDetailInfo>> dic =
                                dt.GetDataTableData<buyerOutWarehouseDetailInfo>();
                            if (info.id == 0) //新增
                            {
                                info.code = code;
                                db.buyerOutWarehouseInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtcode.Text = code;
                                if (dt != null)
                                {
                                    List<buyerOutWarehouseDetailInfo> detaiListAdd =
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
                                    db.buyerOutWarehouseDetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<buyerOutWarehouseDetailInfo> detaiListAdd =
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
                                    db.buyerOutWarehouseDetailInfo.AddRange(detaiListAdd);

                                    List<buyerOutWarehouseDetailInfo> detaiListEdit =
                                        dic["Edit"];

                                    detaiListEdit.ForEach((a) =>
                                    {
                                        //a.buyercode = info.buyercode;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<buyerOutWarehouseDetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) => { db.Entry(a).State = EntityState.Deleted; });
                                    db.SaveChanges();
                                }
                            }
                            tran.Commit();
                            gridControl1.DataSource = db.buyerOutWarehouseDetailInfo.ToList().Where(p => p.masterid == info.id); ; ;
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
                buyerOutWarehouseInfo info = (buyerOutWarehouseInfo)this.ControlDataToModel(new buyerOutWarehouseInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    List<buyerOutWarehouseDetailInfo> list = db.buyerOutWarehouseDetailInfo
                        .Where(p => p.masterid == info.id).ToList();
                    db.buyerOutWarehouseDetailInfo.RemoveRange(list);
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
                        grdList.DataSource = db.buyerOutWarehouseInfo.SqlQuery("select * from buyerOutWarehouse").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.buyerOutWarehouseInfo.SqlQuery($"select * from buyerOutWarehouse where {sql}").ToList();
                    }
                }
            }
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            buyerOutWarehouseInfo info = grdListView.GetFocusedRow() as buyerOutWarehouseInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.buyerOutWarehouseDetailInfo.Where(p => p.masterid == info.id).ToList().ToDataTable();
                    gridView1.BestFitColumns();


                }
            }
        }

        public override void AddFunction()
        {
            gridControl1.DataSource = new List<buyerOutWarehouseDetailInfo>().ToDataTable();
        }

        private void txtsupplierid_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {
                supplierInfo info = db.supplierInfo.Find(txtsupplierid.EditValue);
                txtsuppliercode.Text = info.suppliercode;
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