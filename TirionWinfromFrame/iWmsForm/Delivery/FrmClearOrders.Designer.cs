
namespace TirionWinfromFrame.iWmsForm
{
    partial class FrmClearOrders
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
            this.colDeliveryNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDestination = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinishTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGeneral = new DevExpress.XtraEditors.GroupControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tbOrder = new DevExpress.XtraEditors.TextEdit();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deEndTime = new DevExpress.XtraEditors.DateEdit();
            this.btnClearAll = new DevExpress.XtraEditors.SimpleButton();
            this.tpOperation = new DevExpress.Utils.Layout.TablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.layout)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlpLayout)).BeginInit();
            this.tlpLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBarcodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBarcodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGeneral)).BeginInit();
            this.gcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tpOperation)).BeginInit();
            this.tpOperation.SuspendLayout();
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
            this.colDeliveryNo,
            this.colOrderType,
            this.colDestination,
            this.colStatus,
            this.colOrderTime,
            this.colFinishTime});
            this.gvBarcodes.GridControl = this.gridBarcodes;
            this.gvBarcodes.IndicatorWidth = 50;
            this.gvBarcodes.Name = "gvBarcodes";
            this.gvBarcodes.OptionsBehavior.Editable = false;
            this.gvBarcodes.OptionsView.ShowGroupPanel = false;
            this.gvBarcodes.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.GvBarcodes_CustomDrawRowIndicator);
            // 
            // colDeliveryNo
            // 
            this.colDeliveryNo.Caption = "出库单号";
            this.colDeliveryNo.FieldName = "DeliveryNo";
            this.colDeliveryNo.Name = "colDeliveryNo";
            this.colDeliveryNo.Visible = true;
            this.colDeliveryNo.VisibleIndex = 0;
            // 
            // colOrderType
            // 
            this.colOrderType.Caption = "单据类型";
            this.colOrderType.FieldName = "DeliveryTypeDisplay";
            this.colOrderType.Name = "colOrderType";
            this.colOrderType.Visible = true;
            this.colOrderType.VisibleIndex = 1;
            // 
            // colDestination
            // 
            this.colDestination.Caption = "目的地";
            this.colDestination.FieldName = "LineId";
            this.colDestination.Name = "colDestination";
            this.colDestination.Visible = true;
            this.colDestination.VisibleIndex = 2;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "单据状态";
            this.colStatus.FieldName = "OrderStatusDisplay";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;
            // 
            // colOrderTime
            // 
            this.colOrderTime.Caption = "下达时间";
            this.colOrderTime.FieldName = "CreateTime";
            this.colOrderTime.Name = "colOrderTime";
            this.colOrderTime.Visible = true;
            this.colOrderTime.VisibleIndex = 4;
            // 
            // colFinishTime
            // 
            this.colFinishTime.Caption = "关闭时间";
            this.colFinishTime.FieldName = "LastUpdateTime";
            this.colFinishTime.Name = "colFinishTime";
            this.colFinishTime.Visible = true;
            this.colFinishTime.VisibleIndex = 5;
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
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tpOperation.SetColumn(this.labelControl1, 1);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(16, 45);
            this.labelControl1.Name = "labelControl1";
            this.tpOperation.SetRow(this.labelControl1, 1);
            this.labelControl1.Size = new System.Drawing.Size(74, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "出库单号";
            // 
            // tbOrder
            // 
            this.tpOperation.SetColumn(this.tbOrder, 2);
            this.tbOrder.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbOrder.Location = new System.Drawing.Point(96, 45);
            this.tbOrder.Name = "tbOrder";
            this.tpOperation.SetRow(this.tbOrder, 1);
            this.tbOrder.Size = new System.Drawing.Size(146, 20);
            this.tbOrder.TabIndex = 1;
            this.tbOrder.ToolTip = "请扫描要复核的二维码...";
            // 
            // btnConfirm
            // 
            this.tpOperation.SetColumn(this.btnConfirm, 7);
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Location = new System.Drawing.Point(520, 45);
            this.btnConfirm.Name = "btnConfirm";
            this.tpOperation.SetRow(this.btnConfirm, 1);
            this.btnConfirm.Size = new System.Drawing.Size(94, 20);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "查询";
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // btnExecute
            // 
            this.tpOperation.SetColumn(this.btnExecute, 9);
            this.btnExecute.Location = new System.Drawing.Point(640, 45);
            this.btnExecute.Name = "btnExecute";
            this.tpOperation.SetRow(this.btnExecute, 1);
            this.btnExecute.Size = new System.Drawing.Size(94, 20);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "清理";
            this.btnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tpOperation.SetColumn(this.labelControl2, 4);
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(268, 45);
            this.labelControl2.Name = "labelControl2";
            this.tpOperation.SetRow(this.labelControl2, 1);
            this.labelControl2.Size = new System.Drawing.Size(74, 20);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "截止时间";
            // 
            // deEndTime
            // 
            this.tpOperation.SetColumn(this.deEndTime, 5);
            this.deEndTime.EditValue = null;
            this.deEndTime.Location = new System.Drawing.Point(348, 45);
            this.deEndTime.Name = "deEndTime";
            this.deEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEndTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tpOperation.SetRow(this.deEndTime, 1);
            this.deEndTime.Size = new System.Drawing.Size(146, 20);
            this.deEndTime.TabIndex = 6;
            // 
            // btnClearAll
            // 
            this.tpOperation.SetColumn(this.btnClearAll, 11);
            this.btnClearAll.Location = new System.Drawing.Point(760, 45);
            this.btnClearAll.Name = "btnClearAll";
            this.tpOperation.SetRow(this.btnClearAll, 1);
            this.btnClearAll.Size = new System.Drawing.Size(94, 20);
            this.btnClearAll.TabIndex = 8;
            this.btnClearAll.Text = "清理全部";
            this.btnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // tpOperation
            // 
            this.tpOperation.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 2F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 80F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 24F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 80F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 24F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F)});
            this.tpOperation.Controls.Add(this.btnClearAll);
            this.tpOperation.Controls.Add(this.deEndTime);
            this.tpOperation.Controls.Add(this.labelControl2);
            this.tpOperation.Controls.Add(this.btnExecute);
            this.tpOperation.Controls.Add(this.btnConfirm);
            this.tpOperation.Controls.Add(this.tbOrder);
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
            // FrmClearOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 581);
            this.Controls.Add(this.layout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClearOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "清理出库单";
            ((System.ComponentModel.ISupportInitialize)(this.layout)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlpLayout)).EndInit();
            this.tlpLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBarcodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBarcodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGeneral)).EndInit();
            this.gcGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tpOperation)).EndInit();
            this.tpOperation.ResumeLayout(false);
            this.tpOperation.PerformLayout();
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
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryNo;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderType;
        private DevExpress.XtraGrid.Columns.GridColumn colDestination;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderTime;
        private DevExpress.XtraGrid.Columns.GridColumn colFinishTime;
        private DevExpress.Utils.Layout.TablePanel tpOperation;
        private DevExpress.XtraEditors.SimpleButton btnClearAll;
        private DevExpress.XtraEditors.DateEdit deEndTime;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.TextEdit tbOrder;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}