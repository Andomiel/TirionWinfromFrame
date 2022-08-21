
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;

namespace MES.Form
{
    partial class  Frmdeliversale
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
            this.repositoryItemtxtcustomertype = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtcontactuser = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemtxtcreatorId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEditsalecode = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditwarehouse = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditunit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEditsalecode = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtid = new DevExpress.XtraEditors.TextEdit();
            this.txtcustomerid = new DevExpress.XtraEditors.LookUpEdit();
            this.txtcustomercode = new DevExpress.XtraEditors.TextEdit();
            this.txtdeliverdate = new DevExpress.XtraEditors.DateEdit();
            this.txtcustomertype = new DevExpress.XtraEditors.LookUpEdit();
            this.txtcontactuser = new DevExpress.XtraEditors.LookUpEdit();
            this.txtdeliveraddress = new DevExpress.XtraEditors.TextEdit();
            this.txtcreatorId = new DevExpress.XtraEditors.LookUpEdit();
            this.txtdeliversalecode = new DevExpress.XtraEditors.TextEdit();
            this.txtremark = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcustomerid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcustomertype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcontactuser)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditsalecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditwarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditunit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditsalecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomerid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomercode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliverdate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliverdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomertype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcontactuser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliveraddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreatorId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliversalecode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
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
            this.repositoryItemtxtcustomerid.ValueMember = "ID";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "客户编号";
            this.gridColumn3.FieldName = "customercode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 201;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "出货日期";
            this.gridColumn4.DisplayFormat.FormatString = "G";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "deliverdate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 201;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "客户类型";
            this.gridColumn5.ColumnEdit = this.repositoryItemtxtcustomertype;
            this.gridColumn5.FieldName = "customertype";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 201;
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
            // gridColumn6
            // 
            this.gridColumn6.Caption = "联系人";
            this.gridColumn6.ColumnEdit = this.repositoryItemtxtcontactuser;
            this.gridColumn6.FieldName = "contactuser";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 201;
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
            // gridColumn7
            // 
            this.gridColumn7.Caption = "送货地址";
            this.gridColumn7.FieldName = "deliveraddress";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 201;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "制单人";
            this.gridColumn8.ColumnEdit = this.repositoryItemtxtcreatorId;
            this.gridColumn8.FieldName = "creatorId";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 201;
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
            // gridColumn9
            // 
            this.gridColumn9.Caption = "出货单号";
            this.gridColumn9.FieldName = "deliversalecode";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 201;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "备注";
            this.gridColumn10.FieldName = "remark";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 201;
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
            this.tabDataList.Size = new System.Drawing.Size(1294, 737);
            this.tabDataList.Text = "数据列表";
            // 
            // grdList
            // 
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(0, 0);
            this.grdList.MainView = this.grdListView;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(1294, 737);
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
            this.gridColumn10});
            this.grdListView.GridControl = this.grdList;
            this.grdListView.Name = "grdListView";
            this.grdListView.OptionsBehavior.Editable = false;
            this.grdListView.OptionsView.ColumnAutoWidth = false;
            // 
            // tabDataDetail
            // 
            this.tabDataDetail.Controls.Add(this.panelControl2);
            this.tabDataDetail.Name = "tabDataDetail";
            this.tabDataDetail.Size = new System.Drawing.Size(1305, 746);
            this.tabDataDetail.Text = "数据编辑";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.layoutControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1305, 746);
            this.panelControl2.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.txtid);
            this.layoutControl1.Controls.Add(this.txtcustomerid);
            this.layoutControl1.Controls.Add(this.txtcustomercode);
            this.layoutControl1.Controls.Add(this.txtdeliverdate);
            this.layoutControl1.Controls.Add(this.txtcustomertype);
            this.layoutControl1.Controls.Add(this.txtcontactuser);
            this.layoutControl1.Controls.Add(this.txtdeliveraddress);
            this.layoutControl1.Controls.Add(this.txtcreatorId);
            this.layoutControl1.Controls.Add(this.txtdeliversalecode);
            this.layoutControl1.Controls.Add(this.txtremark);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1301, 742);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Location = new System.Drawing.Point(12, 156);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditwarehouse,
            this.repositoryItemLookUpEditunit,
            this.repositoryItemTextEditsalecode,
            this.repositoryItemGridLookUpEditsalecode});
            this.gridControl1.Size = new System.Drawing.Size(1277, 574);
            this.gridControl1.TabIndex = 11;
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
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "id";
            this.gridColumn11.FieldName = "id";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "出货单";
            this.gridColumn12.FieldName = "deliversaleid";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "销售单号";
            this.gridColumn13.ColumnEdit = this.repositoryItemGridLookUpEditsalecode;
            this.gridColumn13.FieldName = "salecode";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 201;
            // 
            // repositoryItemGridLookUpEditsalecode
            // 
            this.repositoryItemGridLookUpEditsalecode.AutoHeight = false;
            this.repositoryItemGridLookUpEditsalecode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEditsalecode.DisplayMember = "salecode";
            this.repositoryItemGridLookUpEditsalecode.Name = "repositoryItemGridLookUpEditsalecode";
            this.repositoryItemGridLookUpEditsalecode.NullText = "";
            this.repositoryItemGridLookUpEditsalecode.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repositoryItemGridLookUpEditsalecode.ValueMember = "salecode";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ColumnAutoWidth = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "产品名称";
            this.gridColumn14.FieldName = "productname";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 201;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "产品编号";
            this.gridColumn15.FieldName = "productcode";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            this.gridColumn15.Width = 201;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "规格型号";
            this.gridColumn16.FieldName = "productspec";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 4;
            this.gridColumn16.Width = 201;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "仓库";
            this.gridColumn17.ColumnEdit = this.repositoryItemLookUpEditwarehouse;
            this.gridColumn17.FieldName = "warehouse";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 5;
            this.gridColumn17.Width = 201;
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
            // gridColumn18
            // 
            this.gridColumn18.Caption = "出货数量";
            this.gridColumn18.FieldName = "number";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 6;
            this.gridColumn18.Width = 201;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "计量单位";
            this.gridColumn19.ColumnEdit = this.repositoryItemLookUpEditunit;
            this.gridColumn19.FieldName = "unit";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 7;
            this.gridColumn19.Width = 201;
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
            // gridColumn20
            // 
            this.gridColumn20.Caption = "出库单号";
            this.gridColumn20.FieldName = "deliversalecode";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 8;
            this.gridColumn20.Width = 201;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "备注";
            this.gridColumn21.FieldName = "remark";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 9;
            this.gridColumn21.Width = 201;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "明细单号";
            this.gridColumn22.FieldName = "deliversaledetailcode";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 0;
            // 
            // repositoryItemTextEditsalecode
            // 
            this.repositoryItemTextEditsalecode.AutoHeight = false;
            this.repositoryItemTextEditsalecode.Name = "repositoryItemTextEditsalecode";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(63, 12);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(585, 20);
            this.txtid.StyleController = this.layoutControl1;
            this.txtid.TabIndex = 1;
            // 
            // txtcustomerid
            // 
            this.txtcustomerid.EditValue = "";
            this.txtcustomerid.Location = new System.Drawing.Point(63, 36);
            this.txtcustomerid.Name = "txtcustomerid";
            this.txtcustomerid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcustomerid.Properties.DisplayMember = "Name";
            this.txtcustomerid.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtcustomerid.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtcustomerid.Properties.ValueMember = "ID";
            this.txtcustomerid.Size = new System.Drawing.Size(585, 20);
            this.txtcustomerid.StyleController = this.layoutControl1;
            this.txtcustomerid.TabIndex = 2;
            this.txtcustomerid.EditValueChanged += new System.EventHandler(this.txtcustomerid_EditValueChanged);
            // 
            // txtcustomercode
            // 
            this.txtcustomercode.Location = new System.Drawing.Point(703, 36);
            this.txtcustomercode.Name = "txtcustomercode";
            this.txtcustomercode.Size = new System.Drawing.Size(586, 20);
            this.txtcustomercode.StyleController = this.layoutControl1;
            this.txtcustomercode.TabIndex = 3;
            // 
            // txtdeliverdate
            // 
            this.txtdeliverdate.EditValue = null;
            this.txtdeliverdate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtdeliverdate.Location = new System.Drawing.Point(703, 60);
            this.txtdeliverdate.Name = "txtdeliverdate";
            this.txtdeliverdate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtdeliverdate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtdeliverdate.Properties.DisplayFormat.FormatString = "G";
            this.txtdeliverdate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtdeliverdate.Properties.Mask.EditMask = "G";
            this.txtdeliverdate.Size = new System.Drawing.Size(586, 20);
            this.txtdeliverdate.StyleController = this.layoutControl1;
            this.txtdeliverdate.TabIndex = 4;
            // 
            // txtcustomertype
            // 
            this.txtcustomertype.EditValue = "";
            this.txtcustomertype.Location = new System.Drawing.Point(63, 60);
            this.txtcustomertype.Name = "txtcustomertype";
            this.txtcustomertype.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcustomertype.Properties.DisplayMember = "Name";
            this.txtcustomertype.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtcustomertype.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtcustomertype.Properties.ValueMember = "ID";
            this.txtcustomertype.Size = new System.Drawing.Size(585, 20);
            this.txtcustomertype.StyleController = this.layoutControl1;
            this.txtcustomertype.TabIndex = 5;
            // 
            // txtcontactuser
            // 
            this.txtcontactuser.EditValue = "";
            this.txtcontactuser.Location = new System.Drawing.Point(63, 84);
            this.txtcontactuser.Name = "txtcontactuser";
            this.txtcontactuser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcontactuser.Properties.DisplayMember = "Name";
            this.txtcontactuser.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtcontactuser.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtcontactuser.Properties.ValueMember = "ID";
            this.txtcontactuser.Size = new System.Drawing.Size(585, 20);
            this.txtcontactuser.StyleController = this.layoutControl1;
            this.txtcontactuser.TabIndex = 6;
            // 
            // txtdeliveraddress
            // 
            this.txtdeliveraddress.Location = new System.Drawing.Point(703, 84);
            this.txtdeliveraddress.Name = "txtdeliveraddress";
            this.txtdeliveraddress.Size = new System.Drawing.Size(586, 20);
            this.txtdeliveraddress.StyleController = this.layoutControl1;
            this.txtdeliveraddress.TabIndex = 7;
            // 
            // txtcreatorId
            // 
            this.txtcreatorId.EditValue = "";
            this.txtcreatorId.Location = new System.Drawing.Point(63, 108);
            this.txtcreatorId.Name = "txtcreatorId";
            this.txtcreatorId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtcreatorId.Properties.DisplayMember = "Name";
            this.txtcreatorId.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.txtcreatorId.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtcreatorId.Properties.ValueMember = "ID";
            this.txtcreatorId.Size = new System.Drawing.Size(1226, 20);
            this.txtcreatorId.StyleController = this.layoutControl1;
            this.txtcreatorId.TabIndex = 8;
            // 
            // txtdeliversalecode
            // 
            this.txtdeliversalecode.Location = new System.Drawing.Point(703, 12);
            this.txtdeliversalecode.Name = "txtdeliversalecode";
            this.txtdeliversalecode.Size = new System.Drawing.Size(586, 20);
            this.txtdeliversalecode.StyleController = this.layoutControl1;
            this.txtdeliversalecode.TabIndex = 9;
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(63, 132);
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(1226, 20);
            this.txtremark.StyleController = this.layoutControl1;
            this.txtremark.TabIndex = 10;
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
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem9});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1301, 742);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtid;
            this.layoutControlItem1.CustomizationFormText = "id";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(640, 24);
            this.layoutControlItem1.Text = "id";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtcustomerid;
            this.layoutControlItem2.CustomizationFormText = "客户";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(640, 24);
            this.layoutControlItem2.Text = "客户";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtdeliverdate;
            this.layoutControlItem4.CustomizationFormText = "出货日期";
            this.layoutControlItem4.Location = new System.Drawing.Point(640, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(641, 24);
            this.layoutControlItem4.Text = "出货日期";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtcontactuser;
            this.layoutControlItem6.CustomizationFormText = "联系人";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(640, 24);
            this.layoutControlItem6.Text = "联系人";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtcreatorId;
            this.layoutControlItem8.CustomizationFormText = "制单人";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(1281, 24);
            this.layoutControlItem8.Text = "制单人";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtremark;
            this.layoutControlItem10.CustomizationFormText = "备注";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(1281, 24);
            this.layoutControlItem10.Text = "备注";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.gridControl1;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(1281, 578);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtcustomercode;
            this.layoutControlItem3.CustomizationFormText = "客户编号";
            this.layoutControlItem3.Location = new System.Drawing.Point(640, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(641, 24);
            this.layoutControlItem3.Text = "客户编号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtcustomertype;
            this.layoutControlItem5.CustomizationFormText = "客户类型";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(640, 24);
            this.layoutControlItem5.Text = "客户类型";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtdeliveraddress;
            this.layoutControlItem7.CustomizationFormText = "送货地址";
            this.layoutControlItem7.Location = new System.Drawing.Point(640, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(641, 24);
            this.layoutControlItem7.Text = "送货地址";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtdeliversalecode;
            this.layoutControlItem9.CustomizationFormText = "出货单号";
            this.layoutControlItem9.Location = new System.Drawing.Point(640, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(641, 24);
            this.layoutControlItem9.Text = "出货单号";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(48, 14);
            // 
            // Frmdeliversale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 806);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "Frmdeliversale";
            this.Text = "销售出货单";
            this.Load += new System.EventHandler(this.Frmdeliversale_Load);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcustomerid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcustomertype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtcontactuser)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditsalecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditwarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditunit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEditsalecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomerid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomercode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliverdate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliverdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcustomertype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcontactuser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliveraddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcreatorId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdeliversalecode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
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
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtid;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtcustomerid;

        private DevExpress.XtraEditors.LookUpEdit txtcustomerid;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtcustomercode;
        ///////////////////////////////
        private DevExpress.XtraEditors.DateEdit txtdeliverdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtcustomertype;

        private DevExpress.XtraEditors.LookUpEdit txtcustomertype;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtcontactuser;

        private DevExpress.XtraEditors.LookUpEdit txtcontactuser;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtdeliveraddress;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemtxtcreatorId;

        private DevExpress.XtraEditors.LookUpEdit txtcreatorId;
        ///////////////////////////////
        private DevExpress.XtraEditors.TextEdit txtdeliversalecode;
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
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private LayoutControlItem layoutControlItem11;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDel;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditwarehouse;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditunit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditsalecode;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEditsalecode;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
    }
}