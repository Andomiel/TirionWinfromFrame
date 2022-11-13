
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuildCondition = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuildUpns = new DevExpress.XtraEditors.SimpleButton();
            this.lblRemark = new System.Windows.Forms.Label();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.lblStar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(150, 58);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(474, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "按条件创建策略，或指定UPN创建策略";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(530, 365);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(176, 53);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBuildCondition
            // 
            this.btnBuildCondition.Location = new System.Drawing.Point(73, 365);
            this.btnBuildCondition.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuildCondition.Name = "btnBuildCondition";
            this.btnBuildCondition.Size = new System.Drawing.Size(176, 53);
            this.btnBuildCondition.TabIndex = 3;
            this.btnBuildCondition.Text = "按条件筛选";
            this.btnBuildCondition.Click += new System.EventHandler(this.btnBuildCondition_Click);
            // 
            // btnBuildUpns
            // 
            this.btnBuildUpns.Location = new System.Drawing.Point(306, 365);
            this.btnBuildUpns.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuildUpns.Name = "btnBuildUpns";
            this.btnBuildUpns.Size = new System.Drawing.Size(176, 53);
            this.btnBuildUpns.TabIndex = 4;
            this.btnBuildUpns.Text = "指定UPN";
            this.btnBuildUpns.Click += new System.EventHandler(this.btnBuildUpns_Click);
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(78, 128);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(106, 24);
            this.lblRemark.TabIndex = 5;
            this.lblRemark.Text = "冻结原因";
            // 
            // tbRemark
            // 
            this.tbRemark.Location = new System.Drawing.Point(205, 125);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(405, 184);
            this.tbRemark.TabIndex = 6;
            this.tbRemark.Enter += new System.EventHandler(this.tbRemark_Enter);
            this.tbRemark.Leave += new System.EventHandler(this.tbRemark_Leave);
            // 
            // lblStar
            // 
            this.lblStar.AutoSize = true;
            this.lblStar.ForeColor = System.Drawing.Color.Red;
            this.lblStar.Location = new System.Drawing.Point(616, 139);
            this.lblStar.Name = "lblStar";
            this.lblStar.Size = new System.Drawing.Size(22, 24);
            this.lblStar.TabIndex = 7;
            this.lblStar.Text = "*";
            // 
            // FrmBuildRemind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 469);
            this.ControlBox = false;
            this.Controls.Add(this.lblStar);
            this.Controls.Add(this.tbRemark);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.btnBuildUpns);
            this.Controls.Add(this.btnBuildCondition);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBuildRemind";
            this.Text = "创建策略提醒";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnBuildCondition;
        private DevExpress.XtraEditors.SimpleButton btnBuildUpns;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label lblStar;
    }
}