
namespace TirionWinfromFrame.iWmsForm.StockTaking
{
    partial class FrmInventoryDetail
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
            this.layout = new DevExpress.XtraLayout.LayoutControl();
            this.tlpLayout = new DevExpress.Utils.Layout.TablePanel();
            this.gridBarcodes = new DevExpress.XtraGrid.GridControl();
            this.gvBarcodes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUpn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOriginQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActualQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGeneral = new DevExpress.XtraEditors.GroupControl();
            this.tpOperation = new DevExpress.Utils.Layout.TablePanel();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.tbBarcode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlpLayout)).BeginInit();
            this.tlpLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBarcodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBarcodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGeneral)).BeginInit();
            this.gcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tpOperation)).BeginInit();
            this.tpOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBarcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.Controls.Add(this.tlpLayout);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.Root = this.Root;
            this.layout.Size = new System.Drawing.Size(1018, 581);
            this.layout.TabIndex = 0;
            // 
            // tlpLayout
            // 
            this.tlpLayout.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tlpLayout.Controls.Add(this.gridBarcodes);
            this.tlpLayout.Controls.Add(this.gcGeneral);
            this.tlpLayout.Location = new System.Drawing.Point(12, 12);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 140F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 26F)});
            this.tlpLayout.Size = new System.Drawing.Size(994, 557);
            this.tlpLayout.TabIndex = 4;
            // 
            // gridBarcodes
            // 
            this.tlpLayout.SetColumn(this.gridBarcodes, 0);
            this.gridBarcodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBarcodes.Location = new System.Drawing.Point(3, 143);
            this.gridBarcodes.MainView = this.gvBarcodes;
            this.gridBarcodes.Name = "gridBarcodes";
            this.tlpLayout.SetRow(this.gridBarcodes, 1);
            this.gridBarcodes.Size = new System.Drawing.Size(988, 411);
            this.gridBarcodes.TabIndex = 1;
            this.gridBarcodes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBarcodes});
            // 
            // gvBarcodes
            // 
            this.gvBarcodes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUpn,
            this.colMaterialNo,
            this.colOriginQuantity,
            this.colActualQuantity,
            this.colResult});
            this.gvBarcodes.GridControl = this.gridBarcodes;
            this.gvBarcodes.IndicatorWidth = 50;
            this.gvBarcodes.Name = "gvBarcodes";
            this.gvBarcodes.OptionsView.ShowGroupPanel = false;
            this.gvBarcodes.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GvBarcodes_RowCellClick);
            this.gvBarcodes.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.GvBarcodes_CustomDrawRowIndicator);
            this.gvBarcodes.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GvBarcodes_RowCellStyle);
            // 
            // colUpn
            // 
            this.colUpn.Caption = "UPN";
            this.colUpn.FieldName = "Barcode";
            this.colUpn.Name = "colUpn";
            this.colUpn.OptionsColumn.AllowEdit = false;
            this.colUpn.Visible = true;
            this.colUpn.VisibleIndex = 0;
            // 
            // colMaterialNo
            // 
            this.colMaterialNo.Caption = "物料代码";
            this.colMaterialNo.FieldName = "MaterialNo";
            this.colMaterialNo.Name = "colMaterialNo";
            this.colMaterialNo.OptionsColumn.AllowEdit = false;
            this.colMaterialNo.Visible = true;
            this.colMaterialNo.VisibleIndex = 1;
            // 
            // colOriginQuantity
            // 
            this.colOriginQuantity.Caption = "原始数量";
            this.colOriginQuantity.FieldName = "OriginQuantity";
            this.colOriginQuantity.Name = "colOriginQuantity";
            this.colOriginQuantity.OptionsColumn.AllowEdit = false;
            this.colOriginQuantity.Visible = true;
            this.colOriginQuantity.VisibleIndex = 2;
            // 
            // colActualQuantity
            // 
            this.colActualQuantity.Caption = "盘点数量";
            this.colActualQuantity.FieldName = "RealQuantity";
            this.colActualQuantity.Name = "colActualQuantity";
            this.colActualQuantity.Visible = true;
            this.colActualQuantity.VisibleIndex = 3;
            // 
            // colResult
            // 
            this.colResult.Caption = "盘点结论";
            this.colResult.FieldName = "InventoryResult";
            this.colResult.Name = "colResult";
            this.colResult.OptionsColumn.AllowEdit = false;
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 4;
            // 
            // gcGeneral
            // 
            this.tlpLayout.SetColumn(this.gcGeneral, 0);
            this.gcGeneral.Controls.Add(this.tpOperation);
            this.gcGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGeneral.Location = new System.Drawing.Point(3, 3);
            this.gcGeneral.Name = "gcGeneral";
            this.tlpLayout.SetRow(this.gcGeneral, 0);
            this.gcGeneral.Size = new System.Drawing.Size(988, 134);
            this.gcGeneral.TabIndex = 0;
            // 
            // tpOperation
            // 
            this.tpOperation.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 2F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 80F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 48F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 48F)});
            this.tpOperation.Controls.Add(this.btnConfirm);
            this.tpOperation.Controls.Add(this.tbBarcode);
            this.tpOperation.Controls.Add(this.labelControl1);
            this.tpOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpOperation.Location = new System.Drawing.Point(2, 23);
            this.tpOperation.Name = "tpOperation";
            this.tpOperation.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tpOperation.Size = new System.Drawing.Size(984, 109);
            this.tpOperation.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.tpOperation.SetColumn(this.btnConfirm, 4);
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Location = new System.Drawing.Point(503, 45);
            this.btnConfirm.Name = "btnConfirm";
            this.tpOperation.SetRow(this.btnConfirm, 1);
            this.btnConfirm.Size = new System.Drawing.Size(94, 20);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // tbBarcode
            // 
            this.tpOperation.SetColumn(this.tbBarcode, 2);
            this.tbBarcode.Location = new System.Drawing.Point(99, 45);
            this.tbBarcode.Name = "tbBarcode";
            this.tpOperation.SetRow(this.tbBarcode, 1);
            this.tbBarcode.Size = new System.Drawing.Size(378, 20);
            this.tbBarcode.TabIndex = 1;
            this.tbBarcode.ToolTip = "请扫描要复核的二维码...";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tpOperation.SetColumn(this.labelControl1, 1);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(19, 45);
            this.labelControl1.Name = "labelControl1";
            this.tpOperation.SetRow(this.labelControl1, 1);
            this.labelControl1.Size = new System.Drawing.Size(74, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "二维码";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1018, 581);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tlpLayout;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(998, 561);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // FrmInventoryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 581);
            this.Controls.Add(this.layout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInventoryDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInventoryDetail";
            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlpLayout)).EndInit();
            this.tlpLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBarcodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBarcodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGeneral)).EndInit();
            this.gcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tpOperation)).EndInit();
            this.tpOperation.ResumeLayout(false);
            this.tpOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBarcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layout;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.Utils.Layout.TablePanel tlpLayout;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.GroupControl gcGeneral;
        private DevExpress.XtraGrid.GridControl gridBarcodes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBarcodes;
        private DevExpress.XtraGrid.Columns.GridColumn colUpn;
        private DevExpress.Utils.Layout.TablePanel tpOperation;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.TextEdit tbBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialNo;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colActualQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
    }
}