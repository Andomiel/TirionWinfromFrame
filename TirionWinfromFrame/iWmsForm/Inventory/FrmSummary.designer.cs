namespace iWms.Form
{
    partial class FrmSummary
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.数据导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.StatusStrip();
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTower = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据导出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 数据导出ToolStripMenuItem
            // 
            this.数据导出ToolStripMenuItem.Name = "数据导出ToolStripMenuItem";
            this.数据导出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.数据导出ToolStripMenuItem.Text = "数据导出";
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "新项选择";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.miniToolStrip.Size = new System.Drawing.Size(682, 23);
            this.miniToolStrip.TabIndex = 50;
            // 
            // gcSummary
            // 
            this.gcSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSummary.Location = new System.Drawing.Point(0, 34);
            this.gcSummary.MainView = this.gridView1;
            this.gcSummary.Name = "gcSummary";
            this.gcSummary.Size = new System.Drawing.Size(1365, 547);
            this.gcSummary.TabIndex = 2;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTower,
            this.colSubArea,
            this.colMaterialType,
            this.colTotalQuantity});
            this.gridView1.GridControl = this.gcSummary;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gridView1_CellMerge);
            // 
            // colTower
            // 
            this.colTower.Caption = "库区";
            this.colTower.FieldName = "TowerDisplay";
            this.colTower.Name = "colTower";
            this.colTower.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colTower.Visible = true;
            this.colTower.VisibleIndex = 0;
            // 
            // colSubArea
            // 
            this.colSubArea.Caption = "货架";
            this.colSubArea.FieldName = "SubArea";
            this.colSubArea.Name = "colSubArea";
            this.colSubArea.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colSubArea.Visible = true;
            this.colSubArea.VisibleIndex = 1;
            // 
            // colMaterialType
            // 
            this.colMaterialType.Caption = "物料类型";
            this.colMaterialType.FieldName = "MaterialTypeDisplay";
            this.colMaterialType.Name = "colMaterialType";
            this.colMaterialType.OptionsColumn.AllowEdit = false;
            this.colMaterialType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colMaterialType.Visible = true;
            this.colMaterialType.VisibleIndex = 2;
            // 
            // colTotalQuantity
            // 
            this.colTotalQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTotalQuantity.Caption = "总数量";
            this.colTotalQuantity.FieldName = "TotalQuantity";
            this.colTotalQuantity.Name = "colTotalQuantity";
            this.colTotalQuantity.OptionsColumn.AllowEdit = false;
            this.colTotalQuantity.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalQuantity.Visible = true;
            this.colTotalQuantity.VisibleIndex = 3;
            // 
            // FrmSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 581);
            this.Controls.Add(this.gcSummary);
            this.Name = "FrmSummary";
            this.Text = "库存汇总";
            this.Load += new System.EventHandler(this.FrmInStockDatailInfo_Load);
            this.Controls.SetChildIndex(this.gcSummary, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据导出ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip miniToolStrip;
        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTower;
        private DevExpress.XtraGrid.Columns.GridColumn colSubArea;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialType;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalQuantity;
    }
}