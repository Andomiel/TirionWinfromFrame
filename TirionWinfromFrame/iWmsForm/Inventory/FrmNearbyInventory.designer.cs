namespace iWms.Form
{
    partial class FrmNearbyInventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNearbyInventory));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.数据导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtReelid = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPn = new System.Windows.Forms.TextBox();
            this.button3 = new DevExpress.XtraEditors.SimpleButton();
            this.button2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lblShelfSide = new System.Windows.Forms.Label();
            this.cbShelfSide = new System.Windows.Forms.ComboBox();
            this.btnSync = new DevExpress.XtraEditors.SimpleButton();
            this.btnTrancate = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridViewX1 = new System.Windows.Forms.DataGridView();
            this.UPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.料号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturerDc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.库区 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ABSide = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.货位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入库时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tpsrecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tpscurrentPage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tpspageCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnFrist = new System.Windows.Forms.ToolStripSplitButton();
            this.btnPre = new System.Windows.Forms.ToolStripSplitButton();
            this.btnNext = new System.Windows.Forms.ToolStripSplitButton();
            this.BtnLast = new System.Windows.Forms.ToolStripSplitButton();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.tlpBottom.SuspendLayout();
            this.statusStrip2.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewX1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tlpBottom, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1365, 547);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 13;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtpStart, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtpEnd, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.button3, 8, 1);
            this.tableLayoutPanel2.Controls.Add(this.button2, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblShelfSide, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbShelfSide, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnSync, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTrancate, 9, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1361, 96);
            this.tableLayoutPanel2.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 40);
            this.label12.TabIndex = 31;
            this.label12.Text = "入库时间：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpStart
            // 
            this.dtpStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStart.Location = new System.Drawing.Point(83, 48);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(120, 22);
            this.dtpStart.TabIndex = 32;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(205, 40);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 40);
            this.label11.TabIndex = 34;
            this.label11.Text = "-";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEnd.Location = new System.Drawing.Point(222, 48);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(120, 22);
            this.dtpEnd.TabIndex = 33;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(345, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 40);
            this.label2.TabIndex = 7;
            this.label2.Text = "物料料号：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 40);
            this.label3.TabIndex = 9;
            this.label3.Text = "ReelId：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 3);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.txtReelid, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(85, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(255, 36);
            this.tableLayoutPanel3.TabIndex = 47;
            // 
            // txtReelid
            // 
            this.txtReelid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReelid.Location = new System.Drawing.Point(0, 8);
            this.txtReelid.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.txtReelid.Name = "txtReelid";
            this.txtReelid.Size = new System.Drawing.Size(255, 22);
            this.txtReelid.TabIndex = 10;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.txtPn, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(427, 2);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(116, 36);
            this.tableLayoutPanel4.TabIndex = 48;
            // 
            // txtPn
            // 
            this.txtPn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPn.Location = new System.Drawing.Point(0, 8);
            this.txtPn.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.txtPn.Name = "txtPn";
            this.txtPn.Size = new System.Drawing.Size(116, 22);
            this.txtPn.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(771, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 34);
            this.button3.TabIndex = 19;
            this.button3.Text = "导出";
            this.button3.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(631, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 34);
            this.button2.TabIndex = 14;
            this.button2.Text = "清空";
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(631, 43);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(134, 34);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // lblShelfSide
            // 
            this.lblShelfSide.AutoSize = true;
            this.lblShelfSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShelfSide.Location = new System.Drawing.Point(344, 40);
            this.lblShelfSide.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShelfSide.Name = "lblShelfSide";
            this.lblShelfSide.Size = new System.Drawing.Size(79, 40);
            this.lblShelfSide.TabIndex = 53;
            this.lblShelfSide.Text = "线边料架：";
            this.lblShelfSide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbShelfSide
            // 
            this.cbShelfSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShelfSide.FormattingEnabled = true;
            this.cbShelfSide.Location = new System.Drawing.Point(425, 48);
            this.cbShelfSide.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.cbShelfSide.Name = "cbShelfSide";
            this.cbShelfSide.Size = new System.Drawing.Size(120, 22);
            this.cbShelfSide.TabIndex = 54;
            // 
            // btnSync
            // 
            this.btnSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSync.Location = new System.Drawing.Point(831, 3);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(134, 34);
            this.btnSync.TabIndex = 55;
            this.btnSync.Text = "发料点亮";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnTrancate
            // 
            this.btnTrancate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTrancate.Location = new System.Drawing.Point(831, 43);
            this.btnTrancate.Name = "btnTrancate";
            this.btnTrancate.Size = new System.Drawing.Size(134, 34);
            this.btnTrancate.TabIndex = 56;
            this.btnTrancate.Text = "清空库存";
            this.btnTrancate.Click += new System.EventHandler(this.BtnTrancate_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewX1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UPN,
            this.状态,
            this.料号,
            this.colPeriod,
            this.数量,
            this.colOriginMaterialNo,
            this.colManufacturerDc,
            this.colLot,
            this.库区,
            this.ABSide,
            this.货位,
            this.colStatus,
            this.入库时间});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(3, 116);
            this.dataGridViewX1.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowHeadersWidth = 40;
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(1359, 398);
            this.dataGridViewX1.TabIndex = 1;
            this.dataGridViewX1.Tag = "9999";
            this.dataGridViewX1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewX1_ColumnHeaderMouseClick);
            this.dataGridViewX1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewX1_RowPostPaint);
            // 
            // UPN
            // 
            this.UPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UPN.DataPropertyName = "UPN";
            this.UPN.FillWeight = 88.36256F;
            this.UPN.HeaderText = "ReelId";
            this.UPN.MinimumWidth = 160;
            this.UPN.Name = "UPN";
            this.UPN.ReadOnly = true;
            // 
            // 状态
            // 
            this.状态.DataPropertyName = "WorkOrderNo";
            this.状态.FillWeight = 65.98986F;
            this.状态.HeaderText = "工单号";
            this.状态.MinimumWidth = 80;
            this.状态.Name = "状态";
            this.状态.ReadOnly = true;
            // 
            // 料号
            // 
            this.料号.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.料号.DataPropertyName = "PartNumber";
            this.料号.FillWeight = 88.36256F;
            this.料号.HeaderText = "物料料号";
            this.料号.MinimumWidth = 130;
            this.料号.Name = "料号";
            this.料号.ReadOnly = true;
            this.料号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // colPeriod
            // 
            this.colPeriod.DataPropertyName = "BatchNo";
            this.colPeriod.HeaderText = "IC料号";
            this.colPeriod.MinimumWidth = 9;
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.ReadOnly = true;
            this.colPeriod.Width = 120;
            // 
            // 数量
            // 
            this.数量.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.数量.DataPropertyName = "Qty";
            this.数量.FillWeight = 88.36256F;
            this.数量.HeaderText = "数量";
            this.数量.MinimumWidth = 80;
            this.数量.Name = "数量";
            this.数量.ReadOnly = true;
            this.数量.Width = 80;
            // 
            // colOriginMaterialNo
            // 
            this.colOriginMaterialNo.DataPropertyName = "FactoryCode";
            this.colOriginMaterialNo.HeaderText = "原物料料号";
            this.colOriginMaterialNo.Name = "colOriginMaterialNo";
            this.colOriginMaterialNo.ReadOnly = true;
            // 
            // colManufacturerDc
            // 
            this.colManufacturerDc.DataPropertyName = "DateCode";
            this.colManufacturerDc.HeaderText = "供应商色块";
            this.colManufacturerDc.Name = "colManufacturerDc";
            this.colManufacturerDc.ReadOnly = true;
            // 
            // colLot
            // 
            this.colLot.DataPropertyName = "Lot";
            this.colLot.HeaderText = "批次";
            this.colLot.Name = "colLot";
            this.colLot.ReadOnly = true;
            // 
            // 库区
            // 
            this.库区.DataPropertyName = "TowerDes";
            this.库区.HeaderText = "库区";
            this.库区.MinimumWidth = 80;
            this.库区.Name = "库区";
            this.库区.ReadOnly = true;
            this.库区.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ABSide
            // 
            this.ABSide.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ABSide.DataPropertyName = "SubArea";
            this.ABSide.HeaderText = "货架";
            this.ABSide.MinimumWidth = 60;
            this.ABSide.Name = "ABSide";
            this.ABSide.ReadOnly = true;
            this.ABSide.Width = 80;
            // 
            // 货位
            // 
            this.货位.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.货位.DataPropertyName = "Location";
            this.货位.FillWeight = 88.36256F;
            this.货位.HeaderText = "货位";
            this.货位.MinimumWidth = 80;
            this.货位.Name = "货位";
            this.货位.ReadOnly = true;
            this.货位.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "StatusDisplay";
            this.colStatus.HeaderText = "库存状态";
            this.colStatus.MinimumWidth = 80;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // 入库时间
            // 
            this.入库时间.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.入库时间.DataPropertyName = "SaveTime";
            this.入库时间.FillWeight = 186.3569F;
            this.入库时间.HeaderText = "入库时间";
            this.入库时间.MinimumWidth = 130;
            this.入库时间.Name = "入库时间";
            this.入库时间.ReadOnly = true;
            // 
            // tlpBottom
            // 
            this.tlpBottom.ColumnCount = 3;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 933F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.Controls.Add(this.statusStrip2, 1, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(0, 517);
            this.tlpBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.Size = new System.Drawing.Size(1365, 30);
            this.tlpBottom.TabIndex = 51;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tpsrecordCount,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.tpscurrentPage,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.tpspageCount,
            this.toolStripStatusLabel9,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel5,
            this.btnFrist,
            this.btnPre,
            this.btnNext,
            this.BtnLast});
            this.statusStrip2.Location = new System.Drawing.Point(216, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip2.Size = new System.Drawing.Size(682, 23);
            this.statusStrip2.TabIndex = 50;
            this.statusStrip2.Text = "                                        ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(20, 18);
            this.toolStripStatusLabel1.Text = "共";
            // 
            // tpsrecordCount
            // 
            this.tpsrecordCount.Name = "tpsrecordCount";
            this.tpsrecordCount.Size = new System.Drawing.Size(15, 18);
            this.tpsrecordCount.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(47, 18);
            this.toolStripStatusLabel3.Text = "条记录,";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(44, 18);
            this.toolStripStatusLabel4.Text = "当前第";
            // 
            // tpscurrentPage
            // 
            this.tpscurrentPage.Name = "tpscurrentPage";
            this.tpscurrentPage.Size = new System.Drawing.Size(15, 18);
            this.tpscurrentPage.Text = "0";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(23, 18);
            this.toolStripStatusLabel6.Text = "页,";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(20, 18);
            this.toolStripStatusLabel7.Text = "共";
            // 
            // tpspageCount
            // 
            this.tpspageCount.Name = "tpspageCount";
            this.tpspageCount.Size = new System.Drawing.Size(15, 18);
            this.tpspageCount.Text = "0";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(20, 18);
            this.toolStripStatusLabel9.Text = "页";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(84, 18);
            this.toolStripStatusLabel2.Text = "                   ";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(108, 18);
            this.toolStripStatusLabel5.Text = "                         ";
            // 
            // btnFrist
            // 
            this.btnFrist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFrist.Image = ((System.Drawing.Image)(resources.GetObject("btnFrist.Image")));
            this.btnFrist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFrist.Name = "btnFrist";
            this.btnFrist.Size = new System.Drawing.Size(60, 21);
            this.btnFrist.Text = "第一页";
            this.btnFrist.ButtonClick += new System.EventHandler(this.BtnFrist_ButtonClick);
            // 
            // btnPre
            // 
            this.btnPre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPre.Image = ((System.Drawing.Image)(resources.GetObject("btnPre.Image")));
            this.btnPre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(60, 21);
            this.btnPre.Text = "上一页";
            this.btnPre.ButtonClick += new System.EventHandler(this.BtnPre_ButtonClick);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(60, 21);
            this.btnNext.Text = "下一页";
            this.btnNext.ButtonClick += new System.EventHandler(this.BtnNext_ButtonClick);
            // 
            // BtnLast
            // 
            this.BtnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnLast.Image = ((System.Drawing.Image)(resources.GetObject("BtnLast.Image")));
            this.BtnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnLast.Name = "BtnLast";
            this.BtnLast.Size = new System.Drawing.Size(72, 21);
            this.BtnLast.Text = "最后一页";
            this.BtnLast.ButtonClick += new System.EventHandler(this.BtnLast_ButtonClick);
            // 
            // FrmNearbyInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 581);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmNearbyInventory";
            this.Text = "线边库存";
            this.Load += new System.EventHandler(this.FrmInStockDatailInfo_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.tlpBottom.ResumeLayout(false);
            this.tlpBottom.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据导出ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton button3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtReelid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPn;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton button2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.DataGridView dataGridViewX1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblShelfSide;
        private System.Windows.Forms.ComboBox cbShelfSide;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.SimpleButton btnSync;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tpsrecordCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tpscurrentPage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel tpspageCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripSplitButton btnFrist;
        private System.Windows.Forms.ToolStripSplitButton btnPre;
        private System.Windows.Forms.ToolStripSplitButton btnNext;
        private System.Windows.Forms.ToolStripSplitButton BtnLast;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private DevExpress.XtraEditors.SimpleButton btnTrancate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 料号;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturerDc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn 库区;
        private System.Windows.Forms.DataGridViewTextBoxColumn ABSide;
        private System.Windows.Forms.DataGridViewTextBoxColumn 货位;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入库时间;
    }
}