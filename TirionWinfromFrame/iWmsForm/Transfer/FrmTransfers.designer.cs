
namespace iWms.Form
{
    partial class FrmTransfers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.gbConditions = new System.Windows.Forms.GroupBox();
            this.tlpConditions = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOutstock = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tbOrderNo = new System.Windows.Forms.TextBox();
            this.cbOrderStatus = new System.Windows.Forms.ComboBox();
            this.tbMaterialNo = new System.Windows.Forms.TextBox();
            this.dtOrderTime = new System.Windows.Forms.DateTimePicker();
            this.dtFinishedTime = new System.Windows.Forms.DateTimePicker();
            this.tbUpn = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tlbTables = new System.Windows.Forms.TableLayoutPanel();
            this.dgvUpns = new System.Windows.Forms.DataGridView();
            this.colMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinishedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpLayout.SuspendLayout();
            this.gbConditions.SuspendLayout();
            this.tlpConditions.SuspendLayout();
            this.tlbTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 1;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.Controls.Add(this.gbConditions, 0, 0);
            this.tlpLayout.Controls.Add(this.tlbTables, 0, 1);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 34);
            this.tlpLayout.Margin = new System.Windows.Forms.Padding(3, 34, 3, 3);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 2;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpLayout.Size = new System.Drawing.Size(1203, 673);
            this.tlpLayout.TabIndex = 0;
            // 
            // gbConditions
            // 
            this.gbConditions.Controls.Add(this.tlpConditions);
            this.gbConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbConditions.Location = new System.Drawing.Point(3, 3);
            this.gbConditions.Name = "gbConditions";
            this.gbConditions.Size = new System.Drawing.Size(1197, 134);
            this.gbConditions.TabIndex = 0;
            this.gbConditions.TabStop = false;
            // 
            // tlpConditions
            // 
            this.tlpConditions.ColumnCount = 12;
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.Controls.Add(this.label8, 2, 2);
            this.tlpConditions.Controls.Add(this.label7, 0, 2);
            this.tlpConditions.Controls.Add(this.label6, 2, 1);
            this.tlpConditions.Controls.Add(this.label5, 2, 0);
            this.tlpConditions.Controls.Add(this.label4, 0, 1);
            this.tlpConditions.Controls.Add(this.label3, 4, 0);
            this.tlpConditions.Controls.Add(this.label1, 0, 0);
            this.tlpConditions.Controls.Add(this.btnOutstock, 9, 1);
            this.tlpConditions.Controls.Add(this.btnFinish, 9, 2);
            this.tlpConditions.Controls.Add(this.btnExport, 7, 2);
            this.tlpConditions.Controls.Add(this.tbOrderNo, 1, 0);
            this.tlpConditions.Controls.Add(this.cbOrderStatus, 5, 0);
            this.tlpConditions.Controls.Add(this.tbMaterialNo, 3, 0);
            this.tlpConditions.Controls.Add(this.dtOrderTime, 1, 2);
            this.tlpConditions.Controls.Add(this.dtFinishedTime, 3, 2);
            this.tlpConditions.Controls.Add(this.tbUpn, 1, 1);
            this.tlpConditions.Controls.Add(this.cbType, 3, 1);
            this.tlpConditions.Controls.Add(this.btnQuery, 7, 0);
            this.tlpConditions.Controls.Add(this.btnClear, 7, 1);
            this.tlpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditions.Location = new System.Drawing.Point(3, 18);
            this.tlpConditions.Name = "tlpConditions";
            this.tlpConditions.RowCount = 4;
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.Size = new System.Drawing.Size(1191, 113);
            this.tlpConditions.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(236, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 35);
            this.label8.TabIndex = 7;
            this.label8.Text = "完成日期";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 35);
            this.label7.TabIndex = 6;
            this.label7.Text = "创建日期";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(236, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 35);
            this.label6.TabIndex = 5;
            this.label6.Text = "移库类型";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(236, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 35);
            this.label5.TabIndex = 4;
            this.label5.Text = "物料代码";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 35);
            this.label4.TabIndex = 3;
            this.label4.Text = "UPN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(469, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "单据状态";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "移库单号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOutstock
            // 
            this.btnOutstock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOutstock.Location = new System.Drawing.Point(935, 38);
            this.btnOutstock.Name = "btnOutstock";
            this.btnOutstock.Size = new System.Drawing.Size(87, 29);
            this.btnOutstock.TabIndex = 9;
            this.btnOutstock.Text = "执行移库";
            this.btnOutstock.UseVisualStyleBackColor = true;
            this.btnOutstock.Click += new System.EventHandler(this.BtnTransfer_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinish.Location = new System.Drawing.Point(935, 73);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(87, 29);
            this.btnFinish.TabIndex = 12;
            this.btnFinish.Text = "移库完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Location = new System.Drawing.Point(749, 73);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(87, 29);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "导出明细";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // tbOrderNo
            // 
            this.tbOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOrderNo.Location = new System.Drawing.Point(96, 3);
            this.tbOrderNo.Name = "tbOrderNo";
            this.tbOrderNo.Size = new System.Drawing.Size(134, 22);
            this.tbOrderNo.TabIndex = 14;
            // 
            // cbOrderStatus
            // 
            this.cbOrderStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbOrderStatus.FormattingEnabled = true;
            this.cbOrderStatus.Location = new System.Drawing.Point(562, 3);
            this.cbOrderStatus.Name = "cbOrderStatus";
            this.cbOrderStatus.Size = new System.Drawing.Size(134, 22);
            this.cbOrderStatus.TabIndex = 16;
            // 
            // tbMaterialNo
            // 
            this.tbMaterialNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMaterialNo.Location = new System.Drawing.Point(329, 3);
            this.tbMaterialNo.Name = "tbMaterialNo";
            this.tbMaterialNo.Size = new System.Drawing.Size(134, 22);
            this.tbMaterialNo.TabIndex = 18;
            // 
            // dtOrderTime
            // 
            this.dtOrderTime.CustomFormat = "yyyy-MM-dd";
            this.dtOrderTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtOrderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOrderTime.Location = new System.Drawing.Point(96, 73);
            this.dtOrderTime.Name = "dtOrderTime";
            this.dtOrderTime.Size = new System.Drawing.Size(134, 22);
            this.dtOrderTime.TabIndex = 20;
            this.dtOrderTime.Value = new System.DateTime(2022, 2, 22, 12, 4, 52, 0);
            // 
            // dtFinishedTime
            // 
            this.dtFinishedTime.CustomFormat = "yyyy-MM-dd";
            this.dtFinishedTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFinishedTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinishedTime.Location = new System.Drawing.Point(329, 73);
            this.dtFinishedTime.Name = "dtFinishedTime";
            this.dtFinishedTime.Size = new System.Drawing.Size(134, 22);
            this.dtFinishedTime.TabIndex = 21;
            this.dtFinishedTime.Value = new System.DateTime(2022, 2, 22, 0, 0, 0, 0);
            // 
            // tbUpn
            // 
            this.tbUpn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUpn.Location = new System.Drawing.Point(96, 38);
            this.tbUpn.Name = "tbUpn";
            this.tbUpn.Size = new System.Drawing.Size(134, 22);
            this.tbUpn.TabIndex = 23;
            // 
            // cbType
            // 
            this.cbType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(329, 38);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(134, 22);
            this.cbType.TabIndex = 25;
            // 
            // btnQuery
            // 
            this.btnQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuery.Location = new System.Drawing.Point(749, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(87, 29);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(749, 38);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 29);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tlbTables
            // 
            this.tlbTables.ColumnCount = 2;
            this.tlbTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tlbTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tlbTables.Controls.Add(this.dgvUpns, 1, 0);
            this.tlbTables.Controls.Add(this.dgvOrders, 0, 0);
            this.tlbTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlbTables.Location = new System.Drawing.Point(3, 143);
            this.tlbTables.Name = "tlbTables";
            this.tlbTables.RowCount = 1;
            this.tlbTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlbTables.Size = new System.Drawing.Size(1197, 527);
            this.tlbTables.TabIndex = 3;
            // 
            // dgvUpns
            // 
            this.dgvUpns.AllowUserToAddRows = false;
            this.dgvUpns.AllowUserToDeleteRows = false;
            this.dgvUpns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpns.ColumnHeadersHeight = 20;
            this.dgvUpns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUpns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaterialNo,
            this.colUpn,
            this.colQty});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUpns.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUpns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUpns.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvUpns.Location = new System.Drawing.Point(745, 3);
            this.dgvUpns.MultiSelect = false;
            this.dgvUpns.Name = "dgvUpns";
            this.dgvUpns.ReadOnly = true;
            this.dgvUpns.RowHeadersWidth = 40;
            this.dgvUpns.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUpns.RowTemplate.Height = 23;
            this.dgvUpns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUpns.Size = new System.Drawing.Size(449, 521);
            this.dgvUpns.TabIndex = 2;
            this.dgvUpns.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dgv_DataBindingComplete);
            // 
            // colMaterialNo
            // 
            this.colMaterialNo.DataPropertyName = "MaterialNo";
            this.colMaterialNo.HeaderText = "物料代码";
            this.colMaterialNo.MinimumWidth = 9;
            this.colMaterialNo.Name = "colMaterialNo";
            this.colMaterialNo.ReadOnly = true;
            // 
            // colUpn
            // 
            this.colUpn.DataPropertyName = "Barcode";
            this.colUpn.HeaderText = "UPN";
            this.colUpn.MinimumWidth = 9;
            this.colUpn.Name = "colUpn";
            this.colUpn.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            this.colQty.HeaderText = "盘内数量";
            this.colQty.MinimumWidth = 9;
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeight = 20;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNo,
            this.colOrderStatus,
            this.colSource,
            this.colDestination,
            this.colOrderTime,
            this.colFinishedTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvOrders.Location = new System.Drawing.Point(3, 3);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 40;
            this.dgvOrders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOrders.RowTemplate.Height = 23;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOrders.Size = new System.Drawing.Size(736, 521);
            this.dgvOrders.TabIndex = 1;
            this.dgvOrders.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dgv_DataBindingComplete);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // colOrderNo
            // 
            this.colOrderNo.DataPropertyName = "TransferNo";
            this.colOrderNo.FillWeight = 57.44501F;
            this.colOrderNo.HeaderText = "移库单号";
            this.colOrderNo.MinimumWidth = 9;
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.ReadOnly = true;
            // 
            // colOrderStatus
            // 
            this.colOrderStatus.DataPropertyName = "OrderStatusDisplay";
            this.colOrderStatus.FillWeight = 57.44501F;
            this.colOrderStatus.HeaderText = "单据状态";
            this.colOrderStatus.MinimumWidth = 9;
            this.colOrderStatus.Name = "colOrderStatus";
            this.colOrderStatus.ReadOnly = true;
            // 
            // colSource
            // 
            this.colSource.DataPropertyName = "SourceAreaDisplay";
            this.colSource.FillWeight = 57.44501F;
            this.colSource.HeaderText = "来源库区";
            this.colSource.MinimumWidth = 9;
            this.colSource.Name = "colSource";
            this.colSource.ReadOnly = true;
            // 
            // colDestination
            // 
            this.colDestination.DataPropertyName = "TargetAreaDisplay";
            this.colDestination.FillWeight = 56F;
            this.colDestination.HeaderText = "目的库区";
            this.colDestination.MinimumWidth = 9;
            this.colDestination.Name = "colDestination";
            this.colDestination.ReadOnly = true;
            // 
            // colOrderTime
            // 
            this.colOrderTime.DataPropertyName = "CreateTime";
            this.colOrderTime.FillWeight = 57.44501F;
            this.colOrderTime.HeaderText = "创建时间";
            this.colOrderTime.MinimumWidth = 9;
            this.colOrderTime.Name = "colOrderTime";
            this.colOrderTime.ReadOnly = true;
            // 
            // colFinishedTime
            // 
            this.colFinishedTime.DataPropertyName = "LastUpdateTime";
            this.colFinishedTime.FillWeight = 57.44501F;
            this.colFinishedTime.HeaderText = "完成时间";
            this.colFinishedTime.MinimumWidth = 9;
            this.colFinishedTime.Name = "colFinishedTime";
            this.colFinishedTime.ReadOnly = true;
            // 
            // FrmTransfers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 707);
            this.Controls.Add(this.tlpLayout);
            this.Name = "FrmTransfers";
            this.Text = "移库单列表";
            this.Load += new System.EventHandler(this.FrmOutstocks_Load);
            this.Controls.SetChildIndex(this.tlpLayout, 0);
            this.tlpLayout.ResumeLayout(false);
            this.gbConditions.ResumeLayout(false);
            this.tlpConditions.ResumeLayout(false);
            this.tlpConditions.PerformLayout();
            this.tlbTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.GroupBox gbConditions;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.TableLayoutPanel tlpConditions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOutstock;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox tbOrderNo;
        private System.Windows.Forms.ComboBox cbOrderStatus;
        private System.Windows.Forms.TextBox tbMaterialNo;
        private System.Windows.Forms.DateTimePicker dtOrderTime;
        private System.Windows.Forms.DateTimePicker dtFinishedTime;
        private System.Windows.Forms.DataGridView dgvUpns;
        private System.Windows.Forms.TextBox tbUpn;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TableLayoutPanel tlbTables;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinishedTime;
    }
}