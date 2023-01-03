
namespace iWms.Form
{
    partial class FrmRegisterCfg
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
            this.tlpLoayout = new System.Windows.Forms.TableLayoutPanel();
            this.gbConditions = new System.Windows.Forms.GroupBox();
            this.tlpConditions = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaterialNo = new System.Windows.Forms.TextBox();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cbeStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.dgvConfigs = new System.Windows.Forms.DataGridView();
            this.colMaterialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tlpLoayout.SuspendLayout();
            this.gbConditions.SuspendLayout();
            this.tlpConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigs)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpLoayout
            // 
            this.tlpLoayout.ColumnCount = 1;
            this.tlpLoayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLoayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLoayout.Controls.Add(this.gbConditions, 0, 0);
            this.tlpLoayout.Controls.Add(this.dgvConfigs, 0, 1);
            this.tlpLoayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLoayout.Location = new System.Drawing.Point(0, 34);
            this.tlpLoayout.Name = "tlpLoayout";
            this.tlpLoayout.RowCount = 2;
            this.tlpLoayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpLoayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLoayout.Size = new System.Drawing.Size(1210, 595);
            this.tlpLoayout.TabIndex = 0;
            // 
            // gbConditions
            // 
            this.gbConditions.Controls.Add(this.tlpConditions);
            this.gbConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbConditions.Location = new System.Drawing.Point(3, 3);
            this.gbConditions.Name = "gbConditions";
            this.gbConditions.Size = new System.Drawing.Size(1204, 134);
            this.gbConditions.TabIndex = 0;
            this.gbConditions.TabStop = false;
            // 
            // tlpConditions
            // 
            this.tlpConditions.ColumnCount = 10;
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpConditions.Controls.Add(this.label1, 1, 1);
            this.tlpConditions.Controls.Add(this.tbMaterialNo, 2, 1);
            this.tlpConditions.Controls.Add(this.btnQuery, 7, 1);
            this.tlpConditions.Controls.Add(this.label2, 4, 1);
            this.tlpConditions.Controls.Add(this.cbeStatus, 5, 1);
            this.tlpConditions.Controls.Add(this.btnAdd, 8, 1);
            this.tlpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditions.Location = new System.Drawing.Point(3, 18);
            this.tlpConditions.Name = "tlpConditions";
            this.tlpConditions.RowCount = 3;
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditions.Size = new System.Drawing.Size(1198, 113);
            this.tlpConditions.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(50, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "料号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMaterialNo
            // 
            this.tlpConditions.SetColumnSpan(this.tbMaterialNo, 2);
            this.tbMaterialNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMaterialNo.Location = new System.Drawing.Point(143, 44);
            this.tbMaterialNo.Name = "tbMaterialNo";
            this.tbMaterialNo.Size = new System.Drawing.Size(274, 22);
            this.tbMaterialNo.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuery.Location = new System.Drawing.Point(703, 44);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(134, 24);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(423, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "状态";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbeStatus
            // 
            this.cbeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbeStatus.Location = new System.Drawing.Point(516, 44);
            this.cbeStatus.Name = "cbeStatus";
            this.cbeStatus.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cbeStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbeStatus.Size = new System.Drawing.Size(134, 20);
            this.cbeStatus.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(843, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(134, 24);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // dgvConfigs
            // 
            this.dgvConfigs.AllowUserToAddRows = false;
            this.dgvConfigs.AllowUserToDeleteRows = false;
            this.dgvConfigs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConfigs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvConfigs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfigs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaterialNo,
            this.colRemark,
            this.colStatus,
            this.colUpdateUser,
            this.colUpdateTime,
            this.colDel});
            this.dgvConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConfigs.Location = new System.Drawing.Point(3, 143);
            this.dgvConfigs.MultiSelect = false;
            this.dgvConfigs.Name = "dgvConfigs";
            this.dgvConfigs.ReadOnly = true;
            this.dgvConfigs.RowTemplate.Height = 23;
            this.dgvConfigs.Size = new System.Drawing.Size(1204, 449);
            this.dgvConfigs.TabIndex = 1;
            this.dgvConfigs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvConfigs_CellContentClick);
            this.dgvConfigs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvConfigs_CellDoubleClick);
            this.dgvConfigs.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvLogs_RowPostPaint);
            // 
            // colMaterialNo
            // 
            this.colMaterialNo.DataPropertyName = "LogTitle";
            this.colMaterialNo.HeaderText = "料号";
            this.colMaterialNo.Name = "colMaterialNo";
            this.colMaterialNo.ReadOnly = true;
            // 
            // colRemark
            // 
            this.colRemark.DataPropertyName = "LogTime";
            this.colRemark.HeaderText = "备注";
            this.colRemark.Name = "colRemark";
            this.colRemark.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "状态";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colUpdateUser
            // 
            this.colUpdateUser.DataPropertyName = "RequestLimit";
            this.colUpdateUser.HeaderText = "最后修改人";
            this.colUpdateUser.Name = "colUpdateUser";
            this.colUpdateUser.ReadOnly = true;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.DataPropertyName = "ResponseLimit";
            this.colUpdateTime.HeaderText = "最后修改时间";
            this.colUpdateTime.Name = "colUpdateTime";
            this.colUpdateTime.ReadOnly = true;
            // 
            // colDel
            // 
            this.colDel.HeaderText = "操作";
            this.colDel.Name = "colDel";
            this.colDel.ReadOnly = true;
            this.colDel.Text = "删除";
            // 
            // FrmRegisterCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 629);
            this.Controls.Add(this.tlpLoayout);
            this.Name = "FrmRegisterCfg";
            this.Text = "入库注册配置";
            this.Controls.SetChildIndex(this.tlpLoayout, 0);
            this.tlpLoayout.ResumeLayout(false);
            this.gbConditions.ResumeLayout(false);
            this.tlpConditions.ResumeLayout(false);
            this.tlpConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLoayout;
        private System.Windows.Forms.GroupBox gbConditions;
        private System.Windows.Forms.TableLayoutPanel tlpConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaterialNo;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private System.Windows.Forms.DataGridView dgvConfigs;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ComboBoxEdit cbeStatus;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpdateTime;
        private System.Windows.Forms.DataGridViewButtonColumn colDel;
    }
}