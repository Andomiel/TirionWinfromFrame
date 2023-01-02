
namespace iWms.Form
{
    partial class FrmInventoryOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnOutstock = new DevExpress.XtraEditors.SimpleButton();
            this.btnFinish = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.tbOrderNo = new System.Windows.Forms.TextBox();
            this.cbOrderStatus = new System.Windows.Forms.ComboBox();
            this.tbMaterialNo = new System.Windows.Forms.TextBox();
            this.tbUpn = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnProfit = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoss = new DevExpress.XtraEditors.SimpleButton();
            this.tlbTables = new System.Windows.Forms.TableLayoutPanel();
            this.dgvUpns = new System.Windows.Forms.DataGridView();
            this.colMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActualQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtCreate = new DevExpress.XtraEditors.DateEdit();
            this.dtFinish = new DevExpress.XtraEditors.DateEdit();
            this.tlpLayout.SuspendLayout();
            this.gbConditions.SuspendLayout();
            this.tlpConditions.SuspendLayout();
            this.tlbTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties)).BeginInit();
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
            this.tlpLayout.Size = new System.Drawing.Size(1299, 673);
            this.tlpLayout.TabIndex = 0;
            // 
            // gbConditions
            // 
            this.gbConditions.Controls.Add(this.tlpConditions);
            this.gbConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbConditions.Location = new System.Drawing.Point(3, 3);
            this.gbConditions.Name = "gbConditions";
            this.gbConditions.Size = new System.Drawing.Size(1293, 134);
            this.gbConditions.TabIndex = 0;
            this.gbConditions.TabStop = false;
            // 
            // tlpConditions
            // 
            this.tlpConditions.ColumnCount = 14;
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
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpConditions.Controls.Add(this.label8, 2, 2);
            this.tlpConditions.Controls.Add(this.label7, 0, 2);
            this.tlpConditions.Controls.Add(this.label6, 2, 1);
            this.tlpConditions.Controls.Add(this.label5, 2, 0);
            this.tlpConditions.Controls.Add(this.label4, 0, 1);
            this.tlpConditions.Controls.Add(this.label3, 4, 0);
            this.tlpConditions.Controls.Add(this.label1, 0, 0);
            this.tlpConditions.Controls.Add(this.btnOutstock, 9, 2);
            this.tlpConditions.Controls.Add(this.btnFinish, 10, 2);
            this.tlpConditions.Controls.Add(this.btnExport, 7, 2);
            this.tlpConditions.Controls.Add(this.tbOrderNo, 1, 0);
            this.tlpConditions.Controls.Add(this.cbOrderStatus, 5, 0);
            this.tlpConditions.Controls.Add(this.tbMaterialNo, 3, 0);
            this.tlpConditions.Controls.Add(this.tbUpn, 1, 1);
            this.tlpConditions.Controls.Add(this.cbType, 3, 1);
            this.tlpConditions.Controls.Add(this.btnQuery, 7, 0);
            this.tlpConditions.Controls.Add(this.btnClear, 7, 1);
            this.tlpConditions.Controls.Add(this.btnCancel, 10, 1);
            this.tlpConditions.Controls.Add(this.btnReset, 10, 0);
            this.tlpConditions.Controls.Add(this.btnProfit, 12, 1);
            this.tlpConditions.Controls.Add(this.btnLoss, 12, 2);
            this.tlpConditions.Controls.Add(this.dtCreate, 1, 2);
            this.tlpConditions.Controls.Add(this.dtFinish, 3, 2);
            this.tlpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditions.Location = new System.Drawing.Point(3, 18);
            this.tlpConditions.Name = "tlpConditions";
            this.tlpConditions.RowCount = 4;
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.Size = new System.Drawing.Size(1287, 113);
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
            this.label6.Text = "盘点类型";
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
            this.label1.Text = "盘点单号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOutstock
            // 
            this.btnOutstock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOutstock.Location = new System.Drawing.Point(935, 73);
            this.btnOutstock.Name = "btnOutstock";
            this.btnOutstock.Size = new System.Drawing.Size(87, 29);
            this.btnOutstock.TabIndex = 9;
            this.btnOutstock.Text = "执行盘点";
            this.btnOutstock.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinish.Location = new System.Drawing.Point(1028, 73);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(87, 29);
            this.btnFinish.TabIndex = 12;
            this.btnFinish.Text = "盘点完成";
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
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(1028, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 29);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "取消盘点";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.Location = new System.Drawing.Point(1028, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 29);
            this.btnReset.TabIndex = 27;
            this.btnReset.Text = "一键复位";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnProfit
            // 
            this.btnProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProfit.Location = new System.Drawing.Point(1177, 38);
            this.btnProfit.Name = "btnProfit";
            this.btnProfit.Size = new System.Drawing.Size(87, 29);
            this.btnProfit.TabIndex = 28;
            this.btnProfit.Text = "盘盈";
            this.btnProfit.Click += new System.EventHandler(this.BtnProfit_Click);
            // 
            // btnLoss
            // 
            this.btnLoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoss.Location = new System.Drawing.Point(1177, 73);
            this.btnLoss.Name = "btnLoss";
            this.btnLoss.Size = new System.Drawing.Size(87, 29);
            this.btnLoss.TabIndex = 29;
            this.btnLoss.Text = "盘亏";
            this.btnLoss.Click += new System.EventHandler(this.BtnLoss_Click);
            // 
            // tlbTables
            // 
            this.tlbTables.ColumnCount = 2;
            this.tlbTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlbTables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlbTables.Controls.Add(this.dgvUpns, 1, 0);
            this.tlbTables.Controls.Add(this.dgvOrders, 0, 0);
            this.tlbTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlbTables.Location = new System.Drawing.Point(3, 143);
            this.tlbTables.Name = "tlbTables";
            this.tlbTables.RowCount = 1;
            this.tlbTables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlbTables.Size = new System.Drawing.Size(1293, 527);
            this.tlbTables.TabIndex = 3;
            // 
            // dgvUpns
            // 
            this.dgvUpns.AllowUserToAddRows = false;
            this.dgvUpns.AllowUserToDeleteRows = false;
            this.dgvUpns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpns.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUpns.ColumnHeadersHeight = 20;
            this.dgvUpns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUpns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaterialNo,
            this.colUpn,
            this.colQty,
            this.colActualQuantity,
            this.colResult});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUpns.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUpns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUpns.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvUpns.Location = new System.Drawing.Point(714, 3);
            this.dgvUpns.MultiSelect = false;
            this.dgvUpns.Name = "dgvUpns";
            this.dgvUpns.ReadOnly = true;
            this.dgvUpns.RowHeadersWidth = 40;
            this.dgvUpns.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUpns.RowTemplate.Height = 23;
            this.dgvUpns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUpns.Size = new System.Drawing.Size(576, 521);
            this.dgvUpns.TabIndex = 2;
            this.dgvUpns.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dgv_DataBindingComplete);
            this.dgvUpns.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUpns_RowPostPaint);
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
            this.colQty.DataPropertyName = "OriginQuantity";
            this.colQty.HeaderText = "账面数量";
            this.colQty.MinimumWidth = 9;
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colActualQuantity
            // 
            this.colActualQuantity.DataPropertyName = "RealQuantity";
            this.colActualQuantity.HeaderText = "实际数量";
            this.colActualQuantity.Name = "colActualQuantity";
            this.colActualQuantity.ReadOnly = true;
            // 
            // colResult
            // 
            this.colResult.DataPropertyName = "InventoryResult";
            this.colResult.HeaderText = "盘点结论";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOrders.ColumnHeadersHeight = 20;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNo,
            this.colOrderStatus,
            this.colSource,
            this.colDestination,
            this.colOrderTime,
            this.colCreateUser});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.dgvOrders.Size = new System.Drawing.Size(705, 521);
            this.dgvOrders.TabIndex = 1;
            this.dgvOrders.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.Dgv_DataBindingComplete);
            this.dgvOrders.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvOrders_RowPostPaint);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.DgvOrders_SelectionChanged);
            // 
            // colOrderNo
            // 
            this.colOrderNo.DataPropertyName = "InventoryNo";
            this.colOrderNo.FillWeight = 57.44501F;
            this.colOrderNo.HeaderText = "盘点单号";
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
            this.colSource.DataPropertyName = "InventoryAreaDisplay";
            this.colSource.FillWeight = 57.44501F;
            this.colSource.HeaderText = "盘点库区";
            this.colSource.MinimumWidth = 9;
            this.colSource.Name = "colSource";
            this.colSource.ReadOnly = true;
            // 
            // colDestination
            // 
            this.colDestination.DataPropertyName = "SubArea";
            this.colDestination.FillWeight = 56F;
            this.colDestination.HeaderText = "二级区域";
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
            // colCreateUser
            // 
            this.colCreateUser.DataPropertyName = "CreateUser";
            this.colCreateUser.FillWeight = 57.44501F;
            this.colCreateUser.HeaderText = "制单人";
            this.colCreateUser.MinimumWidth = 9;
            this.colCreateUser.Name = "colCreateUser";
            this.colCreateUser.ReadOnly = true;
            // 
            // dtCreate
            // 
            this.dtCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtCreate.EditValue = null;
            this.dtCreate.Location = new System.Drawing.Point(96, 73);
            this.dtCreate.Name = "dtCreate";
            this.dtCreate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCreate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCreate.Size = new System.Drawing.Size(134, 20);
            this.dtCreate.TabIndex = 30;
            // 
            // dtFinish
            // 
            this.dtFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFinish.EditValue = null;
            this.dtFinish.Location = new System.Drawing.Point(329, 73);
            this.dtFinish.Name = "dtFinish";
            this.dtFinish.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFinish.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFinish.Size = new System.Drawing.Size(134, 20);
            this.dtFinish.TabIndex = 31;
            // 
            // FrmInventoryOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 707);
            this.Controls.Add(this.tlpLayout);
            this.Name = "FrmInventoryOrders";
            this.Text = "盘点单列表";
            this.Load += new System.EventHandler(this.FrmOutstocks_Load);
            this.Controls.SetChildIndex(this.tlpLayout, 0);
            this.tlpLayout.ResumeLayout(false);
            this.gbConditions.ResumeLayout(false);
            this.tlpConditions.ResumeLayout(false);
            this.tlpConditions.PerformLayout();
            this.tlbTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCreate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinish.Properties)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton btnOutstock;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.SimpleButton btnFinish;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.TextBox tbOrderNo;
        private System.Windows.Forms.ComboBox cbOrderStatus;
        private System.Windows.Forms.TextBox tbMaterialNo;
        private System.Windows.Forms.DataGridView dgvUpns;
        private System.Windows.Forms.TextBox tbUpn;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private System.Windows.Forms.TableLayoutPanel tlbTables;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbType;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActualQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnProfit;
        private DevExpress.XtraEditors.SimpleButton btnLoss;
        private DevExpress.XtraEditors.DateEdit dtCreate;
        private DevExpress.XtraEditors.DateEdit dtFinish;
    }
}