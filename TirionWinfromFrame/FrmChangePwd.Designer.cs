
namespace TirionWinfromFrame
{
    partial class FrmChangePwd
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCanel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.txtConfirmPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtOriginPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnCanel);
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Controls.Add(this.txtConfirmPwd);
            this.layoutControl1.Controls.Add(this.txtNewPwd);
            this.layoutControl1.Controls.Add(this.txtOriginPwd);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(518, 9, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(412, 259);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCanel
            // 
            this.btnCanel.Location = new System.Drawing.Point(208, 225);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(192, 22);
            this.btnCanel.StyleController = this.layoutControl1;
            this.btnCanel.TabIndex = 12;
            this.btnCanel.Text = "取消";
            this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 225);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(192, 22);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.Location = new System.Drawing.Point(87, 84);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.Size = new System.Drawing.Size(313, 20);
            this.txtConfirmPwd.StyleController = this.layoutControl1;
            this.txtConfirmPwd.TabIndex = 7;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(87, 60);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(313, 20);
            this.txtNewPwd.StyleController = this.layoutControl1;
            this.txtNewPwd.TabIndex = 6;
            // 
            // txtOriginPwd
            // 
            this.txtOriginPwd.Location = new System.Drawing.Point(87, 36);
            this.txtOriginPwd.Name = "txtOriginPwd";
            this.txtOriginPwd.Size = new System.Drawing.Size(313, 20);
            this.txtOriginPwd.StyleController = this.layoutControl1;
            this.txtOriginPwd.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(87, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(313, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(412, 259);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtName;
            this.layoutControlItem1.CustomizationFormText = "用户名：";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(392, 24);
            this.layoutControlItem1.Text = "用户名：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(392, 117);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtOriginPwd;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(392, 24);
            this.layoutControlItem2.Text = "原密码：";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtNewPwd;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(392, 24);
            this.layoutControlItem3.Text = "新密码：";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtConfirmPwd;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(392, 24);
            this.layoutControlItem4.Text = "确认新密码：";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnOk;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 213);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(196, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnCanel;
            this.layoutControlItem9.Location = new System.Drawing.Point(196, 213);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(196, 26);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // FrmChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 259);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmChangePwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnCanel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.TextEdit txtConfirmPwd;
        private DevExpress.XtraEditors.TextEdit txtNewPwd;
        private DevExpress.XtraEditors.TextEdit txtOriginPwd;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}