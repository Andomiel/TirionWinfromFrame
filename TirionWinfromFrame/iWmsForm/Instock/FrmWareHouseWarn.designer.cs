
namespace iWms.Form
{
    partial class FrmWareHouseWarn
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
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblOperater = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.txtOperater = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(80, 64);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(325, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "实际入库数量与入库单数量不一致";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(98, 196);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(275, 119);
            this.txtRemark.TabIndex = 2;
            this.txtRemark.Enter += new System.EventHandler(this.txtRemark_Enter);
            this.txtRemark.Leave += new System.EventHandler(this.txtRemark_Leave);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(116, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(251, 376);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(81, 40);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.Location = new System.Drawing.Point(11, 41);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(58, 24);
            this.lblTip.TabIndex = 5;
            this.lblTip.Text = "提示";
            // 
            // lblOperater
            // 
            this.lblOperater.AutoSize = true;
            this.lblOperater.Location = new System.Drawing.Point(12, 152);
            this.lblOperater.Name = "lblOperater";
            this.lblOperater.Size = new System.Drawing.Size(62, 18);
            this.lblOperater.TabIndex = 6;
            this.lblOperater.Text = "收货人";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(12, 199);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(80, 18);
            this.lblRemark.TabIndex = 7;
            this.lblRemark.Text = "入库原由";
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle2.Location = new System.Drawing.Point(80, 85);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(115, 21);
            this.lblTitle2.TabIndex = 8;
            this.lblTitle2.Text = "请核查明细";
            // 
            // txtOperater
            // 
            this.txtOperater.Location = new System.Drawing.Point(98, 149);
            this.txtOperater.Name = "txtOperater";
            this.txtOperater.Size = new System.Drawing.Size(275, 28);
            this.txtOperater.TabIndex = 9;
            // 
            // FrmWareHouseWarn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 476);
            this.ControlBox = false;
            this.Controls.Add(this.txtOperater);
            this.Controls.Add(this.lblTitle2);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblOperater);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lblTitle);
            this.Name = "FrmWareHouseWarn";
            this.Text = "完成入库确认";
            this.Click += new System.EventHandler(this.FrmWareHouseWarn_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtRemark;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblOperater;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.TextBox txtOperater;
    }
}