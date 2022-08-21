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
	public partial class Frmbuyerreturn : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmbuyerreturn()
		{
			InitializeComponent();
		}
		private void Frmbuyerreturn_Load(object sender, EventArgs e)
        {
			
            InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new buyerreturnInfo(),gridControl1,new []{ "txtreturnbuyercode" , "txttotalprice" });
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
                            .Where(p => p.buyerdetailcode.Equals(code)).FirstOrDefault();
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
                            gridView1.GetFocusedDataRow()["returnnumber"] = buyerdetailInfo.buyernumber;
                            gridView1.GetFocusedDataRow()["unitprice"] = buyerdetailInfo.unitprice;
                            gridView1.GetFocusedDataRow()["money"] = buyerdetailInfo.money;
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
            repositoryItemLookUpEditwarehouse.DataSource = GetDataTableUtils.SqlTable("仓库");
            repositoryItemLookUpEditunit.DataSource = GetDataTableUtils.SqlTable("计量单位");
            repositoryItemLookUpEditmaterialid.DataSource = GetDataTableUtils.SqlTable("物料");
        }
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
			fieldDictionary.Add("供应商编号","suppliercode");     
			fieldDictionary.Add("供应商名称","supplierid");     
        }

		public override void InitgrdListDataSource()
        {
            using (var con=new MESDB())
            {
				grdList.DataSource=con.buyerreturnInfo.ToList();
            }
            Init();
		}
        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            buyerreturnInfo info = grdListView.GetFocusedRow() as buyerreturnInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.buyerreturndetailInfo.Where(p => p.buyerreturnid == info.id).ToList().ToDataTable();
                    gridView1.BestFitColumns();
                }
            }
        }
        /// <summary>
        /// 字段为空校验
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtreturndate.Text.ToString()))
			{
				"退货日期不能为空".ShowWarning();
				txtreturndate.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtsuppliercode.EditValue.ToString()))
			{
				"供应商编号不能为空".ShowWarning();
				txtsuppliercode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtsupplierid.EditValue.ToString()))
			{
				"供应商名称不能为空".ShowWarning();
				txtsupplierid.Focus();
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
            string code = "PR" + DateTime.Now.GetDateTimeCode();

            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                buyerreturnInfo info = (buyerreturnInfo)this.ControlDataToModel(new buyerreturnInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<buyerreturndetailInfo>> dic =
                                dt.GetDataTableData<buyerreturndetailInfo>();
                            if (info.id == 0) //新增
                            {
                                info.returnbuyercode = code;
                                db.buyerreturnInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtreturnbuyercode.Text = code;
                                if (dt != null)
                                {
                                    List<buyerreturndetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        string codedetail = code  + num;
                                        a.buyerreturnid = info.id;
                                        a.returnbuyercode = code;
                                        a.returnbuyerdetailcode = codedetail;
                                    });
                                    db.buyerreturndetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<buyerreturndetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        a.returnbuyercode = info.returnbuyercode;
                                        a.buyerreturnid = info.id;
                                        num++;
                                        string codedetail = code  + num;
                                        a.returnbuyerdetailcode = codedetail;
                                    });
                                    db.buyerreturndetailInfo.AddRange(detaiListAdd);

                                    List<buyerreturndetailInfo> detaiListEdit =
                                        dic["Edit"];

                                    detaiListEdit.ForEach((a) =>
                                    {
                                        a.returnbuyercode = info.returnbuyercode;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<buyerreturndetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) => { db.Entry(a).State = EntityState.Deleted; });
                                    db.SaveChanges();
                                }
                            }

                            tran.Commit();
                            gridControl1.DataSource = db.buyerreturndetailInfo.ToList().Where(p => p.buyerreturnid == info.id); ; ;
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
                buyerreturnInfo info = (buyerreturnInfo)this.ControlDataToModel(new buyerreturnInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    List<buyerreturndetailInfo> list = db.buyerreturndetailInfo
                        .Where(p => p.buyerreturnid == info.id).ToList();
                    db.buyerreturndetailInfo.RemoveRange(list);
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

        public override void AddFunction()
        {
            gridControl1.DataSource = new List<buyerreturndetailInfo>().ToDataTable();
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
                        grdList.DataSource = db.buyerreturnInfo.SqlQuery("select * from buyerreturn").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.buyerreturnInfo.SqlQuery($"select * from buyerreturn where {sql}").ToList();
                    }
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

        private void txtsupplierid_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {
                supplierInfo supplier = db.supplierInfo.Find(txtsupplierid.EditValue);
                txtsuppliercode.Text = supplier.suppliercode;
            }
        }
    }
}