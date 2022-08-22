
namespace TirionWinfromFrame
{
    partial class FrmSearch
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
            this.btncanel = new DevExpress.XtraEditors.SimpleButton();
            this.btnok = new DevExpress.XtraEditors.SimpleButton();
            this.txtvalue = new DevExpress.XtraEditors.TextEdit();
            this.txtrelation = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtSql = new DevExpress.XtraEditors.MemoEdit();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.txtoperator = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtvalue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrelation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSql.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtoperator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btncanel);
            this.layoutControl1.Controls.Add(this.btnok);
            this.layoutControl1.Controls.Add(this.txtvalue);
            this.layoutControl1.Controls.Add(this.txtrelation);
            this.layoutControl1.Controls.Add(this.txtSql);
            this.layoutControl1.Controls.Add(this.btnadd);
            this.layoutControl1.Controls.Add(this.txtoperator);
            this.layoutControl1.Controls.Add(this.txtField);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(536, 299);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btncanel
            // 
            this.btncanel.Location = new System.Drawing.Point(270, 265);
            this.btncanel.Name = "btncanel";
            this.btncanel.Size = new System.Drawing.Size(254, 22);
            this.btncanel.StyleController = this.layoutControl1;
            this.btncanel.TabIndex = 13;
            this.btncanel.Text = "取消";
            this.btncanel.Click += new System.EventHandler(this.btncanel_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(12, 265);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(254, 22);
            this.btnok.StyleController = this.layoutControl1;
            this.btnok.TabIndex = 12;
            this.btnok.Text = "确定";
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // txtvalue
            // 
            this.txtvalue.Location = new System.Drawing.Point(222, 12);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.Size = new System.Drawing.Size(97, 20);
            this.txtvalue.StyleController = this.layoutControl1;
            this.txtvalue.TabIndex = 11;
            // 
            // txtrelation
            // 
            this.txtrelation.EditValue = "与-and";
            this.txtrelation.Location = new System.Drawing.Point(364, 12);
            this.txtrelation.Name = "txtrelation";
            this.txtrelation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtrelation.Properties.Items.AddRange(new object[] {
            "与-and",
            "或-or"});
            this.txtrelation.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtrelation.Size = new System.Drawing.Size(71, 20);
            this.txtrelation.StyleController = this.layoutControl1;
            this.txtrelation.TabIndex = 10;
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(12, 38);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(512, 223);
            this.txtSql.StyleController = this.layoutControl1;
            this.txtSql.TabIndex = 8;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(439, 12);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(85, 22);
            this.btnadd.StyleController = this.layoutControl1;
            this.btnadd.TabIndex = 7;
            this.btnadd.Text = "增加";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtoperator
            // 
            this.txtoperator.EditValue = "等于-=";
            this.txtoperator.Location = new System.Drawing.Point(136, 12);
            this.txtoperator.Name = "txtoperator";
            this.txtoperator.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtoperator.Properties.Items.AddRange(new object[] {
            "等于-=",
            "大于->",
            "小于-<",
            "包含-like"});
            this.txtoperator.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtoperator.Size = new System.Drawing.Size(67, 20);
            this.txtoperator.StyleController = this.layoutControl1;
            this.txtoperator.TabIndex = 5;
            // 
            // txtField
            // 
            this.txtField.Location = new System.Drawing.Point(41, 12);
            this.txtField.Name = "txtField";
            this.txtField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtField.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtField.Size = new System.Drawing.Size(91, 20);
            this.txtField.StyleController = this.layoutControl1;
            this.txtField.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem3,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(536, 299);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtField;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(124, 26);
            this.layoutControlItem1.Text = "字段";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(24, 14);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtoperator;
            this.layoutControlItem2.Location = new System.Drawing.Point(124, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(71, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnadd;
            this.layoutControlItem4.Location = new System.Drawing.Point(427, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(89, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtSql;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(516, 227);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtrelation;
            this.layoutControlItem6.Location = new System.Drawing.Point(311, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(116, 26);
            this.layoutControlItem6.Text = "关系符";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(36, 14);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtvalue;
            this.layoutControlItem3.Location = new System.Drawing.Point(195, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(116, 26);
            this.layoutControlItem3.Text = "值";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(12, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnok;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 253);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(258, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btncanel;
            this.layoutControlItem8.Location = new System.Drawing.Point(258, 253);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(258, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 299);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "搜索";
            this.Load += new System.EventHandler(this.FrmSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtvalue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrelation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSql.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtoperator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.ComboBoxEdit txtField;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.MemoEdit txtSql;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.ComboBoxEdit txtoperator;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit txtvalue;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ComboBoxEdit txtrelation;
        private DevExpress.XtraEditors.SimpleButton btncanel;
        private DevExpress.XtraEditors.SimpleButton btnok;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}