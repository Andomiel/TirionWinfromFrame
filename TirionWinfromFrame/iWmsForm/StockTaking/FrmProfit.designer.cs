
namespace iWms.Form
{
    partial class FrmProfit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProfit));
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpConditions = new System.Windows.Forms.TableLayoutPanel();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.btnProfit = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridViewRecord = new iWms.Form.RowMergeDataGridView();
            this.QRCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReelType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsdOverdue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Success = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSuccess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpConditions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Location = new System.Drawing.Point(1180, 33);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.tlpConditions.SetRowSpan(this.btnExport, 2);
            this.btnExport.Size = new System.Drawing.Size(136, 58);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(760, 33);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.tlpConditions.SetRowSpan(this.btnClear, 2);
            this.btnClear.Size = new System.Drawing.Size(136, 58);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 414F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.62745F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.37255F));
            this.tableLayoutPanel1.Controls.Add(this.tlpConditions, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 34, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1324, 731);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // tlpConditions
            // 
            this.tlpConditions.ColumnCount = 7;
            this.tableLayoutPanel1.SetColumnSpan(this.tlpConditions, 3);
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.Controls.Add(this.btnExecute, 4, 1);
            this.tlpConditions.Controls.Add(this.btnExport, 6, 1);
            this.tlpConditions.Controls.Add(this.btnClear, 3, 1);
            this.tlpConditions.Controls.Add(this.btnProfit, 5, 1);
            this.tlpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditions.Location = new System.Drawing.Point(3, 3);
            this.tlpConditions.Name = "tlpConditions";
            this.tlpConditions.RowCount = 4;
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.Size = new System.Drawing.Size(1318, 134);
            this.tlpConditions.TabIndex = 42;
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExecute.Location = new System.Drawing.Point(901, 34);
            this.btnExecute.Name = "btnExecute";
            this.tlpConditions.SetRowSpan(this.btnExecute, 2);
            this.btnExecute.Size = new System.Drawing.Size(134, 56);
            this.btnExecute.TabIndex = 45;
            this.btnExecute.Text = "筛选";
            this.btnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // btnProfit
            // 
            this.btnProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProfit.Location = new System.Drawing.Point(1041, 34);
            this.btnProfit.Name = "btnProfit";
            this.tlpConditions.SetRowSpan(this.btnProfit, 2);
            this.btnProfit.Size = new System.Drawing.Size(134, 56);
            this.btnProfit.TabIndex = 42;
            this.btnProfit.Text = "盘盈";
            this.btnProfit.Click += new System.EventHandler(this.BtnProfit_Click);
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.rtbText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 142);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1034, 291);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息录入";
            // 
            // rtbText
            // 
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.Location = new System.Drawing.Point(2, 17);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(1030, 272);
            this.rtbText.TabIndex = 0;
            this.rtbText.Text = "";
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 3);
            this.groupBox2.Controls.Add(this.gridViewRecord);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 437);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1320, 292);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "筛选结果";
            // 
            // gridViewRecord
            // 
            this.gridViewRecord.AllowUserToAddRows = false;
            this.gridViewRecord.AllowUserToDeleteRows = false;
            this.gridViewRecord.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridViewRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QRCode,
            this.UPN,
            this.PartNumber,
            this.Qty,
            this.colReelType,
            this.MSD,
            this.MsdOverdue,
            this.IsLock,
            this.Success,
            this.IsSuccess,
            this.Message});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewRecord.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewRecord.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridViewRecord.Location = new System.Drawing.Point(2, 17);
            this.gridViewRecord.Margin = new System.Windows.Forms.Padding(2);
            this.gridViewRecord.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gridViewRecord.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridViewRecord.MergeColumnNames")));
            this.gridViewRecord.MergeFocusNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridViewRecord.MergeFocusNames")));
            this.gridViewRecord.Name = "gridViewRecord";
            this.gridViewRecord.RowHeadersWidth = 25;
            this.gridViewRecord.RowTemplate.Height = 30;
            this.gridViewRecord.Size = new System.Drawing.Size(1316, 273);
            this.gridViewRecord.TabIndex = 25;
            // 
            // QRCode
            // 
            this.QRCode.DataPropertyName = "QRCode";
            this.QRCode.HeaderText = "二维码";
            this.QRCode.MinimumWidth = 10;
            this.QRCode.Name = "QRCode";
            this.QRCode.Width = 400;
            // 
            // UPN
            // 
            this.UPN.DataPropertyName = "UPN";
            this.UPN.HeaderText = "UPN";
            this.UPN.MinimumWidth = 8;
            this.UPN.Name = "UPN";
            this.UPN.Width = 160;
            // 
            // PartNumber
            // 
            this.PartNumber.DataPropertyName = "PartNumber";
            this.PartNumber.HeaderText = "物料代码";
            this.PartNumber.MinimumWidth = 10;
            this.PartNumber.Name = "PartNumber";
            this.PartNumber.Width = 120;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "数量";
            this.Qty.MinimumWidth = 8;
            this.Qty.Name = "Qty";
            this.Qty.Width = 60;
            // 
            // colReelType
            // 
            this.colReelType.DataPropertyName = "ReelTypeDisplay";
            this.colReelType.HeaderText = "料盘类型";
            this.colReelType.Name = "colReelType";
            // 
            // MSD
            // 
            this.MSD.DataPropertyName = "MSD";
            this.MSD.HeaderText = "MSD等级";
            this.MSD.MinimumWidth = 10;
            this.MSD.Name = "MSD";
            this.MSD.Width = 90;
            // 
            // MsdOverdue
            // 
            this.MsdOverdue.DataPropertyName = "MsdOverdue";
            this.MsdOverdue.HeaderText = "是否超期";
            this.MsdOverdue.MinimumWidth = 10;
            this.MsdOverdue.Name = "MsdOverdue";
            this.MsdOverdue.Width = 80;
            // 
            // IsLock
            // 
            this.IsLock.DataPropertyName = "IsLock";
            this.IsLock.HeaderText = "是否锁定";
            this.IsLock.MinimumWidth = 10;
            this.IsLock.Name = "IsLock";
            this.IsLock.Width = 80;
            // 
            // Success
            // 
            this.Success.DataPropertyName = "Success";
            this.Success.HeaderText = "结果";
            this.Success.MinimumWidth = 10;
            this.Success.Name = "Success";
            this.Success.Width = 80;
            // 
            // IsSuccess
            // 
            this.IsSuccess.DataPropertyName = "IsSuccess";
            this.IsSuccess.HeaderText = "IsSuccess";
            this.IsSuccess.MinimumWidth = 10;
            this.IsSuccess.Name = "IsSuccess";
            this.IsSuccess.Visible = false;
            this.IsSuccess.Width = 200;
            // 
            // Message
            // 
            this.Message.DataPropertyName = "Message";
            this.Message.HeaderText = "原因";
            this.Message.MinimumWidth = 10;
            this.Message.Name = "Message";
            this.Message.Width = 250;
            // 
            // FrmProfit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 731);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProfit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "盘盈";
            this.Load += new System.EventHandler(this.FrmReview_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpConditions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tlpConditions;
        private DevExpress.XtraEditors.SimpleButton btnProfit;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private System.Windows.Forms.RichTextBox rtbText;
        private RowMergeDataGridView gridViewRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn QRCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReelType;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MsdOverdue;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsLock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Success;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSuccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
    }
}