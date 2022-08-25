
namespace iWms.Form
{
    partial class FrmInventory
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gridInventory = new System.Windows.Forms.DataGridView();
            this.WAREHOUSE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOT02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOT03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATERIAL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IWMS_QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.txtPartNumber);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1334, 31);
            this.panel1.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1090, 5);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(74, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(938, 5);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(74, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "开始比对";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "物料代码：";
            this.label1.Visible = false;
            // 
            // gridInventory
            // 
            this.gridInventory.AllowUserToAddRows = false;
            this.gridInventory.AllowUserToDeleteRows = false;
            this.gridInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridInventory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WAREHOUSE_ID,
            this.LOT02,
            this.LOT03,
            this.SKU,
            this.MATERIAL_NAME,
            this.QTY,
            this.IWMS_QTY,
            this.Difference,
            this.Unit});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridInventory.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInventory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridInventory.Location = new System.Drawing.Point(0, 31);
            this.gridInventory.Name = "gridInventory";
            this.gridInventory.ReadOnly = true;
            this.gridInventory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.gridInventory.RowTemplate.Height = 23;
            this.gridInventory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridInventory.Size = new System.Drawing.Size(1334, 684);
            this.gridInventory.TabIndex = 10;
            // 
            // WAREHOUSE_ID
            // 
            this.WAREHOUSE_ID.DataPropertyName = "WAREHOUSE_ID";
            this.WAREHOUSE_ID.HeaderText = "仓库号";
            this.WAREHOUSE_ID.MinimumWidth = 10;
            this.WAREHOUSE_ID.Name = "WAREHOUSE_ID";
            this.WAREHOUSE_ID.ReadOnly = true;
            // 
            // LOT02
            // 
            this.LOT02.DataPropertyName = "LOT02";
            this.LOT02.HeaderText = "库存组织";
            this.LOT02.MinimumWidth = 10;
            this.LOT02.Name = "LOT02";
            this.LOT02.ReadOnly = true;
            // 
            // LOT03
            // 
            this.LOT03.DataPropertyName = "LOT03";
            this.LOT03.HeaderText = "状态";
            this.LOT03.MinimumWidth = 10;
            this.LOT03.Name = "LOT03";
            this.LOT03.ReadOnly = true;
            // 
            // SKU
            // 
            this.SKU.DataPropertyName = "SKU";
            this.SKU.HeaderText = "物料代码";
            this.SKU.MinimumWidth = 10;
            this.SKU.Name = "SKU";
            this.SKU.ReadOnly = true;
            // 
            // MATERIAL_NAME
            // 
            this.MATERIAL_NAME.DataPropertyName = "MATERIAL_NAME";
            this.MATERIAL_NAME.HeaderText = "物料名称";
            this.MATERIAL_NAME.MinimumWidth = 10;
            this.MATERIAL_NAME.Name = "MATERIAL_NAME";
            this.MATERIAL_NAME.ReadOnly = true;
            // 
            // QTY
            // 
            this.QTY.DataPropertyName = "QTY";
            this.QTY.HeaderText = "WMS数量";
            this.QTY.MinimumWidth = 10;
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            // 
            // IWMS_QTY
            // 
            this.IWMS_QTY.DataPropertyName = "IWMS_QTY";
            this.IWMS_QTY.HeaderText = "IWMS数量";
            this.IWMS_QTY.MinimumWidth = 10;
            this.IWMS_QTY.Name = "IWMS_QTY";
            this.IWMS_QTY.ReadOnly = true;
            // 
            // Difference
            // 
            this.Difference.DataPropertyName = "Difference";
            this.Difference.HeaderText = "差异";
            this.Difference.MinimumWidth = 10;
            this.Difference.Name = "Difference";
            this.Difference.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "单位";
            this.Unit.MinimumWidth = 10;
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Unit.Visible = false;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Location = new System.Drawing.Point(87, 7);
            this.txtPartNumber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(202, 22);
            this.txtPartNumber.TabIndex = 1;
            this.txtPartNumber.Visible = false;
            // 
            // FrmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1334, 715);
            this.Controls.Add(this.gridInventory);
            this.Controls.Add(this.panel1);
            this.Name = "FrmInventory";
            this.Load += new System.EventHandler(this.FrmInventory_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gridInventory, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridInventory;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAREHOUSE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT02;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOT03;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATERIAL_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn IWMS_QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Difference;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.TextBox txtPartNumber;
    }
}
