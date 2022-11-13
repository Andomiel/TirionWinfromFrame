
namespace iWms.Form
{
    partial class FrmInventoryOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventoryOrder));
            this.btnSearch = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.btnBuildTransfer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewSelect = new System.Windows.Forms.DataGridView();
            this.UPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.供货厂家 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.库区 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.料盘类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入库时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.tlpConditions = new System.Windows.Forms.TableLayoutPanel();
            this.lblShelfSide = new System.Windows.Forms.Label();
            this.cbShelfSide = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.nupPercent = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaterialNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).BeginInit();
            this.tlpLayout.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tlpConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(562, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(134, 29);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "查询计算";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(236, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 35);
            this.label12.TabIndex = 42;
            this.label12.Text = "库区：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbArea
            // 
            this.cmbArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(329, 11);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(134, 22);
            this.cmbArea.TabIndex = 43;
            this.cmbArea.SelectionChangeCommitted += new System.EventHandler(this.CmbArea_SelectionChangeCommitted);
            // 
            // btnBuildTransfer
            // 
            this.btnBuildTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuildTransfer.Location = new System.Drawing.Point(725, 46);
            this.btnBuildTransfer.Name = "btnBuildTransfer";
            this.btnBuildTransfer.Size = new System.Drawing.Size(134, 29);
            this.btnBuildTransfer.TabIndex = 45;
            this.btnBuildTransfer.Text = "创建盘点单";
            this.btnBuildTransfer.UseVisualStyleBackColor = true;
            this.btnBuildTransfer.Click += new System.EventHandler(this.BtnBuildTransfer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 58;
            this.label1.Text = "目标Upn列表";
            // 
            // dataGridViewSelect
            // 
            this.dataGridViewSelect.AllowUserToAddRows = false;
            this.dataGridViewSelect.AllowUserToDeleteRows = false;
            this.dataGridViewSelect.AllowUserToResizeRows = false;
            this.dataGridViewSelect.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewSelect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSelect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSelect.ColumnHeadersHeight = 24;
            this.dataGridViewSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UPN,
            this.PartNumber,
            this.供货厂家,
            this.DateCode,
            this.SerialNo,
            this.Qty,
            this.库区,
            this.colLocation,
            this.料盘类型,
            this.入库时间});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSelect.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelect.EnableHeadersVisualStyles = false;
            this.dataGridViewSelect.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewSelect.Location = new System.Drawing.Point(3, 131);
            this.dataGridViewSelect.Name = "dataGridViewSelect";
            this.dataGridViewSelect.RowHeadersWidth = 30;
            this.dataGridViewSelect.RowTemplate.Height = 23;
            this.dataGridViewSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewSelect.Size = new System.Drawing.Size(1421, 504);
            this.dataGridViewSelect.TabIndex = 56;
            this.dataGridViewSelect.Tag = "9999";
            // 
            // UPN
            // 
            this.UPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UPN.DataPropertyName = "Barcode";
            this.UPN.FillWeight = 60F;
            this.UPN.HeaderText = "UPN";
            this.UPN.MinimumWidth = 200;
            this.UPN.Name = "UPN";
            this.UPN.ReadOnly = true;
            // 
            // PartNumber
            // 
            this.PartNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PartNumber.DataPropertyName = "MaterialNo";
            this.PartNumber.FillWeight = 40F;
            this.PartNumber.HeaderText = "料号";
            this.PartNumber.MinimumWidth = 80;
            this.PartNumber.Name = "PartNumber";
            this.PartNumber.ReadOnly = true;
            // 
            // 供货厂家
            // 
            this.供货厂家.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.供货厂家.DataPropertyName = "Manufacturer";
            this.供货厂家.FillWeight = 165.4751F;
            this.供货厂家.HeaderText = "供货厂家";
            this.供货厂家.MinimumWidth = 120;
            this.供货厂家.Name = "供货厂家";
            this.供货厂家.ReadOnly = true;
            this.供货厂家.Width = 120;
            // 
            // DateCode
            // 
            this.DateCode.DataPropertyName = "DateCode";
            this.DateCode.HeaderText = "生产日期";
            this.DateCode.MinimumWidth = 9;
            this.DateCode.Name = "DateCode";
            this.DateCode.Width = 175;
            // 
            // SerialNo
            // 
            this.SerialNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SerialNo.DataPropertyName = "SerialNo";
            this.SerialNo.HeaderText = "流水号";
            this.SerialNo.MinimumWidth = 8;
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.Width = 120;
            // 
            // Qty
            // 
            this.Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Qty.DataPropertyName = "Quantity";
            this.Qty.HeaderText = "数量";
            this.Qty.MinimumWidth = 100;
            this.Qty.Name = "Qty";
            this.Qty.Width = 175;
            // 
            // 库区
            // 
            this.库区.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.库区.DataPropertyName = "Tower";
            this.库区.FillWeight = 83.89111F;
            this.库区.HeaderText = "库区";
            this.库区.MinimumWidth = 120;
            this.库区.Name = "库区";
            this.库区.ReadOnly = true;
            this.库区.Width = 120;
            // 
            // colLocation
            // 
            this.colLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colLocation.DataPropertyName = "Location";
            this.colLocation.FillWeight = 95.35567F;
            this.colLocation.HeaderText = "储位";
            this.colLocation.MinimumWidth = 130;
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            this.colLocation.Width = 150;
            // 
            // 料盘类型
            // 
            this.料盘类型.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.料盘类型.DataPropertyName = "ReelTypeDes";
            this.料盘类型.FillWeight = 154.0412F;
            this.料盘类型.HeaderText = "料盘类型";
            this.料盘类型.MinimumWidth = 120;
            this.料盘类型.Name = "料盘类型";
            this.料盘类型.ReadOnly = true;
            this.料盘类型.Width = 120;
            // 
            // 入库时间
            // 
            this.入库时间.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.入库时间.DataPropertyName = "SaveTime";
            this.入库时间.FillWeight = 179.0699F;
            this.入库时间.HeaderText = "入库时间";
            this.入库时间.MinimumWidth = 150;
            this.入库时间.Name = "入库时间";
            this.入库时间.ReadOnly = true;
            this.入库时间.Width = 150;
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 1;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.Controls.Add(this.statusStrip2, 0, 3);
            this.tlpLayout.Controls.Add(this.panel2, 0, 1);
            this.tlpLayout.Controls.Add(this.dataGridViewSelect, 0, 2);
            this.tlpLayout.Controls.Add(this.tlpConditions, 0, 0);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 34);
            this.tlpLayout.Margin = new System.Windows.Forms.Padding(2, 34, 2, 2);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 4;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpLayout.Size = new System.Drawing.Size(1427, 673);
            this.tlpLayout.TabIndex = 64;
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
            this.statusStrip2.Location = new System.Drawing.Point(0, 638);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip2.Size = new System.Drawing.Size(682, 23);
            this.statusStrip2.TabIndex = 65;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 95);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1423, 31);
            this.panel2.TabIndex = 62;
            // 
            // tlpConditions
            // 
            this.tlpConditions.ColumnCount = 15;
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.Controls.Add(this.lblShelfSide, 4, 1);
            this.tlpConditions.Controls.Add(this.cbShelfSide, 5, 1);
            this.tlpConditions.Controls.Add(this.label12, 2, 1);
            this.tlpConditions.Controls.Add(this.cmbArea, 3, 1);
            this.tlpConditions.Controls.Add(this.btnSearch, 5, 2);
            this.tlpConditions.Controls.Add(this.btnBuildTransfer, 7, 2);
            this.tlpConditions.Controls.Add(this.label2, 0, 2);
            this.tlpConditions.Controls.Add(this.cbType, 1, 2);
            this.tlpConditions.Controls.Add(this.lblPercent, 2, 2);
            this.tlpConditions.Controls.Add(this.nupPercent, 3, 2);
            this.tlpConditions.Controls.Add(this.label3, 0, 1);
            this.tlpConditions.Controls.Add(this.tbMaterialNo, 1, 1);
            this.tlpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditions.Location = new System.Drawing.Point(3, 3);
            this.tlpConditions.Name = "tlpConditions";
            this.tlpConditions.RowCount = 4;
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditions.Size = new System.Drawing.Size(1421, 87);
            this.tlpConditions.TabIndex = 64;
            // 
            // lblShelfSide
            // 
            this.lblShelfSide.AutoSize = true;
            this.lblShelfSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShelfSide.Location = new System.Drawing.Point(469, 8);
            this.lblShelfSide.Name = "lblShelfSide";
            this.lblShelfSide.Size = new System.Drawing.Size(87, 35);
            this.lblShelfSide.TabIndex = 70;
            this.lblShelfSide.Text = "货架：";
            this.lblShelfSide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblShelfSide.Visible = false;
            // 
            // cbShelfSide
            // 
            this.cbShelfSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbShelfSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShelfSide.FormattingEnabled = true;
            this.cbShelfSide.Location = new System.Drawing.Point(562, 11);
            this.cbShelfSide.Name = "cbShelfSide";
            this.cbShelfSide.Size = new System.Drawing.Size(134, 22);
            this.cbShelfSide.TabIndex = 71;
            this.cbShelfSide.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 35);
            this.label2.TabIndex = 72;
            this.label2.Text = "盘点模式：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbType
            // 
            this.cbType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(96, 46);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(134, 22);
            this.cbType.TabIndex = 73;
            this.cbType.SelectionChangeCommitted += new System.EventHandler(this.CbType_SelectionChangeCommitted);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPercent.Location = new System.Drawing.Point(236, 43);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(87, 35);
            this.lblPercent.TabIndex = 74;
            this.lblPercent.Text = "抽检比例：";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nupPercent
            // 
            this.nupPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nupPercent.Location = new System.Drawing.Point(329, 46);
            this.nupPercent.Name = "nupPercent";
            this.nupPercent.Size = new System.Drawing.Size(134, 22);
            this.nupPercent.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 35);
            this.label3.TabIndex = 76;
            this.label3.Text = "料号：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMaterialNo
            // 
            this.tbMaterialNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMaterialNo.Location = new System.Drawing.Point(96, 11);
            this.tbMaterialNo.Name = "tbMaterialNo";
            this.tbMaterialNo.Size = new System.Drawing.Size(134, 22);
            this.tbMaterialNo.TabIndex = 77;
            // 
            // FrmInventoryOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 707);
            this.Controls.Add(this.tlpLayout);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmInventoryOrder";
            this.Text = "创建盘点单";
            this.Controls.SetChildIndex(this.tlpLayout, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).EndInit();
            this.tlpLayout.ResumeLayout(false);
            this.tlpLayout.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tlpConditions.ResumeLayout(false);
            this.tlpConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPercent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewSelect;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Button btnBuildTransfer;
        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tlpConditions;
        private System.Windows.Forms.ComboBox cbShelfSide;
        private System.Windows.Forms.Label lblShelfSide;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.NumericUpDown nupPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn 供货厂家;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn 库区;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn 料盘类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入库时间;
    }
}