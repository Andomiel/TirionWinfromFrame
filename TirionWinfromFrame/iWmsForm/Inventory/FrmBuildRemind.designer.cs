
namespace iWms.Form
{
    partial class FrmBuildRemind
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuildCondition = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuildUpns = new DevExpress.XtraEditors.SimpleButton();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblStar = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblUser = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.meReason = new DevExpress.XtraEditors.MemoEdit();
            this.downloadClass1 = new Updater.Core.DownloadClass(this.components);
            this.meRange = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.meReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRange.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(95, 22);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(238, 14);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "按条件创建策略，或指定UPN创建策略";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(313, 304);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnBuildCondition
            // 
            this.btnBuildCondition.Location = new System.Drawing.Point(47, 304);
            this.btnBuildCondition.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuildCondition.Name = "btnBuildCondition";
            this.btnBuildCondition.Size = new System.Drawing.Size(103, 31);
            this.btnBuildCondition.TabIndex = 3;
            this.btnBuildCondition.Text = "按条件筛选";
            this.btnBuildCondition.Click += new System.EventHandler(this.BtnBuildCondition_Click);
            // 
            // btnBuildUpns
            // 
            this.btnBuildUpns.Location = new System.Drawing.Point(182, 304);
            this.btnBuildUpns.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuildUpns.Name = "btnBuildUpns";
            this.btnBuildUpns.Size = new System.Drawing.Size(103, 31);
            this.btnBuildUpns.TabIndex = 4;
            this.btnBuildUpns.Text = "指定UPN";
            this.btnBuildUpns.Click += new System.EventHandler(this.BtnBuildUpns_Click);
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(70, 187);
            this.lblRemark.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(55, 14);
            this.lblRemark.TabIndex = 5;
            this.lblRemark.Text = "物料范围";
            // 
            // lblStar
            // 
            this.lblStar.AutoSize = true;
            this.lblStar.ForeColor = System.Drawing.Color.Red;
            this.lblStar.Location = new System.Drawing.Point(377, 111);
            this.lblStar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStar.Name = "lblStar";
            this.lblStar.Size = new System.Drawing.Size(14, 14);
            this.lblStar.TabIndex = 7;
            this.lblStar.Text = "*";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(89, 78);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "操作人";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(135, 79);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(63, 14);
            this.lblUser.TabIndex = 9;
            this.lblUser.Text = "80252523";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(77, 111);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "冻结原因";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(377, 187);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "*";
            // 
            // meReason
            // 
            this.meReason.Location = new System.Drawing.Point(138, 111);
            this.meReason.Name = "meReason";
            this.meReason.Properties.MaxLength = 200;
            this.meReason.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.meReason.Size = new System.Drawing.Size(234, 66);
            this.meReason.TabIndex = 13;
            // 
            // downloadClass1
            // 
            this.downloadClass1.TempPath = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Professional\\Common7\\IDE\\temp" +
    "";
            // 
            // meRange
            // 
            this.meRange.Location = new System.Drawing.Point(138, 187);
            this.meRange.Name = "meRange";
            this.meRange.Properties.MaxLength = 200;
            this.meRange.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.meRange.Size = new System.Drawing.Size(234, 66);
            this.meRange.TabIndex = 14;
            // 
            // FrmBuildRemind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 375);
            this.ControlBox = false;
            this.Controls.Add(this.meRange);
            this.Controls.Add(this.meReason);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblStar);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.btnBuildUpns);
            this.Controls.Add(this.btnBuildCondition);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmBuildRemind";
            this.Text = "创建策略提醒";
            ((System.ComponentModel.ISupportInitialize)(this.meReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meRange.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnBuildCondition;
        private DevExpress.XtraEditors.SimpleButton btnBuildUpns;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblStar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label lblUser;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.MemoEdit meReason;
        private Updater.Core.DownloadClass downloadClass1;
        private DevExpress.XtraEditors.MemoEdit meRange;
    }
}