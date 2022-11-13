
namespace iWms.Form
{
    partial class FrmInstocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInstocks));
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
            this.tbUpn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            this.tbOrderNo = new System.Windows.Forms.TextBox();
            this.cbOrderType = new System.Windows.Forms.ComboBox();
            this.cbOrderStatus = new System.Windows.Forms.ComboBox();
            this.tbMaterialNo = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.dtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.dtFinishDate = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNoSource = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colIsSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinishedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperate = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tbDetails = new System.Windows.Forms.GroupBox();
            this.tlpDetails = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.colMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterialCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiveStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBarcodes = new System.Windows.Forms.DataGridView();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInnerCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTowerNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpLayout.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.gbConditions.SuspendLayout();
            this.tlpConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.tbDetails.SuspendLayout();
            this.tlpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodes)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 1;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.Controls.Add(this.statusStrip2, 0, 2);
            this.tlpLayout.Controls.Add(this.gbConditions, 0, 0);
            this.tlpLayout.Controls.Add(this.dgvOrders, 0, 1);
            this.tlpLayout.Controls.Add(this.tbDetails, 0, 3);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 34);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 4;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpLayout.Size = new System.Drawing.Size(1224, 673);
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
            this.statusStrip2.Location = new System.Drawing.Point(0, 290);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip2.Size = new System.Drawing.Size(682, 23);
            this.statusStrip2.TabIndex = 8;
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
            this.btnFrist.ButtonClick += new System.EventHandler(this.btnFrist_ButtonClick);
            // 
            // btnPre
            // 
            this.btnPre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPre.Image = ((System.Drawing.Image)(resources.GetObject("btnPre.Image")));
            this.btnPre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(60, 21);
            this.btnPre.Text = "上一页";
            this.btnPre.ButtonClick += new System.EventHandler(this.btnPre_ButtonClick);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(60, 21);
            this.btnNext.Text = "下一页";
            this.btnNext.ButtonClick += new System.EventHandler(this.btnNext_ButtonClick);
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
            this.gbConditions.Size = new System.Drawing.Size(1218, 134);
            this.gbConditions.TabIndex = 0;
            this.gbConditions.TabStop = false;
            // 
            // tlpConditions
            // 
            this.tlpConditions.ColumnCount = 11;
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.Controls.Add(this.tbUpn, 1, 1);
            this.tlpConditions.Controls.Add(this.label7, 2, 2);
            this.tlpConditions.Controls.Add(this.label6, 0, 2);
            this.tlpConditions.Controls.Add(this.label5, 4, 1);
            this.tlpConditions.Controls.Add(this.label4, 2, 1);
            this.tlpConditions.Controls.Add(this.label3, 0, 1);
            this.tlpConditions.Controls.Add(this.label2, 4, 0);
            this.tlpConditions.Controls.Add(this.label1, 2, 0);
            this.tlpConditions.Controls.Add(this.lblNo, 0, 0);
            this.tlpConditions.Controls.Add(this.tbOrderNo, 1, 0);
            this.tlpConditions.Controls.Add(this.cbOrderType, 3, 0);
            this.tlpConditions.Controls.Add(this.cbOrderStatus, 5, 0);
            this.tlpConditions.Controls.Add(this.tbMaterialNo, 3, 1);
            this.tlpConditions.Controls.Add(this.tbUser, 5, 1);
            this.tlpConditions.Controls.Add(this.dtOrderDate, 1, 2);
            this.tlpConditions.Controls.Add(this.dtFinishDate, 3, 2);
            this.tlpConditions.Controls.Add(this.btnQuery, 7, 1);
            this.tlpConditions.Controls.Add(this.btnExport, 8, 1);
            this.tlpConditions.Controls.Add(this.btnClear, 8, 2);
            this.tlpConditions.Controls.Add(this.btnNoSource, 8, 0);
            this.tlpConditions.Controls.Add(this.btnCancel, 9, 1);
            this.tlpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditions.Location = new System.Drawing.Point(3, 18);
            this.tlpConditions.Name = "tlpConditions";
            this.tlpConditions.RowCount = 4;
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.Size = new System.Drawing.Size(1212, 113);
            this.tlpConditions.TabIndex = 0;
            // 
            // tbUpn
            // 
            this.tbUpn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUpn.Location = new System.Drawing.Point(95, 37);
            this.tbUpn.Margin = new System.Windows.Forms.Padding(2);
            this.tbUpn.Name = "tbUpn";
            this.tbUpn.Size = new System.Drawing.Size(159, 22);
            this.tbUpn.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(259, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 35);
            this.label7.TabIndex = 7;
            this.label7.Text = "完成日期";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 35);
            this.label6.TabIndex = 6;
            this.label6.Text = "下达日期";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(492, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 35);
            this.label5.TabIndex = 5;
            this.label5.Text = "操作账号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(259, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 35);
            this.label4.TabIndex = 4;
            this.label4.Text = "物料代码";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 35);
            this.label3.TabIndex = 3;
            this.label3.Text = "UPN";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(492, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "单据状态";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(259, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "单据类型";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNo.Location = new System.Drawing.Point(3, 0);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(87, 35);
            this.lblNo.TabIndex = 0;
            this.lblNo.Text = "入库单号";
            this.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbOrderNo
            // 
            this.tbOrderNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOrderNo.Location = new System.Drawing.Point(96, 3);
            this.tbOrderNo.Name = "tbOrderNo";
            this.tbOrderNo.Size = new System.Drawing.Size(157, 22);
            this.tbOrderNo.TabIndex = 8;
            // 
            // cbOrderType
            // 
            this.cbOrderType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbOrderType.FormattingEnabled = true;
            this.cbOrderType.Location = new System.Drawing.Point(352, 3);
            this.cbOrderType.Name = "cbOrderType";
            this.cbOrderType.Size = new System.Drawing.Size(134, 22);
            this.cbOrderType.TabIndex = 10;
            // 
            // cbOrderStatus
            // 
            this.cbOrderStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbOrderStatus.FormattingEnabled = true;
            this.cbOrderStatus.Location = new System.Drawing.Point(585, 3);
            this.cbOrderStatus.Name = "cbOrderStatus";
            this.cbOrderStatus.Size = new System.Drawing.Size(134, 22);
            this.cbOrderStatus.TabIndex = 11;
            // 
            // tbMaterialNo
            // 
            this.tbMaterialNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMaterialNo.Location = new System.Drawing.Point(352, 38);
            this.tbMaterialNo.Name = "tbMaterialNo";
            this.tbMaterialNo.Size = new System.Drawing.Size(134, 22);
            this.tbMaterialNo.TabIndex = 12;
            // 
            // tbUser
            // 
            this.tbUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUser.Location = new System.Drawing.Point(585, 38);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(134, 22);
            this.tbUser.TabIndex = 13;
            // 
            // dtOrderDate
            // 
            this.dtOrderDate.CustomFormat = "yyyy-MM-dd";
            this.dtOrderDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOrderDate.Location = new System.Drawing.Point(96, 73);
            this.dtOrderDate.Name = "dtOrderDate";
            this.dtOrderDate.Size = new System.Drawing.Size(157, 22);
            this.dtOrderDate.TabIndex = 14;
            this.dtOrderDate.Value = new System.DateTime(2022, 2, 22, 0, 0, 0, 0);
            this.dtOrderDate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Dtp_MouseUp);
            // 
            // dtFinishDate
            // 
            this.dtFinishDate.CustomFormat = "yyyy-MM-dd";
            this.dtFinishDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFinishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinishDate.Location = new System.Drawing.Point(352, 73);
            this.dtFinishDate.Name = "dtFinishDate";
            this.dtFinishDate.Size = new System.Drawing.Size(134, 22);
            this.dtFinishDate.TabIndex = 15;
            this.dtFinishDate.Value = new System.DateTime(2022, 2, 22, 11, 54, 41, 0);
            this.dtFinishDate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Dtp_MouseUp);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(818, 38);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(86, 27);
            this.btnQuery.TabIndex = 16;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(911, 38);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(86, 27);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "导出明细";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(911, 73);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 29);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnNoSource
            // 
            this.btnNoSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNoSource.Location = new System.Drawing.Point(911, 3);
            this.btnNoSource.Name = "btnNoSource";
            this.btnNoSource.Size = new System.Drawing.Size(87, 29);
            this.btnNoSource.TabIndex = 19;
            this.btnNoSource.Text = "无源入库";
            this.btnNoSource.UseVisualStyleBackColor = true;
            this.btnNoSource.Click += new System.EventHandler(this.btnNoSource_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1004, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 27);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取消入库";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelected,
            this.colOrderNo,
            this.colOrderType,
            this.colOrderStatus,
            this.colOrderTime,
            this.colFinishedTime,
            this.colOperate});
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
            this.dgvOrders.RowHeadersWidth = 50;
            this.dgvOrders.RowTemplate.Height = 23;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1218, 144);
            this.dgvOrders.TabIndex = 1;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            this.dgvOrders.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            this.dgvOrders.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvOrders_RowPostPaint);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            this.dgvOrders.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvOrders_KeyUp);
            // 
            // colIsSelected
            // 
            this.colIsSelected.DataPropertyName = "IsSelected";
            this.colIsSelected.FalseValue = "False";
            this.colIsSelected.HeaderText = "选择";
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.ToolTipText = "只在取消入库时生效";
            this.colIsSelected.TrueValue = "True";
            // 
            // colOrderNo
            // 
            this.colOrderNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrderNo.DataPropertyName = "InstockNo";
            this.colOrderNo.HeaderText = "入库单号";
            this.colOrderNo.MinimumWidth = 9;
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.ReadOnly = true;
            // 
            // colOrderType
            // 
            this.colOrderType.DataPropertyName = "OrderTypeDisplay";
            this.colOrderType.HeaderText = "单据类型";
            this.colOrderType.MinimumWidth = 9;
            this.colOrderType.Name = "colOrderType";
            this.colOrderType.ReadOnly = true;
            this.colOrderType.Width = 175;
            // 
            // colOrderStatus
            // 
            this.colOrderStatus.DataPropertyName = "OrderStatusDisplay";
            this.colOrderStatus.HeaderText = "单据状态";
            this.colOrderStatus.MinimumWidth = 9;
            this.colOrderStatus.Name = "colOrderStatus";
            this.colOrderStatus.ReadOnly = true;
            this.colOrderStatus.Width = 175;
            // 
            // colOrderTime
            // 
            this.colOrderTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrderTime.DataPropertyName = "CreateTime";
            this.colOrderTime.HeaderText = "下达时间";
            this.colOrderTime.MinimumWidth = 9;
            this.colOrderTime.Name = "colOrderTime";
            this.colOrderTime.ReadOnly = true;
            // 
            // colFinishedTime
            // 
            this.colFinishedTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFinishedTime.DataPropertyName = "LastUpdateTime";
            this.colFinishedTime.HeaderText = "完成时间";
            this.colFinishedTime.MinimumWidth = 9;
            this.colFinishedTime.Name = "colFinishedTime";
            this.colFinishedTime.ReadOnly = true;
            // 
            // colOperate
            // 
            this.colOperate.DataPropertyName = "OperationText";
            this.colOperate.HeaderText = "操作";
            this.colOperate.MinimumWidth = 9;
            this.colOperate.Name = "colOperate";
            this.colOperate.ReadOnly = true;
            this.colOperate.Text = "入库";
            this.colOperate.Width = 175;
            // 
            // tbDetails
            // 
            this.tbDetails.Controls.Add(this.tlpDetails);
            this.tbDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDetails.Location = new System.Drawing.Point(3, 323);
            this.tbDetails.Name = "tbDetails";
            this.tbDetails.Size = new System.Drawing.Size(1218, 347);
            this.tbDetails.TabIndex = 2;
            this.tbDetails.TabStop = false;
            this.tbDetails.Text = "入库明细";
            // 
            // tlpDetails
            // 
            this.tlpDetails.ColumnCount = 2;
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpDetails.Controls.Add(this.dgvMaterials, 0, 0);
            this.tlpDetails.Controls.Add(this.dgvBarcodes, 1, 0);
            this.tlpDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetails.Location = new System.Drawing.Point(3, 18);
            this.tlpDetails.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDetails.Name = "tlpDetails";
            this.tlpDetails.RowCount = 1;
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetails.Size = new System.Drawing.Size(1212, 326);
            this.tlpDetails.TabIndex = 4;
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.AllowUserToAddRows = false;
            this.dgvMaterials.AllowUserToDeleteRows = false;
            this.dgvMaterials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterials.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaterialNo,
            this.colMaterialCount,
            this.colReceiveStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaterials.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterials.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvMaterials.Location = new System.Drawing.Point(3, 3);
            this.dgvMaterials.MultiSelect = false;
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.ReadOnly = true;
            this.dgvMaterials.RowHeadersWidth = 50;
            this.dgvMaterials.RowTemplate.Height = 23;
            this.dgvMaterials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterials.Size = new System.Drawing.Size(478, 320);
            this.dgvMaterials.TabIndex = 0;
            this.dgvMaterials.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            this.dgvMaterials.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMaterials_RowPostPaint);
            this.dgvMaterials.SelectionChanged += new System.EventHandler(this.dgvMaterials_SelectionChanged);
            // 
            // colMaterialNo
            // 
            this.colMaterialNo.DataPropertyName = "MaterialNo";
            this.colMaterialNo.HeaderText = "物料代码";
            this.colMaterialNo.MinimumWidth = 9;
            this.colMaterialNo.Name = "colMaterialNo";
            this.colMaterialNo.ReadOnly = true;
            // 
            // colMaterialCount
            // 
            this.colMaterialCount.DataPropertyName = "RequireCount";
            this.colMaterialCount.HeaderText = "入库数量";
            this.colMaterialCount.MinimumWidth = 9;
            this.colMaterialCount.Name = "colMaterialCount";
            this.colMaterialCount.ReadOnly = true;
            // 
            // colReceiveStatus
            // 
            this.colReceiveStatus.DataPropertyName = "ReceiveStatusDisplay";
            this.colReceiveStatus.HeaderText = "入库状态";
            this.colReceiveStatus.Name = "colReceiveStatus";
            this.colReceiveStatus.ReadOnly = true;
            // 
            // dgvBarcodes
            // 
            this.dgvBarcodes.AllowUserToAddRows = false;
            this.dgvBarcodes.AllowUserToDeleteRows = false;
            this.dgvBarcodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBarcodes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBarcodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarcodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBarcode,
            this.colInnerCount,
            this.colTowerNo,
            this.colLocation,
            this.colOperator});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBarcodes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBarcodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBarcodes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvBarcodes.Location = new System.Drawing.Point(487, 3);
            this.dgvBarcodes.MultiSelect = false;
            this.dgvBarcodes.Name = "dgvBarcodes";
            this.dgvBarcodes.ReadOnly = true;
            this.dgvBarcodes.RowHeadersWidth = 50;
            this.dgvBarcodes.RowTemplate.Height = 23;
            this.dgvBarcodes.Size = new System.Drawing.Size(722, 320);
            this.dgvBarcodes.TabIndex = 1;
            this.dgvBarcodes.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvBarcodes_RowPostPaint);
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Upn";
            this.colBarcode.HeaderText = "UPN";
            this.colBarcode.MinimumWidth = 9;
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colInnerCount
            // 
            this.colInnerCount.DataPropertyName = "InnerQty";
            this.colInnerCount.HeaderText = "盘内数量";
            this.colInnerCount.MinimumWidth = 9;
            this.colInnerCount.Name = "colInnerCount";
            this.colInnerCount.ReadOnly = true;
            // 
            // colTowerNo
            // 
            this.colTowerNo.DataPropertyName = "TowerNo";
            this.colTowerNo.HeaderText = "库区";
            this.colTowerNo.Name = "colTowerNo";
            this.colTowerNo.ReadOnly = true;
            // 
            // colLocation
            // 
            this.colLocation.DataPropertyName = "Location";
            this.colLocation.HeaderText = "库位";
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            // 
            // colOperator
            // 
            this.colOperator.DataPropertyName = "Operator";
            this.colOperator.HeaderText = "操作账号";
            this.colOperator.MinimumWidth = 9;
            this.colOperator.Name = "colOperator";
            this.colOperator.ReadOnly = true;
            // 
            // FrmInstocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 707);
            this.Controls.Add(this.tlpLayout);
            this.Name = "FrmInstocks";
            this.Text = "入库单列表";
            this.Load += new System.EventHandler(this.FrmInstocks_Load);
            this.Controls.SetChildIndex(this.tlpLayout, 0);
            this.tlpLayout.ResumeLayout(false);
            this.tlpLayout.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.gbConditions.ResumeLayout(false);
            this.tlpConditions.ResumeLayout(false);
            this.tlpConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.tbDetails.ResumeLayout(false);
            this.tlpDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcodes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.GroupBox gbConditions;
        private System.Windows.Forms.TableLayoutPanel tlpConditions;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbOrderNo;
        private System.Windows.Forms.TextBox tbUpn;
        private System.Windows.Forms.ComboBox cbOrderType;
        private System.Windows.Forms.ComboBox cbOrderStatus;
        private System.Windows.Forms.TextBox tbMaterialNo;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.DateTimePicker dtOrderDate;
        private System.Windows.Forms.DateTimePicker dtFinishDate;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.GroupBox tbDetails;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNoSource;
        private System.Windows.Forms.TableLayoutPanel tlpDetails;
        private  System.Windows.Forms.DataGridView dgvMaterials;
        private  System.Windows.Forms.DataGridView dgvBarcodes;
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
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInnerCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTowerNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiveStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinishedTime;
        private System.Windows.Forms.DataGridViewLinkColumn colOperate;
    }
}