﻿
namespace iWms.Form
{
    partial class FrmReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReview));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpConditions = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOrderNo = new System.Windows.Forms.ComboBox();
            this.lblOrderOrder = new System.Windows.Forms.Label();
            this.cbOrderType = new System.Windows.Forms.ComboBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbBoxScan = new System.Windows.Forms.CheckBox();
            this.txtBoxScan = new System.Windows.Forms.TextBox();
            this.lblScan = new System.Windows.Forms.Label();
            this.tbScan = new System.Windows.Forms.TextBox();
            this.cbOriginal = new System.Windows.Forms.CheckBox();
            this.tbOriginal = new System.Windows.Forms.TextBox();
            this.btnAlarm = new System.Windows.Forms.Button();
            this.btnNotify = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridViewRecord = new RowMergeDataGridView();
            this.rUPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridViewSummary = new RowMergeDataGridView();
            this.LineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllocateQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Match = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QRCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbAlert = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblWarningTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpConditions.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecord)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSummary)).BeginInit();
            this.gbAlert.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnComplete
            // 
            this.btnComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnComplete.Enabled = false;
            this.btnComplete.Location = new System.Drawing.Point(925, 29);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(2);
            this.btnComplete.Name = "btnComplete";
            this.tlpConditions.SetRowSpan(this.btnComplete, 3);
            this.btnComplete.Size = new System.Drawing.Size(116, 77);
            this.btnComplete.TabIndex = 10;
            this.btnComplete.Text = "完成";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.BtnComplete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(685, 29);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.tlpConditions.SetRowSpan(this.btnCancel, 3);
            this.btnCancel.Size = new System.Drawing.Size(116, 77);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(565, 29);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.tlpConditions.SetRowSpan(this.btnExport, 3);
            this.btnExport.Size = new System.Drawing.Size(116, 77);
            this.btnExport.TabIndex = 27;
            this.btnExport.Text = "复核汇总导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 355F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.62745F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.37255F));
            this.tableLayoutPanel1.Controls.Add(this.tlpConditions, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gbAlert, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1049, 606);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // tlpConditions
            // 
            this.tlpConditions.ColumnCount = 7;
            this.tableLayoutPanel1.SetColumnSpan(this.tlpConditions, 3);
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpConditions.Controls.Add(this.btnComplete, 6, 1);
            this.tlpConditions.Controls.Add(this.label1, 0, 0);
            this.tlpConditions.Controls.Add(this.btnCancel, 4, 1);
            this.tlpConditions.Controls.Add(this.cbOrderNo, 1, 1);
            this.tlpConditions.Controls.Add(this.lblOrderOrder, 0, 1);
            this.tlpConditions.Controls.Add(this.cbOrderType, 1, 0);
            this.tlpConditions.Controls.Add(this.lblDestination, 2, 1);
            this.tlpConditions.Controls.Add(this.btnExport, 3, 1);
            this.tlpConditions.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tlpConditions.Controls.Add(this.btnAlarm, 5, 4);
            this.tlpConditions.Controls.Add(this.btnNotify, 5, 1);
            this.tlpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditions.Location = new System.Drawing.Point(3, 3);
            this.tlpConditions.Name = "tlpConditions";
            this.tlpConditions.RowCount = 6;
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.Size = new System.Drawing.Size(1043, 134);
            this.tlpConditions.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 6, 0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "单据类型";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbOrderNo
            // 
            this.cbOrderNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbOrderNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrderNo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbOrderNo.FormattingEnabled = true;
            this.cbOrderNo.Location = new System.Drawing.Point(103, 30);
            this.cbOrderNo.Name = "cbOrderNo";
            this.cbOrderNo.Size = new System.Drawing.Size(170, 20);
            this.cbOrderNo.TabIndex = 11;
            this.cbOrderNo.SelectionChangeCommitted += new System.EventHandler(this.CbOrderNo_SelectionChangeCommitted);
            // 
            // lblOrderOrder
            // 
            this.lblOrderOrder.AutoSize = true;
            this.lblOrderOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderOrder.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOrderOrder.Location = new System.Drawing.Point(4, 33);
            this.lblOrderOrder.Margin = new System.Windows.Forms.Padding(4, 6, 0, 4);
            this.lblOrderOrder.Name = "lblOrderOrder";
            this.lblOrderOrder.Size = new System.Drawing.Size(96, 17);
            this.lblOrderOrder.TabIndex = 12;
            this.lblOrderOrder.Text = "出库单号";
            this.lblOrderOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbOrderType
            // 
            this.cbOrderType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbOrderType.FormattingEnabled = true;
            this.cbOrderType.Location = new System.Drawing.Point(103, 3);
            this.cbOrderType.Name = "cbOrderType";
            this.cbOrderType.Size = new System.Drawing.Size(170, 20);
            this.cbOrderType.TabIndex = 38;
            this.cbOrderType.SelectedValueChanged += new System.EventHandler(this.cbOrderType_SelectedValueChanged);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDestination.Location = new System.Drawing.Point(403, 27);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(157, 27);
            this.lblDestination.TabIndex = 39;
            this.lblDestination.Text = "目的地";
            this.lblDestination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.tlpConditions.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.cbBoxScan);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxScan);
            this.flowLayoutPanel1.Controls.Add(this.lblScan);
            this.flowLayoutPanel1.Controls.Add(this.tbScan);
            this.flowLayoutPanel1.Controls.Add(this.cbOriginal);
            this.flowLayoutPanel1.Controls.Add(this.tbOriginal);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.tlpConditions.SetRowSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(400, 81);
            this.flowLayoutPanel1.TabIndex = 40;
            // 
            // cbBoxScan
            // 
            this.cbBoxScan.AutoSize = true;
            this.cbBoxScan.Location = new System.Drawing.Point(48, 6);
            this.cbBoxScan.Margin = new System.Windows.Forms.Padding(48, 6, 0, 4);
            this.cbBoxScan.Name = "cbBoxScan";
            this.cbBoxScan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbBoxScan.Size = new System.Drawing.Size(48, 16);
            this.cbBoxScan.TabIndex = 35;
            this.cbBoxScan.Text = "箱号";
            this.cbBoxScan.UseVisualStyleBackColor = true;
            this.cbBoxScan.CheckedChanged += new System.EventHandler(this.cbBoxScan_CheckedChanged);
            // 
            // txtBoxScan
            // 
            this.txtBoxScan.Enabled = false;
            this.txtBoxScan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxScan.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txtBoxScan.Location = new System.Drawing.Point(99, 3);
            this.txtBoxScan.Name = "txtBoxScan";
            this.txtBoxScan.ShortcutsEnabled = false;
            this.txtBoxScan.Size = new System.Drawing.Size(279, 21);
            this.txtBoxScan.TabIndex = 30;
            this.txtBoxScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxScan_KeyPress);
            // 
            // lblScan
            // 
            this.lblScan.AutoSize = true;
            this.lblScan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScan.Location = new System.Drawing.Point(55, 33);
            this.lblScan.Margin = new System.Windows.Forms.Padding(55, 6, 0, 4);
            this.lblScan.Name = "lblScan";
            this.lblScan.Size = new System.Drawing.Size(41, 12);
            this.lblScan.TabIndex = 1;
            this.lblScan.Text = "二维码";
            this.lblScan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbScan
            // 
            this.tbScan.Enabled = false;
            this.tbScan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbScan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbScan.Location = new System.Drawing.Point(99, 30);
            this.tbScan.Name = "tbScan";
            this.tbScan.ShortcutsEnabled = false;
            this.tbScan.Size = new System.Drawing.Size(279, 21);
            this.tbScan.TabIndex = 0;
            this.tbScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbScan_KeyPress);
            // 
            // cbOriginal
            // 
            this.cbOriginal.AutoSize = true;
            this.cbOriginal.Location = new System.Drawing.Point(24, 60);
            this.cbOriginal.Margin = new System.Windows.Forms.Padding(24, 6, 0, 4);
            this.cbOriginal.Name = "cbOriginal";
            this.cbOriginal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbOriginal.Size = new System.Drawing.Size(72, 16);
            this.cbOriginal.TabIndex = 36;
            this.cbOriginal.Text = "原厂条码";
            this.cbOriginal.UseVisualStyleBackColor = true;
            this.cbOriginal.CheckedChanged += new System.EventHandler(this.cbOriginal_CheckedChanged);
            // 
            // tbOriginal
            // 
            this.tbOriginal.Enabled = false;
            this.tbOriginal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbOriginal.Location = new System.Drawing.Point(99, 57);
            this.tbOriginal.Name = "tbOriginal";
            this.tbOriginal.Size = new System.Drawing.Size(279, 21);
            this.tbOriginal.TabIndex = 32;
            this.tbOriginal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbOriginal_KeyPress);
            // 
            // btnAlarm
            // 
            this.btnAlarm.Location = new System.Drawing.Point(806, 111);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(75, 21);
            this.btnAlarm.TabIndex = 41;
            this.btnAlarm.Text = "button1";
            this.btnAlarm.UseVisualStyleBackColor = true;
            this.btnAlarm.Visible = false;
            this.btnAlarm.Click += new System.EventHandler(this.btnAlarm_Click);
            // 
            // btnNotify
            // 
            this.btnNotify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNotify.Enabled = false;
            this.btnNotify.Location = new System.Drawing.Point(806, 30);
            this.btnNotify.Name = "btnNotify";
            this.tlpConditions.SetRowSpan(this.btnNotify, 3);
            this.btnNotify.Size = new System.Drawing.Size(114, 75);
            this.btnNotify.TabIndex = 42;
            this.btnNotify.Text = "反馈MES/WMS";
            this.btnNotify.UseVisualStyleBackColor = true;
            this.btnNotify.Click += new System.EventHandler(this.btnNotify_Click);
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.gridViewRecord);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 142);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(827, 229);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "扫描记录";
            // 
            // gridViewRecord
            // 
            this.gridViewRecord.AllowUserToAddRows = false;
            this.gridViewRecord.AllowUserToDeleteRows = false;
            this.gridViewRecord.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridViewRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rUPN,
            this.BoxNo,
            this.OriginalCode,
            this.rQty,
            this.rStatus,
            this.Barcode});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewRecord.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewRecord.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridViewRecord.Location = new System.Drawing.Point(2, 16);
            this.gridViewRecord.Margin = new System.Windows.Forms.Padding(2);
            this.gridViewRecord.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gridViewRecord.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridViewRecord.MergeColumnNames")));
            this.gridViewRecord.MergeFocusNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridViewRecord.MergeFocusNames")));
            this.gridViewRecord.Name = "gridViewRecord";
            this.gridViewRecord.RowHeadersWidth = 25;
            this.gridViewRecord.RowTemplate.Height = 30;
            this.gridViewRecord.Size = new System.Drawing.Size(823, 211);
            this.gridViewRecord.TabIndex = 22;
            this.gridViewRecord.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gridViewRecord_RowPrePaint);
            // 
            // rUPN
            // 
            this.rUPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rUPN.DataPropertyName = "UPN";
            this.rUPN.HeaderText = "UPN";
            this.rUPN.MinimumWidth = 190;
            this.rUPN.Name = "rUPN";
            // 
            // BoxNo
            // 
            this.BoxNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BoxNo.DataPropertyName = "BoxNo";
            this.BoxNo.HeaderText = "箱码";
            this.BoxNo.MinimumWidth = 110;
            this.BoxNo.Name = "BoxNo";
            this.BoxNo.Width = 130;
            // 
            // OriginalCode
            // 
            this.OriginalCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OriginalCode.DataPropertyName = "OriginalCode";
            this.OriginalCode.HeaderText = "原厂条码";
            this.OriginalCode.MinimumWidth = 110;
            this.OriginalCode.Name = "OriginalCode";
            // 
            // rQty
            // 
            this.rQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.rQty.DataPropertyName = "Qty";
            this.rQty.HeaderText = "数量";
            this.rQty.MinimumWidth = 60;
            this.rQty.Name = "rQty";
            this.rQty.Width = 80;
            // 
            // rStatus
            // 
            this.rStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rStatus.DataPropertyName = "Status";
            this.rStatus.HeaderText = "状态";
            this.rStatus.MinimumWidth = 200;
            this.rStatus.Name = "rStatus";
            // 
            // Barcode
            // 
            this.Barcode.DataPropertyName = "Barcode";
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.MinimumWidth = 10;
            this.Barcode.Name = "Barcode";
            this.Barcode.Visible = false;
            this.Barcode.Width = 200;
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 3);
            this.groupBox2.Controls.Add(this.gridViewSummary);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 375);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1045, 229);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "复核汇总";
            // 
            // gridViewSummary
            // 
            this.gridViewSummary.AllowUserToAddRows = false;
            this.gridViewSummary.AllowUserToDeleteRows = false;
            this.gridViewSummary.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridViewSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNumber,
            this.PartNumber,
            this.NeedQty,
            this.UPN,
            this.AllocateQty,
            this.MatchDes,
            this.Match,
            this.RealQty,
            this.SourceDes,
            this.TowerDes,
            this.QRCode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewSummary.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewSummary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridViewSummary.Location = new System.Drawing.Point(2, 16);
            this.gridViewSummary.Margin = new System.Windows.Forms.Padding(2);
            this.gridViewSummary.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.gridViewSummary.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridViewSummary.MergeColumnNames")));
            this.gridViewSummary.MergeFocusNames = ((System.Collections.Generic.List<string>)(resources.GetObject("gridViewSummary.MergeFocusNames")));
            this.gridViewSummary.Name = "gridViewSummary";
            this.gridViewSummary.ReadOnly = true;
            this.gridViewSummary.RowHeadersWidth = 25;
            this.gridViewSummary.RowTemplate.Height = 30;
            this.gridViewSummary.Size = new System.Drawing.Size(1041, 211);
            this.gridViewSummary.TabIndex = 23;
            this.gridViewSummary.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gridViewSummary_RowPrePaint);
            // 
            // LineNumber
            // 
            this.LineNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LineNumber.DataPropertyName = "LineNumber";
            this.LineNumber.HeaderText = "行号";
            this.LineNumber.MinimumWidth = 60;
            this.LineNumber.Name = "LineNumber";
            this.LineNumber.ReadOnly = true;
            this.LineNumber.Width = 60;
            // 
            // PartNumber
            // 
            this.PartNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PartNumber.DataPropertyName = "PartNumber";
            this.PartNumber.HeaderText = "物料代码";
            this.PartNumber.MinimumWidth = 150;
            this.PartNumber.Name = "PartNumber";
            this.PartNumber.ReadOnly = true;
            // 
            // NeedQty
            // 
            this.NeedQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NeedQty.DataPropertyName = "NeedQty";
            this.NeedQty.HeaderText = "需求数量";
            this.NeedQty.MinimumWidth = 110;
            this.NeedQty.Name = "NeedQty";
            this.NeedQty.ReadOnly = true;
            this.NeedQty.Width = 110;
            // 
            // UPN
            // 
            this.UPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UPN.DataPropertyName = "UPN";
            this.UPN.HeaderText = "UPN";
            this.UPN.MinimumWidth = 200;
            this.UPN.Name = "UPN";
            this.UPN.ReadOnly = true;
            // 
            // AllocateQty
            // 
            this.AllocateQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AllocateQty.DataPropertyName = "AllocateQty";
            this.AllocateQty.HeaderText = "待分配数量";
            this.AllocateQty.MinimumWidth = 150;
            this.AllocateQty.Name = "AllocateQty";
            this.AllocateQty.ReadOnly = true;
            this.AllocateQty.Width = 150;
            // 
            // MatchDes
            // 
            this.MatchDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MatchDes.DataPropertyName = "MatchDes";
            this.MatchDes.HeaderText = "是否已复核";
            this.MatchDes.MinimumWidth = 150;
            this.MatchDes.Name = "MatchDes";
            this.MatchDes.ReadOnly = true;
            this.MatchDes.Width = 150;
            // 
            // Match
            // 
            this.Match.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Match.DataPropertyName = "Match";
            this.Match.HeaderText = "Match";
            this.Match.MinimumWidth = 8;
            this.Match.Name = "Match";
            this.Match.ReadOnly = true;
            this.Match.Visible = false;
            this.Match.Width = 8;
            // 
            // RealQty
            // 
            this.RealQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RealQty.DataPropertyName = "RealQty";
            this.RealQty.HeaderText = "实出数量";
            this.RealQty.MinimumWidth = 150;
            this.RealQty.Name = "RealQty";
            this.RealQty.ReadOnly = true;
            this.RealQty.Width = 150;
            // 
            // SourceDes
            // 
            this.SourceDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SourceDes.DataPropertyName = "SourceDes";
            this.SourceDes.HeaderText = "备注";
            this.SourceDes.MinimumWidth = 120;
            this.SourceDes.Name = "SourceDes";
            this.SourceDes.ReadOnly = true;
            // 
            // TowerDes
            // 
            this.TowerDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TowerDes.DataPropertyName = "TowerDes";
            this.TowerDes.HeaderText = "库区";
            this.TowerDes.MinimumWidth = 150;
            this.TowerDes.Name = "TowerDes";
            this.TowerDes.ReadOnly = true;
            this.TowerDes.Visible = false;
            this.TowerDes.Width = 150;
            // 
            // QRCode
            // 
            this.QRCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QRCode.DataPropertyName = "QRCode";
            this.QRCode.HeaderText = "二维码";
            this.QRCode.MinimumWidth = 200;
            this.QRCode.Name = "QRCode";
            this.QRCode.ReadOnly = true;
            // 
            // gbAlert
            // 
            this.gbAlert.Controls.Add(this.panel2);
            this.gbAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAlert.Location = new System.Drawing.Point(833, 142);
            this.gbAlert.Margin = new System.Windows.Forms.Padding(2);
            this.gbAlert.Name = "gbAlert";
            this.gbAlert.Padding = new System.Windows.Forms.Padding(2);
            this.gbAlert.Size = new System.Drawing.Size(214, 229);
            this.gbAlert.TabIndex = 40;
            this.gbAlert.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblWarning);
            this.panel2.Controls.Add(this.lblWarningTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 16);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 211);
            this.panel2.TabIndex = 39;
            // 
            // lblWarning
            // 
            this.lblWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWarning.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWarning.ForeColor = System.Drawing.Color.White;
            this.lblWarning.Location = new System.Drawing.Point(16, 31);
            this.lblWarning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(212, 108);
            this.lblWarning.TabIndex = 24;
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWarning.Visible = false;
            // 
            // lblWarningTitle
            // 
            this.lblWarningTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWarningTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWarningTitle.ForeColor = System.Drawing.Color.White;
            this.lblWarningTitle.Location = new System.Drawing.Point(16, 7);
            this.lblWarningTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWarningTitle.Name = "lblWarningTitle";
            this.lblWarningTitle.Size = new System.Drawing.Size(212, 26);
            this.lblWarningTitle.TabIndex = 25;
            this.lblWarningTitle.Text = "警告";
            this.lblWarningTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWarningTitle.Visible = false;
            // 
            // FrmReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 606);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmReview";
            this.Text = "出库复核";
            this.Load += new System.EventHandler(this.FrmReview_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpConditions.ResumeLayout(false);
            this.tlpConditions.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRecord)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSummary)).EndInit();
            this.gbAlert.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnComplete;
        private RowMergeDataGridView gridViewSummary;
        private RowMergeDataGridView gridViewRecord;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rUPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn rQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn rStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.GroupBox gbAlert;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblWarningTitle;
        private System.Windows.Forms.TableLayoutPanel tlpConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOriginal;
        private System.Windows.Forms.CheckBox cbOriginal;
        private System.Windows.Forms.TextBox tbScan;
        private System.Windows.Forms.Label lblScan;
        private System.Windows.Forms.TextBox txtBoxScan;
        private System.Windows.Forms.CheckBox cbBoxScan;
        private System.Windows.Forms.ComboBox cbOrderNo;
        private System.Windows.Forms.Label lblOrderOrder;
        private System.Windows.Forms.ComboBox cbOrderType;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn NeedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllocateQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Match;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn QRCode;
        private System.Windows.Forms.Button btnAlarm;
        private System.Windows.Forms.Button btnNotify;
    }
}