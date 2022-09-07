
namespace iWms.Form
{
    partial class FrmSortNo
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
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.btnZero = new DevExpress.XtraEditors.SimpleButton();
            this.btnThird = new DevExpress.XtraEditors.SimpleButton();
            this.btnForth = new DevExpress.XtraEditors.SimpleButton();
            this.btnSecond = new DevExpress.XtraEditors.SimpleButton();
            this.btnAuto = new DevExpress.XtraEditors.SimpleButton();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.separatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
            this.separatorControl3 = new DevExpress.XtraEditors.SeparatorControl();
            this.separatorControl4 = new DevExpress.XtraEditors.SeparatorControl();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFirst
            // 
            this.btnFirst.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFirst.Enabled = false;
            this.btnFirst.Location = new System.Drawing.Point(102, 91);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 23);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "紧急口";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(190, 23);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(75, 23);
            this.btnZero.TabIndex = 6;
            this.btnZero.Text = "首盘口";
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // btnThird
            // 
            this.btnThird.Location = new System.Drawing.Point(282, 91);
            this.btnThird.Name = "btnThird";
            this.btnThird.Size = new System.Drawing.Size(75, 23);
            this.btnThird.TabIndex = 7;
            this.btnThird.Text = "工单口1";
            this.btnThird.Click += new System.EventHandler(this.btnThird_Click);
            // 
            // btnForth
            // 
            this.btnForth.Location = new System.Drawing.Point(282, 163);
            this.btnForth.Name = "btnForth";
            this.btnForth.Size = new System.Drawing.Size(75, 23);
            this.btnForth.TabIndex = 8;
            this.btnForth.Text = "工单口2";
            this.btnForth.Click += new System.EventHandler(this.btnForth_Click);
            // 
            // btnSecond
            // 
            this.btnSecond.Enabled = false;
            this.btnSecond.Location = new System.Drawing.Point(102, 163);
            this.btnSecond.Name = "btnSecond";
            this.btnSecond.Size = new System.Drawing.Size(75, 23);
            this.btnSecond.TabIndex = 9;
            this.btnSecond.Text = "NG口";
            this.btnSecond.Click += new System.EventHandler(this.btnSecond_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAuto.Location = new System.Drawing.Point(282, 247);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 10;
            this.btnAuto.Text = "自动选择";
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // separatorControl1
            // 
            this.separatorControl1.Location = new System.Drawing.Point(183, 91);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(93, 23);
            this.separatorControl1.TabIndex = 11;
            // 
            // separatorControl2
            // 
            this.separatorControl2.Location = new System.Drawing.Point(183, 163);
            this.separatorControl2.Name = "separatorControl2";
            this.separatorControl2.Size = new System.Drawing.Size(93, 23);
            this.separatorControl2.TabIndex = 12;
            // 
            // separatorControl3
            // 
            this.separatorControl3.LineOrientation = System.Windows.Forms.Orientation.Vertical;
            this.separatorControl3.Location = new System.Drawing.Point(215, 52);
            this.separatorControl3.Name = "separatorControl3";
            this.separatorControl3.Size = new System.Drawing.Size(23, 181);
            this.separatorControl3.TabIndex = 13;
            // 
            // separatorControl4
            // 
            this.separatorControl4.Location = new System.Drawing.Point(133, 212);
            this.separatorControl4.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.separatorControl4.Name = "separatorControl4";
            this.separatorControl4.Padding = new System.Windows.Forms.Padding(9, 9, 0, 9);
            this.separatorControl4.Size = new System.Drawing.Size(93, 23);
            this.separatorControl4.TabIndex = 14;
            // 
            // FrmSortNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 310);
            this.Controls.Add(this.separatorControl4);
            this.Controls.Add(this.separatorControl3);
            this.Controls.Add(this.separatorControl2);
            this.Controls.Add(this.separatorControl1);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnSecond);
            this.Controls.Add(this.btnForth);
            this.Controls.Add(this.btnThird);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnFirst);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSortNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择分拣口";
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.SimpleButton btnZero;
        private DevExpress.XtraEditors.SimpleButton btnThird;
        private DevExpress.XtraEditors.SimpleButton btnForth;
        private DevExpress.XtraEditors.SimpleButton btnSecond;
        private DevExpress.XtraEditors.SimpleButton btnAuto;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.SeparatorControl separatorControl2;
        private DevExpress.XtraEditors.SeparatorControl separatorControl3;
        private DevExpress.XtraEditors.SeparatorControl separatorControl4;
    }
}