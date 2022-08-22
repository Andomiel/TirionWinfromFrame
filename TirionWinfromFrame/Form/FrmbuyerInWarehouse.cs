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
	public partial class FrmbuyerInWarehouse : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmbuyerInWarehouse()
		{
			InitializeComponent();
		}
		private void FrmbuyerInWarehouse_Load(object sender, EventArgs e)
        {
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new buyerInWarehouseInfo(),gridControl1,new string[]{ "txtcode" });
            InitSearchDicData();
            repositoryItemTextEditbuyerdetailcode.KeyDown += RepositoryItemTextEditbuyerdetailcode_KeyDown;
        }

        private void RepositoryItemTextEditbuyerdetailcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                using (var db = new MESDB())
                {
                    string code = gridView1.EditingValue.ToString();
                    if (!string.IsNullOrEmpty(code))
                    {
                        buyerdetailInfo buyerdetailInfo = db.buyerdetailInfo
                            .Where(p => p.buyerdetailcode == code).FirstOrDefault();
                        if (buyerdetailInfo == null)
                        {
                            "单号不存在".ShowWarning();
                        }
                        else
                        {
                            gridView1.GetFocusedDataRow()["buyerdetailcode"] = buyerdetailInfo.buyerdetailcode;
                            gridView1.GetFocusedDataRow()["buyercode"] = buyerdetailInfo.buyercode;
                            gridView1.GetFocusedDataRow()["materialid"] = buyerdetailInfo.materialid;
                            gridView1.GetFocusedDataRow()["materialcode"] = buyerdetailInfo.materialcode;
                            gridView1.GetFocusedDataRow()["materialspec"] = buyerdetailInfo.materialspec;
                            gridView1.GetFocusedDataRow()["unit"] = buyerdetailInfo.materialunit;
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
			txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");  
			txtsupplierid.Properties.DataSource = GetDataTableUtils.SqlTable("供应商");     
			repositoryItemtxtsupplierid.DataSource= GetDataTableUtils.SqlTable("供应商");
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
				grdList.DataSource=con.buyerInWarehouseInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtcreatorId.EditValue.ToString()))
			{
				"制单人不能为空".ShowWarning();
				txtcreatorId.Focus();
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
			if(string.IsNullOrEmpty(txtintime.Text))
			{
				"入库日期不能为空".ShowWarning();
				txtintime.Focus();
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
            string code = "CGI" + DateTime.Now.GetDateTimeCode();

            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                buyerInWarehouseInfo info = (buyerInWarehouseInfo)this.ControlDataToModel(new buyerInWarehouseInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<buyerInWarehouseDetailInfo>> dic =
                                dt.GetDataTableData<buyerInWarehouseDetailInfo>();
                            if (info.id == 0) //新增
                            {
                                info.code = code;
                                db.buyerInWarehouseInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtcode.Text = code;
                                if (dt != null)
                                {
                                    List<buyerInWarehouseDetailInfo> detaiListAdd =
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
                                    db.buyerInWarehouseDetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<buyerInWarehouseDetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        a.masterid = info.id;
                                        a.mastercode = info.code;
                                        num++;
                                        string codedetail = code+ num;
                                        a.detailcode = codedetail;
                                    });
                                    db.buyerInWarehouseDetailInfo.AddRange(detaiListAdd);

                                    List<buyerInWarehouseDetailInfo> detaiListEdit =
                                        dic["Edit"];

                                    detaiListEdit.ForEach((a) =>
                                    {
                                        //a.buyercode = info.buyercode;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<buyerInWarehouseDetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) => { db.Entry(a).State = EntityState.Deleted; });
                                    db.SaveChanges();
                                }
                            }

                            tran.Commit();
                            gridControl1.DataSource = db.buyerInWarehouseDetailInfo.ToList().Where(p => p.masterid == info.id); ;
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
                buyerInWarehouseInfo info = (buyerInWarehouseInfo)this.ControlDataToModel(new buyerInWarehouseInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    List<buyerInWarehouseDetailInfo> list = db.buyerInWarehouseDetailInfo
                        .Where(p => p.masterid == info.id).ToList();
                    db.buyerInWarehouseDetailInfo.RemoveRange(list);
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
                        grdList.DataSource = db.buyerInWarehouseInfo.SqlQuery("select * from buyerInWarehouse").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.buyerInWarehouseInfo.SqlQuery($"select * from buyerInWarehouse where {sql}").ToList();
                    }
                }
            }
        }

        public override void AddFunction()
        {
           gridControl1.DataSource= new List<buyerInWarehouseDetailInfo>().ToDataTable();
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            buyerInWarehouseInfo info = grdListView.GetFocusedRow() as buyerInWarehouseInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.buyerInWarehouseDetailInfo.Where(p => p.masterid == info.id).ToList().ToDataTable();
                    gridView1.BestFitColumns();


                }
            }
        }

        private void txtsupplierid_EditValueChanged(object sender, EventArgs e)
        {
            using (var db=new MESDB())
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