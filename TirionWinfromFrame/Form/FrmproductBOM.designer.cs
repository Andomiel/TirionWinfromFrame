
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;

namespace MES.Form
{
    partial class  FrmproductBOM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtcustomerid = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtproductid = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtunit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtwarehouse = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabDataList = new DevExpress.XtraTab.XtraTabPage();
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.grdListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtcreatorId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxteditorId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabDataDetail = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txteditTime = new DevExpress.XtraEditors.DateEdit();
            this.txtcreateTime = new DevExpress.XtraEditors.DateEdit();
            this.txteditorId = new DevExpress.XtraEditors.LookUpEdit();
            this.txtcreatorId = new DevExpress.XtraEditors.LookUpEdit();
            this.txtunitcost = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemLookUpEditmaterialname = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn10 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemLookUpEditmaterialtype = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.treeListColumn11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn12 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn13 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn14 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn15 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn16 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddSon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.txtid = new DevExpress.XtraEditors.TextEdit();
            this.txtcustomerid = new DevExpress.XtraEditors.LookUpEdit();
            this.txtcustomercode = new DevExpress.XtraEditors.TextEdit();
            this.txtproductcode = new DevExpress.XtraEditors.TextEdit();
            this.txtproductid = new DevExpress.XtraEditors.LookUpEdit();
            this.txtspec = new DevExpress.XtraEditors.TextEdit();
            this.txtunit = new DevExpress.XtraEditors.LookUpEdit();
            this.txtwarehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.txtversion = new DevExpress.XtraEditors.TextEdit();
            this.txtproductBOMcode = new DevExpress.XtraEditors.TextEdit();
            this.txtremark = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtunitcost111 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcustomerid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtproductid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtunit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtwarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcreatorId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxteditorId)).BeginInit();
            this.tabDataDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txteditTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txteditTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txteditorId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreatorId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunitcost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialtype)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomerid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomercode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtspec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtversion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductBOMcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunitcost111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "id";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "客户";
            this.gridColumn2.ColumnEdit = this.repositoryItemtxtcustomerid;
            this.gridColumn2.FieldName = "customerid";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 201;
            // 
            // repositoryItemtxtcustomerid
            // 
            this.repositoryItemtxtcustomerid.AutoHeight = false;
            this.repositoryItemtxtcustomerid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtcustomerid.DisplayMember = "Name";
            this.repositoryItemtxtcustomerid.Name = "repositoryItemtxtcustomerid";
            this.repositoryItemtxtcustomerid.NullText = "";
            this.repositoryItemtxtcustomerid.ValueMember = "ID";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "客户编码";
            this.gridColumn3.FieldName = "customercode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 201;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "产品编号";
            this.gridColumn4.FieldName = "productcode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 201;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "产品";
            this.gridColumn5.ColumnEdit = this.repositoryItemtxtproductid;
            this.gridColumn5.FieldName = "productid";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 201;
            // 
            // repositoryItemtxtproductid
            // 
            this.repositoryItemtxtproductid.AutoHeight = false;
            this.repositoryItemtxtproductid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtproductid.DisplayMember = "Name";
            this.repositoryItemtxtproductid.Name = "repositoryItemtxtproductid";
            this.repositoryItemtxtproductid.NullText = "";
            this.repositoryItemtxtproductid.ValueMember = "ID";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "规格型号";
            this.gridColumn6.FieldName = "spec";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 201;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "计量单位";
            this.gridColumn7.ColumnEdit = this.repositoryItemtxtunit;
            this.gridColumn7.FieldName = "unit";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 201;
            // 
            // repositoryItemtxtunit
            // 
            this.repositoryItemtxtunit.AutoHeight = false;
            this.repositoryItemtxtunit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtunit.DisplayMember = "Name";
            this.repositoryItemtxtunit.Name = "repositoryItemtxtunit";
            this.repositoryItemtxtunit.NullText = "";
            this.repositoryItemtxtunit.ValueMember = "ID";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "仓库";
            this.gridColumn8.ColumnEdit = this.repositoryItemtxtwarehouse;
            this.gridColumn8.FieldName = "warehouse";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 201;
            // 
            // repositoryItemtxtwarehouse
            // 
            this.repositoryItemtxtwarehouse.AutoHeight = false;
            this.repositoryItemtxtwarehouse.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtwarehouse.DisplayMember = "Name";
            this.repositoryItemtxtwarehouse.Name = "repositoryItemtxtwarehouse";
            this.repositoryItemtxtwarehouse.NullText = "";
            this.repositoryItemtxtwarehouse.ValueMember = "ID";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "版本号";
            this.gridColumn9.FieldName = "version";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 201;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "BOM编号";
            this.gridColumn10.FieldName = "productBOMcode";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 201;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "备注";
            this.gridColumn11.FieldName = "remark";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 201;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 34);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabDataList;
            this.xtraTabControl1.Size = new System.Drawing.Size(1047, 722);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDataList,
            this.tabDataDetail});
            // 
            // tabDataList
            // 
            this.tabDataList.Controls.Add(this.grdList);
            this.tabDataList.Name = "tabDataList";
            this.tabDataList.Size = new System.Drawing.Size(1041, 693);
            this.tabDataList.Text = "数据列表";
            // 
            // grdList
            // 
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(0, 0);
            this.grdList.MainView = this.grdListView;
            this.grdList.Name = "grdList";
            this.grdList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemtxtcreatorId,
            this.repositoryItemtxteditorId});
            this.grdList.Size = new System.Drawing.Size(1041, 693);
            this.grdList.TabIndex = 0;
            this.grdList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdListView});
            // 
            // grdListView
            // 
            this.grdListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15});
            this.grdListView.GridControl = this.grdList;
            this.grdListView.Name = "grdListView";
            this.grdListView.OptionsBehavior.Editable = false;
            this.grdListView.OptionsView.ColumnAutoWidth = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "创建人";
            this.gridColumn12.ColumnEdit = this.repositoryItemtxtcreatorId;
            this.gridColumn12.FieldName = "creatorId";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            // 
            // repositoryItemtxtcreatorId
            // 
            this.repositoryItemtxtcreatorId.AutoHeight = false;
            this.repositoryItemtxtcreatorId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtcreatorId.DisplayMember = "Name";
            this.repositoryItemtxtcreatorId.Name = "repositoryItemtxtcreatorId";
            this.repositoryItemtxtcreatorId.NullText = "";
            this.repositoryItemtxtcreatorId.ValueMember = "ID";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "创建时间";
            this.gridColumn13.DisplayFormat.FormatString = "G";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn13.FieldName = "createTime";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "编辑人";
            this.gridColumn14.ColumnEdit = this.repositoryItemtxteditorId;
            this.gridColumn14.FieldName = "editorId";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            // 
            // repositoryItemtxteditorId
            // 
            this.repositoryItemtxteditorId.AutoHeight = false;
            this.repositoryItemtxteditorId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxteditorId.DisplayMember = "Name";
            this.repositoryItemtxteditorId.Name = "repositoryItemtxteditorId";
            this.repositoryItemtxteditorId.NullText = "";
            this.repositoryItemtxteditorId.ValueMember = "ID";
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "编辑时间";
            this.gridColumn15.DisplayFormat.FormatString = "G";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn15.FieldName = "editTime";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 13;
            // 
            // tabDataDetail
            // 
            this.tabDataDetail.Controls.Add(this.panelControl2);
            this.tabDataDetail.Name = "tabDataDetail";
            this.tabDataDetail.Size = new System.Drawing.Size(1041, 693);
            this.tabDataDetail.Text = "数据编辑";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.layoutControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1041, 693);
            this.panelControl2.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txteditTime);
            this.layoutControl1.Controls.Add(this.txtcreateTime);
            this.layoutControl1.Controls.Add(this.txteditorId);
            this.layoutControl1.Controls.Add(this.txtcreatorId);
            this.layoutControl1.Controls.Add(this.txtunitcost);
            this.layoutControl1.Controls.Add(this.xtraTabControl2);
            this.layoutControl1.Controls.Add(this.txtid);
            this.layoutControl1.Controls.Add(this.txtcustomerid);
            this.layoutControl1.Controls.Add(this.txtcustomercode);
            this.layoutControl1.Controls.Add(this.txtproductcode);
            this.layoutControl1.Controls.Add(this.txtproductid);
            this.layoutControl1.Controls.Add(this.txtspec);
            this.layoutControl1.Controls.Add(this.txtunit);
            this.layoutControl1.Controls.Add(this.txtwarehouse);
            this.layoutControl1.Controls.Add(this.txtversion);
            this.layoutControl1.Controls.Add(this.txtproductBOMcode);
            this.layoutControl1.Controls.Add(this.txtremark);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1037, 689);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txteditTime
            // 
            this.txteditTime.EditValue = null;
            this.txteditTime.Location = new System.Drawing.Point(570, 156);
            this.txteditTime.Name = "txteditTime";
            this.txteditTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txteditTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txteditTime.Properties.DisplayFormat.FormatString = "G";
            this.txteditTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txteditTime.Properties.EditFormat.FormatString = "G";
            this.txteditTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txteditTime.Properties.Mask.EditMask = "G";
            this.txteditTime.Size = new System.Drawing.Size(455, 20);
            this.txteditTime.StyleController = this.layoutControl1;
            this.txteditTime.TabIndex = 1;
            // 
            // txtcreateTime
            // 
            this.txtcreateTime.EditValue = null;
            this.txtcreateTime.Location = new System.Drawing.Point(570, 132);
            this.txtcreateTime.Name = "txtcreateTime";
            this.txtcreateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcreateTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcreateTime.Properties.DisplayFormat.FormatString = "G";
            this.txtcreateTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtcreateTime.Properties.EditFormat.FormatString = "G";
            this.txtcreateTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtcreateTime.Properties.Mask.EditMask = "G";
            this.txtcreateTime.Size = new System.Drawing.Size(455, 20);
            this.txtcreateTime.StyleController = this.layoutControl1;
            this.txtcreateTime.TabIndex = 1;
            // 
            // txteditorId
            // 
            this.txteditorId.Location = new System.Drawing.Point(64, 156);
            this.txteditorId.Name = "txteditorId";
            this.txteditorId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txteditorId.Properties.DisplayMember = "Name";
            this.txteditorId.Properties.ValueMember = "ID";
            this.txteditorId.Size = new System.Drawing.Size(450, 20);
            this.txteditorId.StyleController = this.layoutControl1;
            this.txteditorId.TabIndex = 1;
            // 
            // txtcreatorId
            // 
            this.txtcreatorId.Location = new System.Drawing.Point(64, 132);
            this.txtcreatorId.Name = "txtcreatorId";
            this.txtcreatorId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcreatorId.Properties.DisplayMember = "Name";
            this.txtcreatorId.Properties.ValueMember = "ID";
            this.txtcreatorId.Size = new System.Drawing.Size(450, 20);
            this.txtcreatorId.StyleController = this.layoutControl1;
            this.txtcreatorId.TabIndex = 1;
            // 
            // txtunitcost
            // 
            this.txtunitcost.Location = new System.Drawing.Point(64, 180);
            this.txtunitcost.Name = "txtunitcost";
            this.txtunitcost.Size = new System.Drawing.Size(450, 20);
            this.txtunitcost.StyleController = this.layoutControl1;
            this.txtunitcost.TabIndex = 1;
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Location = new System.Drawing.Point(12, 204);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl2.Size = new System.Drawing.Size(1013, 473);
            this.xtraTabControl2.TabIndex = 12;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.treeList1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1007, 444);
            this.xtraTabPage1.Text = "物料清单";
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn7,
            this.treeListColumn8,
            this.treeListColumn9,
            this.treeListColumn10,
            this.treeListColumn11,
            this.treeListColumn12,
            this.treeListColumn13,
            this.treeListColumn14,
            this.treeListColumn15,
            this.treeListColumn16,
            this.treeListColumn6});
            this.treeList1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "id";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.ParentFieldName = "pid";
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditmaterialtype,
            this.repositoryItemLookUpEditmaterialname});
            this.treeList1.Size = new System.Drawing.Size(1007, 444);
            this.treeList1.TabIndex = 0;
            this.treeList1.ValidateNode += new DevExpress.XtraTreeList.ValidateNodeEventHandler(this.treeList1_ValidateNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "id";
            this.treeListColumn1.Name = "treeListColumn1";
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "pid";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "treeListColumn3";
            this.treeListColumn3.FieldName = "productBOMid";
            this.treeListColumn3.Name = "treeListColumn3";
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "BOM编号";
            this.treeListColumn4.FieldName = "productBOMcode";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowEdit = false;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "产品编号";
            this.treeListColumn5.FieldName = "productcode";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.OptionsColumn.AllowEdit = false;
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.Caption = "物料名称";
            this.treeListColumn7.ColumnEdit = this.repositoryItemLookUpEditmaterialname;
            this.treeListColumn7.FieldName = "materialid";
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEditmaterialname
            // 
            this.repositoryItemLookUpEditmaterialname.AutoHeight = false;
            this.repositoryItemLookUpEditmaterialname.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditmaterialname.DisplayMember = "Name";
            this.repositoryItemLookUpEditmaterialname.Name = "repositoryItemLookUpEditmaterialname";
            this.repositoryItemLookUpEditmaterialname.NullText = "";
            this.repositoryItemLookUpEditmaterialname.ValueMember = "ID";
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.Caption = "物料编码";
            this.treeListColumn8.FieldName = "materialcode";
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.OptionsColumn.AllowEdit = false;
            this.treeListColumn8.Visible = true;
            this.treeListColumn8.VisibleIndex = 1;
            // 
            // treeListColumn9
            // 
            this.treeListColumn9.Caption = "规格型号";
            this.treeListColumn9.FieldName = "materialspec";
            this.treeListColumn9.Name = "treeListColumn9";
            this.treeListColumn9.OptionsColumn.AllowEdit = false;
            this.treeListColumn9.Visible = true;
            this.treeListColumn9.VisibleIndex = 2;
            // 
            // treeListColumn10
            // 
            this.treeListColumn10.Caption = "物料类型";
            this.treeListColumn10.ColumnEdit = this.repositoryItemLookUpEditmaterialtype;
            this.treeListColumn10.FieldName = "materialtype";
            this.treeListColumn10.Name = "treeListColumn10";
            this.treeListColumn10.OptionsColumn.AllowEdit = false;
            this.treeListColumn10.Visible = true;
            this.treeListColumn10.VisibleIndex = 3;
            // 
            // repositoryItemLookUpEditmaterialtype
            // 
            this.repositoryItemLookUpEditmaterialtype.AutoHeight = false;
            this.repositoryItemLookUpEditmaterialtype.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditmaterialtype.DisplayMember = "Name";
            this.repositoryItemLookUpEditmaterialtype.Name = "repositoryItemLookUpEditmaterialtype";
            this.repositoryItemLookUpEditmaterialtype.NullText = "";
            this.repositoryItemLookUpEditmaterialtype.ValueMember = "ID";
            // 
            // treeListColumn11
            // 
            this.treeListColumn11.Caption = "单位用量";
            this.treeListColumn11.FieldName = "unitusenumber";
            this.treeListColumn11.Name = "treeListColumn11";
            this.treeListColumn11.Visible = true;
            this.treeListColumn11.VisibleIndex = 4;
            // 
            // treeListColumn12
            // 
            this.treeListColumn12.Caption = "计量单位";
            this.treeListColumn12.ColumnEdit = this.repositoryItemtxtunit;
            this.treeListColumn12.FieldName = "unit";
            this.treeListColumn12.Name = "treeListColumn12";
            this.treeListColumn12.OptionsColumn.AllowEdit = false;
            this.treeListColumn12.Visible = true;
            this.treeListColumn12.VisibleIndex = 5;
            // 
            // treeListColumn13
            // 
            this.treeListColumn13.Caption = "仓库";
            this.treeListColumn13.ColumnEdit = this.repositoryItemtxtwarehouse;
            this.treeListColumn13.FieldName = "warehouse";
            this.treeListColumn13.Name = "treeListColumn13";
            this.treeListColumn13.OptionsColumn.AllowEdit = false;
            this.treeListColumn13.Visible = true;
            this.treeListColumn13.VisibleIndex = 6;
            // 
            // treeListColumn14
            // 
            this.treeListColumn14.Caption = "单价";
            this.treeListColumn14.FieldName = "unitprice";
            this.treeListColumn14.Name = "treeListColumn14";
            this.treeListColumn14.Visible = true;
            this.treeListColumn14.VisibleIndex = 7;
            // 
            // treeListColumn15
            // 
            this.treeListColumn15.AllNodesSummary = true;
            this.treeListColumn15.Caption = "金额";
            this.treeListColumn15.FieldName = "money";
            this.treeListColumn15.Name = "treeListColumn15";
            this.treeListColumn15.OptionsColumn.AllowEdit = false;
            this.treeListColumn15.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColumn15.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Sum;
            this.treeListColumn15.Visible = true;
            this.treeListColumn15.VisibleIndex = 8;
            // 
            // treeListColumn16
            // 
            this.treeListColumn16.Caption = "备注";
            this.treeListColumn16.FieldName = "remark";
            this.treeListColumn16.Name = "treeListColumn16";
            this.treeListColumn16.Visible = true;
            this.treeListColumn16.VisibleIndex = 9;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "明细编号";
            this.treeListColumn6.FieldName = "productBOMdetailcode";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAdd,
            this.toolStripMenuItemAddSon,
            this.toolStripMenuItemDel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemAdd.Text = "新增";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.toolStripMenuItemAdd_Click);
            // 
            // toolStripMenuItemAddSon
            // 
            this.toolStripMenuItemAddSon.Name = "toolStripMenuItemAddSon";
            this.toolStripMenuItemAddSon.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemAddSon.Text = "新增子级";
            this.toolStripMenuItemAddSon.Click += new System.EventHandler(this.toolStripMenuItemAddSon_Click);
            // 
            // toolStripMenuItemDel
            // 
            this.toolStripMenuItemDel.Name = "toolStripMenuItemDel";
            this.toolStripMenuItemDel.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemDel.Text = "删除";
            this.toolStripMenuItemDel.Click += new System.EventHandler(this.toolStripMenuItemDel_Click);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(64, 12);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(450, 20);
            this.txtid.StyleController = this.layoutControl1;
            this.txtid.TabIndex = 1;
            // 
            // txtcustomerid
            // 
            this.txtcustomerid.EditValue = "";
            this.txtcustomerid.Location = new System.Drawing.Point(64, 36);
            this.txtcustomerid.Name = "txtcustomerid";
            this.txtcustomerid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcustomerid.Properties.DisplayMember = "Name";
            this.txtcustomerid.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtcustomerid.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtcustomerid.Properties.ValueMember = "ID";
            this.txtcustomerid.Size = new System.Drawing.Size(450, 20);
            this.txtcustomerid.StyleController = this.layoutControl1;
            this.txtcustomerid.TabIndex = 2;
            this.txtcustomerid.EditValueChanged += new System.EventHandler(this.txtcustomerid_EditValueChanged);
            // 
            // txtcustomercode
            // 
            this.txtcustomercode.Location = new System.Drawing.Point(570, 36);
            this.txtcustomercode.Name = "txtcustomercode";
            this.txtcustomercode.Size = new System.Drawing.Size(455, 20);
            this.txtcustomercode.StyleController = this.layoutControl1;
            this.txtcustomercode.TabIndex = 3;
            // 
            // txtproductcode
            // 
            this.txtproductcode.Location = new System.Drawing.Point(570, 60);
            this.txtproductcode.Name = "txtproductcode";
            this.txtproductcode.Size = new System.Drawing.Size(455, 20);
            this.txtproductcode.StyleController = this.layoutControl1;
            this.txtproductcode.TabIndex = 4;
            // 
            // txtproductid
            // 
            this.txtproductid.EditValue = "";
            this.txtproductid.Location = new System.Drawing.Point(64, 60);
            this.txtproductid.Name = "txtproductid";
            this.txtproductid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtproductid.Properties.DisplayMember = "Name";
            this.txtproductid.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtproductid.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtproductid.Properties.ValueMember = "ID";
            this.txtproductid.Size = new System.Drawing.Size(450, 20);
            this.txtproductid.StyleController = this.layoutControl1;
            this.txtproductid.TabIndex = 5;
            this.txtproductid.EditValueChanged += new System.EventHandler(this.txtproductid_EditValueChanged);
            // 
            // txtspec
            // 
            this.txtspec.Location = new System.Drawing.Point(64, 84);
            this.txtspec.Name = "txtspec";
            this.txtspec.Size = new System.Drawing.Size(450, 20);
            this.txtspec.StyleController = this.layoutControl1;
            this.txtspec.TabIndex = 6;
            // 
            // txtunit
            // 
            this.txtunit.EditValue = "";
            this.txtunit.Location = new System.Drawing.Point(570, 84);
            this.txtunit.Name = "txtunit";
            this.txtunit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtunit.Properties.DisplayMember = "Name";
            this.txtunit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtunit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtunit.Properties.ValueMember = "ID";
            this.txtunit.Size = new System.Drawing.Size(455, 20);
            this.txtunit.StyleController = this.layoutControl1;
            this.txtunit.TabIndex = 7;
            // 
            // txtwarehouse
            // 
            this.txtwarehouse.EditValue = "";
            this.txtwarehouse.Location = new System.Drawing.Point(64, 108);
            this.txtwarehouse.Name = "txtwarehouse";
            this.txtwarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtwarehouse.Properties.DisplayMember = "Name";
            this.txtwarehouse.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtwarehouse.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtwarehouse.Properties.ValueMember = "ID";
            this.txtwarehouse.Size = new System.Drawing.Size(450, 20);
            this.txtwarehouse.StyleController = this.layoutControl1;
            this.txtwarehouse.TabIndex = 8;
            // 
            // txtversion
            // 
            this.txtversion.Location = new System.Drawing.Point(570, 108);
            this.txtversion.Name = "txtversion";
            this.txtversion.Size = new System.Drawing.Size(455, 20);
            this.txtversion.StyleController = this.layoutControl1;
            this.txtversion.TabIndex = 9;
            // 
            // txtproductBOMcode
            // 
            this.txtproductBOMcode.Location = new System.Drawing.Point(570, 12);
            this.txtproductBOMcode.Name = "txtproductBOMcode";
            this.txtproductBOMcode.Size = new System.Drawing.Size(455, 20);
            this.txtproductBOMcode.StyleController = this.layoutControl1;
            this.txtproductBOMcode.TabIndex = 10;
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(570, 180);
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(455, 20);
            this.txtremark.StyleController = this.layoutControl1;
            this.txtremark.TabIndex = 11;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem11,
            this.layoutControlItem3,
            this.layoutControlItem10,
            this.layoutControlItem7,
            this.layoutControlItem9,
            this.layoutControlItem12,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.txtunitcost111,
            this.layoutControlItem13,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem16});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1037, 689);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtid;
            this.layoutControlItem1.CustomizationFormText = "id";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(506, 24);
            this.layoutControlItem1.Text = "id";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtcustomerid;
            this.layoutControlItem2.CustomizationFormText = "客户";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(506, 24);
            this.layoutControlItem2.Text = "客户";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtspec;
            this.layoutControlItem6.CustomizationFormText = "规格型号";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(506, 24);
            this.layoutControlItem6.Text = "规格型号";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtwarehouse;
            this.layoutControlItem8.CustomizationFormText = "仓库";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(506, 24);
            this.layoutControlItem8.Text = "仓库";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtremark;
            this.layoutControlItem11.CustomizationFormText = "备注";
            this.layoutControlItem11.Location = new System.Drawing.Point(506, 168);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(511, 24);
            this.layoutControlItem11.Text = "备注";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtcustomercode;
            this.layoutControlItem3.CustomizationFormText = "客户编码";
            this.layoutControlItem3.Location = new System.Drawing.Point(506, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(511, 24);
            this.layoutControlItem3.Text = "客户编码";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtproductBOMcode;
            this.layoutControlItem10.CustomizationFormText = "BOM编号";
            this.layoutControlItem10.Location = new System.Drawing.Point(506, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(511, 24);
            this.layoutControlItem10.Text = "BOM编号";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtunit;
            this.layoutControlItem7.CustomizationFormText = "计量单位";
            this.layoutControlItem7.Location = new System.Drawing.Point(506, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(511, 24);
            this.layoutControlItem7.Text = "计量单位";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtversion;
            this.layoutControlItem9.CustomizationFormText = "版本号";
            this.layoutControlItem9.Location = new System.Drawing.Point(506, 96);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(511, 24);
            this.layoutControlItem9.Text = "版本号";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.xtraTabControl2;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(1017, 477);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtproductid;
            this.layoutControlItem5.CustomizationFormText = "产品";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(506, 24);
            this.layoutControlItem5.Text = "产品";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtproductcode;
            this.layoutControlItem4.CustomizationFormText = "产品编号";
            this.layoutControlItem4.Location = new System.Drawing.Point(506, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(511, 24);
            this.layoutControlItem4.Text = "产品编号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(49, 14);
            // 
            // txtunitcost111
            // 
            this.txtunitcost111.Control = this.txtunitcost;
            this.txtunitcost111.Location = new System.Drawing.Point(0, 168);
            this.txtunitcost111.Name = "txtunitcost111";
            this.txtunitcost111.Size = new System.Drawing.Size(506, 24);
            this.txtunitcost111.Text = "单位成本";
            this.txtunitcost111.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtcreatorId;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(506, 24);
            this.layoutControlItem13.Text = "创建人";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txteditorId;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(506, 24);
            this.layoutControlItem14.Text = "编辑人";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.txtcreateTime;
            this.layoutControlItem15.Location = new System.Drawing.Point(506, 120);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(511, 24);
            this.layoutControlItem15.Text = "创建时间";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(49, 14);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txteditTime;
            this.layoutControlItem16.Location = new System.Drawing.Point(506, 144);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(511, 24);
            this.layoutControlItem16.Text = "编辑时间";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(49, 14);
            // 
            // FrmproductBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 756);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FrmproductBOM";
            this.Text = "产品BOM";
            this.Load += new System.EventHandler(this.FrmproductBOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcustomerid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtproductid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtunit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtwarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcreatorId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxteditorId)).EndInit();
            this.tabDataDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txteditTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txteditTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txteditorId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreatorId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunitcost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialtype)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomerid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomercode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtspec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtversion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductBOMcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunitcost111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraTabControl xtraTabControl1;
        private XtraTabPage tabDataList;
        private XtraTabPage tabDataDetail;
        private DevExpress.XtraGrid.GridControl grdList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdListView;
        private PanelControl panelControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;

		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtid;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtcustomerid;

        private DevExpress.XtraEditors.LookUpEdit txtcustomerid;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtcustomercode;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtproductcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtproductid;

        private DevExpress.XtraEditors.LookUpEdit txtproductid;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtspec;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtunit;

        private DevExpress.XtraEditors.LookUpEdit txtunit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtwarehouse;

        private DevExpress.XtraEditors.LookUpEdit txtwarehouse;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtversion;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtproductBOMcode;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtremark;

        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private XtraTabControl xtraTabControl2;
        private XtraTabPage xtraTabPage1;
        private LayoutControlItem layoutControlItem12;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddSon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDel;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn10;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn11;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn12;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn13;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn14;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn15;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn16;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditmaterialtype;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditmaterialname;
        private TextEdit txtunitcost;
        private LayoutControlItem txtunitcost111;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DateEdit txteditTime;
        private DateEdit txtcreateTime;
        private LookUpEdit txteditorId;
        private LookUpEdit txtcreatorId;
        private LayoutControlItem layoutControlItem13;
        private LayoutControlItem layoutControlItem14;
        private LayoutControlItem layoutControlItem15;
        private LayoutControlItem layoutControlItem16;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtcreatorId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxteditorId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
    }
}