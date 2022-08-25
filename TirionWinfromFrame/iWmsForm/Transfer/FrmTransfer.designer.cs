
namespace iWms.Form
{
    partial class FrmTransfer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUPN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPartNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpCycleEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpCycleStart = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.cbMSD = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSerialNoEnd = new System.Windows.Forms.TextBox();
            this.txtSerialNoStart = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TextSupply = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbMateType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbTarget = new System.Windows.Forms.ComboBox();
            this.btnBuildTransfer = new System.Windows.Forms.Button();
            this.btnSelectReverse = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.dataGridViewTransfer = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewSelect = new System.Windows.Forms.DataGridView();
            this.DGVSelect选择 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.供货厂家 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.库区 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.料盘类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入库时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.gbCondition = new System.Windows.Forms.GroupBox();
            this.tlpConditions = new System.Windows.Forms.TableLayoutPanel();
            this.txtExceedStart = new System.Windows.Forms.TextBox();
            this.txtExceedEnd = new System.Windows.Forms.TextBox();
            this.lblShelfSide = new System.Windows.Forms.Label();
            this.cbShelfSide = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).BeginInit();
            this.tlpLayout.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbCondition.SuspendLayout();
            this.tlpConditions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(1285, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(111, 29);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(2, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 35);
            this.label3.TabIndex = 21;
            this.label3.Text = "UPN：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbUPN
            // 
            this.tbUPN.Location = new System.Drawing.Point(95, 2);
            this.tbUPN.Margin = new System.Windows.Forms.Padding(2);
            this.tbUPN.Name = "tbUPN";
            this.tbUPN.Size = new System.Drawing.Size(135, 22);
            this.tbUPN.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(2, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 35);
            this.label4.TabIndex = 23;
            this.label4.Text = "料号：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPartNumber
            // 
            this.tbPartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPartNumber.Location = new System.Drawing.Point(95, 37);
            this.tbPartNumber.Margin = new System.Windows.Forms.Padding(2);
            this.tbPartNumber.Name = "tbPartNumber";
            this.tbPartNumber.Size = new System.Drawing.Size(136, 22);
            this.tbPartNumber.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(468, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 35);
            this.label5.TabIndex = 25;
            this.label5.Text = "入库时间：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpStart
            // 
            this.dtpStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStart.Location = new System.Drawing.Point(561, 72);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(136, 22);
            this.dtpStart.TabIndex = 26;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEnd.Location = new System.Drawing.Point(724, 72);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(136, 22);
            this.dtpEnd.TabIndex = 27;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(701, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 35);
            this.label6.TabIndex = 28;
            this.label6.Text = "-";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(1285, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 29);
            this.button2.TabIndex = 67;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Location = new System.Drawing.Point(702, 35);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 35);
            this.label20.TabIndex = 64;
            this.label20.Text = "-";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Location = new System.Drawing.Point(469, 35);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 35);
            this.label21.TabIndex = 62;
            this.label21.Text = "超期：";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(701, 0);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 35);
            this.label18.TabIndex = 61;
            this.label18.Text = "-";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpCycleEnd
            // 
            this.dtpCycleEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpCycleEnd.Location = new System.Drawing.Point(724, 2);
            this.dtpCycleEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dtpCycleEnd.Name = "dtpCycleEnd";
            this.dtpCycleEnd.Size = new System.Drawing.Size(136, 22);
            this.dtpCycleEnd.TabIndex = 60;
            this.dtpCycleEnd.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // dtpCycleStart
            // 
            this.dtpCycleStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpCycleStart.Location = new System.Drawing.Point(561, 2);
            this.dtpCycleStart.Margin = new System.Windows.Forms.Padding(2);
            this.dtpCycleStart.Name = "dtpCycleStart";
            this.dtpCycleStart.Size = new System.Drawing.Size(136, 22);
            this.dtpCycleStart.TabIndex = 59;
            this.dtpCycleStart.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(469, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 35);
            this.label16.TabIndex = 58;
            this.label16.Text = "生产日期：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMSD
            // 
            this.cbMSD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMSD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMSD.FormattingEnabled = true;
            this.cbMSD.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "2A",
            "3",
            "3A"});
            this.cbMSD.Location = new System.Drawing.Point(329, 38);
            this.cbMSD.Name = "cbMSD";
            this.cbMSD.Size = new System.Drawing.Size(134, 22);
            this.cbMSD.TabIndex = 57;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(236, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 35);
            this.label17.TabIndex = 56;
            this.label17.Text = "MSD等级：";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(1098, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 35);
            this.label10.TabIndex = 55;
            this.label10.Text = "-";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSerialNoEnd
            // 
            this.txtSerialNoEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSerialNoEnd.Location = new System.Drawing.Point(1121, 3);
            this.txtSerialNoEnd.Name = "txtSerialNoEnd";
            this.txtSerialNoEnd.Size = new System.Drawing.Size(111, 22);
            this.txtSerialNoEnd.TabIndex = 54;
            // 
            // txtSerialNoStart
            // 
            this.txtSerialNoStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSerialNoStart.Location = new System.Drawing.Point(958, 3);
            this.txtSerialNoStart.Name = "txtSerialNoStart";
            this.txtSerialNoStart.Size = new System.Drawing.Size(134, 22);
            this.txtSerialNoStart.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(865, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 35);
            this.label9.TabIndex = 52;
            this.label9.Text = "流水号：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextSupply
            // 
            this.TextSupply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextSupply.Location = new System.Drawing.Point(96, 73);
            this.TextSupply.Name = "TextSupply";
            this.TextSupply.Size = new System.Drawing.Size(134, 22);
            this.TextSupply.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 35);
            this.label11.TabIndex = 50;
            this.label11.Text = "供货厂家：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMateType
            // 
            this.cbMateType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMateType.FormattingEnabled = true;
            this.cbMateType.Items.AddRange(new object[] {
            "F",
            "S",
            "T"});
            this.cbMateType.Location = new System.Drawing.Point(329, 3);
            this.cbMateType.Name = "cbMateType";
            this.cbMateType.Size = new System.Drawing.Size(134, 22);
            this.cbMateType.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(236, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 35);
            this.label15.TabIndex = 48;
            this.label15.Text = "料盘类型：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(865, 35);
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
            this.cmbArea.Location = new System.Drawing.Point(958, 38);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(134, 22);
            this.cmbArea.TabIndex = 43;
            this.cmbArea.SelectionChangeCommitted += new System.EventHandler(this.cmbArea_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(817, 8);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 14);
            this.label7.TabIndex = 46;
            this.label7.Text = "目标库区：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTarget
            // 
            this.cbTarget.FormattingEnabled = true;
            this.cbTarget.Location = new System.Drawing.Point(896, 3);
            this.cbTarget.Margin = new System.Windows.Forms.Padding(2);
            this.cbTarget.Name = "cbTarget";
            this.cbTarget.Size = new System.Drawing.Size(135, 22);
            this.cbTarget.TabIndex = 47;
            // 
            // btnBuildTransfer
            // 
            this.btnBuildTransfer.Location = new System.Drawing.Point(1078, 1);
            this.btnBuildTransfer.Name = "btnBuildTransfer";
            this.btnBuildTransfer.Size = new System.Drawing.Size(110, 28);
            this.btnBuildTransfer.TabIndex = 45;
            this.btnBuildTransfer.Text = "创建移库单";
            this.btnBuildTransfer.UseVisualStyleBackColor = true;
            this.btnBuildTransfer.Click += new System.EventHandler(this.btnBuildTransfer_Click);
            // 
            // btnSelectReverse
            // 
            this.btnSelectReverse.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSelectReverse.Location = new System.Drawing.Point(177, 2);
            this.btnSelectReverse.Name = "btnSelectReverse";
            this.btnSelectReverse.Size = new System.Drawing.Size(52, 27);
            this.btnSelectReverse.TabIndex = 63;
            this.btnSelectReverse.Text = "反选";
            this.btnSelectReverse.UseVisualStyleBackColor = true;
            this.btnSelectReverse.Click += new System.EventHandler(this.btnSelectReverse_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSelectAll.Location = new System.Drawing.Point(97, 2);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(52, 27);
            this.btnSelectAll.TabIndex = 62;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // dataGridViewTransfer
            // 
            this.dataGridViewTransfer.AllowUserToAddRows = false;
            this.dataGridViewTransfer.AllowUserToDeleteRows = false;
            this.dataGridViewTransfer.AllowUserToResizeRows = false;
            this.dataGridViewTransfer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTransfer.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTransfer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTransfer.ColumnHeadersHeight = 24;
            this.dataGridViewTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewTransfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTransfer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTransfer.EnableHeadersVisualStyles = false;
            this.dataGridViewTransfer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewTransfer.Location = new System.Drawing.Point(3, 488);
            this.dataGridViewTransfer.Name = "dataGridViewTransfer";
            this.dataGridViewTransfer.RowHeadersWidth = 30;
            this.dataGridViewTransfer.RowTemplate.Height = 23;
            this.dataGridViewTransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewTransfer.Size = new System.Drawing.Size(1421, 182);
            this.dataGridViewTransfer.TabIndex = 61;
            this.dataGridViewTransfer.Tag = "9999";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "SelectFlag";
            this.dataGridViewCheckBoxColumn1.FillWeight = 26.40847F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "选择";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 8;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "reelid";
            this.dataGridViewTextBoxColumn11.FillWeight = 52.118F;
            this.dataGridViewTextBoxColumn11.HeaderText = "UPN";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "PartNumber";
            this.dataGridViewTextBoxColumn12.FillWeight = 71.81016F;
            this.dataGridViewTextBoxColumn12.HeaderText = "料号";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Qty";
            this.dataGridViewTextBoxColumn13.HeaderText = "数量";
            this.dataGridViewTextBoxColumn13.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("宋体", 9F);
            this.btnRemove.Location = new System.Drawing.Point(182, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(52, 27);
            this.btnRemove.TabIndex = 60;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSelect.Location = new System.Drawing.Point(101, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(52, 27);
            this.btnSelect.TabIndex = 57;
            this.btnSelect.Text = "选取";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 59;
            this.label2.Text = "移库单";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 58;
            this.label1.Text = "筛选列表";
            // 
            // dataGridViewSelect
            // 
            this.dataGridViewSelect.AllowUserToAddRows = false;
            this.dataGridViewSelect.AllowUserToDeleteRows = false;
            this.dataGridViewSelect.AllowUserToResizeRows = false;
            this.dataGridViewSelect.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSelect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSelect.ColumnHeadersHeight = 24;
            this.dataGridViewSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSelect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVSelect选择,
            this.UPN,
            this.PartNumber,
            this.供货厂家,
            this.DateCode,
            this.SerialNo,
            this.Qty,
            this.库区,
            this.Location,
            this.料盘类型,
            this.入库时间});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSelect.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelect.EnableHeadersVisualStyles = false;
            this.dataGridViewSelect.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewSelect.Location = new System.Drawing.Point(3, 171);
            this.dataGridViewSelect.Name = "dataGridViewSelect";
            this.dataGridViewSelect.RowHeadersWidth = 30;
            this.dataGridViewSelect.RowTemplate.Height = 23;
            this.dataGridViewSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewSelect.Size = new System.Drawing.Size(1421, 276);
            this.dataGridViewSelect.TabIndex = 56;
            this.dataGridViewSelect.Tag = "9999";
            // 
            // DGVSelect选择
            // 
            this.DGVSelect选择.DataPropertyName = "SelectFlag";
            this.DGVSelect选择.FillWeight = 26.40847F;
            this.DGVSelect选择.HeaderText = "选择";
            this.DGVSelect选择.MinimumWidth = 9;
            this.DGVSelect选择.Name = "DGVSelect选择";
            this.DGVSelect选择.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGVSelect选择.Width = 40;
            // 
            // UPN
            // 
            this.UPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UPN.DataPropertyName = "reelid";
            this.UPN.FillWeight = 60F;
            this.UPN.HeaderText = "UPN";
            this.UPN.MinimumWidth = 200;
            this.UPN.Name = "UPN";
            this.UPN.ReadOnly = true;
            // 
            // PartNumber
            // 
            this.PartNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PartNumber.DataPropertyName = "PartNumber";
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
            this.Qty.DataPropertyName = "Qty";
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
            // Location
            // 
            this.Location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Location.DataPropertyName = "Location";
            this.Location.FillWeight = 95.35567F;
            this.Location.HeaderText = "储位";
            this.Location.MinimumWidth = 130;
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Width = 150;
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
            this.tlpLayout.Controls.Add(this.dataGridViewTransfer, 0, 4);
            this.tlpLayout.Controls.Add(this.panel2, 0, 1);
            this.tlpLayout.Controls.Add(this.panel4, 0, 3);
            this.tlpLayout.Controls.Add(this.dataGridViewSelect, 0, 2);
            this.tlpLayout.Controls.Add(this.gbCondition, 0, 0);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 34);
            this.tlpLayout.Margin = new System.Windows.Forms.Padding(2, 34, 2, 2);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 5;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpLayout.Size = new System.Drawing.Size(1427, 673);
            this.tlpLayout.TabIndex = 64;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnSelectReverse);
            this.panel2.Controls.Add(this.btnSelectAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 135);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1423, 31);
            this.panel2.TabIndex = 62;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnImport);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.btnSelect);
            this.panel4.Controls.Add(this.cbTarget);
            this.panel4.Controls.Add(this.btnRemove);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnBuildTransfer);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(2, 452);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1423, 31);
            this.panel4.TabIndex = 63;
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("宋体", 9F);
            this.btnImport.Location = new System.Drawing.Point(273, 2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(52, 27);
            this.btnImport.TabIndex = 61;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // gbCondition
            // 
            this.gbCondition.Controls.Add(this.tlpConditions);
            this.gbCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCondition.Location = new System.Drawing.Point(0, 0);
            this.gbCondition.Margin = new System.Windows.Forms.Padding(0);
            this.gbCondition.Name = "gbCondition";
            this.gbCondition.Size = new System.Drawing.Size(1427, 133);
            this.gbCondition.TabIndex = 65;
            this.gbCondition.TabStop = false;
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
            this.tlpConditions.Controls.Add(this.label3, 0, 0);
            this.tlpConditions.Controls.Add(this.tbUPN, 1, 0);
            this.tlpConditions.Controls.Add(this.label20, 6, 1);
            this.tlpConditions.Controls.Add(this.label4, 0, 1);
            this.tlpConditions.Controls.Add(this.label21, 4, 1);
            this.tlpConditions.Controls.Add(this.tbPartNumber, 1, 1);
            this.tlpConditions.Controls.Add(this.dtpCycleEnd, 7, 0);
            this.tlpConditions.Controls.Add(this.label18, 6, 0);
            this.tlpConditions.Controls.Add(this.label11, 0, 2);
            this.tlpConditions.Controls.Add(this.TextSupply, 1, 2);
            this.tlpConditions.Controls.Add(this.dtpEnd, 7, 2);
            this.tlpConditions.Controls.Add(this.label6, 6, 2);
            this.tlpConditions.Controls.Add(this.dtpCycleStart, 5, 0);
            this.tlpConditions.Controls.Add(this.label15, 2, 0);
            this.tlpConditions.Controls.Add(this.dtpStart, 5, 2);
            this.tlpConditions.Controls.Add(this.label16, 4, 0);
            this.tlpConditions.Controls.Add(this.label5, 4, 2);
            this.tlpConditions.Controls.Add(this.cbMateType, 3, 0);
            this.tlpConditions.Controls.Add(this.label17, 2, 1);
            this.tlpConditions.Controls.Add(this.cbMSD, 3, 1);
            this.tlpConditions.Controls.Add(this.txtExceedStart, 5, 1);
            this.tlpConditions.Controls.Add(this.txtExceedEnd, 7, 1);
            this.tlpConditions.Controls.Add(this.lblShelfSide, 8, 2);
            this.tlpConditions.Controls.Add(this.cbShelfSide, 9, 2);
            this.tlpConditions.Controls.Add(this.label12, 8, 1);
            this.tlpConditions.Controls.Add(this.cmbArea, 9, 1);
            this.tlpConditions.Controls.Add(this.label9, 8, 0);
            this.tlpConditions.Controls.Add(this.txtSerialNoStart, 9, 0);
            this.tlpConditions.Controls.Add(this.label10, 10, 0);
            this.tlpConditions.Controls.Add(this.txtSerialNoEnd, 11, 0);
            this.tlpConditions.Controls.Add(this.btnSearch, 13, 0);
            this.tlpConditions.Controls.Add(this.button2, 13, 1);
            this.tlpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditions.Location = new System.Drawing.Point(3, 18);
            this.tlpConditions.Margin = new System.Windows.Forms.Padding(0);
            this.tlpConditions.Name = "tlpConditions";
            this.tlpConditions.RowCount = 4;
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpConditions.Size = new System.Drawing.Size(1421, 112);
            this.tlpConditions.TabIndex = 64;
            // 
            // txtExceedStart
            // 
            this.txtExceedStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExceedStart.Location = new System.Drawing.Point(561, 37);
            this.txtExceedStart.Margin = new System.Windows.Forms.Padding(2);
            this.txtExceedStart.Name = "txtExceedStart";
            this.txtExceedStart.Size = new System.Drawing.Size(136, 22);
            this.txtExceedStart.TabIndex = 72;
            // 
            // txtExceedEnd
            // 
            this.txtExceedEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExceedEnd.Location = new System.Drawing.Point(724, 37);
            this.txtExceedEnd.Margin = new System.Windows.Forms.Padding(2);
            this.txtExceedEnd.Name = "txtExceedEnd";
            this.txtExceedEnd.Size = new System.Drawing.Size(136, 22);
            this.txtExceedEnd.TabIndex = 73;
            // 
            // lblShelfSide
            // 
            this.lblShelfSide.AutoSize = true;
            this.lblShelfSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShelfSide.Location = new System.Drawing.Point(865, 70);
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
            this.cbShelfSide.Location = new System.Drawing.Point(958, 73);
            this.cbShelfSide.Name = "cbShelfSide";
            this.cbShelfSide.Size = new System.Drawing.Size(134, 22);
            this.cbShelfSide.TabIndex = 71;
            this.cbShelfSide.Visible = false;
            // 
            // FrmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 707);
            this.Controls.Add(this.tlpLayout);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmTransfer";
            this.Text = "移库";
            this.Controls.SetChildIndex(this.tlpLayout, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).EndInit();
            this.tlpLayout.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gbCondition.ResumeLayout(false);
            this.tlpConditions.ResumeLayout(false);
            this.tlpConditions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUPN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPartNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectReverse;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.DataGridView dataGridViewTransfer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewSelect;
        private System.Windows.Forms.ComboBox cbMateType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.ComboBox cbMSD;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSerialNoEnd;
        private System.Windows.Forms.TextBox txtSerialNoStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TextSupply;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpCycleEnd;
        private System.Windows.Forms.DateTimePicker dtpCycleStart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTarget;
        private System.Windows.Forms.Button btnBuildTransfer;
        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tlpConditions;
        private System.Windows.Forms.ComboBox cbShelfSide;
        private System.Windows.Forms.Label lblShelfSide;
        private System.Windows.Forms.TextBox txtExceedStart;
        private System.Windows.Forms.TextBox txtExceedEnd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGVSelect选择;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn 供货厂家;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn 库区;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn 料盘类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入库时间;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.GroupBox gbCondition;
    }
}