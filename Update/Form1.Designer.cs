namespace Update
{
    partial class Form1
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
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.lab_percent = new DevExpress.XtraEditors.LabelControl();
            this.lab_filename = new System.Windows.Forms.Label();
            this.lab_fileinfo = new System.Windows.Forms.Label();
            this.lblUpdateLog = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(25, 63);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new System.Drawing.Size(438, 35);
            this.progressBarControl1.TabIndex = 0;
            // 
            // lab_percent
            // 
            this.lab_percent.Location = new System.Drawing.Point(469, 74);
            this.lab_percent.Name = "lab_percent";
            this.lab_percent.Size = new System.Drawing.Size(18, 15);
            this.lab_percent.TabIndex = 1;
            this.lab_percent.Text = "0%";
            // 
            // lab_filename
            // 
            this.lab_filename.BackColor = System.Drawing.Color.Transparent;
            this.lab_filename.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_filename.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_filename.Location = new System.Drawing.Point(31, 31);
            this.lab_filename.Name = "lab_filename";
            this.lab_filename.Size = new System.Drawing.Size(410, 19);
            this.lab_filename.TabIndex = 3;
            this.lab_filename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_fileinfo
            // 
            this.lab_fileinfo.BackColor = System.Drawing.Color.Transparent;
            this.lab_fileinfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_fileinfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lab_fileinfo.Location = new System.Drawing.Point(23, 114);
            this.lab_fileinfo.Name = "lab_fileinfo";
            this.lab_fileinfo.Size = new System.Drawing.Size(410, 19);
            this.lab_fileinfo.TabIndex = 4;
            this.lab_fileinfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUpdateLog
            // 
            this.lblUpdateLog.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUpdateLog.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUpdateLog.Location = new System.Drawing.Point(23, 133);
            this.lblUpdateLog.Name = "lblUpdateLog";
            this.lblUpdateLog.Size = new System.Drawing.Size(440, 85);
            this.lblUpdateLog.TabIndex = 6;
            this.lblUpdateLog.Text = "更新说明：（无）";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 233);
            this.Controls.Add(this.lblUpdateLog);
            this.Controls.Add(this.lab_fileinfo);
            this.Controls.Add(this.lab_filename);
            this.Controls.Add(this.lab_percent);
            this.Controls.Add(this.progressBarControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "版本更新";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.LabelControl lab_percent;
        private System.Windows.Forms.Label lab_filename;
        private System.Windows.Forms.Label lab_fileinfo;
        private System.Windows.Forms.Label lblUpdateLog;
    }
}

