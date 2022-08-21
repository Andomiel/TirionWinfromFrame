using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinformGeneralDeveloperFrame;
using WinformGeneralDeveloperFrame.Commons;
using DevExpress.XtraLayout;
using MES.Entity;
using System.Data.Entity;
using CCWin.SkinClass;
using CCWin.SkinControl;

namespace MES.Form
{
    public partial class Frmbuyer : FrmBaseForm
    {
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();

        public Frmbuyer()
        {
            InitializeComponent();
        }

        private void Frmbuyer_Load(object sender, EventArgs e)
        {
            InitFrom(xtraTabControl1, grdList, grdListView, new LayoutControlGroup[] {layoutControlGroup1},
                new buyerInfo(), gridControl1, new[] {"txtbuyercode", "txttotalprice"});
            InitSearchDicData();
            repositoryItemTextEditrequisitioncode.KeyDown += RepositoryItemTextEditrequisitioncode_KeyDown;
            txtsupplierid.EditValueChanged += Txtsupplierid_EditValueChanged;
        }

        private void Txtsupplierid_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {
                supplierInfo supplier = db.supplierInfo.Find(txtsupplierid.EditValue);
                txtsuppliercode.Text = supplier.suppliercode;
            }
        }

        private void RepositoryItemTextEditrequisitioncode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                using (var db = new MESDB())
                {
                    string code = gridView1.EditingValue.ToString();
                    if (!string.IsNullOrEmpty(code))
                    {
                        requisitiondetailInfo requisitiondetail = db.requisitiondetailInfo
                            .Where(p => p.requisitiondetailcode.Equals(code)).FirstOrDefault();
                        if (requisitiondetail == null)
                        {
                            "单号不存在".ShowWarning();
                        }
                        else
                        {
                            gridView1.GetFocusedDataRow()["materialid"] = requisitiondetail.materialid;
                            gridView1.GetFocusedDataRow()["materialcode"] = requisitiondetail.materialcode;
                            gridView1.GetFocusedDataRow()["materialspec"] = requisitiondetail.materialspec;
                            gridView1.GetFocusedDataRow()["materialunit"] = requisitiondetail.materialunit;
                            gridView1.GetFocusedDataRow()["buyernumber"] = requisitiondetail.requisitionnumber;
                            gridView1.GetFocusedDataRow()["unitprice"] = requisitiondetail.unitprice;
                            gridView1.GetFocusedDataRow()["money"] = requisitiondetail.money;
                            gridView1.GetFocusedDataRow()["warehouse"] = requisitiondetail.warehouse;
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
            repositoryItemtxtsupplierid.DataSource = GetDataTableUtils.SqlTable("物料");
            txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");
            repositoryItemtxtcreatorId.DataSource = GetDataTableUtils.SqlTable("用户");
            repositoryItemLookUpEditmaterialid.DataSource = GetDataTableUtils.SqlTable("物料");
            repositoryItemLookUpEditmaterialunit.DataSource = GetDataTableUtils.SqlTable("计量单位");
            repositoryItemLookUpEditwarehouse.DataSource = GetDataTableUtils.SqlTable("仓库");
        }

        /// <summary>
        /// 搜索字段
        /// </summary>
        /// <returns></returns>
        private void InitSearchDicData()
        {
            fieldDictionary.Add("id", "id");
            fieldDictionary.Add("采购单号", "buyercode");
            fieldDictionary.Add("采购日期", "buyerdate");
            fieldDictionary.Add("供应商", "supplierid");
            fieldDictionary.Add("供应商编码", "suppliercode");
            fieldDictionary.Add("完货日期", "deliverdate");
            fieldDictionary.Add("制单人", "creatorId");
            fieldDictionary.Add("金额", "totalprice");
            fieldDictionary.Add("备注", "remark");
        }

        public override void InitgrdListDataSource()
        {
            using (var con = new MESDB()) ///
            {
                grdList.DataSource = con.buyerInfo.ToList();
            }

            Init();
        }

        /// <summary>
        /// 字段为空校验
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtbuyerdate.ToString()))
            {
                "采购日期不能为空".ShowWarning();
                txtbuyerdate.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtsupplierid.EditValue.ToString()))
            {
                "供应商不能为空".ShowWarning();
                txtsupplierid.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtsuppliercode.EditValue.ToString()))
            {
                "供应商编码不能为空".ShowWarning();
                txtsuppliercode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtdeliverdate.EditValue.ToString()))
            {
                "完货日期不能为空".ShowWarning();
                txtdeliverdate.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtcreatorId.EditValue.ToString()))
            {
                "制单人不能为空".ShowWarning();
                txtcreatorId.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txttotalprice.EditValue.ToString()))
            {
                "金额不能为空".ShowWarning();
                txttotalprice.Focus();
                return false;
            }

            return true;
        }

        public override void AddFunction()
        {
            gridControl1.DataSource = new List<buyerdetailInfo>().ToDataTable();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveFunction()
        {
            string code = "CG" + DateTime.Now.GetDateTimeCode();

            DataTable dt = gridControl1.DataSource as DataTable;
            try
            {
                buyerInfo info = (buyerInfo) this.ControlDataToModel(new buyerInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<buyerdetailInfo>> dic =
                                dt.GetDataTableData<buyerdetailInfo>();
                            if (info.id == 0) //新增
                            {
                                info.buyercode = code;
                                db.buyerInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtbuyercode.Text = code;
                                if (dt != null)
                                {
                                    List<buyerdetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        num++;
                                        string codedetail = code + num;
                                        a.buyercode = info.buyercode;
                                        a.buyerid = info.id;
                                        a.buyerdetailcode = codedetail;
                                    });
                                    db.buyerdetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //更新
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<buyerdetailInfo> detaiListAdd =
                                        dic["Add"];
                                    int num = 0;
                                    detaiListAdd.ForEach(a =>
                                    {
                                        a.buyercode = info.buyercode;
                                        a.buyerid = info.id;
                                        num++;
                                        string codedetail = code + num;
                                        a.buyerdetailcode = codedetail;
                                    });
                                    db.buyerdetailInfo.AddRange(detaiListAdd);

                                    List<buyerdetailInfo> detaiListEdit =
                                        dic["Edit"];

                                    detaiListEdit.ForEach((a) =>
                                    {
                                        a.buyercode = info.buyercode;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<buyerdetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) => { db.Entry(a).State = EntityState.Deleted; });
                                    db.SaveChanges();
                                }
                            }

                            tran.Commit();
                            gridControl1.DataSource = db.buyerdetailInfo.ToList().Where(p=>p.buyerid==info.id);
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
                buyerInfo info = (buyerInfo) this.ControlDataToModel(new buyerInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State = EntityState.Deleted;
                    List<buyerdetailInfo> list = db.buyerdetailInfo
                        .Where(p => p.buyerid == info.id).ToList();
                    db.buyerdetailInfo.RemoveRange(list);
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
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string sql = frm.sql;
                using (var db = new MESDB())
                {
                    if (string.IsNullOrEmpty(sql))
                    {
                        grdList.DataSource = db.buyerInfo.SqlQuery("select * from buyer").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.buyerInfo.SqlQuery($"select * from buyer where {sql}").ToList();
                    }
                }
            }
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            buyerInfo info = grdListView.GetFocusedRow() as buyerInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    gridControl1.DataSource = db.buyerdetailInfo.Where(p => p.buyerid == info.id).ToList().ToDataTable();
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

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //gridControl1.RefreshDataSource();
            //DataTable dt=gridControl1.DataSource as DataTable; ;   
            //decimal total = 0;
            //foreach (DataRow row in dt.Rows)
            //{
            //    total += row.ItemArray[10].ToDecimal(0);
            //}
            //txttotalprice.Text = total.ToString();
        }

        private void gridControl1_Validated(object sender, EventArgs e)
        {
            DataTable dt = gridControl1.DataSource as DataTable; ;
            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += row.ItemArray[10].ToDecimal(0);
            }
            txttotalprice.Text = total.ToString();
        }

        private void gridView1_ValidateRow_1(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (gridView1.GetFocusedDataRow()["money"].ToString().IsNullOrEmpty())
            {
                e.Valid = false;
                e.ErrorText = "请输入请购明细单号";
            }
        }
    }
}