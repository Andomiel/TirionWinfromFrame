
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;

namespace MES.Form
{
    partial class  FrmproductionRequisition
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
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtproductID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtunit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTreeListtxtpickingdept = new DevExpress.XtraEditors.Repository.RepositoryItemTreeListLookUpEdit();
            this.repositoryItemTreeListtxtpickingdeptTreeList = new DevExpress.XtraTreeList.TreeList();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtcreatorId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabDataList = new DevExpress.XtraTab.XtraTabPage();
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.grdListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabDataDetail = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditmaterialid = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditmaterialtype = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditunit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditwarehouse = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtid = new DevExpress.XtraEditors.TextEdit();
            this.txtcode = new DevExpress.XtraEditors.TextEdit();
            this.txtwocode = new DevExpress.XtraEditors.TextEdit();
            this.txtsalecode = new DevExpress.XtraEditors.TextEdit();
            this.txtpickingtime = new DevExpress.XtraEditors.DateEdit();
            this.txtproductID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtproductcode = new DevExpress.XtraEditors.TextEdit();
            this.txtproductspec = new DevExpress.XtraEditors.TextEdit();
            this.txtnumber = new DevExpress.XtraEditors.TextEdit();
            this.txtunit = new DevExpress.XtraEditors.LookUpEdit();
            this.txtpickingdept = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.txtpickingdeptTreeList = new DevExpress.XtraTreeList.TreeList();
            this.txtcreatorId = new DevExpress.XtraEditors.LookUpEdit();
            this.txtcreateTime = new DevExpress.XtraEditors.DateEdit();
            this.txtremark = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtproductID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtunit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTreeListtxtpickingdept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTreeListtxtpickingdeptTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcreatorId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListView)).BeginInit();
            this.tabDataDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialtype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditunit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditwarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwocode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsalecode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpickingtime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpickingtime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductspec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpickingdept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpickingdeptTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreatorId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
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
            this.gridColumn2.Caption = "领料单号";
            this.gridColumn2.FieldName = "code";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 201;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "工单号";
            this.gridColumn3.FieldName = "wocode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 201;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "销售单号";
            this.gridColumn4.FieldName = "salecode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 201;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "领料日期";
            this.gridColumn5.DisplayFormat.FormatString = "G";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn5.FieldName = "pickingtime";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 201;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "产品";
            this.gridColumn6.ColumnEdit = this.repositoryItemtxtproductID;
            this.gridColumn6.FieldName = "productID";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 201;
            // 
            // repositoryItemtxtproductID
            // 
            this.repositoryItemtxtproductID.AutoHeight = false;
            this.repositoryItemtxtproductID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtproductID.DisplayMember = "Name";
            this.repositoryItemtxtproductID.Name = "repositoryItemtxtproductID";
            this.repositoryItemtxtproductID.ValueMember = "ID";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "产品编号";
            this.gridColumn7.FieldName = "productcode";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 201;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "规格型号";
            this.gridColumn8.FieldName = "productspec";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 201;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "生产数量";
            this.gridColumn9.FieldName = "number";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 201;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "计量单位";
            this.gridColumn10.ColumnEdit = this.repositoryItemtxtunit;
            this.gridColumn10.FieldName = "unit";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 201;
            // 
            // repositoryItemtxtunit
            // 
            this.repositoryItemtxtunit.AutoHeight = false;
            this.repositoryItemtxtunit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtunit.DisplayMember = "Name";
            this.repositoryItemtxtunit.Name = "repositoryItemtxtunit";
            this.repositoryItemtxtunit.ValueMember = "ID";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "领料部门";
            this.gridColumn11.ColumnEdit = this.repositoryItemTreeListtxtpickingdept;
            this.gridColumn11.FieldName = "pickingdept";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 201;
            // 
            // repositoryItemTreeListtxtpickingdept
            // 
            this.repositoryItemTreeListtxtpickingdept.AutoHeight = false;
            this.repositoryItemTreeListtxtpickingdept.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTreeListtxtpickingdept.DisplayMember = "Name";
            this.repositoryItemTreeListtxtpickingdept.Name = "repositoryItemTreeListtxtpickingdept";
            this.repositoryItemTreeListtxtpickingdept.TreeList = this.repositoryItemTreeListtxtpickingdeptTreeList;
            this.repositoryItemTreeListtxtpickingdept.ValueMember = "ID";
            // 
            // repositoryItemTreeListtxtpickingdeptTreeList
            // 
            this.repositoryItemTreeListtxtpickingdeptTreeList.Location = new System.Drawing.Point(0, 0);
            this.repositoryItemTreeListtxtpickingdeptTreeList.Name = "repositoryItemTreeListtxtpickingdeptTreeList";
            this.repositoryItemTreeListtxtpickingdeptTreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.repositoryItemTreeListtxtpickingdeptTreeList.ParentFieldName = "PID";
            this.repositoryItemTreeListtxtpickingdeptTreeList.Size = new System.Drawing.Size(400, 200);
            this.repositoryItemTreeListtxtpickingdeptTreeList.TabIndex = 0;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "制单人";
            this.gridColumn12.ColumnEdit = this.repositoryItemtxtcreatorId;
            this.gridColumn12.FieldName = "creatorId";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            this.gridColumn12.Width = 201;
            // 
            // repositoryItemtxtcreatorId
            // 
            this.repositoryItemtxtcreatorId.AutoHeight = false;
            this.repositoryItemtxtcreatorId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtcreatorId.DisplayMember = "Name";
            this.repositoryItemtxtcreatorId.Name = "repositoryItemtxtcreatorId";
            this.repositoryItemtxtcreatorId.ValueMember = "ID";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "制单日期";
            this.gridColumn13.DisplayFormat.FormatString = "G";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn13.FieldName = "createTime";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 201;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "备注";
            this.gridColumn14.FieldName = "remark";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            this.gridColumn14.Width = 201;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 34);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabDataList;
            this.xtraTabControl1.Size = new System.Drawing.Size(1310, 772);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDataList,
            this.tabDataDetail});
            // 
            // tabDataList
            // 
            this.tabDataList.Controls.Add(this.grdList);
            this.tabDataList.Name = "tabDataList";
            this.tabDataList.Size = new System.Drawing.Size(1304, 743);
            this.tabDataList.Text = "数据列表";
            // 
            // grdList
            // 
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(0, 0);
            this.grdList.MainView = this.grdListView;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(1304, 743);
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
            this.gridColumn14});
            this.grdListView.GridControl = this.grdList;
            this.grdListView.Name = "grdListView";
            this.grdListView.OptionsBehavior.Editable = false;
            this.grdListView.OptionsView.ColumnAutoWidth = false;
            this.grdListView.OptionsView.ShowGroupPanel = false;
            // 
            // tabDataDetail
            // 
            this.tabDataDetail.Controls.Add(this.panelControl2);
            this.tabDataDetail.Name = "tabDataDetail";
            this.tabDataDetail.Size = new System.Drawing.Size(1304, 743);
            this.tabDataDetail.Text = "数据编辑";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.layoutControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1304, 743);
            this.panelControl2.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.xtraTabControl2);
            this.layoutControl1.Controls.Add(this.txtid);
            this.layoutControl1.Controls.Add(this.txtcode);
            this.layoutControl1.Controls.Add(this.txtwocode);
            this.layoutControl1.Controls.Add(this.txtsalecode);
            this.layoutControl1.Controls.Add(this.txtpickingtime);
            this.layoutControl1.Controls.Add(this.txtproductID);
            this.layoutControl1.Controls.Add(this.txtproductcode);
            this.layoutControl1.Controls.Add(this.txtproductspec);
            this.layoutControl1.Controls.Add(this.txtnumber);
            this.layoutControl1.Controls.Add(this.txtunit);
            this.layoutControl1.Controls.Add(this.txtpickingdept);
            this.layoutControl1.Controls.Add(this.txtcreatorId);
            this.layoutControl1.Controls.Add(this.txtcreateTime);
            this.layoutControl1.Controls.Add(this.txtremark);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1300, 739);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Location = new System.Drawing.Point(12, 180);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl2.Size = new System.Drawing.Size(1276, 547);
            this.xtraTabControl2.TabIndex = 15;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1270, 518);
            this.xtraTabPage2.Text = "领料明细";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditmaterialid,
            this.repositoryItemLookUpEditmaterialtype,
            this.repositoryItemLookUpEditunit,
            this.repositoryItemLookUpEditwarehouse});
            this.gridControl1.Size = new System.Drawing.Size(1270, 518);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAdd,
            this.toolStripMenuItemDel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 48);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemAdd.Text = "新增行";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.toolStripMenuItemAdd_Click);
            // 
            // toolStripMenuItemDel
            // 
            this.toolStripMenuItemDel.Name = "toolStripMenuItemDel";
            this.toolStripMenuItemDel.Size = new System.Drawing.Size(112, 22);
            this.toolStripMenuItemDel.Text = "删除行";
            this.toolStripMenuItemDel.Click += new System.EventHandler(this.toolStripMenuItemDel_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "id";
            this.gridColumn15.FieldName = "id";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Width = 201;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "主表ID";
            this.gridColumn16.FieldName = "masterid";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Width = 201;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "领料单号";
            this.gridColumn17.FieldName = "mastercode";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 11;
            this.gridColumn17.Width = 201;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "领料明细单号";
            this.gridColumn18.FieldName = "detailcode";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 12;
            this.gridColumn18.Width = 201;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "物料";
            this.gridColumn19.ColumnEdit = this.repositoryItemLookUpEditmaterialid;
            this.gridColumn19.FieldName = "materialid";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 0;
            this.gridColumn19.Width = 201;
            // 
            // repositoryItemLookUpEditmaterialid
            // 
            this.repositoryItemLookUpEditmaterialid.AutoHeight = false;
            this.repositoryItemLookUpEditmaterialid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditmaterialid.DisplayMember = "Name";
            this.repositoryItemLookUpEditmaterialid.Name = "repositoryItemLookUpEditmaterialid";
            this.repositoryItemLookUpEditmaterialid.NullText = "";
            this.repositoryItemLookUpEditmaterialid.ValueMember = "ID";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "物料编码";
            this.gridColumn20.FieldName = "materialcode";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 1;
            this.gridColumn20.Width = 201;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "规格型号";
            this.gridColumn21.FieldName = "materialspec";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 2;
            this.gridColumn21.Width = 201;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "物料类型";
            this.gridColumn22.ColumnEdit = this.repositoryItemLookUpEditmaterialtype;
            this.gridColumn22.FieldName = "materialtype";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 3;
            this.gridColumn22.Width = 201;
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
            // gridColumn23
            // 
            this.gridColumn23.Caption = "单位用量";
            this.gridColumn23.FieldName = "unitnumber";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 4;
            this.gridColumn23.Width = 201;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "产品生产数量";
            this.gridColumn24.FieldName = "productnumber";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 5;
            this.gridColumn24.Width = 201;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "领料数量";
            this.gridColumn25.FieldName = "picknumber";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 6;
            this.gridColumn25.Width = 201;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "计量单位";
            this.gridColumn26.ColumnEdit = this.repositoryItemLookUpEditunit;
            this.gridColumn26.FieldName = "unit";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 7;
            this.gridColumn26.Width = 201;
            // 
            // repositoryItemLookUpEditunit
            // 
            this.repositoryItemLookUpEditunit.AutoHeight = false;
            this.repositoryItemLookUpEditunit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditunit.DisplayMember = "Name";
            this.repositoryItemLookUpEditunit.Name = "repositoryItemLookUpEditunit";
            this.repositoryItemLookUpEditunit.NullText = "";
            this.repositoryItemLookUpEditunit.ValueMember = "ID";
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "仓库";
            this.gridColumn27.ColumnEdit = this.repositoryItemLookUpEditwarehouse;
            this.gridColumn27.FieldName = "warehouse";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 8;
            this.gridColumn27.Width = 201;
            // 
            // repositoryItemLookUpEditwarehouse
            // 
            this.repositoryItemLookUpEditwarehouse.AutoHeight = false;
            this.repositoryItemLookUpEditwarehouse.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditwarehouse.DisplayMember = "Name";
            this.repositoryItemLookUpEditwarehouse.Name = "repositoryItemLookUpEditwarehouse";
            this.repositoryItemLookUpEditwarehouse.NullText = "";
            this.repositoryItemLookUpEditwarehouse.ValueMember = "ID";
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "备注";
            this.gridColumn28.FieldName = "remark";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 9;
            this.gridColumn28.Width = 201;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "工单号";
            this.gridColumn29.FieldName = "wocode";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 10;
            this.gridColumn29.Width = 201;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(63, 12);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(582, 20);
            this.txtid.StyleController = this.layoutControl1;
            this.txtid.TabIndex = 1;
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(700, 12);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(588, 20);
            this.txtcode.StyleController = this.layoutControl1;
            this.txtcode.TabIndex = 2;
            // 
            // txtwocode
            // 
            this.txtwocode.Location = new System.Drawing.Point(63, 36);
            this.txtwocode.Name = "txtwocode";
            this.txtwocode.Size = new System.Drawing.Size(582, 20);
            this.txtwocode.StyleController = this.layoutControl1;
            this.txtwocode.TabIndex = 3;
            this.txtwocode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtwocode_KeyPress);
            // 
            // txtsalecode
            // 
            this.txtsalecode.Location = new System.Drawing.Point(700, 36);
            this.txtsalecode.Name = "txtsalecode";
            this.txtsalecode.Size = new System.Drawing.Size(588, 20);
            this.txtsalecode.StyleController = this.layoutControl1;
            this.txtsalecode.TabIndex = 4;
            // 
            // txtpickingtime
            // 
            this.txtpickingtime.EditValue = null;
            this.txtpickingtime.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtpickingtime.Location = new System.Drawing.Point(63, 108);
            this.txtpickingtime.Name = "txtpickingtime";
            this.txtpickingtime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtpickingtime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtpickingtime.Properties.DisplayFormat.FormatString = "G";
            this.txtpickingtime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtpickingtime.Properties.Mask.EditMask = "G";
            this.txtpickingtime.Size = new System.Drawing.Size(582, 20);
            this.txtpickingtime.StyleController = this.layoutControl1;
            this.txtpickingtime.TabIndex = 5;
            // 
            // txtproductID
            // 
            this.txtproductID.EditValue = "";
            this.txtproductID.Location = new System.Drawing.Point(63, 60);
            this.txtproductID.Name = "txtproductID";
            this.txtproductID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtproductID.Properties.DisplayMember = "Name";
            this.txtproductID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtproductID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtproductID.Properties.ValueMember = "ID";
            this.txtproductID.Size = new System.Drawing.Size(582, 20);
            this.txtproductID.StyleController = this.layoutControl1;
            this.txtproductID.TabIndex = 6;
            // 
            // txtproductcode
            // 
            this.txtproductcode.Location = new System.Drawing.Point(700, 60);
            this.txtproductcode.Name = "txtproductcode";
            this.txtproductcode.Size = new System.Drawing.Size(588, 20);
            this.txtproductcode.StyleController = this.layoutControl1;
            this.txtproductcode.TabIndex = 7;
            // 
            // txtproductspec
            // 
            this.txtproductspec.Location = new System.Drawing.Point(63, 84);
            this.txtproductspec.Name = "txtproductspec";
            this.txtproductspec.Size = new System.Drawing.Size(582, 20);
            this.txtproductspec.StyleController = this.layoutControl1;
            this.txtproductspec.TabIndex = 8;
            // 
            // txtnumber
            // 
            this.txtnumber.Location = new System.Drawing.Point(700, 84);
            this.txtnumber.Name = "txtnumber";
            this.txtnumber.Size = new System.Drawing.Size(266, 20);
            this.txtnumber.StyleController = this.layoutControl1;
            this.txtnumber.TabIndex = 9;
            // 
            // txtunit
            // 
            this.txtunit.EditValue = "";
            this.txtunit.Location = new System.Drawing.Point(1021, 84);
            this.txtunit.Name = "txtunit";
            this.txtunit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtunit.Properties.DisplayMember = "Name";
            this.txtunit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtunit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtunit.Properties.ValueMember = "ID";
            this.txtunit.Size = new System.Drawing.Size(267, 20);
            this.txtunit.StyleController = this.layoutControl1;
            this.txtunit.TabIndex = 10;
            // 
            // txtpickingdept
            // 
            this.txtpickingdept.EditValue = "";
            this.txtpickingdept.Location = new System.Drawing.Point(700, 108);
            this.txtpickingdept.Name = "txtpickingdept";
            this.txtpickingdept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtpickingdept.Properties.DisplayMember = "Name";
            this.txtpickingdept.Properties.TreeList = this.txtpickingdeptTreeList;
            this.txtpickingdept.Properties.ValueMember = "ID";
            this.txtpickingdept.Size = new System.Drawing.Size(588, 20);
            this.txtpickingdept.StyleController = this.layoutControl1;
            this.txtpickingdept.TabIndex = 11;
            // 
            // txtpickingdeptTreeList
            // 
            this.txtpickingdeptTreeList.Location = new System.Drawing.Point(0, 0);
            this.txtpickingdeptTreeList.Name = "txtpickingdeptTreeList";
            this.txtpickingdeptTreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.txtpickingdeptTreeList.ParentFieldName = "PID";
            this.txtpickingdeptTreeList.Size = new System.Drawing.Size(400, 200);
            this.txtpickingdeptTreeList.TabIndex = 0;
            // 
            // txtcreatorId
            // 
            this.txtcreatorId.EditValue = "";
            this.txtcreatorId.Location = new System.Drawing.Point(63, 132);
            this.txtcreatorId.Name = "txtcreatorId";
            this.txtcreatorId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcreatorId.Properties.DisplayMember = "Name";
            this.txtcreatorId.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtcreatorId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtcreatorId.Properties.ValueMember = "ID";
            this.txtcreatorId.Size = new System.Drawing.Size(582, 20);
            this.txtcreatorId.StyleController = this.layoutControl1;
            this.txtcreatorId.TabIndex = 12;
            // 
            // txtcreateTime
            // 
            this.txtcreateTime.EditValue = null;
            this.txtcreateTime.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtcreateTime.Location = new System.Drawing.Point(700, 132);
            this.txtcreateTime.Name = "txtcreateTime";
            this.txtcreateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcreateTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtcreateTime.Properties.DisplayFormat.FormatString = "G";
            this.txtcreateTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtcreateTime.Properties.Mask.EditMask = "G";
            this.txtcreateTime.Size = new System.Drawing.Size(588, 20);
            this.txtcreateTime.StyleController = this.layoutControl1;
            this.txtcreateTime.TabIndex = 13;
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(63, 156);
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(1225, 20);
            this.txtremark.StyleController = this.layoutControl1;
            this.txtremark.TabIndex = 14;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem12,
            this.layoutControlItem14,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem9,
            this.layoutControlItem11,
            this.layoutControlItem5,
            this.layoutControlItem10,
            this.layoutControlItem13,
            this.layoutControlItem15});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1300, 739);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtid;
            this.layoutControlItem1.CustomizationFormText = "id";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(637, 24);
            this.layoutControlItem1.Text = "id";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtwocode;
            this.layoutControlItem3.CustomizationFormText = "工单号";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(637, 24);
            this.layoutControlItem3.Text = "工单号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtproductID;
            this.layoutControlItem6.CustomizationFormText = "产品";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(637, 24);
            this.layoutControlItem6.Text = "产品";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtproductspec;
            this.layoutControlItem8.CustomizationFormText = "规格型号";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(637, 24);
            this.layoutControlItem8.Text = "规格型号";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtcreatorId;
            this.layoutControlItem12.CustomizationFormText = "制单人";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(637, 24);
            this.layoutControlItem12.Text = "制单人";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtremark;
            this.layoutControlItem14.CustomizationFormText = "备注";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(1280, 24);
            this.layoutControlItem14.Text = "备注";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtcode;
            this.layoutControlItem2.CustomizationFormText = "领料单号";
            this.layoutControlItem2.Location = new System.Drawing.Point(637, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(643, 24);
            this.layoutControlItem2.Text = "领料单号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtsalecode;
            this.layoutControlItem4.CustomizationFormText = "销售单号";
            this.layoutControlItem4.Location = new System.Drawing.Point(637, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(643, 24);
            this.layoutControlItem4.Text = "销售单号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtproductcode;
            this.layoutControlItem7.CustomizationFormText = "产品编号";
            this.layoutControlItem7.Location = new System.Drawing.Point(637, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(643, 24);
            this.layoutControlItem7.Text = "产品编号";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtnumber;
            this.layoutControlItem9.CustomizationFormText = "生产数量";
            this.layoutControlItem9.Location = new System.Drawing.Point(637, 72);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(321, 24);
            this.layoutControlItem9.Text = "生产数量";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtpickingdept;
            this.layoutControlItem11.CustomizationFormText = "领料部门";
            this.layoutControlItem11.Location = new System.Drawing.Point(637, 96);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(643, 24);
            this.layoutControlItem11.Text = "领料部门";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtpickingtime;
            this.layoutControlItem5.CustomizationFormText = "领料日期";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(637, 24);
            this.layoutControlItem5.Text = "领料日期";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtunit;
            this.layoutControlItem10.CustomizationFormText = "计量单位";
            this.layoutControlItem10.Location = new System.Drawing.Point(958, 72);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(322, 24);
            this.layoutControlItem10.Text = "计量单位";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtcreateTime;
            this.layoutControlItem13.CustomizationFormText = "制单日期";
            this.layoutControlItem13.Location = new System.Drawing.Point(637, 120);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(643, 24);
            this.layoutControlItem13.Text = "制单日期";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.xtraTabControl2;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 168);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(1280, 551);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // FrmproductionRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 806);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FrmproductionRequisition";
            this.Text = "生产领料申请单";
            this.Load += new System.EventHandler(this.FrmproductionRequisition_Load);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtproductID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtunit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTreeListtxtpickingdept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTreeListtxtpickingdeptTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcreatorId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListView)).EndInit();
            this.tabDataDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialtype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditunit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditwarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwocode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsalecode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpickingtime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpickingtime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductspec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpickingdept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpickingdeptTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreatorId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
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
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtid;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtcode;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtwocode;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtsalecode;
        ///////////////////////////////
        private DevExpress.XtraEditors.DateEdit txtpickingtime;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtproductID;

        private DevExpress.XtraEditors.LookUpEdit txtproductID;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtproductcode;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtproductspec;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtnumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtunit;

        private DevExpress.XtraEditors.LookUpEdit txtunit;
        private DevExpress.XtraTreeList.TreeList txtpickingdeptTreeList;
        private DevExpress.XtraEditors.Repository.RepositoryItemTreeListLookUpEdit repositoryItemTreeListtxtpickingdept;
        private DevExpress.XtraTreeList.TreeList repositoryItemTreeListtxtpickingdeptTreeList;  

        private DevExpress.XtraEditors.TreeListLookUpEdit txtpickingdept;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtcreatorId;

        private DevExpress.XtraEditors.LookUpEdit txtcreatorId;
        ///////////////////////////////
        private DevExpress.XtraEditors.DateEdit txtcreateTime;
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
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private XtraTabControl xtraTabControl2;
        private XtraTabPage xtraTabPage2;
        private LayoutControlItem layoutControlItem15;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditmaterialid;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditmaterialtype;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditunit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditwarehouse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDel;
    }
}