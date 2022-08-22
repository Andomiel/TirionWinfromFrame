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

namespace MES.Form
{
	public partial class FrmsaleOutWarehouse : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmsaleOutWarehouse()
		{
			InitializeComponent();
		}
		private void FrmsaleOutWarehouse_Load(object sender, EventArgs e)
        {
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new saleOutWarehouseInfo(),gridControl1,new []{"txtcode"});
            InitSearchDicData();
            repositoryItemTextEditsaledeliverdetailcode.KeyDown += RepositoryItemTextEditsaledeliverdetailcode_KeyDown;
        }

        private void RepositoryItemTextEditsaledeliverdetailcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                using (var db = new MESDB())
                {
                    string code = gridView1.EditingValue.ToString();
                    if (!string.IsNullOrEmpty(code))
                    {
                        deliversaledetailInfo buyerdetailInfo = db.deliversaledetailInfo
                            .Where(p => p.deliversaledetailcode == code).FirstOrDefault();
                        if (buyerdetailInfo == null)
                        {
                            "单号不存在".ShowWarning();
                        }
                        else
                        {
                            gridView1.GetFocusedDataRow()["saledelivercode"] = buyerdetailInfo.deliversalecode;
                            gridView1.GetFocusedDataRow()["saledeliverdetailcode"] = buyerdetailInfo.deliversaledetailcode;
                            gridView1.GetFocusedDataRow()["salecode"] = buyerdetailInfo.salecode;
                            gridView1.GetFocusedDataRow()["productid"] =db.productInfo.Where(p=>p.productcode== buyerdetailInfo.productcode).FirstOrDefault().id ;
                            gridView1.GetFocusedDataRow()["productcode"] = buyerdetailInfo.productcode;
                            gridView1.GetFocusedDataRow()["spec"] = buyerdetailInfo.productspec;
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
			repositoryItemTreeListtxtdept.DataSource= GetDataTableUtils.SqlTable("部门");  
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
			fieldDictionary.Add("销售出库单号","code");     
        }

		public override void InitgrdListDataSource()
        {
			 using (var con=new MESDB())///
            {
				grdList.DataSource=con.saleOutWarehouseInfo.ToList();
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
			if(string.IsNullOrEmpty(txtdept.EditValue.ToString()))
			{
				"出库单位不能为空".ShowWarning();
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
            string code = "SOO" + DateTime.Now.GetDateTimeCode();

            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                saleOutWarehouseInfo info = (saleOutWarehouseInfo)this.ControlDataToModel(new saleOutWarehouseInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<saleOutWarehouseDetailInfo>> dic =
                                dt.GetDataTableData<saleOutWarehouseDetailInfo>();
                            if (info.id == 0) //新增
                            {
                                info.code = code;
                                db.saleOutWarehouseInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtcode.Text = code;
                                if (dt != null)
                                {
                                    List<saleOutWarehouseDetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        string codedetail = code + num;
                                        a.masterid = info.id;
                                        a.mastercode = info.code;
                                        a.detailcode = codedetail;
                                        //更新产品入库数量
                                        productInfo product = db.productInfo.Find(a.productid);
                                        product.saleoutnumber += a.number;
                                    });
                                    db.saleOutWarehouseDetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<saleOutWarehouseDetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        a.masterid = info.id;
                                        a.mastercode = info.code;
                                        num++;
                                        string codedetail = code + num;
                                        a.detailcode = codedetail;
                                        //更新产品入库数量
                                        productInfo product = db.productInfo.Find(a.productid);
                                        product.saleoutnumber += a.number;
                                    });
                                    db.saleOutWarehouseDetailInfo.AddRange(detaiListAdd);

                                    List<saleOutWarehouseDetailInfo> detaiListEdit =
                                        dic["Edit"];

                                    detaiListEdit.ForEach((a) =>
                                    {
                                        decimal oldnumber =
                                            GetDataTableUtils
                                                .SqlTableBySql(
                                                    $"select number from saleOutWarehouseDetail where id={a.id}")
                                                .Rows[0]["number"].ToDecimal(0);
                                        //a.buyercode = info.buyercode;
                                        productInfo product = db.productInfo.Find(a.productid);
                                        product.saleoutnumber += a.number;
                                        product.saleoutnumber -= oldnumber;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<saleOutWarehouseDetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) =>
                                    {
                                        productInfo product = db.productInfo.Find(a.productid);
                                        product.saleoutnumber -= a.number;
                                        db.Entry(a).State = EntityState.Deleted;
                                    });
                                    db.SaveChanges();
                                }
                            }

                            tran.Commit();
                            gridControl1.DataSource = db.saleOutWarehouseDetailInfo.Where(p => p.masterid == info.id).ToList().ToDataTable(); ; ;
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
                saleOutWarehouseInfo info = (saleOutWarehouseInfo)this.ControlDataToModel(new saleOutWarehouseInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    List<saleOutWarehouseDetailInfo> list = db.saleOutWarehouseDetailInfo
                        .Where(p => p.masterid == info.id).ToList();
                    foreach (var item in list)
                    {
                        productInfo product = db.productInfo.Find(item.productid);
                        product.productinnumber -= item.number;
                    }
                    db.saleOutWarehouseDetailInfo.RemoveRange(list);
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
                        grdList.DataSource = db.saleOutWarehouseInfo.SqlQuery("select * from saleOutWarehouse").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.saleOutWarehouseInfo.SqlQuery($"select * from saleOutWarehouse where {sql}").ToList();
                    }
                }
            }
        }

        public override void AddFunction()
        {
            gridControl1.DataSource = new List<saleOutWarehouseDetailInfo>().ToDataTable();
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            saleOutWarehouseInfo info = grdListView.GetFocusedRow() as saleOutWarehouseInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.saleOutWarehouseDetailInfo.Where(p => p.masterid == info.id).ToList().ToDataTable();
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