
namespace iWms.Form
{
    partial class FrmInStockNotice
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
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.lblPath = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnDownload = new DevExpress.XtraEditors.SimpleButton();
            this.btnResharpBarcode = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(416, 44);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "导入";
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(112, 45);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(242, 21);
            this.txtPath.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(360, 44);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(36, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "...";
            this.btnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(41, 49);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(65, 12);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "入库通知单";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(360, 13);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(131, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "下载模板";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnResharpBarcode
            // 
            this.btnResharpBarcode.Location = new System.Drawing.Point(360, 74);
            this.btnResharpBarcode.Name = "btnResharpBarcode";
            this.btnResharpBarcode.Size = new System.Drawing.Size(131, 23);
            this.btnResharpBarcode.TabIndex = 5;
            this.btnResharpBarcode.Text = "重新更新二维码";
            this.btnResharpBarcode.Click += new System.EventHandler(this.btnResharpBarcode_Click);
            // 
            // FrmInStockNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 105);
            this.Controls.Add(this.btnResharpBarcode);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmInStockNotice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入库通知单导入";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnImport;
        private System.Windows.Forms.TextBox txtPath;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.SimpleButton btnDownload;
        private DevExpress.XtraEditors.SimpleButton btnResharpBarcode;
    }
}