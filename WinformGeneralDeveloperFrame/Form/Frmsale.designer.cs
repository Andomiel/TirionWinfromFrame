
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;

namespace MES.Form
{
    partial class  Frmsale
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
            this.repositoryItemtxtcustomerid = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtcustomertype = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtcontactuser = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtsalesman = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtpreparedby = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabDataList = new DevExpress.XtraTab.XtraTabPage();
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.grdListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabDataDetail = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtunit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtwarehouse = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtproductid = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtid = new DevExpress.XtraEditors.TextEdit();
            this.txtsaleordercode = new DevExpress.XtraEditors.TextEdit();
            this.txtorderdate = new DevExpress.XtraEditors.DateEdit();
            this.txtcustomerid = new DevExpress.XtraEditors.LookUpEdit();
            this.txtcustomercode = new DevExpress.XtraEditors.TextEdit();
            this.txtcustomertype = new DevExpress.XtraEditors.LookUpEdit();
            this.txtcustomerordercode = new DevExpress.XtraEditors.TextEdit();
            this.txtcontactuser = new DevExpress.XtraEditors.LookUpEdit();
            this.txtcontactphone = new DevExpress.XtraEditors.TextEdit();
            this.txtdeliveraddress = new DevExpress.XtraEditors.TextEdit();
            this.txtsalesman = new DevExpress.XtraEditors.LookUpEdit();
            this.txtfinishdate = new DevExpress.XtraEditors.DateEdit();
            this.txtcreatorId = new DevExpress.XtraEditors.LookUpEdit();
            this.txtremark = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcustomerid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcustomertype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcontactuser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtsalesman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtpreparedby)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtunit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtwarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtproductid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsaleordercode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtorderdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtorderdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomerid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomercode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomertype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomerordercode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcontactuser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcontactphone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliveraddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsalesman.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfinishdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfinishdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreatorId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
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
            this.gridColumn2.Caption = "销售单号";
            this.gridColumn2.FieldName = "saleordercode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 201;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "订单日期";
            this.gridColumn3.DisplayFormat.FormatString = "G";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "orderdate";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 201;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "客户";
            this.gridColumn4.ColumnEdit = this.repositoryItemtxtcustomerid;
            this.gridColumn4.FieldName = "customerid";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 201;
            // 
            // repositoryItemtxtcustomerid
            // 
            this.repositoryItemtxtcustomerid.AutoHeight = false;
            this.repositoryItemtxtcustomerid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtcustomerid.DisplayMember = "Name";
            this.repositoryItemtxtcustomerid.Name = "repositoryItemtxtcustomerid";
            this.repositoryItemtxtcustomerid.ValueMember = "ID";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "客户编号";
            this.gridColumn5.FieldName = "customercode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 201;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "客户类型";
            this.gridColumn6.ColumnEdit = this.repositoryItemtxtcustomertype;
            this.gridColumn6.FieldName = "customertype";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 201;
            // 
            // repositoryItemtxtcustomertype
            // 
            this.repositoryItemtxtcustomertype.AutoHeight = false;
            this.repositoryItemtxtcustomertype.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtcustomertype.DisplayMember = "Name";
            this.repositoryItemtxtcustomertype.Name = "repositoryItemtxtcustomertype";
            this.repositoryItemtxtcustomertype.ValueMember = "ID";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "客户单号";
            this.gridColumn7.FieldName = "customerordercode";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 201;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "联系人";
            this.gridColumn8.ColumnEdit = this.repositoryItemtxtcontactuser;
            this.gridColumn8.FieldName = "contactuser";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 201;
            // 
            // repositoryItemtxtcontactuser
            // 
            this.repositoryItemtxtcontactuser.AutoHeight = false;
            this.repositoryItemtxtcontactuser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtcontactuser.DisplayMember = "Name";
            this.repositoryItemtxtcontactuser.Name = "repositoryItemtxtcontactuser";
            this.repositoryItemtxtcontactuser.ValueMember = "ID";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "联系电话";
            this.gridColumn9.FieldName = "contactphone";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 201;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "送货地址";
            this.gridColumn10.FieldName = "deliveraddress";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 201;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "业务员";
            this.gridColumn11.ColumnEdit = this.repositoryItemtxtsalesman;
            this.gridColumn11.FieldName = "salesman";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            this.gridColumn11.Width = 201;
            // 
            // repositoryItemtxtsalesman
            // 
            this.repositoryItemtxtsalesman.AutoHeight = false;
            this.repositoryItemtxtsalesman.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtsalesman.DisplayMember = "Name";
            this.repositoryItemtxtsalesman.Name = "repositoryItemtxtsalesman";
            this.repositoryItemtxtsalesman.ValueMember = "ID";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "完货日期";
            this.gridColumn12.DisplayFormat.FormatString = "G";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn12.FieldName = "finishdate";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            this.gridColumn12.Width = 201;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "制单人";
            this.gridColumn13.ColumnEdit = this.repositoryItemtxtpreparedby;
            this.gridColumn13.FieldName = "creatorId";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 201;
            // 
            // repositoryItemtxtpreparedby
            // 
            this.repositoryItemtxtpreparedby.AutoHeight = false;
            this.repositoryItemtxtpreparedby.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtpreparedby.DisplayMember = "Name";
            this.repositoryItemtxtpreparedby.Name = "repositoryItemtxtpreparedby";
            this.repositoryItemtxtpreparedby.ValueMember = "ID";
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
            this.xtraTabControl1.Size = new System.Drawing.Size(964, 648);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDataList,
            this.tabDataDetail});
            // 
            // tabDataList
            // 
            this.tabDataList.Controls.Add(this.grdList);
            this.tabDataList.Name = "tabDataList";
            this.tabDataList.Size = new System.Drawing.Size(948, 613);
            this.tabDataList.Text = "数据列表";
            // 
            // grdList
            // 
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(0, 0);
            this.grdList.MainView = this.grdListView;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(948, 613);
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
            // 
            // tabDataDetail
            // 
            this.tabDataDetail.Controls.Add(this.panelControl2);
            this.tabDataDetail.Name = "tabDataDetail";
            this.tabDataDetail.Size = new System.Drawing.Size(959, 622);
            this.tabDataDetail.Text = "数据编辑";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.layoutControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(959, 622);
            this.panelControl2.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.txtid);
            this.layoutControl1.Controls.Add(this.txtsaleordercode);
            this.layoutControl1.Controls.Add(this.txtorderdate);
            this.layoutControl1.Controls.Add(this.txtcustomerid);
            this.layoutControl1.Controls.Add(this.txtcustomercode);
            this.layoutControl1.Controls.Add(this.txtcustomertype);
            this.layoutControl1.Controls.Add(this.txtcustomerordercode);
            this.layoutControl1.Controls.Add(this.txtcontactuser);
            this.layoutControl1.Controls.Add(this.txtcontactphone);
            this.layoutControl1.Controls.Add(this.txtdeliveraddress);
            this.layoutControl1.Controls.Add(this.txtsalesman);
            this.layoutControl1.Controls.Add(this.txtfinishdate);
            this.layoutControl1.Controls.Add(this.txtcreatorId);
            this.layoutControl1.Controls.Add(this.txtremark);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(955, 618);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Location = new System.Drawing.Point(12, 204);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemtxtproductid,
            this.repositoryItemtxtunit,
            this.repositoryItemtxtwarehouse,
            this.repositoryItemGridLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(931, 402);
            this.gridControl1.TabIndex = 15;
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
            this.toolStripMenuItemAdd.Text = "添加行";
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
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
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
            this.gridColumn16.Caption = "产品";
            this.gridColumn16.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.gridColumn16.FieldName = "productid";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            this.gridColumn16.Width = 201;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.DisplayMember = "productname";
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.NullText = "";
            this.repositoryItemGridLookUpEdit1.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repositoryItemGridLookUpEdit1.ValueMember = "productid";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsBehavior.AllowIncrementalSearch = true;
            this.repositoryItemGridLookUpEdit1View.OptionsBehavior.Editable = false;
            this.repositoryItemGridLookUpEdit1View.OptionsFind.SearchInPreview = true;
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ColumnAutoWidth = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "规格型号";
            this.gridColumn17.FieldName = "productspec";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 2;
            this.gridColumn17.Width = 201;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "数量";
            this.gridColumn18.FieldName = "salenumber";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 3;
            this.gridColumn18.Width = 201;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "计量单位";
            this.gridColumn19.ColumnEdit = this.repositoryItemtxtunit;
            this.gridColumn19.FieldName = "unit";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 4;
            this.gridColumn19.Width = 201;
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
            // gridColumn20
            // 
            this.gridColumn20.Caption = "单价";
            this.gridColumn20.FieldName = "unitprice";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 5;
            this.gridColumn20.Width = 201;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "金额";
            this.gridColumn21.FieldName = "money";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 6;
            this.gridColumn21.Width = 201;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "交货日期";
            this.gridColumn22.DisplayFormat.FormatString = "G";
            this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn22.FieldName = "deliverdate";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 7;
            this.gridColumn22.Width = 201;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "仓库";
            this.gridColumn23.ColumnEdit = this.repositoryItemtxtwarehouse;
            this.gridColumn23.FieldName = "warehouse";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 8;
            this.gridColumn23.Width = 201;
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
            // gridColumn24
            // 
            this.gridColumn24.Caption = "已排产量";
            this.gridColumn24.FieldName = "readynumber";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 9;
            this.gridColumn24.Width = 201;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "待排产量";
            this.gridColumn25.FieldName = "noreadynumber";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 10;
            this.gridColumn25.Width = 201;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "已完工量";
            this.gridColumn26.FieldName = "finishnumber";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 11;
            this.gridColumn26.Width = 201;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "已出货量";
            this.gridColumn27.FieldName = "outnumber";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 12;
            this.gridColumn27.Width = 201;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "退货量";
            this.gridColumn28.FieldName = "returnnumber";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 13;
            this.gridColumn28.Width = 201;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "未交货数量";
            this.gridColumn29.FieldName = "nodelivernumber";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 14;
            this.gridColumn29.Width = 201;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "实际交货数量";
            this.gridColumn30.FieldName = "delivernumber";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 15;
            this.gridColumn30.Width = 201;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "已结算数量";
            this.gridColumn31.FieldName = "closenumber";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 16;
            this.gridColumn31.Width = 201;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "未结算数量";
            this.gridColumn32.FieldName = "noclosenumber";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.AllowEdit = false;
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 17;
            this.gridColumn32.Width = 201;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "物料成本";
            this.gridColumn33.FieldName = "materialcost";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 18;
            this.gridColumn33.Width = 201;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "实际物料成本";
            this.gridColumn34.FieldName = "realmaterialcost";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 19;
            this.gridColumn34.Width = 201;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "产品编号";
            this.gridColumn35.FieldName = "productcode";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 20;
            this.gridColumn35.Width = 201;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "销售主表";
            this.gridColumn36.FieldName = "saleid";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.Width = 201;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "销售单号";
            this.gridColumn37.FieldName = "salecode";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 21;
            this.gridColumn37.Width = 201;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "明细单号";
            this.gridColumn38.FieldName = "saledetailcode";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.AllowEdit = false;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 0;
            // 
            // repositoryItemtxtproductid
            // 
            this.repositoryItemtxtproductid.AutoHeight = false;
            this.repositoryItemtxtproductid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemtxtproductid.Name = "repositoryItemtxtproductid";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(63, 12);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(880, 20);
            this.txtid.StyleController = this.layoutControl1;
            this.txtid.TabIndex = 1;
            // 
            // txtsaleordercode
            // 
            this.txtsaleordercode.Location = new System.Drawing.Point(63, 36);
            this.txtsaleordercode.Name = "txtsaleordercode";
            this.txtsaleordercode.Size = new System.Drawing.Size(412, 20);
            this.txtsaleordercode.StyleController = this.layoutControl1;
            this.txtsaleordercode.TabIndex = 2;
            // 
            // txtorderdate
            // 
            this.txtorderdate.EditValue = null;
            this.txtorderdate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtorderdate.Location = new System.Drawing.Point(530, 36);
            this.txtorderdate.Name = "txtorderdate";
            this.txtorderdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtorderdate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtorderdate.Properties.DisplayFormat.FormatString = "G";
            this.txtorderdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtorderdate.Properties.Mask.EditMask = "G";
            this.txtorderdate.Size = new System.Drawing.Size(413, 20);
            this.txtorderdate.StyleController = this.layoutControl1;
            this.txtorderdate.TabIndex = 3;
            // 
            // txtcustomerid
            // 
            this.txtcustomerid.EditValue = "";
            this.txtcustomerid.Location = new System.Drawing.Point(63, 60);
            this.txtcustomerid.Name = "txtcustomerid";
            this.txtcustomerid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcustomerid.Properties.DisplayMember = "Name";
            this.txtcustomerid.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtcustomerid.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtcustomerid.Properties.ValueMember = "ID";
            this.txtcustomerid.Size = new System.Drawing.Size(412, 20);
            this.txtcustomerid.StyleController = this.layoutControl1;
            this.txtcustomerid.TabIndex = 4;
            this.txtcustomerid.EditValueChanged += new System.EventHandler(this.txtcustomerid_EditValueChanged);
            // 
            // txtcustomercode
            // 
            this.txtcustomercode.Location = new System.Drawing.Point(530, 60);
            this.txtcustomercode.Name = "txtcustomercode";
            this.txtcustomercode.Size = new System.Drawing.Size(413, 20);
            this.txtcustomercode.StyleController = this.layoutControl1;
            this.txtcustomercode.TabIndex = 5;
            // 
            // txtcustomertype
            // 
            this.txtcustomertype.EditValue = "";
            this.txtcustomertype.Location = new System.Drawing.Point(63, 84);
            this.txtcustomertype.Name = "txtcustomertype";
            this.txtcustomertype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcustomertype.Properties.DisplayMember = "Name";
            this.txtcustomertype.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtcustomertype.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtcustomertype.Properties.ValueMember = "ID";
            this.txtcustomertype.Size = new System.Drawing.Size(412, 20);
            this.txtcustomertype.StyleController = this.layoutControl1;
            this.txtcustomertype.TabIndex = 6;
            // 
            // txtcustomerordercode
            // 
            this.txtcustomerordercode.Location = new System.Drawing.Point(530, 84);
            this.txtcustomerordercode.Name = "txtcustomerordercode";
            this.txtcustomerordercode.Size = new System.Drawing.Size(413, 20);
            this.txtcustomerordercode.StyleController = this.layoutControl1;
            this.txtcustomerordercode.TabIndex = 7;
            // 
            // txtcontactuser
            // 
            this.txtcontactuser.EditValue = "";
            this.txtcontactuser.Location = new System.Drawing.Point(63, 108);
            this.txtcontactuser.Name = "txtcontactuser";
            this.txtcontactuser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcontactuser.Properties.DisplayMember = "Name";
            this.txtcontactuser.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtcontactuser.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtcontactuser.Properties.ValueMember = "ID";
            this.txtcontactuser.Size = new System.Drawing.Size(412, 20);
            this.txtcontactuser.StyleController = this.layoutControl1;
            this.txtcontactuser.TabIndex = 8;
            // 
            // txtcontactphone
            // 
            this.txtcontactphone.Location = new System.Drawing.Point(530, 108);
            this.txtcontactphone.Name = "txtcontactphone";
            this.txtcontactphone.Size = new System.Drawing.Size(413, 20);
            this.txtcontactphone.StyleController = this.layoutControl1;
            this.txtcontactphone.TabIndex = 9;
            // 
            // txtdeliveraddress
            // 
            this.txtdeliveraddress.Location = new System.Drawing.Point(530, 132);
            this.txtdeliveraddress.Name = "txtdeliveraddress";
            this.txtdeliveraddress.Size = new System.Drawing.Size(413, 20);
            this.txtdeliveraddress.StyleController = this.layoutControl1;
            this.txtdeliveraddress.TabIndex = 10;
            // 
            // txtsalesman
            // 
            this.txtsalesman.EditValue = "";
            this.txtsalesman.Location = new System.Drawing.Point(63, 132);
            this.txtsalesman.Name = "txtsalesman";
            this.txtsalesman.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtsalesman.Properties.DisplayMember = "Name";
            this.txtsalesman.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtsalesman.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtsalesman.Properties.ValueMember = "ID";
            this.txtsalesman.Size = new System.Drawing.Size(412, 20);
            this.txtsalesman.StyleController = this.layoutControl1;
            this.txtsalesman.TabIndex = 11;
            // 
            // txtfinishdate
            // 
            this.txtfinishdate.EditValue = null;
            this.txtfinishdate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtfinishdate.Location = new System.Drawing.Point(63, 156);
            this.txtfinishdate.Name = "txtfinishdate";
            this.txtfinishdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtfinishdate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtfinishdate.Properties.DisplayFormat.FormatString = "G";
            this.txtfinishdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtfinishdate.Properties.Mask.EditMask = "G";
            this.txtfinishdate.Size = new System.Drawing.Size(412, 20);
            this.txtfinishdate.StyleController = this.layoutControl1;
            this.txtfinishdate.TabIndex = 12;
            // 
            // txtcreatorId
            // 
            this.txtcreatorId.EditValue = "";
            this.txtcreatorId.Location = new System.Drawing.Point(530, 156);
            this.txtcreatorId.Name = "txtcreatorId";
            this.txtcreatorId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcreatorId.Properties.DisplayMember = "Name";
            this.txtcreatorId.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtcreatorId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtcreatorId.Properties.ValueMember = "ID";
            this.txtcreatorId.Size = new System.Drawing.Size(413, 20);
            this.txtcreatorId.StyleController = this.layoutControl1;
            this.txtcreatorId.TabIndex = 13;
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(63, 180);
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(880, 20);
            this.txtremark.StyleController = this.layoutControl1;
            this.txtremark.TabIndex = 14;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem13,
            this.layoutControlItem15,
            this.layoutControlItem14});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(955, 618);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtid;
            this.layoutControlItem1.CustomizationFormText = "id";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(935, 24);
            this.layoutControlItem1.Text = "id";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtsaleordercode;
            this.layoutControlItem2.CustomizationFormText = "销售单号";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(467, 24);
            this.layoutControlItem2.Text = "销售单号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtcustomerid;
            this.layoutControlItem4.CustomizationFormText = "客户";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(467, 24);
            this.layoutControlItem4.Text = "客户";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtcustomertype;
            this.layoutControlItem6.CustomizationFormText = "客户类型";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(467, 24);
            this.layoutControlItem6.Text = "客户类型";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtcontactuser;
            this.layoutControlItem8.CustomizationFormText = "联系人";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(467, 24);
            this.layoutControlItem8.Text = "联系人";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtsalesman;
            this.layoutControlItem11.CustomizationFormText = "业务员";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(467, 24);
            this.layoutControlItem11.Text = "业务员";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtfinishdate;
            this.layoutControlItem12.CustomizationFormText = "完货日期";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(467, 24);
            this.layoutControlItem12.Text = "完货日期";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtorderdate;
            this.layoutControlItem3.CustomizationFormText = "订单日期";
            this.layoutControlItem3.Location = new System.Drawing.Point(467, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(468, 24);
            this.layoutControlItem3.Text = "订单日期";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtcustomercode;
            this.layoutControlItem5.CustomizationFormText = "客户编号";
            this.layoutControlItem5.Location = new System.Drawing.Point(467, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(468, 24);
            this.layoutControlItem5.Text = "客户编号";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtcustomerordercode;
            this.layoutControlItem7.CustomizationFormText = "客户单号";
            this.layoutControlItem7.Location = new System.Drawing.Point(467, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(468, 24);
            this.layoutControlItem7.Text = "客户单号";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtcontactphone;
            this.layoutControlItem9.CustomizationFormText = "联系电话";
            this.layoutControlItem9.Location = new System.Drawing.Point(467, 96);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(468, 24);
            this.layoutControlItem9.Text = "联系电话";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtdeliveraddress;
            this.layoutControlItem10.CustomizationFormText = "送货地址";
            this.layoutControlItem10.Location = new System.Drawing.Point(467, 120);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(468, 24);
            this.layoutControlItem10.Text = "送货地址";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtcreatorId;
            this.layoutControlItem13.CustomizationFormText = "制单人";
            this.layoutControlItem13.Location = new System.Drawing.Point(467, 144);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(468, 24);
            this.layoutControlItem13.Text = "制单人";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.gridControl1;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 192);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(935, 406);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtremark;
            this.layoutControlItem14.CustomizationFormText = "备注";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 168);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(935, 24);
            this.layoutControlItem14.Text = "备注";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(48, 14);
            // 
            // Frmsale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 682);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "Frmsale";
            this.Text = "销售订单";
            this.Load += new System.EventHandler(this.Frmsale_Load);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcustomerid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcustomertype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcontactuser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtsalesman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtpreparedby)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtunit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtwarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtproductid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsaleordercode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtorderdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtorderdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomerid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomercode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomertype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomerordercode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcontactuser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcontactphone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliveraddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsalesman.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfinishdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfinishdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreatorId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtsaleordercode;
        ///////////////////////////////
        private DevExpress.XtraEditors.DateEdit txtorderdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtcustomerid;

        private DevExpress.XtraEditors.LookUpEdit txtcustomerid;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtcustomercode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtcustomertype;

        private DevExpress.XtraEditors.LookUpEdit txtcustomertype;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtcustomerordercode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtcontactuser;

        private DevExpress.XtraEditors.LookUpEdit txtcontactuser;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtcontactphone;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtdeliveraddress;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtsalesman;

        private DevExpress.XtraEditors.LookUpEdit txtsalesman;
        ///////////////////////////////
        private DevExpress.XtraEditors.DateEdit txtfinishdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtpreparedby;

        private DevExpress.XtraEditors.LookUpEdit txtcreatorId;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private LayoutControlItem layoutControlItem15;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtproductid;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtunit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtwarehouse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDel;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
    }
}