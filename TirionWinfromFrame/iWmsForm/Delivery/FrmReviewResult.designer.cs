
namespace iWms.Form
{
    partial class FrmReviewResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReviewResult));
            this.rowMergeDataGridView1 = new RowMergeDataGridView();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rowMergeDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rowMergeDataGridView1
            // 
            this.rowMergeDataGridView1.AllowUserToAddRows = false;
            this.rowMergeDataGridView1.AllowUserToDeleteRows = false;
            this.rowMergeDataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.rowMergeDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rowMergeDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rowMergeDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNo,
            this.LineNumber,
            this.PartNumber,
            this.NeedQty,
            this.UPN,
            this.Qty,
            this.TotalQty,
            this.Result,
            this.TowerDes,
            this.Remark,
            this.TowerNo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rowMergeDataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.rowMergeDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.rowMergeDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.rowMergeDataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rowMergeDataGridView1.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.rowMergeDataGridView1.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("rowMergeDataGridView1.MergeColumnNames")));
            this.rowMergeDataGridView1.MergeFocusNames = ((System.Collections.Generic.List<string>)(resources.GetObject("rowMergeDataGridView1.MergeFocusNames")));
            this.rowMergeDataGridView1.Name = "rowMergeDataGridView1";
            this.rowMergeDataGridView1.RowHeadersWidth = 25;
            this.rowMergeDataGridView1.RowTemplate.Height = 30;
            this.rowMergeDataGridView1.Size = new System.Drawing.Size(872, 368);
            this.rowMergeDataGridView1.TabIndex = 18;
            this.rowMergeDataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.rowMergeDataGridView1_RowPostPaint);
            this.rowMergeDataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.rowMergeDataGridView1_RowPrePaint);
            // 
            // OrderNo
            // 
            this.OrderNo.DataPropertyName = "OrderNo";
            this.OrderNo.HeaderText = "出库单号";
            this.OrderNo.MinimumWidth = 8;
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Visible = false;
            this.OrderNo.Width = 180;
            // 
            // LineNumber
            // 
            this.LineNumber.DataPropertyName = "LineNumber";
            this.LineNumber.HeaderText = "行号";
            this.LineNumber.MinimumWidth = 10;
            this.LineNumber.Name = "LineNumber";
            this.LineNumber.Width = 60;
            // 
            // PartNumber
            // 
            this.PartNumber.DataPropertyName = "PartNumber";
            this.PartNumber.HeaderText = "料号";
            this.PartNumber.MinimumWidth = 8;
            this.PartNumber.Name = "PartNumber";
            this.PartNumber.Width = 120;
            // 
            // NeedQty
            // 
            this.NeedQty.DataPropertyName = "NeedQty";
            this.NeedQty.HeaderText = "需求数量";
            this.NeedQty.MinimumWidth = 8;
            this.NeedQty.Name = "NeedQty";
            this.NeedQty.Width = 80;
            // 
            // UPN
            // 
            this.UPN.DataPropertyName = "UPN";
            this.UPN.HeaderText = "UPN";
            this.UPN.MinimumWidth = 8;
            this.UPN.Name = "UPN";
            this.UPN.Width = 200;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "出库数量";
            this.Qty.MinimumWidth = 8;
            this.Qty.Name = "Qty";
            this.Qty.Width = 80;
            // 
            // TotalQty
            // 
            this.TotalQty.DataPropertyName = "TotalQty";
            this.TotalQty.HeaderText = "合计";
            this.TotalQty.MinimumWidth = 8;
            this.TotalQty.Name = "TotalQty";
            this.TotalQty.Width = 150;
            // 
            // Result
            // 
            this.Result.DataPropertyName = "Result";
            this.Result.HeaderText = "结果";
            this.Result.MinimumWidth = 8;
            this.Result.Name = "Result";
            this.Result.Width = 120;
            // 
            // TowerDes
            // 
            this.TowerDes.DataPropertyName = "TowerDes";
            this.TowerDes.HeaderText = "库区";
            this.TowerDes.MinimumWidth = 8;
            this.TowerDes.Name = "TowerDes";
            this.TowerDes.Width = 150;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "描述";
            this.Remark.MinimumWidth = 8;
            this.Remark.Name = "Remark";
            this.Remark.Width = 150;
            // 
            // TowerNo
            // 
            this.TowerNo.DataPropertyName = "TowerNo";
            this.TowerNo.HeaderText = "TowerNo";
            this.TowerNo.MinimumWidth = 8;
            this.TowerNo.Name = "TowerNo";
            this.TowerNo.Visible = false;
            this.TowerNo.Width = 150;
            // 
            // FrmReviewResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 408);
            this.Controls.Add(this.rowMergeDataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmReviewResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "复核结果";
            ((System.ComponentModel.ISupportInitialize)(this.rowMergeDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private RowMergeDataGridView rowMergeDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn NeedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerNo;
    }
}