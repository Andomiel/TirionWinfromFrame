namespace iWms.Form
{
    partial class FrmManualCounting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManualCounting));
            this.lblScan = new System.Windows.Forms.Label();
            this.tbScan = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtMaterialInfo = new System.Windows.Forms.TextBox();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.cbIsTypeT = new System.Windows.Forms.CheckBox();
            this.lblTypeT = new System.Windows.Forms.Label();
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.gbRecord = new System.Windows.Forms.GroupBox();
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
            this.panelData = new System.Windows.Forms.Panel();
            this.tlpLayout.SuspendLayout();
            this.gbRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecord)).BeginInit();
            this.panelData.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblScan
            // 
            this.lblScan.AutoSize = true;
            this.lblScan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScan.Location = new System.Drawing.Point(26, 34);
            this.lblScan.Margin = new System.Windows.Forms.Padding(5, 7, 0, 5);
            this.lblScan.Name = "lblScan";
            this.lblScan.Size = new System.Drawing.Size(41, 12);
            this.lblScan.TabIndex = 3;
            this.lblScan.Text = "二维码";
            // 
            // tbScan
            // 
            this.tbScan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbScan.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tbScan.Location = new System.Drawing.Point(85, 29);
            this.tbScan.Margin = new System.Windows.Forms.Padding(37, 3, 2, 3);
            this.tbScan.Name = "tbScan";
            this.tbScan.ShortcutsEnabled = false;
            this.tbScan.Size = new System.Drawing.Size(307, 21);
            this.tbScan.TabIndex = 2;
            this.tbScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbScan_KeyPress);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQty.Location = new System.Drawing.Point(40, 61);
            this.lblQty.Margin = new System.Windows.Forms.Padding(5, 7, 0, 5);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(29, 12);
            this.lblQty.TabIndex = 5;
            this.lblQty.Text = "数量";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(460, 34);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(113, 63);
            this.btnSubmit.TabIndex = 25;
            this.btnSubmit.Text = "点料";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // txtMaterialInfo
            // 
            this.txtMaterialInfo.Location = new System.Drawing.Point(839, 87);
            this.txtMaterialInfo.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaterialInfo.Name = "txtMaterialInfo";
            this.txtMaterialInfo.Size = new System.Drawing.Size(60, 22);
            this.txtMaterialInfo.TabIndex = 26;
            this.txtMaterialInfo.Visible = false;
            // 
            // tbQty
            // 
            this.tbQty.Location = new System.Drawing.Point(85, 59);
            this.tbQty.Margin = new System.Windows.Forms.Padding(2);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(95, 22);
            this.tbQty.TabIndex = 27;
            this.tbQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbQty_KeyPress);
            // 
            // cbIsTypeT
            // 
            this.cbIsTypeT.AutoSize = true;
            this.cbIsTypeT.Location = new System.Drawing.Point(85, 91);
            this.cbIsTypeT.Margin = new System.Windows.Forms.Padding(2);
            this.cbIsTypeT.Name = "cbIsTypeT";
            this.cbIsTypeT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbIsTypeT.Size = new System.Drawing.Size(15, 14);
            this.cbIsTypeT.TabIndex = 29;
            this.cbIsTypeT.UseVisualStyleBackColor = true;
            // 
            // lblTypeT
            // 
            this.lblTypeT.AutoSize = true;
            this.lblTypeT.Location = new System.Drawing.Point(12, 91);
            this.lblTypeT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTypeT.Name = "lblTypeT";
            this.lblTypeT.Size = new System.Drawing.Size(55, 14);
            this.lblTypeT.TabIndex = 28;
            this.lblTypeT.Text = "两节物料";
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 1;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpLayout.Controls.Add(this.gbRecord, 0, 1);
            this.tlpLayout.Controls.Add(this.panelData, 0, 0);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpLayout.Margin = new System.Windows.Forms.Padding(3, 34, 3, 3);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 2;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.Size = new System.Drawing.Size(1122, 610);
            this.tlpLayout.TabIndex = 30;
            // 
            // gbRecord
            // 
            this.gbRecord.Controls.Add(this.gridViewRecord);
            this.gbRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRecord.Location = new System.Drawing.Point(3, 143);
            this.gbRecord.Name = "gbRecord";
            this.gbRecord.Size = new System.Drawing.Size(1116, 464);
            this.gbRecord.TabIndex = 0;
            this.gbRecord.TabStop = false;
            this.gbRecord.Text = "点料记录";
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
            this.gridViewRecord.Location = new System.Drawing.Point(3, 18);
            this.gridViewRecord.Margin = new System.Windows.Forms.Padding(2);
            this.gridViewRecord.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gridViewRecord.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridViewRecord.MergeColumnNames")));
            this.gridViewRecord.MergeFocusNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridViewRecord.MergeFocusNames")));
            this.gridViewRecord.Name = "gridViewRecord";
            this.gridViewRecord.RowHeadersWidth = 25;
            this.gridViewRecord.RowTemplate.Height = 30;
            this.gridViewRecord.Size = new System.Drawing.Size(1110, 443);
            this.gridViewRecord.TabIndex = 24;
            this.gridViewRecord.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gridViewRecord_RowPostPaint);
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
            // panelData
            // 
            this.panelData.Controls.Add(this.btnSubmit);
            this.panelData.Controls.Add(this.cbIsTypeT);
            this.panelData.Controls.Add(this.tbScan);
            this.panelData.Controls.Add(this.lblTypeT);
            this.panelData.Controls.Add(this.lblScan);
            this.panelData.Controls.Add(this.tbQty);
            this.panelData.Controls.Add(this.lblQty);
            this.panelData.Controls.Add(this.txtMaterialInfo);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(3, 3);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1116, 134);
            this.panelData.TabIndex = 1;
            // 
            // FrmManualCounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 610);
            this.Controls.Add(this.tlpLayout);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmManualCounting";
            this.Text = "手动点料";
            this.Controls.SetChildIndex(this.tlpLayout, 0);
            this.tlpLayout.ResumeLayout(false);
            this.gbRecord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecord)).EndInit();
            this.panelData.ResumeLayout(false);
            this.panelData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblScan;
        private System.Windows.Forms.TextBox tbScan;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtMaterialInfo;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.CheckBox cbIsTypeT;
        private System.Windows.Forms.Label lblTypeT;
        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.GroupBox gbRecord;
        private RowMergeDataGridView gridViewRecord;
        private System.Windows.Forms.Panel panelData;
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