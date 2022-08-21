
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;

namespace MES.Form
{
    partial class  FrmsysDataTable
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
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabDataList = new DevExpress.XtraTab.XtraTabPage();
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.grdListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabDataDetail = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtDataTableSql = new DevExpress.XtraEditors.MemoEdit();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtDataTableName = new DevExpress.XtraEditors.TextEdit();
            this.txtDataTableUrl = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataTableSql.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataTableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataTableUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "数据集名称";
            this.gridColumn1.FieldName = "DataTableName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 201;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "数据集sql";
            this.gridColumn2.FieldName = "DataTableSql";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 201;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "数据集连接";
            this.gridColumn3.FieldName = "DataTableUrl";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 201;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 33);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabDataList;
            this.xtraTabControl1.Size = new System.Drawing.Size(1300, 766);
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
            this.grdList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdList_MouseDoubleClick);
            // 
            // grdListView
            // 
            this.grdListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grdListView.GridControl = this.grdList;
            this.grdListView.Name = "grdListView";
            this.grdListView.OptionsBehavior.ReadOnly = true;
            this.grdListView.OptionsView.ColumnAutoWidth = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "数据源名称";
            this.gridColumn4.FieldName = "DataSourceName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // tabDataDetail
            // 
            this.tabDataDetail.Controls.Add(this.panelControl2);
            this.tabDataDetail.Name = "tabDataDetail";
            this.tabDataDetail.Size = new System.Drawing.Size(1294, 737);
            this.tabDataDetail.Text = "数据编辑";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.layoutControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1294, 737);
            this.panelControl2.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnTest);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.txtDataTableSql);
            this.layoutControl1.Controls.Add(this.comboBoxEdit1);
            this.layoutControl1.Controls.Add(this.txtDataTableName);
            this.layoutControl1.Controls.Add(this.txtDataTableUrl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1290, 733);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 265);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(631, 22);
            this.btnTest.StyleController = this.layoutControl1;
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "测试";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(647, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(631, 22);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 291);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1266, 430);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // txtDataTableSql
            // 
            this.txtDataTableSql.Location = new System.Drawing.Point(75, 84);
            this.txtDataTableSql.Name = "txtDataTableSql";
            this.txtDataTableSql.Size = new System.Drawing.Size(1203, 177);
            this.txtDataTableSql.StyleController = this.layoutControl1;
            this.txtDataTableSql.TabIndex = 5;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(75, 36);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(1203, 20);
            this.comboBoxEdit1.StyleController = this.layoutControl1;
            this.comboBoxEdit1.TabIndex = 4;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // txtDataTableName
            // 
            this.txtDataTableName.Location = new System.Drawing.Point(75, 12);
            this.txtDataTableName.Name = "txtDataTableName";
            this.txtDataTableName.Size = new System.Drawing.Size(1203, 20);
            this.txtDataTableName.StyleController = this.layoutControl1;
            this.txtDataTableName.TabIndex = 1;
            // 
            // txtDataTableUrl
            // 
            this.txtDataTableUrl.Location = new System.Drawing.Point(75, 60);
            this.txtDataTableUrl.Name = "txtDataTableUrl";
            this.txtDataTableUrl.Size = new System.Drawing.Size(1203, 20);
            this.txtDataTableUrl.StyleController = this.layoutControl1;
            this.txtDataTableUrl.TabIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem7,
            this.layoutControlItem6});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1290, 733);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDataTableName;
            this.layoutControlItem1.CustomizationFormText = "数据集名称";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1270, 24);
            this.layoutControlItem1.Text = "数据集名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDataTableUrl;
            this.layoutControlItem3.CustomizationFormText = "数据集连接";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1270, 24);
            this.layoutControlItem3.Text = "数据集连接";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.comboBoxEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1270, 24);
            this.layoutControlItem4.Text = "数据源名称";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtDataTableSql;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1270, 181);
            this.layoutControlItem5.Text = "数据集SQL";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 279);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1270, 434);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnTest;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 253);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(635, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnSave;
            this.layoutControlItem6.Location = new System.Drawing.Point(635, 253);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(635, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // FrmsysDataTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FrmsysDataTable";
            this.Text = "数据集维护";
            this.Load += new System.EventHandler(this.FrmsysDataTable_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataTableSql.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataTableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataTableUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
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
         private DevExpress.XtraEditors.TextEdit txtDataTableName;
         private DevExpress.XtraEditors.TextEdit txtDataTableUrl;
 
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private ComboBoxEdit comboBoxEdit1;
        private LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private MemoEdit txtDataTableSql;
        private LayoutControlItem layoutControlItem5;
        private LayoutControlItem layoutControlItem2;
        private SimpleButton btnTest;
        private SimpleButton btnSave;
        private LayoutControlItem layoutControlItem7;
        private LayoutControlItem layoutControlItem6;
    }
}