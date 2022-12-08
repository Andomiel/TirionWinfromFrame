
namespace iWms.Form
{
    partial class FrmWareHouseDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPause = new DevExpress.XtraEditors.SimpleButton();
            this.btnFinish = new DevExpress.XtraEditors.SimpleButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbSorting = new System.Windows.Forms.CheckBox();
            this.cbAsrs = new System.Windows.Forms.CheckBox();
            this.cbLightShelf = new System.Windows.Forms.CheckBox();
            this.cbReform = new System.Windows.Forms.CheckBox();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLock = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblOrderNoTitle = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblTypeTitle = new System.Windows.Forms.Label();
            this.gridWMS = new System.Windows.Forms.DataGridView();
            this.WZ_BM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RK_RKSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridIWMS = new System.Windows.Forms.DataGridView();
            this.ReelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnForceFinish = new DevExpress.XtraEditors.SimpleButton();
            this.tlpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIWMS)).BeginInit();
            this.tlpLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(1, 1);
            this.btnPause.Margin = new System.Windows.Forms.Padding(1);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(114, 33);
            this.btnPause.TabIndex = 0;
            this.btnPause.Text = "暂停入库";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(141, 1);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(1);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(114, 33);
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "完成入库";
            this.btnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 45000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.lblTypeName);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblLock);
            this.panel1.Controls.Add(this.lblOrderNo);
            this.panel1.Controls.Add(this.lblOrderNoTitle);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.lblTypeTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1248, 85);
            this.panel1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cbSorting);
            this.flowLayoutPanel1.Controls.Add(this.cbAsrs);
            this.flowLayoutPanel1.Controls.Add(this.cbLightShelf);
            this.flowLayoutPanel1.Controls.Add(this.cbReform);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(83, 41);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(801, 33);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // cbSorting
            // 
            this.cbSorting.AutoSize = true;
            this.cbSorting.Location = new System.Drawing.Point(3, 3);
            this.cbSorting.Name = "cbSorting";
            this.cbSorting.Size = new System.Drawing.Size(62, 18);
            this.cbSorting.TabIndex = 13;
            this.cbSorting.Text = "理料区";
            this.cbSorting.UseVisualStyleBackColor = true;
            this.cbSorting.CheckedChanged += new System.EventHandler(this.cbReform_CheckedChanged);
            // 
            // cbAsrs
            // 
            this.cbAsrs.AutoSize = true;
            this.cbAsrs.Location = new System.Drawing.Point(71, 3);
            this.cbAsrs.Name = "cbAsrs";
            this.cbAsrs.Size = new System.Drawing.Size(62, 18);
            this.cbAsrs.TabIndex = 14;
            this.cbAsrs.Text = "智能仓";
            this.cbAsrs.UseVisualStyleBackColor = true;
            this.cbAsrs.CheckedChanged += new System.EventHandler(this.cbReform_CheckedChanged);
            // 
            // cbLightShelf
            // 
            this.cbLightShelf.AutoSize = true;
            this.cbLightShelf.Location = new System.Drawing.Point(139, 3);
            this.cbLightShelf.Name = "cbLightShelf";
            this.cbLightShelf.Size = new System.Drawing.Size(74, 18);
            this.cbLightShelf.TabIndex = 15;
            this.cbLightShelf.Text = "亮灯料架";
            this.cbLightShelf.UseVisualStyleBackColor = true;
            this.cbLightShelf.CheckedChanged += new System.EventHandler(this.cbReform_CheckedChanged);
            // 
            // cbReform
            // 
            this.cbReform.AutoSize = true;
            this.cbReform.Location = new System.Drawing.Point(219, 3);
            this.cbReform.Name = "cbReform";
            this.cbReform.Size = new System.Drawing.Size(74, 18);
            this.cbReform.TabIndex = 16;
            this.cbReform.Text = "改造货架";
            this.cbReform.UseVisualStyleBackColor = true;
            this.cbReform.CheckedChanged += new System.EventHandler(this.cbReform_CheckedChanged);
            // 
            // lblTypeName
            // 
            this.lblTypeName.AutoSize = true;
            this.lblTypeName.Location = new System.Drawing.Point(87, 10);
            this.lblTypeName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(55, 14);
            this.lblTypeName.TabIndex = 12;
            this.lblTypeName.Text = "调拨入库";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 85);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1105, 444);
            this.panel2.TabIndex = 11;
            // 
            // lblLock
            // 
            this.lblLock.AutoSize = true;
            this.lblLock.Location = new System.Drawing.Point(7, 45);
            this.lblLock.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblLock.Name = "lblLock";
            this.lblLock.Size = new System.Drawing.Size(67, 14);
            this.lblLock.TabIndex = 7;
            this.lblLock.Text = "仓储锁定：";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(303, 10);
            this.lblOrderNo.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(78, 14);
            this.lblOrderNo.TabIndex = 3;
            this.lblOrderNo.Text = "CN20210202";
            // 
            // lblOrderNoTitle
            // 
            this.lblOrderNoTitle.AutoSize = true;
            this.lblOrderNoTitle.Location = new System.Drawing.Point(223, 10);
            this.lblOrderNoTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblOrderNoTitle.Name = "lblOrderNoTitle";
            this.lblOrderNoTitle.Size = new System.Drawing.Size(67, 14);
            this.lblOrderNoTitle.TabIndex = 2;
            this.lblOrderNoTitle.Text = "工单编号：";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(185, 10);
            this.lblType.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(36, 14);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "DBRK";
            this.lblType.Visible = false;
            // 
            // lblTypeTitle
            // 
            this.lblTypeTitle.AutoSize = true;
            this.lblTypeTitle.Location = new System.Drawing.Point(7, 10);
            this.lblTypeTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTypeTitle.Name = "lblTypeTitle";
            this.lblTypeTitle.Size = new System.Drawing.Size(67, 14);
            this.lblTypeTitle.TabIndex = 0;
            this.lblTypeTitle.Text = "工单类型：";
            // 
            // gridWMS
            // 
            this.gridWMS.AllowUserToAddRows = false;
            this.gridWMS.AllowUserToDeleteRows = false;
            this.gridWMS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridWMS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridWMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridWMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridWMS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WZ_BM,
            this.RK_RKSL,
            this.State});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridWMS.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridWMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridWMS.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridWMS.Location = new System.Drawing.Point(3, 3);
            this.gridWMS.Name = "gridWMS";
            this.gridWMS.ReadOnly = true;
            this.gridWMS.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.gridWMS.RowTemplate.Height = 23;
            this.gridWMS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridWMS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridWMS.Size = new System.Drawing.Size(493, 712);
            this.gridWMS.TabIndex = 11;
            this.gridWMS.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridWMS_CellFormatting);
            this.gridWMS.SelectionChanged += new System.EventHandler(this.gridWMS_SelectionChanged);
            // 
            // WZ_BM
            // 
            this.WZ_BM.DataPropertyName = "MaterialNo";
            this.WZ_BM.HeaderText = "物料编号";
            this.WZ_BM.MinimumWidth = 10;
            this.WZ_BM.Name = "WZ_BM";
            this.WZ_BM.ReadOnly = true;
            // 
            // RK_RKSL
            // 
            this.RK_RKSL.DataPropertyName = "RequireCount";
            this.RK_RKSL.HeaderText = "需求数量";
            this.RK_RKSL.MinimumWidth = 10;
            this.RK_RKSL.Name = "RK_RKSL";
            this.RK_RKSL.ReadOnly = true;
            // 
            // State
            // 
            this.State.DataPropertyName = "ReceiveStatusDisplay";
            this.State.HeaderText = "状态";
            this.State.MinimumWidth = 10;
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // gridIWMS
            // 
            this.gridIWMS.AllowUserToAddRows = false;
            this.gridIWMS.AllowUserToDeleteRows = false;
            this.gridIWMS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridIWMS.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridIWMS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridIWMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridIWMS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReelID,
            this.Qty,
            this.TowerNo,
            this.CreateTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridIWMS.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridIWMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIWMS.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridIWMS.Location = new System.Drawing.Point(502, 3);
            this.gridIWMS.Name = "gridIWMS";
            this.gridIWMS.ReadOnly = true;
            this.gridIWMS.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.gridIWMS.RowTemplate.Height = 23;
            this.gridIWMS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridIWMS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridIWMS.Size = new System.Drawing.Size(743, 712);
            this.gridIWMS.TabIndex = 12;
            // 
            // ReelID
            // 
            this.ReelID.DataPropertyName = "Upn";
            this.ReelID.HeaderText = "UPN";
            this.ReelID.MinimumWidth = 10;
            this.ReelID.Name = "ReelID";
            this.ReelID.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "InnerQty";
            this.Qty.HeaderText = "数量";
            this.Qty.MinimumWidth = 10;
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // TowerNo
            // 
            this.TowerNo.DataPropertyName = "TowerDisplay";
            this.TowerNo.HeaderText = "库区";
            this.TowerNo.MinimumWidth = 10;
            this.TowerNo.Name = "TowerNo";
            this.TowerNo.ReadOnly = true;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "入库时间";
            this.CreateTime.MinimumWidth = 10;
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            // 
            // btnForceFinish
            // 
            this.btnForceFinish.Location = new System.Drawing.Point(398, 1);
            this.btnForceFinish.Margin = new System.Windows.Forms.Padding(1);
            this.btnForceFinish.Name = "btnForceFinish";
            this.btnForceFinish.Size = new System.Drawing.Size(114, 33);
            this.btnForceFinish.TabIndex = 13;
            this.btnForceFinish.Text = "强制入库";
            this.btnForceFinish.Visible = false;
            this.btnForceFinish.Click += new System.EventHandler(this.btnForceFinish_Click);
            // 
            // tlpLayout
            // 
            this.tlpLayout.ColumnCount = 2;
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpLayout.Controls.Add(this.gridWMS, 0, 0);
            this.tlpLayout.Controls.Add(this.gridIWMS, 1, 0);
            this.tlpLayout.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tlpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLayout.Location = new System.Drawing.Point(0, 85);
            this.tlpLayout.Name = "tlpLayout";
            this.tlpLayout.RowCount = 2;
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpLayout.Size = new System.Drawing.Size(1248, 753);
            this.tlpLayout.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnPause, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnForceFinish, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFinish, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(499, 718);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(749, 35);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(936, 45);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // FrmWareHouseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 838);
            this.Controls.Add(this.tlpLayout);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWareHouseDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入库明细";
            this.Load += new System.EventHandler(this.FrmWareHouseDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIWMS)).EndInit();
            this.tlpLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPause;
        private DevExpress.XtraEditors.SimpleButton btnFinish;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTypeTitle;
        private System.Windows.Forms.Label lblOrderNoTitle;
        private System.Windows.Forms.Label lblLock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridWMS;
        private System.Windows.Forms.DataGridView gridIWMS;
        public System.Windows.Forms.Label lblType;
        public System.Windows.Forms.Label lblOrderNo;
        public System.Windows.Forms.Label lblTypeName;
        private DevExpress.XtraEditors.SimpleButton btnForceFinish;
        private System.Windows.Forms.DataGridViewTextBoxColumn WZ_BM;
        private System.Windows.Forms.DataGridViewTextBoxColumn RK_RKSL;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.TableLayoutPanel tlpLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox cbLightShelf;
        private System.Windows.Forms.CheckBox cbAsrs;
        private System.Windows.Forms.CheckBox cbSorting;
        private System.Windows.Forms.CheckBox cbReform;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}