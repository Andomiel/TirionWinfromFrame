
namespace TirionWinfromFrame
{
    partial class FrmRegisterAdd
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
            this.teRemark = new DevExpress.XtraEditors.TextEdit();
            this.teMaterialNo = new DevExpress.XtraEditors.TextEdit();
            this.ceStatus = new DevExpress.XtraEditors.CheckEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnCanel);
            this.layoutControl1.Controls.Add(this.btnOk);
            this.layoutControl1.Controls.Add(this.teRemark);
            this.layoutControl1.Controls.Add(this.teMaterialNo);
            this.layoutControl1.Controls.Add(this.ceStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(518, 9, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(412, 277);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCanel
            // 
            this.btnCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanel.Location = new System.Drawing.Point(208, 242);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(192, 22);
            this.btnCanel.StyleController = this.layoutControl1;
            this.btnCanel.TabIndex = 12;
            this.btnCanel.Text = "取消";
            this.btnCanel.Click += new System.EventHandler(this.BtnCanel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 242);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(192, 22);
            this.btnOk.StyleController = this.layoutControl1;
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // teRemark
            // 
            this.teRemark.Location = new System.Drawing.Point(67, 50);
            this.teRemark.Name = "teRemark";
            this.teRemark.Size = new System.Drawing.Size(333, 22);
            this.teRemark.StyleController = this.layoutControl1;
            this.teRemark.TabIndex = 5;
            // 
            // teMaterialNo
            // 
            this.teMaterialNo.Location = new System.Drawing.Point(67, 13);
            this.teMaterialNo.Name = "teMaterialNo";
            this.teMaterialNo.Size = new System.Drawing.Size(333, 22);
            this.teMaterialNo.StyleController = this.layoutControl1;
            this.teMaterialNo.TabIndex = 4;
            // 
            // ceStatus
            // 
            this.ceStatus.Location = new System.Drawing.Point(12, 87);
            this.ceStatus.Name = "ceStatus";
            this.ceStatus.Properties.Caption = "有效";
            this.ceStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ceStatus.Size = new System.Drawing.Size(388, 20);
            this.ceStatus.StyleController = this.layoutControl1;
            this.ceStatus.TabIndex = 13;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(412, 277);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.teMaterialNo;
            this.layoutControlItem1.CustomizationFormText = "用户名：";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(392, 26);
            this.layoutControlItem1.Text = "表达式：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 15);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.teRemark;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 37);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(392, 26);
            this.layoutControlItem2.Text = "备注：";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(52, 15);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnOk;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 229);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(196, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnCanel;
            this.layoutControlItem9.Location = new System.Drawing.Point(196, 229);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(196, 26);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 63);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(392, 11);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(392, 11);
            this.emptySpaceItem1.Text = "状态：";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 98);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(392, 131);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ceStatus;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(392, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FrmRegisterAdd
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCanel;
            this.ClientSize = new System.Drawing.Size(412, 277);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegisterAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "注册配置";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teMaterialNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnCanel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.TextEdit teRemark;
        private DevExpress.XtraEditors.TextEdit teMaterialNo;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.CheckEdit ceStatus;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}