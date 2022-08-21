
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;

namespace MES.Form
{
    partial class  Frmworkorder
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
            this.repositoryItemtxtworkordertype = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtproductdept = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtproductid = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtunit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtwarehouse = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtcreatorId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabDataList = new DevExpress.XtraTab.XtraTabPage();
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.grdListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabDataDetail = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtproducttype = new DevExpress.XtraEditors.LookUpEdit();
            this.txtbomid = new DevExpress.XtraEditors.LookUpEdit();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditmaterialid = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditmaterialtype = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtid = new DevExpress.XtraEditors.TextEdit();
            this.txtwordordercode = new DevExpress.XtraEditors.TextEdit();
            this.txtsalecode = new DevExpress.XtraEditors.TextEdit();
            this.txtsaledetailcode = new DevExpress.XtraEditors.TextEdit();
            this.txtworkordertype = new DevExpress.XtraEditors.LookUpEdit();
            this.txtproductdate = new DevExpress.XtraEditors.DateEdit();
            this.txtproductdept = new DevExpress.XtraEditors.LookUpEdit();
            this.txtproductcode = new DevExpress.XtraEditors.TextEdit();
            this.txtproductid = new DevExpress.XtraEditors.LookUpEdit();
            this.txtspec = new DevExpress.XtraEditors.TextEdit();
            this.txtproductnumber = new DevExpress.XtraEditors.TextEdit();
            this.txtunit = new DevExpress.XtraEditors.LookUpEdit();
            this.txtfinishdate = new DevExpress.XtraEditors.DateEdit();
            this.txtdeliverdate = new DevExpress.XtraEditors.DateEdit();
            this.txtwarehouse = new DevExpress.XtraEditors.LookUpEdit();
            this.txtcreatorId = new DevExpress.XtraEditors.LookUpEdit();
            this.txtcreateTime = new DevExpress.XtraEditors.DateEdit();
            this.txtremark = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtworkordertype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtproductdept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtproductid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtunit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtwarehouse)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtproducttype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbomid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialtype)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwordordercode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsalecode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsaledetailcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtworkordertype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductdept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtspec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductnumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfinishdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfinishdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliverdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliverdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreatorId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
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
            this.gridColumn2.Caption = "工单号";
            this.gridColumn2.FieldName = "wordordercode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 201;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "销售单号";
            this.gridColumn3.FieldName = "salecode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 201;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "销售明细单号";
            this.gridColumn4.FieldName = "saledetailcode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 201;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "工单类型";
            this.gridColumn5.ColumnEdit = this.repositoryItemtxtworkordertype;
            this.gridColumn5.FieldName = "workordertype";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 201;
            // 
            // repositoryItemtxtworkordertype
            // 
            this.repositoryItemtxtworkordertype.AutoHeight = false;
            this.repositoryItemtxtworkordertype.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtworkordertype.DisplayMember = "Name";
            this.repositoryItemtxtworkordertype.Name = "repositoryItemtxtworkordertype";
            this.repositoryItemtxtworkordertype.ValueMember = "ID";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "生产日期";
            this.gridColumn6.DisplayFormat.FormatString = "G";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "productdate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 201;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "生产单位";
            this.gridColumn7.ColumnEdit = this.repositoryItemtxtproductdept;
            this.gridColumn7.FieldName = "productdept";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 201;
            // 
            // repositoryItemtxtproductdept
            // 
            this.repositoryItemtxtproductdept.AutoHeight = false;
            this.repositoryItemtxtproductdept.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtproductdept.DisplayMember = "Name";
            this.repositoryItemtxtproductdept.Name = "repositoryItemtxtproductdept";
            this.repositoryItemtxtproductdept.ValueMember = "ID";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "产品编号";
            this.gridColumn8.FieldName = "productcode";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 201;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "产品名称";
            this.gridColumn9.ColumnEdit = this.repositoryItemtxtproductid;
            this.gridColumn9.FieldName = "productid";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 201;
            // 
            // repositoryItemtxtproductid
            // 
            this.repositoryItemtxtproductid.AutoHeight = false;
            this.repositoryItemtxtproductid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtproductid.DisplayMember = "Name";
            this.repositoryItemtxtproductid.Name = "repositoryItemtxtproductid";
            this.repositoryItemtxtproductid.ValueMember = "ID";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "规格型号";
            this.gridColumn10.FieldName = "spec";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 201;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "生产数量";
            this.gridColumn11.FieldName = "productnumber";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 201;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "计量单位";
            this.gridColumn12.ColumnEdit = this.repositoryItemtxtunit;
            this.gridColumn12.FieldName = "unit";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            this.gridColumn12.Width = 201;
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
            // gridColumn13
            // 
            this.gridColumn13.Caption = "完工日期";
            this.gridColumn13.DisplayFormat.FormatString = "G";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn13.FieldName = "finishdate";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 201;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "交货日期";
            this.gridColumn14.DisplayFormat.FormatString = "G";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn14.FieldName = "deliverdate";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            this.gridColumn14.Width = 201;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "仓库";
            this.gridColumn15.ColumnEdit = this.repositoryItemtxtwarehouse;
            this.gridColumn15.FieldName = "warehouse";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 13;
            this.gridColumn15.Width = 201;
            // 
            // repositoryItemtxtwarehouse
            // 
            this.repositoryItemtxtwarehouse.AutoHeight = false;
            this.repositoryItemtxtwarehouse.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtwarehouse.DisplayMember = "Name";
            this.repositoryItemtxtwarehouse.Name = "repositoryItemtxtwarehouse";
            this.repositoryItemtxtwarehouse.ValueMember = "ID";
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "制单人";
            this.gridColumn16.ColumnEdit = this.repositoryItemtxtcreatorId;
            this.gridColumn16.FieldName = "creatorId";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 14;
            this.gridColumn16.Width = 201;
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
            // gridColumn17
            // 
            this.gridColumn17.Caption = "制单日期";
            this.gridColumn17.DisplayFormat.FormatString = "G";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn17.FieldName = "createTime";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 15;
            this.gridColumn17.Width = 201;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "备注";
            this.gridColumn18.FieldName = "remark";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 16;
            this.gridColumn18.Width = 201;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 34);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabDataList;
            this.xtraTabControl1.Size = new System.Drawing.Size(1082, 661);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDataList,
            this.tabDataDetail});
            // 
            // tabDataList
            // 
            this.tabDataList.Controls.Add(this.grdList);
            this.tabDataList.Name = "tabDataList";
            this.tabDataList.Size = new System.Drawing.Size(1076, 632);
            this.tabDataList.Text = "数据列表";
            // 
            // grdList
            // 
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(0, 0);
            this.grdList.MainView = this.grdListView;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(1076, 632);
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
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.grdListView.GridControl = this.grdList;
            this.grdListView.Name = "grdListView";
            this.grdListView.OptionsBehavior.Editable = false;
            this.grdListView.OptionsView.ColumnAutoWidth = false;
            // 
            // tabDataDetail
            // 
            this.tabDataDetail.Controls.Add(this.panelControl2);
            this.tabDataDetail.Name = "tabDataDetail";
            this.tabDataDetail.Size = new System.Drawing.Size(1076, 632);
            this.tabDataDetail.Text = "数据编辑";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.layoutControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1076, 632);
            this.panelControl2.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtproducttype);
            this.layoutControl1.Controls.Add(this.txtbomid);
            this.layoutControl1.Controls.Add(this.xtraTabControl2);
            this.layoutControl1.Controls.Add(this.txtid);
            this.layoutControl1.Controls.Add(this.txtwordordercode);
            this.layoutControl1.Controls.Add(this.txtsalecode);
            this.layoutControl1.Controls.Add(this.txtsaledetailcode);
            this.layoutControl1.Controls.Add(this.txtworkordertype);
            this.layoutControl1.Controls.Add(this.txtproductdate);
            this.layoutControl1.Controls.Add(this.txtproductdept);
            this.layoutControl1.Controls.Add(this.txtproductcode);
            this.layoutControl1.Controls.Add(this.txtproductid);
            this.layoutControl1.Controls.Add(this.txtspec);
            this.layoutControl1.Controls.Add(this.txtproductnumber);
            this.layoutControl1.Controls.Add(this.txtunit);
            this.layoutControl1.Controls.Add(this.txtfinishdate);
            this.layoutControl1.Controls.Add(this.txtdeliverdate);
            this.layoutControl1.Controls.Add(this.txtwarehouse);
            this.layoutControl1.Controls.Add(this.txtcreatorId);
            this.layoutControl1.Controls.Add(this.txtcreateTime);
            this.layoutControl1.Controls.Add(this.txtremark);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1072, 628);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtproducttype
            // 
            this.txtproducttype.Location = new System.Drawing.Point(87, 84);
            this.txtproducttype.Name = "txtproducttype";
            this.txtproducttype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtproducttype.Properties.DisplayMember = "Name";
            this.txtproducttype.Properties.NullText = "";
            this.txtproducttype.Properties.ReadOnly = true;
            this.txtproducttype.Properties.ValueMember = "ID";
            this.txtproducttype.Size = new System.Drawing.Size(445, 20);
            this.txtproducttype.StyleController = this.layoutControl1;
            this.txtproducttype.TabIndex = 21;
            // 
            // txtbomid
            // 
            this.txtbomid.Location = new System.Drawing.Point(87, 132);
            this.txtbomid.Name = "txtbomid";
            this.txtbomid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtbomid.Properties.DisplayMember = "Name";
            this.txtbomid.Properties.NullText = "";
            this.txtbomid.Properties.ValueMember = "ID";
            this.txtbomid.Size = new System.Drawing.Size(445, 20);
            this.txtbomid.StyleController = this.layoutControl1;
            this.txtbomid.TabIndex = 20;
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Location = new System.Drawing.Point(12, 252);
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl2.Size = new System.Drawing.Size(1048, 364);
            this.xtraTabControl2.TabIndex = 19;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1042, 335);
            this.xtraTabPage1.Text = "物料需求明细";
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
            this.repositoryItemLookUpEditmaterialtype});
            this.gridControl1.Size = new System.Drawing.Size(1042, 335);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "物料需求明细";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "id";
            this.gridColumn19.FieldName = "id";
            this.gridColumn19.Name = "gridColumn19";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "工程BOM编号";
            this.gridColumn20.FieldName = "projectBOMcode";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Width = 201;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "生产BOM编号";
            this.gridColumn21.FieldName = "productionBOMcode";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Width = 201;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "产品生产数量";
            this.gridColumn22.FieldName = "number";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 0;
            this.gridColumn22.Width = 201;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "物料编码";
            this.gridColumn23.FieldName = "materialcode";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 1;
            this.gridColumn23.Width = 201;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "物料名称";
            this.gridColumn24.ColumnEdit = this.repositoryItemLookUpEditmaterialid;
            this.gridColumn24.FieldName = "materialid";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 2;
            this.gridColumn24.Width = 201;
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
            // gridColumn25
            // 
            this.gridColumn25.Caption = "规格型号";
            this.gridColumn25.FieldName = "spec";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 3;
            this.gridColumn25.Width = 201;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "物料类型";
            this.gridColumn26.ColumnEdit = this.repositoryItemLookUpEditmaterialtype;
            this.gridColumn26.FieldName = "materialtype";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 4;
            this.gridColumn26.Width = 201;
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
            // gridColumn27
            // 
            this.gridColumn27.Caption = "单位用量";
            this.gridColumn27.FieldName = "uintnumber";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 5;
            this.gridColumn27.Width = 201;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "需求总量";
            this.gridColumn28.FieldName = "neednumber";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 7;
            this.gridColumn28.Width = 201;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "计量单位";
            this.gridColumn29.ColumnEdit = this.repositoryItemtxtunit;
            this.gridColumn29.FieldName = "unit";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 6;
            this.gridColumn29.Width = 201;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "单价";
            this.gridColumn30.FieldName = "unitprice";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 8;
            this.gridColumn30.Width = 201;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "总价";
            this.gridColumn31.FieldName = "totalprice";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 10;
            this.gridColumn31.Width = 201;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "仓库";
            this.gridColumn32.ColumnEdit = this.repositoryItemtxtwarehouse;
            this.gridColumn32.FieldName = "warehouse";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 9;
            this.gridColumn32.Width = 201;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "备注";
            this.gridColumn33.FieldName = "remark";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 11;
            this.gridColumn33.Width = 201;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControl2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1042, 335);
            this.xtraTabPage2.Text = "入库明细";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1042, 335);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(87, 12);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(445, 20);
            this.txtid.StyleController = this.layoutControl1;
            this.txtid.TabIndex = 1;
            // 
            // txtwordordercode
            // 
            this.txtwordordercode.Location = new System.Drawing.Point(611, 12);
            this.txtwordordercode.Name = "txtwordordercode";
            this.txtwordordercode.Size = new System.Drawing.Size(449, 20);
            this.txtwordordercode.StyleController = this.layoutControl1;
            this.txtwordordercode.TabIndex = 2;
            // 
            // txtsalecode
            // 
            this.txtsalecode.Location = new System.Drawing.Point(611, 108);
            this.txtsalecode.Name = "txtsalecode";
            this.txtsalecode.Size = new System.Drawing.Size(449, 20);
            this.txtsalecode.StyleController = this.layoutControl1;
            this.txtsalecode.TabIndex = 3;
            // 
            // txtsaledetailcode
            // 
            this.txtsaledetailcode.Location = new System.Drawing.Point(87, 108);
            this.txtsaledetailcode.Name = "txtsaledetailcode";
            this.txtsaledetailcode.Size = new System.Drawing.Size(445, 20);
            this.txtsaledetailcode.StyleController = this.layoutControl1;
            this.txtsaledetailcode.TabIndex = 4;
            this.txtsaledetailcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsaledetailcode_KeyPress);
            // 
            // txtworkordertype
            // 
            this.txtworkordertype.EditValue = "";
            this.txtworkordertype.Location = new System.Drawing.Point(87, 36);
            this.txtworkordertype.Name = "txtworkordertype";
            this.txtworkordertype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtworkordertype.Properties.DisplayMember = "Name";
            this.txtworkordertype.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtworkordertype.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtworkordertype.Properties.ValueMember = "ID";
            this.txtworkordertype.Size = new System.Drawing.Size(445, 20);
            this.txtworkordertype.StyleController = this.layoutControl1;
            this.txtworkordertype.TabIndex = 5;
            // 
            // txtproductdate
            // 
            this.txtproductdate.EditValue = null;
            this.txtproductdate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtproductdate.Location = new System.Drawing.Point(611, 36);
            this.txtproductdate.Name = "txtproductdate";
            this.txtproductdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtproductdate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtproductdate.Properties.DisplayFormat.FormatString = "G";
            this.txtproductdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtproductdate.Properties.Mask.EditMask = "G";
            this.txtproductdate.Size = new System.Drawing.Size(449, 20);
            this.txtproductdate.StyleController = this.layoutControl1;
            this.txtproductdate.TabIndex = 6;
            // 
            // txtproductdept
            // 
            this.txtproductdept.EditValue = "";
            this.txtproductdept.Location = new System.Drawing.Point(611, 84);
            this.txtproductdept.Name = "txtproductdept";
            this.txtproductdept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtproductdept.Properties.DisplayMember = "Name";
            this.txtproductdept.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtproductdept.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtproductdept.Properties.ValueMember = "ID";
            this.txtproductdept.Size = new System.Drawing.Size(449, 20);
            this.txtproductdept.StyleController = this.layoutControl1;
            this.txtproductdept.TabIndex = 7;
            // 
            // txtproductcode
            // 
            this.txtproductcode.Location = new System.Drawing.Point(611, 60);
            this.txtproductcode.Name = "txtproductcode";
            this.txtproductcode.Size = new System.Drawing.Size(449, 20);
            this.txtproductcode.StyleController = this.layoutControl1;
            this.txtproductcode.TabIndex = 8;
            // 
            // txtproductid
            // 
            this.txtproductid.EditValue = "";
            this.txtproductid.Location = new System.Drawing.Point(87, 60);
            this.txtproductid.Name = "txtproductid";
            this.txtproductid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtproductid.Properties.DisplayMember = "Name";
            this.txtproductid.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtproductid.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtproductid.Properties.ValueMember = "ID";
            this.txtproductid.Size = new System.Drawing.Size(445, 20);
            this.txtproductid.StyleController = this.layoutControl1;
            this.txtproductid.TabIndex = 9;
            this.txtproductid.EditValueChanged += new System.EventHandler(this.txtproductid_EditValueChanged);
            // 
            // txtspec
            // 
            this.txtspec.Location = new System.Drawing.Point(611, 132);
            this.txtspec.Name = "txtspec";
            this.txtspec.Size = new System.Drawing.Size(449, 20);
            this.txtspec.StyleController = this.layoutControl1;
            this.txtspec.TabIndex = 10;
            // 
            // txtproductnumber
            // 
            this.txtproductnumber.Location = new System.Drawing.Point(87, 156);
            this.txtproductnumber.Name = "txtproductnumber";
            this.txtproductnumber.Size = new System.Drawing.Size(445, 20);
            this.txtproductnumber.StyleController = this.layoutControl1;
            this.txtproductnumber.TabIndex = 11;
            // 
            // txtunit
            // 
            this.txtunit.EditValue = "";
            this.txtunit.Location = new System.Drawing.Point(611, 156);
            this.txtunit.Name = "txtunit";
            this.txtunit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtunit.Properties.DisplayMember = "Name";
            this.txtunit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtunit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtunit.Properties.ValueMember = "ID";
            this.txtunit.Size = new System.Drawing.Size(449, 20);
            this.txtunit.StyleController = this.layoutControl1;
            this.txtunit.TabIndex = 12;
            // 
            // txtfinishdate
            // 
            this.txtfinishdate.EditValue = null;
            this.txtfinishdate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtfinishdate.Location = new System.Drawing.Point(87, 180);
            this.txtfinishdate.Name = "txtfinishdate";
            this.txtfinishdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtfinishdate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtfinishdate.Properties.DisplayFormat.FormatString = "G";
            this.txtfinishdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtfinishdate.Properties.Mask.EditMask = "G";
            this.txtfinishdate.Size = new System.Drawing.Size(445, 20);
            this.txtfinishdate.StyleController = this.layoutControl1;
            this.txtfinishdate.TabIndex = 13;
            // 
            // txtdeliverdate
            // 
            this.txtdeliverdate.EditValue = null;
            this.txtdeliverdate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtdeliverdate.Location = new System.Drawing.Point(611, 180);
            this.txtdeliverdate.Name = "txtdeliverdate";
            this.txtdeliverdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtdeliverdate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtdeliverdate.Properties.DisplayFormat.FormatString = "G";
            this.txtdeliverdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtdeliverdate.Properties.Mask.EditMask = "G";
            this.txtdeliverdate.Size = new System.Drawing.Size(449, 20);
            this.txtdeliverdate.StyleController = this.layoutControl1;
            this.txtdeliverdate.TabIndex = 14;
            // 
            // txtwarehouse
            // 
            this.txtwarehouse.EditValue = "";
            this.txtwarehouse.Location = new System.Drawing.Point(87, 204);
            this.txtwarehouse.Name = "txtwarehouse";
            this.txtwarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtwarehouse.Properties.DisplayMember = "Name";
            this.txtwarehouse.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtwarehouse.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtwarehouse.Properties.ValueMember = "ID";
            this.txtwarehouse.Size = new System.Drawing.Size(445, 20);
            this.txtwarehouse.StyleController = this.layoutControl1;
            this.txtwarehouse.TabIndex = 15;
            // 
            // txtcreatorId
            // 
            this.txtcreatorId.EditValue = "";
            this.txtcreatorId.Location = new System.Drawing.Point(87, 228);
            this.txtcreatorId.Name = "txtcreatorId";
            this.txtcreatorId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcreatorId.Properties.DisplayMember = "Name";
            this.txtcreatorId.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtcreatorId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtcreatorId.Properties.ValueMember = "ID";
            this.txtcreatorId.Size = new System.Drawing.Size(445, 20);
            this.txtcreatorId.StyleController = this.layoutControl1;
            this.txtcreatorId.TabIndex = 16;
            // 
            // txtcreateTime
            // 
            this.txtcreateTime.EditValue = null;
            this.txtcreateTime.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtcreateTime.Location = new System.Drawing.Point(611, 228);
            this.txtcreateTime.Name = "txtcreateTime";
            this.txtcreateTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcreateTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtcreateTime.Properties.DisplayFormat.FormatString = "G";
            this.txtcreateTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtcreateTime.Properties.Mask.EditMask = "G";
            this.txtcreateTime.Size = new System.Drawing.Size(449, 20);
            this.txtcreateTime.StyleController = this.layoutControl1;
            this.txtcreateTime.TabIndex = 17;
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(611, 204);
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(449, 20);
            this.txtremark.StyleController = this.layoutControl1;
            this.txtremark.TabIndex = 18;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem11,
            this.layoutControlItem13,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem2,
            this.layoutControlItem10,
            this.layoutControlItem14,
            this.layoutControlItem18,
            this.layoutControlItem17,
            this.layoutControlItem19,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem20,
            this.layoutControlItem12,
            this.layoutControlItem9,
            this.layoutControlItem8,
            this.layoutControlItem3,
            this.layoutControlItem21,
            this.layoutControlItem7});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1072, 628);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtid;
            this.layoutControlItem1.CustomizationFormText = "id";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(524, 24);
            this.layoutControlItem1.Text = "id";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtsaledetailcode;
            this.layoutControlItem4.CustomizationFormText = "销售明细单号";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(524, 24);
            this.layoutControlItem4.Text = "销售明细单号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtproductnumber;
            this.layoutControlItem11.CustomizationFormText = "生产数量";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(524, 24);
            this.layoutControlItem11.Text = "生产数量";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtfinishdate;
            this.layoutControlItem13.CustomizationFormText = "完工日期";
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 168);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(524, 24);
            this.layoutControlItem13.Text = "完工日期";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.txtwarehouse;
            this.layoutControlItem15.CustomizationFormText = "仓库";
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(524, 24);
            this.layoutControlItem15.Text = "仓库";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txtcreatorId;
            this.layoutControlItem16.CustomizationFormText = "制单人";
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 216);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(524, 24);
            this.layoutControlItem16.Text = "制单人";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtwordordercode;
            this.layoutControlItem2.CustomizationFormText = "工单号";
            this.layoutControlItem2.Location = new System.Drawing.Point(524, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(528, 24);
            this.layoutControlItem2.Text = "工单号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtspec;
            this.layoutControlItem10.CustomizationFormText = "规格型号";
            this.layoutControlItem10.Location = new System.Drawing.Point(524, 120);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(528, 24);
            this.layoutControlItem10.Text = "规格型号";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtdeliverdate;
            this.layoutControlItem14.CustomizationFormText = "交货日期";
            this.layoutControlItem14.Location = new System.Drawing.Point(524, 168);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(528, 24);
            this.layoutControlItem14.Text = "交货日期";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txtremark;
            this.layoutControlItem18.CustomizationFormText = "备注";
            this.layoutControlItem18.Location = new System.Drawing.Point(524, 192);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(528, 24);
            this.layoutControlItem18.Text = "备注";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.txtcreateTime;
            this.layoutControlItem17.CustomizationFormText = "制单日期";
            this.layoutControlItem17.Location = new System.Drawing.Point(524, 216);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(528, 24);
            this.layoutControlItem17.Text = "制单日期";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.xtraTabControl2;
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 240);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(1052, 368);
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtworkordertype;
            this.layoutControlItem5.CustomizationFormText = "工单类型";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(524, 24);
            this.layoutControlItem5.Text = "工单类型";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtproductdate;
            this.layoutControlItem6.CustomizationFormText = "生产日期";
            this.layoutControlItem6.Location = new System.Drawing.Point(524, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(528, 24);
            this.layoutControlItem6.Text = "生产日期";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.txtbomid;
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(524, 24);
            this.layoutControlItem20.Text = "bom";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtunit;
            this.layoutControlItem12.CustomizationFormText = "计量单位";
            this.layoutControlItem12.Location = new System.Drawing.Point(524, 144);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(528, 24);
            this.layoutControlItem12.Text = "计量单位";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtproductid;
            this.layoutControlItem9.CustomizationFormText = "产品名称";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(524, 24);
            this.layoutControlItem9.Text = "产品名称";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtproductcode;
            this.layoutControlItem8.CustomizationFormText = "产品编号";
            this.layoutControlItem8.Location = new System.Drawing.Point(524, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(528, 24);
            this.layoutControlItem8.Text = "产品编号";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtsalecode;
            this.layoutControlItem3.CustomizationFormText = "销售单号";
            this.layoutControlItem3.Location = new System.Drawing.Point(524, 96);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(528, 24);
            this.layoutControlItem3.Text = "销售单号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.txtproducttype;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(524, 24);
            this.layoutControlItem21.Text = "产品类型";
            this.layoutControlItem21.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtproductdept;
            this.layoutControlItem7.CustomizationFormText = "生产单位";
            this.layoutControlItem7.Location = new System.Drawing.Point(524, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(528, 24);
            this.layoutControlItem7.Text = "生产单位";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(72, 14);
            // 
            // Frmworkorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 695);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "Frmworkorder";
            this.Text = "工单";
            this.Load += new System.EventHandler(this.Frmworkorder_Load);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtworkordertype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtproductdept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtproductid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtunit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtwarehouse)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtproducttype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbomid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditmaterialtype)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwordordercode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsalecode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsaledetailcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtworkordertype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductdept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtspec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtproductnumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtunit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfinishdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfinishdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliverdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliverdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreatorId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreateTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
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
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtid;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtwordordercode;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtsalecode;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtsaledetailcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtworkordertype;

        private DevExpress.XtraEditors.LookUpEdit txtworkordertype;
        ///////////////////////////////
        private DevExpress.XtraEditors.DateEdit txtproductdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtproductdept;

        private DevExpress.XtraEditors.LookUpEdit txtproductdept;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtproductcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtproductid;

        private DevExpress.XtraEditors.LookUpEdit txtproductid;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtspec;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtproductnumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtunit;

        private DevExpress.XtraEditors.LookUpEdit txtunit;
        ///////////////////////////////
        private DevExpress.XtraEditors.DateEdit txtfinishdate;
        ///////////////////////////////
        private DevExpress.XtraEditors.DateEdit txtdeliverdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtwarehouse;

        private DevExpress.XtraEditors.LookUpEdit txtwarehouse;
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
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private XtraTabControl xtraTabControl2;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private LayoutControlItem layoutControlItem19;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private LookUpEdit txtbomid;
        private LayoutControlItem layoutControlItem20;
        private LookUpEdit txtproducttype;
        private LayoutControlItem layoutControlItem21;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditmaterialid;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditmaterialtype;
    }
}