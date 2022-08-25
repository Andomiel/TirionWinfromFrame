
namespace iWms.Form
{
    partial class FrmLogs
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
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pgLog = new System.Windows.Forms.PropertyGrid();
            this.tlpLoayout.SuspendLayout();
            this.gbConditions.SuspendLayout();
            this.tlpConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpLoayout
            // 
            this.tlpLoayout.ColumnCount = 2;
            this.tlpLoayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpLoayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpLoayout.Controls.Add(this.gbConditions, 0, 0);
            this.tlpLoayout.Controls.Add(this.dgvLogs, 0, 1);
            this.tlpLoayout.Controls.Add(this.pgLog, 1, 1);
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
            this.tlpLoayout.SetColumnSpan(this.gbConditions, 2);
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
            this.tlpConditions.Controls.Add(this.tbKey, 2, 1);
            this.tlpConditions.Controls.Add(this.btnQuery, 7, 1);
            this.tlpConditions.Controls.Add(this.label2, 4, 1);
            this.tlpConditions.Controls.Add(this.dtpTime, 5, 1);
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
            this.label1.Text = "查询条件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbKey
            // 
            this.tlpConditions.SetColumnSpan(this.tbKey, 2);
            this.tbKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbKey.Location = new System.Drawing.Point(143, 44);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(274, 22);
            this.tbKey.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuery.Location = new System.Drawing.Point(703, 44);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(134, 24);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "查询日志";
            this.btnQuery.UseVisualStyleBackColor = true;
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
            this.label2.Text = "日期";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "yyyy-MM-dd";
            this.dtpTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(516, 44);
            this.dtpTime.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(134, 22);
            this.dtpTime.TabIndex = 4;
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTitle,
            this.colTime,
            this.colRequest,
            this.colResult});
            this.dgvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLogs.Location = new System.Drawing.Point(3, 143);
            this.dgvLogs.MultiSelect = false;
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowTemplate.Height = 23;
            this.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogs.Size = new System.Drawing.Size(720, 449);
            this.dgvLogs.TabIndex = 1;
            this.dgvLogs.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvLogs_RowPostPaint);
            this.dgvLogs.SelectionChanged += new System.EventHandler(this.DgvLogs_SelectionChanged);
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "LogTitle";
            this.colTitle.HeaderText = "描述";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // colTime
            // 
            this.colTime.DataPropertyName = "LogTime";
            this.colTime.HeaderText = "时间";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colRequest
            // 
            this.colRequest.DataPropertyName = "RequestLimit";
            this.colRequest.HeaderText = "请求内容";
            this.colRequest.Name = "colRequest";
            this.colRequest.ReadOnly = true;
            // 
            // colResult
            // 
            this.colResult.DataPropertyName = "ResponseLimit";
            this.colResult.HeaderText = "响应内容";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            // 
            // pgLog
            // 
            this.pgLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgLog.Location = new System.Drawing.Point(729, 143);
            this.pgLog.Name = "pgLog";
            this.pgLog.Size = new System.Drawing.Size(478, 449);
            this.pgLog.TabIndex = 2;
            // 
            // FrmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 629);
            this.Controls.Add(this.tlpLoayout);
            this.Name = "FrmLogs";
            this.Text = "FrmLogs";
            this.Controls.SetChildIndex(this.tlpLoayout, 0);
            this.tlpLoayout.ResumeLayout(false);
            this.gbConditions.ResumeLayout(false);
            this.tlpConditions.ResumeLayout(false);
            this.tlpConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpLoayout;
        private System.Windows.Forms.GroupBox gbConditions;
        private System.Windows.Forms.TableLayoutPanel tlpConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.PropertyGrid pgLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTime;
    }
}