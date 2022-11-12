
namespace iWms.Form
{
    partial class FrmOutstocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOutstocks));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
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
            this.gbConditions = new System.Windows.Forms.GroupBox();
            this.tlpConditions = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOutstock = new DevExpress.XtraEditors.SimpleButton();
            this.btnFinish = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.tbOrderNo = new System.Windows.Forms.TextBox();
            this.cbOrderType = new System.Windows.Forms.ComboBox();
            this.cbOrderStatus = new System.Windows.Forms.ComboBox();
            this.tbDestination = new System.Windows.Forms.TextBox();
            this.tbMaterialNo = new System.Windows.Forms.TextBox();
            this.dtOrderTime = new System.Windows.Forms.DateTimePicker();
            this.dtFinishedTime = new System.Windows.Forms.DateTimePicker();
            this.tbOperator = new System.Windows.Forms.TextBox();
            this.tbUpn = new System.Windows.Forms.TextBox();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnCalculate = new DevExpress.XtraEditors.SimpleButton();
            this.btnSpecial = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestinationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSortingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinishedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReview = new System.Windows.Forms.DataGridViewLinkColumn();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.tlpDetails = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInventoryStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUpns = new System.Windows.Forms.DataGridView();
            this.colUpn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInnerCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLack = new DevExpress.XtraEditors.SimpleButton();
            this.tlpLayout.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.gbConditions.SuspendLayout();
            this.tlpConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.gbDetails.SuspendLayout();
            this.tlpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpns)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 1;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.Controls.Add(this.statusStrip2, 0, 2);
            this.tlpLayout.Controls.Add(this.gbConditions, 0, 0);
            this.tlpLayout.Controls.Add(this.dgvOrders, 0, 1);
            this.tlpLayout.Controls.Add(this.gbDetails, 0, 3);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 34);
            this.tlpLayout.Margin = new System.Windows.Forms.Padding(3, 34, 3, 3);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 4;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpLayout.Size = new System.Drawing.Size(1227, 673);
            this.tlpLayout.TabIndex = 0;
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
            this.statusStrip2.Location = new System.Drawing.Point(0, 341);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip2.Size = new System.Drawing.Size(682, 23);
            this.statusStrip2.TabIndex = 7;
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
            // gbConditions
            // 
            this.gbConditions.Controls.Add(this.tlpConditions);
            this.gbConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbConditions.Location = new System.Drawing.Point(3, 3);
            this.gbConditions.Name = "gbConditions";
            this.gbConditions.Size = new System.Drawing.Size(1221, 134);
            this.gbConditions.TabIndex = 0;
            this.gbConditions.TabStop = false;
            // 
            // tlpConditions
            // 
            this.tlpConditions.ColumnCount = 17;
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.Controls.Add(this.label9, 4, 2);
            this.tlpConditions.Controls.Add(this.label8, 2, 2);
            this.tlpConditions.Controls.Add(this.label7, 0, 2);
            this.tlpConditions.Controls.Add(this.label6, 4, 1);
            this.tlpConditions.Controls.Add(this.label5, 2, 1);
            this.tlpConditions.Controls.Add(this.label4, 0, 1);
            this.tlpConditions.Controls.Add(this.label3, 4, 0);
            this.tlpConditions.Controls.Add(this.label2, 2, 0);
            this.tlpConditions.Controls.Add(this.label1, 0, 0);
            this.tlpConditions.Controls.Add(this.btnOutstock, 9, 2);
            this.tlpConditions.Controls.Add(this.btnFinish, 11, 2);
            this.tlpConditions.Controls.Add(this.btnExport, 11, 0);
            this.tlpConditions.Controls.Add(this.tbOrderNo, 1, 0);
            this.tlpConditions.Controls.Add(this.cbOrderType, 3, 0);
            this.tlpConditions.Controls.Add(this.cbOrderStatus, 5, 0);
            this.tlpConditions.Controls.Add(this.tbDestination, 5, 1);
            this.tlpConditions.Controls.Add(this.tbMaterialNo, 3, 1);
            this.tlpConditions.Controls.Add(this.dtOrderTime, 1, 2);
            this.tlpConditions.Controls.Add(this.dtFinishedTime, 3, 2);
            this.tlpConditions.Controls.Add(this.tbOperator, 5, 2);
            this.tlpConditions.Controls.Add(this.tbUpn, 1, 1);
            this.tlpConditions.Controls.Add(this.btnClear, 9, 0);
            this.tlpConditions.Controls.Add(this.btnQuery, 7, 0);
            this.tlpConditions.Controls.Add(this.btnCancel, 13, 2);
            this.tlpConditions.Controls.Add(this.btnCalculate, 7, 2);
            this.tlpConditions.Controls.Add(this.btnSpecial, 11, 1);
            this.tlpConditions.Controls.Add(this.btnReset, 13, 1);
            this.tlpConditions.Controls.Add(this.btnLack, 13, 0);
            this.tlpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditions.Location = new System.Drawing.Point(3, 18);
            this.tlpConditions.Name = "tlpConditions";
            this.tlpConditions.RowCount = 4;
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.Size = new System.Drawing.Size(1215, 113);
            this.tlpConditions.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(443, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 35);
            this.label9.TabIndex = 8;
            this.label9.Text = "操作人";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(223, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 35);
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
            this.label7.Size = new System.Drawing.Size(74, 35);
            this.label7.TabIndex = 6;
            this.label7.Text = "下达日期";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(443, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 35);
            this.label6.TabIndex = 5;
            this.label6.Text = "目的地";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(223, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 35);
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
            this.label4.Size = new System.Drawing.Size(74, 35);
            this.label4.TabIndex = 3;
            this.label4.Text = "UPN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(443, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "单据状态";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(223, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "单据类型";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "出库单号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOutstock
            // 
            this.btnOutstock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOutstock.Location = new System.Drawing.Point(810, 73);
            this.btnOutstock.Name = "btnOutstock";
            this.btnOutstock.Size = new System.Drawing.Size(74, 29);
            this.btnOutstock.TabIndex = 9;
            this.btnOutstock.Text = "执行出库";
            this.btnOutstock.Click += new System.EventHandler(this.BtnOutstock_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinish.Location = new System.Drawing.Point(910, 73);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(74, 29);
            this.btnFinish.TabIndex = 12;
            this.btnFinish.Text = "拣料完成";
            this.btnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Location = new System.Drawing.Point(910, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(74, 29);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "导出明细";
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // tbOrderNo
            // 
            this.tbOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOrderNo.Location = new System.Drawing.Point(83, 3);
            this.tbOrderNo.Name = "tbOrderNo";
            this.tbOrderNo.Size = new System.Drawing.Size(134, 22);
            this.tbOrderNo.TabIndex = 14;
            // 
            // cbOrderType
            // 
            this.cbOrderType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbOrderType.FormattingEnabled = true;
            this.cbOrderType.Location = new System.Drawing.Point(303, 3);
            this.cbOrderType.Name = "cbOrderType";
            this.cbOrderType.Size = new System.Drawing.Size(134, 22);
            this.cbOrderType.TabIndex = 15;
            // 
            // cbOrderStatus
            // 
            this.cbOrderStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbOrderStatus.FormattingEnabled = true;
            this.cbOrderStatus.Location = new System.Drawing.Point(523, 3);
            this.cbOrderStatus.Name = "cbOrderStatus";
            this.cbOrderStatus.Size = new System.Drawing.Size(134, 22);
            this.cbOrderStatus.TabIndex = 16;
            // 
            // tbDestination
            // 
            this.tbDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDestination.Location = new System.Drawing.Point(523, 38);
            this.tbDestination.Name = "tbDestination";
            this.tbDestination.Size = new System.Drawing.Size(134, 22);
            this.tbDestination.TabIndex = 17;
            // 
            // tbMaterialNo
            // 
            this.tbMaterialNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMaterialNo.Location = new System.Drawing.Point(303, 38);
            this.tbMaterialNo.Name = "tbMaterialNo";
            this.tbMaterialNo.Size = new System.Drawing.Size(134, 22);
            this.tbMaterialNo.TabIndex = 18;
            // 
            // dtOrderTime
            // 
            this.dtOrderTime.CustomFormat = "yyyy-MM-dd";
            this.dtOrderTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtOrderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOrderTime.Location = new System.Drawing.Point(83, 73);
            this.dtOrderTime.Name = "dtOrderTime";
            this.dtOrderTime.Size = new System.Drawing.Size(134, 22);
            this.dtOrderTime.TabIndex = 20;
            this.dtOrderTime.Value = new System.DateTime(2022, 2, 22, 12, 4, 52, 0);
            this.dtOrderTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dtp_MouseUp);
            // 
            // dtFinishedTime
            // 
            this.dtFinishedTime.CustomFormat = "yyyy-MM-dd";
            this.dtFinishedTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFinishedTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinishedTime.Location = new System.Drawing.Point(303, 73);
            this.dtFinishedTime.Name = "dtFinishedTime";
            this.dtFinishedTime.Size = new System.Drawing.Size(134, 22);
            this.dtFinishedTime.TabIndex = 21;
            this.dtFinishedTime.Value = new System.DateTime(2022, 2, 22, 0, 0, 0, 0);
            this.dtFinishedTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dtp_MouseUp);
            // 
            // tbOperator
            // 
            this.tbOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOperator.Location = new System.Drawing.Point(523, 73);
            this.tbOperator.Name = "tbOperator";
            this.tbOperator.Size = new System.Drawing.Size(134, 22);
            this.tbOperator.TabIndex = 22;
            // 
            // tbUpn
            // 
            this.tbUpn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUpn.Location = new System.Drawing.Point(83, 38);
            this.tbUpn.Name = "tbUpn";
            this.tbUpn.Size = new System.Drawing.Size(134, 22);
            this.tbUpn.TabIndex = 23;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(810, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 29);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuery.Location = new System.Drawing.Point(710, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(74, 29);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(1010, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 29);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "取消出库";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCalculate.Location = new System.Drawing.Point(710, 73);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(74, 29);
            this.btnCalculate.TabIndex = 26;
            this.btnCalculate.Text = "出库计算";
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // btnSpecial
            // 
            this.btnSpecial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSpecial.Location = new System.Drawing.Point(910, 38);
            this.btnSpecial.Name = "btnSpecial";
            this.btnSpecial.Size = new System.Drawing.Size(74, 29);
            this.btnSpecial.TabIndex = 27;
            this.btnSpecial.Text = "有料出库";
            this.btnSpecial.Click += new System.EventHandler(this.BtnSpecial_Click);
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.Location = new System.Drawing.Point(1010, 38);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(74, 29);
            this.btnReset.TabIndex = 28;
            this.btnReset.Text = "一键复位";
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeight = 29;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNo,
            this.colOrderType,
            this.colOrderStatus,
            this.colDestinationNo,
            this.colSortingId,
            this.colOrderTime,
            this.colFinishedTime,
            this.colReview});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvOrders.Location = new System.Drawing.Point(3, 143);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 40;
            this.dgvOrders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOrders.RowTemplate.Height = 23;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1221, 195);
            this.dgvOrders.TabIndex = 1;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            this.dgvOrders.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvOrders_RowPostPaint);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.DgvOrders_SelectionChanged);
            // 
            // colOrderNo
            // 
            this.colOrderNo.DataPropertyName = "DeliveryNo";
            this.colOrderNo.HeaderText = "出库单号";
            this.colOrderNo.MinimumWidth = 120;
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.ReadOnly = true;
            // 
            // colOrderType
            // 
            this.colOrderType.DataPropertyName = "DeliveryTypeDisplay";
            this.colOrderType.HeaderText = "单据类型";
            this.colOrderType.MinimumWidth = 100;
            this.colOrderType.Name = "colOrderType";
            this.colOrderType.ReadOnly = true;
            // 
            // colOrderStatus
            // 
            this.colOrderStatus.DataPropertyName = "OrderStatusDisplay";
            this.colOrderStatus.HeaderText = "单据状态";
            this.colOrderStatus.MinimumWidth = 100;
            this.colOrderStatus.Name = "colOrderStatus";
            this.colOrderStatus.ReadOnly = true;
            // 
            // colDestinationNo
            // 
            this.colDestinationNo.DataPropertyName = "LineId";
            this.colDestinationNo.HeaderText = "目的地";
            this.colDestinationNo.MinimumWidth = 100;
            this.colDestinationNo.Name = "colDestinationNo";
            // 
            // colSortingId
            // 
            this.colSortingId.DataPropertyName = "SortingId";
            this.colSortingId.HeaderText = "分拣口";
            this.colSortingId.MinimumWidth = 80;
            this.colSortingId.Name = "colSortingId";
            // 
            // colOrderTime
            // 
            this.colOrderTime.DataPropertyName = "CreateTime";
            this.colOrderTime.HeaderText = "下达时间";
            this.colOrderTime.MinimumWidth = 120;
            this.colOrderTime.Name = "colOrderTime";
            this.colOrderTime.ReadOnly = true;
            // 
            // colFinishedTime
            // 
            this.colFinishedTime.DataPropertyName = "LastUpdateTime";
            this.colFinishedTime.HeaderText = "完成时间";
            this.colFinishedTime.MinimumWidth = 120;
            this.colFinishedTime.Name = "colFinishedTime";
            this.colFinishedTime.ReadOnly = true;
            // 
            // colReview
            // 
            this.colReview.DataPropertyName = "OperationText";
            this.colReview.HeaderText = "复核";
            this.colReview.MinimumWidth = 60;
            this.colReview.Name = "colReview";
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.tlpDetails);
            this.gbDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetails.Location = new System.Drawing.Point(3, 374);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(1221, 296);
            this.gbDetails.TabIndex = 2;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "出库明细";
            // 
            // tlpDetails
            // 
            this.tlpDetails.ColumnCount = 3;
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDetails.Controls.Add(this.dgvDetails, 0, 0);
            this.tlpDetails.Controls.Add(this.dgvUpns, 2, 0);
            this.tlpDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetails.Location = new System.Drawing.Point(3, 18);
            this.tlpDetails.Name = "tlpDetails";
            this.tlpDetails.RowCount = 1;
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetails.Size = new System.Drawing.Size(1215, 275);
            this.tlpDetails.TabIndex = 0;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaterialNo,
            this.colDeliveryCount,
            this.colInventoryStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDetails.Location = new System.Drawing.Point(3, 3);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 40;
            this.dgvDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDetails.RowTemplate.Height = 23;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetails.Size = new System.Drawing.Size(598, 269);
            this.dgvDetails.TabIndex = 1;
            this.dgvDetails.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvDetails_RowPostPaint);
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.DgvDetails_SelectionChanged);
            // 
            // colMaterialNo
            // 
            this.colMaterialNo.DataPropertyName = "MaterialNo";
            this.colMaterialNo.HeaderText = "物料代码";
            this.colMaterialNo.MinimumWidth = 9;
            this.colMaterialNo.Name = "colMaterialNo";
            this.colMaterialNo.ReadOnly = true;
            // 
            // colDeliveryCount
            // 
            this.colDeliveryCount.DataPropertyName = "RequireCount";
            this.colDeliveryCount.HeaderText = "需求数量";
            this.colDeliveryCount.MinimumWidth = 9;
            this.colDeliveryCount.Name = "colDeliveryCount";
            this.colDeliveryCount.ReadOnly = true;
            // 
            // colInventoryStatus
            // 
            this.colInventoryStatus.DataPropertyName = "DeliveryStatusDisplay";
            this.colInventoryStatus.HeaderText = "库存状态";
            this.colInventoryStatus.MinimumWidth = 9;
            this.colInventoryStatus.Name = "colInventoryStatus";
            this.colInventoryStatus.ReadOnly = true;
            // 
            // dgvUpns
            // 
            this.dgvUpns.AllowUserToAddRows = false;
            this.dgvUpns.AllowUserToDeleteRows = false;
            this.dgvUpns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUpn,
            this.colInnerCount,
            this.colTower,
            this.colLocation,
            this.colOperator});
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
            this.dgvUpns.Location = new System.Drawing.Point(613, 3);
            this.dgvUpns.MultiSelect = false;
            this.dgvUpns.Name = "dgvUpns";
            this.dgvUpns.ReadOnly = true;
            this.dgvUpns.RowHeadersWidth = 40;
            this.dgvUpns.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUpns.RowTemplate.Height = 23;
            this.dgvUpns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUpns.Size = new System.Drawing.Size(599, 269);
            this.dgvUpns.TabIndex = 2;
            this.dgvUpns.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUpns_RowPostPaint);
            // 
            // colUpn
            // 
            this.colUpn.DataPropertyName = "Barcode";
            this.colUpn.HeaderText = "UPN";
            this.colUpn.MinimumWidth = 9;
            this.colUpn.Name = "colUpn";
            this.colUpn.ReadOnly = true;
            // 
            // colInnerCount
            // 
            this.colInnerCount.DataPropertyName = "DeliveryQuantity";
            this.colInnerCount.HeaderText = "盘内数量";
            this.colInnerCount.MinimumWidth = 9;
            this.colInnerCount.Name = "colInnerCount";
            this.colInnerCount.ReadOnly = true;
            // 
            // colTower
            // 
            this.colTower.DataPropertyName = "TowerDisplay";
            this.colTower.HeaderText = "出库库区";
            this.colTower.Name = "colTower";
            this.colTower.ReadOnly = true;
            // 
            // colLocation
            // 
            this.colLocation.DataPropertyName = "DeliveryLocation";
            this.colLocation.HeaderText = "出库库位";
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            // 
            // colOperator
            // 
            this.colOperator.DataPropertyName = "LastUpdateUser";
            this.colOperator.HeaderText = "操作人";
            this.colOperator.MinimumWidth = 9;
            this.colOperator.Name = "colOperator";
            this.colOperator.ReadOnly = true;
            // 
            // btnLack
            // 
            this.btnLack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLack.Location = new System.Drawing.Point(1010, 3);
            this.btnLack.Name = "btnLack";
            this.btnLack.Size = new System.Drawing.Size(74, 29);
            this.btnLack.TabIndex = 29;
            this.btnLack.Text = "欠料分析";
            this.btnLack.Click += new System.EventHandler(this.BtnLack_Click);
            // 
            // FrmOutstocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 707);
            this.Controls.Add(this.tlpLayout);
            this.Name = "FrmOutstocks";
            this.Text = "出库单列表";
            this.Load += new System.EventHandler(this.FrmOutstocks_Load);
            this.Controls.SetChildIndex(this.tlpLayout, 0);
            this.tlpLayout.ResumeLayout(false);
            this.tlpLayout.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.gbConditions.ResumeLayout(false);
            this.tlpConditions.ResumeLayout(false);
            this.tlpConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.gbDetails.ResumeLayout(false);
            this.tlpDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.GroupBox gbConditions;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.TableLayoutPanel tlpConditions;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnOutstock;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private DevExpress.XtraEditors.SimpleButton btnFinish;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.TextBox tbOrderNo;
        private System.Windows.Forms.ComboBox cbOrderType;
        private System.Windows.Forms.ComboBox cbOrderStatus;
        private System.Windows.Forms.TextBox tbDestination;
        private System.Windows.Forms.TextBox tbMaterialNo;
        private System.Windows.Forms.DateTimePicker dtOrderTime;
        private System.Windows.Forms.DateTimePicker dtFinishedTime;
        private System.Windows.Forms.TextBox tbOperator;
        private System.Windows.Forms.TableLayoutPanel tlpDetails;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.DataGridView dgvUpns;
        private System.Windows.Forms.TextBox tbUpn;
        private DevExpress.XtraEditors.SimpleButton btnClear;
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
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnCalculate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryStatus;
        private DevExpress.XtraEditors.SimpleButton btnSpecial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInnerCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTower;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestinationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSortingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinishedTime;
        private System.Windows.Forms.DataGridViewLinkColumn colReview;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnLack;
    }
}