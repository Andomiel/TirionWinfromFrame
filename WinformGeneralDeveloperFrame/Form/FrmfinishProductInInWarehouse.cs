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

namespace MES.Form
{
	public partial class FrmfinishProductInInWarehouse : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmfinishProductInInWarehouse()
		{
			InitializeComponent();
		}
		private void FrmfinishProductInInWarehouse_Load(object sender, EventArgs e)
        {
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new finishProductInInWarehouseInfo(),gridControl1,new []{"txtcode"});
            InitSearchDicData();
            repositoryItemTextEditcompletionProductInWarehouseDetailCode.KeyDown += RepositoryItemTextEditcompletionProductInWarehouseDetailCode_KeyDown;
        }

        private void RepositoryItemTextEditcompletionProductInWarehouseDetailCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                using (var db = new MESDB())
                {
                    string code = gridView1.EditingValue.ToString();
                    if (!string.IsNullOrEmpty(code))
                    {
                        completionProductInWarehouseDetailInfo buyerdetailInfo = db.completionProductInWarehouseDetailInfo
                            .Where(p => p.detailcode == code).FirstOrDefault();
                        if (buyerdetailInfo == null)
                        {
                            "单号不存在".ShowWarning();
                        }
                        else
                        {
                            gridView1.GetFocusedDataRow()["completionProductInWarehouseDetailCode"] = buyerdetailInfo.detailcode;
                            gridView1.GetFocusedDataRow()["completionProductInWarehouseCode"] = buyerdetailInfo.mastercode;
                            gridView1.GetFocusedDataRow()["wocode"] = buyerdetailInfo.wocode;
                            gridView1.GetFocusedDataRow()["salecode"] = buyerdetailInfo.salecode;
                            gridView1.GetFocusedDataRow()["saledetailcode"] = buyerdetailInfo.saledetailcode;
                            gridView1.GetFocusedDataRow()["productid"] = buyerdetailInfo.productid;
                            gridView1.GetFocusedDataRow()["productcode"] = buyerdetailInfo.productcode;
                            gridView1.GetFocusedDataRow()["productspec"] = buyerdetailInfo.productcode;
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
				grdList.DataSource=con.finishProductInInWarehouseInfo.ToList();
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
				"制单日期不能为空".ShowWarning();
				txtcreateTime.Focus();
				return false;
			}
			//if(string.IsNullOrEmpty(txtcode.EditValue.ToString()))
			//{
			//	"入库单号不能为空".ShowWarning();
			//	txtcode.Focus();
			//	return false;
			//}
			return true;
        }
        /// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            string code = "MPI" + DateTime.Now.GetDateTimeCode();

            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                finishProductInInWarehouseInfo info = (finishProductInInWarehouseInfo)this.ControlDataToModel(new finishProductInInWarehouseInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<finishProductInInWarehouseDetailInfo>> dic =
                                dt.GetDataTableData<finishProductInInWarehouseDetailInfo>();
                            if (info.id == 0) //新增
                            {
                                info.code = code;
                                db.finishProductInInWarehouseInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtcode.Text = code;
                                if (dt != null)
                                {
                                    List<finishProductInInWarehouseDetailInfo> detaiListAdd =
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
                                        product.productinnumber += a.number;
                                    });
                                    db.finishProductInInWarehouseDetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<finishProductInInWarehouseDetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        a.masterid = info.id;
                                        a.mastercode = info.code;
                                        num++;
                                        string codedetail = code + num;
                                        a.detailcode = codedetail;
                                        productInfo product = db.productInfo.Find(a.productid);
                                        product.productinnumber += a.number;
                                    });
                                    db.finishProductInInWarehouseDetailInfo.AddRange(detaiListAdd);

                                    List<finishProductInInWarehouseDetailInfo> detaiListEdit =
                                        dic["Edit"];

                                    detaiListEdit.ForEach((a) =>
                                    {
                                        decimal oldnumber =
                                            GetDataTableUtils
                                                .SqlTableBySql(
                                                    $"select number from finishProductInInWarehouseDetail where id={a.id}")
                                                .Rows[0]["number"].ToDecimal(0);
                                            //a.buyercode = info.buyercode;
                                        productInfo product = db.productInfo.Find(a.productid);
                                        product.productinnumber += a.number;
                                        product.productinnumber -= oldnumber;
                                        
                                        db.Entry(a).State = EntityState.Modified;
                                        
                                    });

                                    List<finishProductInInWarehouseDetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) =>
                                    {
                                        productInfo product = db.productInfo.Find(a.productid);
                                        product.productinnumber -= a.number;
                                        db.Entry(a).State = EntityState.Deleted;
                                    });
                                    db.SaveChanges();
                                }
                            }

                            tran.Commit();
                            gridControl1.DataSource = db.finishProductInInWarehouseDetailInfo.ToList().Where(p => p.masterid == info.id); ; ;
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
                finishProductInInWarehouseInfo info = (finishProductInInWarehouseInfo)this.ControlDataToModel(new finishProductInInWarehouseInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    List<finishProductInInWarehouseDetailInfo> list = db.finishProductInInWarehouseDetailInfo
                        .Where(p => p.masterid == info.id).ToList();
                    foreach (var item in list)
                    {
                        productInfo product = db.productInfo.Find(item.productid);
                        product.productinnumber -= item.number;
                    }
                    db.finishProductInInWarehouseDetailInfo.RemoveRange(list);
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
                        grdList.DataSource = db.finishProductInInWarehouseInfo.SqlQuery("select * from finishProductInInWarehouse").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.finishProductInInWarehouseInfo.SqlQuery($"select * from finishProductInInWarehouse where {sql}").ToList();
                    }
                }
            }
        }

        public override void AddFunction()
        {
            gridControl1.DataSource = new List<finishProductInInWarehouseDetailInfo>().ToDataTable();
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            finishProductInInWarehouseInfo info = grdListView.GetFocusedRow() as finishProductInInWarehouseInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.finishProductInInWarehouseDetailInfo.Where(p => p.masterid == info.id).ToList().ToDataTable();
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