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
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace MES.Form
{
	public partial class FrmproductBOM : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmproductBOM()
		{
			InitializeComponent();
		}
		private void FrmproductBOM_Load(object sender, EventArgs e)
        {
		
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new productBOMInfo(), treeList1, new []{ "txtproductBOMcode" , "txtunitcost" });
            InitSearchDicData();
            repositoryItemLookUpEditmaterialname.EditValueChanged += RepositoryItemLookUpEditmaterialname_EditValueChanged;
        }

        private void RepositoryItemLookUpEditmaterialname_EditValueChanged(object sender, EventArgs e)
        {
            using (var db=new MESDB())
            {
				LookUpEdit lookUpEdit=sender as LookUpEdit;
                int materialid=  lookUpEdit.EditValue.ToString().ToInt16();
                materialInfo material = db.materialInfo.Find(materialid);
                if (material != null)
                {
                    treeList1.FocusedNode["materialcode"] = material.code;
                    treeList1.FocusedNode["materialspec"] = material.spec;
                    treeList1.FocusedNode["materialtype"] = material.materialtype;
                    treeList1.FocusedNode["unit"] = material.unit;
                    treeList1.FocusedNode["unitprice"] = material.referprice;
                    treeList1.FocusedNode["warehouse"] = material.warehouse;
                }
            }
        }

        /// <summary>
        /// ??????????????????
        /// </summary>
        /// <returns></returns>
        private void Init()
		{
            txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("??????");
            repositoryItemtxtcreatorId.DataSource = GetDataTableUtils.SqlTable("??????");
            txteditorId.Properties.DataSource = GetDataTableUtils.SqlTable("??????");
            repositoryItemtxteditorId.DataSource = GetDataTableUtils.SqlTable("??????");
            txtcustomerid.Properties.DataSource = GetDataTableUtils.SqlTable("??????");     
			repositoryItemtxtcustomerid.DataSource= GetDataTableUtils.SqlTable("??????");  
			txtproductid.Properties.DataSource = GetDataTableUtils.SqlTable("??????");     
			repositoryItemtxtproductid.DataSource= GetDataTableUtils.SqlTable("??????");  
			txtunit.Properties.DataSource = GetDataTableUtils.SqlTable("????????????");     
			repositoryItemtxtunit.DataSource= GetDataTableUtils.SqlTable("????????????");  
			txtwarehouse.Properties.DataSource = GetDataTableUtils.SqlTable("??????");     
			repositoryItemtxtwarehouse.DataSource= GetDataTableUtils.SqlTable("??????");

            repositoryItemLookUpEditmaterialtype.DataSource = GetDataTableUtils.SqlTable("????????????");
            repositoryItemLookUpEditmaterialname.DataSource = GetDataTableUtils.SqlTable("??????");

        }
        /// <summary>
		/// ????????????
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
			fieldDictionary.Add("????????????","customercode");     
			fieldDictionary.Add("????????????","productcode");     
			fieldDictionary.Add("BOM??????","productBOMcode");     
        }
        public override void AddFunction()
        {
            treeList1.DataSource = new List<productBOMdetailInfo>().ToDataTable();
        }
		public override void InitgrdListDataSource()
        {
			 using (var con=new MESDB())///
            {
				grdList.DataSource=con.productBOMInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// ??????????????????
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtcustomerid.EditValue.ToString()))
			{
				"??????????????????".ShowWarning();
				txtcustomerid.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcustomercode.EditValue.ToString()))
			{
				"????????????????????????".ShowWarning();
				txtcustomercode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductcode.EditValue.ToString()))
			{
				"????????????????????????".ShowWarning();
				txtproductcode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtproductid.EditValue.ToString()))
			{
				"??????????????????".ShowWarning();
				txtproductid.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtspec.EditValue.ToString()))
			{
				"????????????????????????".ShowWarning();
				txtspec.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtunit.EditValue.ToString()))
			{
				"????????????????????????".ShowWarning();
				txtunit.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtwarehouse.EditValue.ToString()))
			{
				"??????????????????".ShowWarning();
				txtwarehouse.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtversion.EditValue.ToString()))
			{
				"?????????????????????".ShowWarning();
				txtversion.Focus();
				return false;
			}
            return true;
        }
        /// <summary>
		/// ??????
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            string code = "BOM" + DateTime.Now.GetDateTimeCode();
            DataTable dt = treeList1.DataSource as DataTable;
            try
            {
                productBOMInfo info = (productBOMInfo)this.ControlDataToModel(new productBOMInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Dictionary<string, List<productBOMdetailInfo>> dic =
                                dt.GetDataTableData<productBOMdetailInfo>();
                            if (info.id == 0)//??????
                            {
                                info.productBOMcode = code;
                                db.productBOMInfo.Add(info);
                                db.SaveChanges();
                                txtid.Text = info.id.ToString();
                                txtproductBOMcode.Text = code;
                                if (dt != null)
                                {
                                    List<productBOMdetailInfo> detaiListAdd =
                                        dic["Add"];
                                    detaiListAdd.ForEach(a =>
                                    {
                                        a.productBOMid = info.id;
                                        a.productBOMcode = info.productBOMcode;
                                        a.productcode = info.productcode;
                                    });
                                    db.productBOMdetailInfo.AddRange(detaiListAdd);
                                    db.SaveChanges();
                                }
                            }
                            else //??????
                            {
                                db.Entry(info).State = EntityState.Modified;
                                db.SaveChanges();
                                if (dt != null)
                                {
                                    List<productBOMdetailInfo> detaiListAdd =
                                        dic["Add"];
                                    detaiListAdd.ForEach(a =>
                                    {
                                        a.productBOMid = info.id;
                                        a.productBOMcode = info.productBOMcode;
                                        a.productcode = info.productcode;
                                    });
                                    db.productBOMdetailInfo.AddRange(detaiListAdd);

                                    List<productBOMdetailInfo> detaiListEdit =
                                        dic["Edit"];
                                    detaiListEdit.ForEach((a) =>
                                    {
                                        a.productBOMcode = info.productBOMcode;
                                        a.productcode = info.productcode;
                                        db.Entry(a).State = EntityState.Modified;
                                    });

                                    List<productBOMdetailInfo> detaiListDel =
                                        dic["Del"];
                                    detaiListDel.ForEach((a) =>
                                    {
                                        db.Entry(a).State = EntityState.Deleted;
                                    });
                                    db.SaveChanges();
                                }
                            }
                            tran.Commit();
                            treeList1.DataSource = db.productBOMdetailInfo.ToList().Where(p => p.productBOMid == info.id); ; ;
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
		/// ??????
		/// </summary>
		/// <returns></returns>
		public override bool DelFunction()
        {
            try
            {
                productBOMInfo info = (productBOMInfo)this.ControlDataToModel(new productBOMInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    List<productBOMdetailInfo> list = db.productBOMdetailInfo
                        .Where(p => p.productBOMid == info.id).ToList();
                    db.productBOMdetailInfo.RemoveRange(list);
                    treeList1.DataSource = null;
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
		/// ??????
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
                        grdList.DataSource = db.productBOMInfo.SqlQuery("select * from productBOM").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.productBOMInfo.SqlQuery($"select * from productBOM where {sql}").ToList();
                    }
                }
            }
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {
            productBOMInfo info = grdListView.GetFocusedRow() as productBOMInfo;
            if (info != null)
            {
                using (var db = new MESDB())
                {
                    treeList1.DataSource = db.productBOMdetailInfo.Where(p => p.productBOMid == info.id).ToList().ToDataTable();
                    treeList1.BestFitColumns();
                }
            }
        }

        /// <summary>
		/// ??????
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            productBOMdetailInfo productBoMdetail = new productBOMdetailInfo()
            {
                productcode = txtproductcode.Text,
                productBOMcode = txtproductBOMcode.Text
            };
            treeList1.Nodes.Add(productBoMdetail);
        }
		/// <summary>
		/// ????????????
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void toolStripMenuItemAddSon_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                productBOMdetailInfo productBoMdetail = new productBOMdetailInfo()
                {
                    pid = treeList1.FocusedNode["materialid"].ToString().ToInt16(),
                    productcode = txtproductcode.Text,
                    productBOMcode = txtproductBOMcode.Text
                };
                treeList1.FocusedNode.Nodes.Add(productBoMdetail);
            }
        }
		/// <summary>
		/// ??????
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void toolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            if (treeList1.FocusedNode != null)
            {
                treeList1.DeleteNode(treeList1.FocusedNode);
            }
        }

        private void treeList1_ValidateNode(object sender, ValidateNodeEventArgs e)
        {
            if (e.Node.ParentNode != null)
            {
                e.Node["money"] = decimal.Multiply(
                    e.Node["unitprice"].ToDecimal(0),
                    e.Node["unitusenumber"].ToDecimal(0))* e.Node.ParentNode["unitusenumber"].ToDecimal(1);
            }
            else
            {
                e.Node["money"] = decimal.Multiply(
                    e.Node["unitprice"].ToDecimal(0),
                    e.Node["unitusenumber"].ToDecimal(0));
            }
            treeList1.BestFitColumns();
            decimal totalprice = 0;
            foreach (TreeListNode node in treeList1.Nodes)
            {
                totalprice += sumNode(node);
            }

            txtunitcost.Text = totalprice.ToString();
        }

        private decimal sumNode(TreeListNode node)
        {
            decimal sum = 0;
            if (node.Nodes.Count == 0)
            {
                sum = node.GetValue("money").ToDecimal(0);
                return sum;
            }
            sum += node.GetValue("money").ToDecimal(0);
            foreach (TreeListNode item in node.Nodes)
            {
                sum += item.GetValue("money").ToDecimal(0);
            }
            return sum;
        }
        private void txtcustomerid_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {

                if (txtcustomerid.EditValue != null)
                {
                    int id = txtcustomerid.EditValue.ToString().ToInt16();
                    customerInfo customer = db.customerInfo.Where(p => p.id == id)
                        .First();
                    if (customer != null)
                    {
                        txtcustomercode.Text = customer.customercode;
                    }
                }
            }
        }
        private void txtproductid_EditValueChanged(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {

                if (txtproductid.EditValue != null)
                {
                    int id = txtproductid.EditValue.ToString().ToInt16();
                    productInfo product = db.productInfo.Find(id);
                    if (product != null)
                    {
                        txtproductcode.Text = product.productcode;
                        txtspec.Text = product.spec;
                        txtunit.EditValue = product.unit;
                        txtwarehouse.EditValue = product.warehouse;
                    }
                }
            }
        }

    }
}