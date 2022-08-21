
namespace WinformGeneralDeveloperFrame
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.skinPaletteRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.bsi_Date = new DevExpress.XtraBars.BarStaticItem();
            this.barListItem1 = new DevExpress.XtraBars.BarListItem();
            this.barUserName = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.btnabout = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bsi_UserName = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.ImageIndex = ((int)(resources.GetObject("ribbonControl1.ExpandCollapseItem.ImageOptions.ImageIndex")));
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("ribbonControl1.ExpandCollapseItem.ImageOptions.LargeImageIndex")));
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonControl1.ExpandCollapseItem.ImageOptions.SvgImage")));
            this.ribbonControl1.ExpandCollapseItem.SearchTags = resources.GetString("ribbonControl1.ExpandCollapseItem.SearchTags");
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.ribbonGalleryBarItem1,
            this.skinPaletteRibbonGalleryBarItem1,
            this.barEditItem1,
            this.bsi_Date,
            this.barListItem1,
            this.barUserName,
            this.barStaticItem3,
            this.btnabout,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barStaticItem2,
            this.barButtonItem3});
            this.ribbonControl1.MaxItemId = 13;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.ribbonGalleryBarItem1);
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1});
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // ribbonGalleryBarItem1
            // 
            resources.ApplyResources(this.ribbonGalleryBarItem1, "ribbonGalleryBarItem1");
            this.ribbonGalleryBarItem1.Id = 1;
            this.ribbonGalleryBarItem1.ImageOptions.ImageIndex = ((int)(resources.GetObject("ribbonGalleryBarItem1.ImageOptions.ImageIndex")));
            this.ribbonGalleryBarItem1.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("ribbonGalleryBarItem1.ImageOptions.LargeImageIndex")));
            this.ribbonGalleryBarItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonGalleryBarItem1.ImageOptions.SvgImage")));
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            // 
            // skinPaletteRibbonGalleryBarItem1
            // 
            resources.ApplyResources(this.skinPaletteRibbonGalleryBarItem1, "skinPaletteRibbonGalleryBarItem1");
            this.skinPaletteRibbonGalleryBarItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.skinPaletteRibbonGalleryBarItem1.Id = 2;
            this.skinPaletteRibbonGalleryBarItem1.ImageOptions.ImageIndex = ((int)(resources.GetObject("skinPaletteRibbonGalleryBarItem1.ImageOptions.ImageIndex")));
            this.skinPaletteRibbonGalleryBarItem1.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("skinPaletteRibbonGalleryBarItem1.ImageOptions.LargeImageIndex")));
            this.skinPaletteRibbonGalleryBarItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("skinPaletteRibbonGalleryBarItem1.ImageOptions.SvgImage")));
            this.skinPaletteRibbonGalleryBarItem1.Name = "skinPaletteRibbonGalleryBarItem1";
            // 
            // barEditItem1
            // 
            resources.ApplyResources(this.barEditItem1, "barEditItem1");
            this.barEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barEditItem1.Edit = this.repositoryItemTimeEdit1;
            this.barEditItem1.Id = 3;
            this.barEditItem1.ImageOptions.ImageIndex = ((int)(resources.GetObject("barEditItem1.ImageOptions.ImageIndex")));
            this.barEditItem1.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barEditItem1.ImageOptions.LargeImageIndex")));
            this.barEditItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barEditItem1.ImageOptions.SvgImage")));
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTimeEdit1
            // 
            resources.ApplyResources(this.repositoryItemTimeEdit1, "repositoryItemTimeEdit1");
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemTimeEdit1.Buttons"))))});
            this.repositoryItemTimeEdit1.Mask.EditMask = resources.GetString("repositoryItemTimeEdit1.Mask.EditMask");
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // bsi_Date
            // 
            resources.ApplyResources(this.bsi_Date, "bsi_Date");
            this.bsi_Date.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsi_Date.Id = 4;
            this.bsi_Date.ImageOptions.Image = global::WinformGeneralDeveloperFrame.Properties.Resources.time_16x16;
            this.bsi_Date.ImageOptions.ImageIndex = ((int)(resources.GetObject("bsi_Date.ImageOptions.ImageIndex")));
            this.bsi_Date.ImageOptions.LargeImage = global::WinformGeneralDeveloperFrame.Properties.Resources.time_32x32;
            this.bsi_Date.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bsi_Date.ImageOptions.LargeImageIndex")));
            this.bsi_Date.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bsi_Date.ImageOptions.SvgImage")));
            this.bsi_Date.Name = "bsi_Date";
            this.bsi_Date.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barListItem1
            // 
            resources.ApplyResources(this.barListItem1, "barListItem1");
            this.barListItem1.Id = 5;
            this.barListItem1.ImageOptions.ImageIndex = ((int)(resources.GetObject("barListItem1.ImageOptions.ImageIndex")));
            this.barListItem1.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barListItem1.ImageOptions.LargeImageIndex")));
            this.barListItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barListItem1.ImageOptions.SvgImage")));
            this.barListItem1.Name = "barListItem1";
            // 
            // barUserName
            // 
            resources.ApplyResources(this.barUserName, "barUserName");
            this.barUserName.Id = 6;
            this.barUserName.ImageOptions.Image = global::WinformGeneralDeveloperFrame.Properties.Resources.bocustomer_16x16;
            this.barUserName.ImageOptions.ImageIndex = ((int)(resources.GetObject("barUserName.ImageOptions.ImageIndex")));
            this.barUserName.ImageOptions.LargeImage = global::WinformGeneralDeveloperFrame.Properties.Resources.bocustomer_32x321;
            this.barUserName.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barUserName.ImageOptions.LargeImageIndex")));
            this.barUserName.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barUserName.ImageOptions.SvgImage")));
            this.barUserName.Name = "barUserName";
            this.barUserName.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem3
            // 
            resources.ApplyResources(this.barStaticItem3, "barStaticItem3");
            this.barStaticItem3.Id = 7;
            this.barStaticItem3.ImageOptions.ImageIndex = ((int)(resources.GetObject("barStaticItem3.ImageOptions.ImageIndex")));
            this.barStaticItem3.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barStaticItem3.ImageOptions.LargeImageIndex")));
            this.barStaticItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barStaticItem3.ImageOptions.SvgImage")));
            this.barStaticItem3.Name = "barStaticItem3";
            // 
            // btnabout
            // 
            resources.ApplyResources(this.btnabout, "btnabout");
            this.btnabout.Id = 8;
            this.btnabout.ImageOptions.Image = global::WinformGeneralDeveloperFrame.Properties.Resources.operatingsystem_16x16;
            this.btnabout.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnabout.ImageOptions.ImageIndex")));
            this.btnabout.ImageOptions.LargeImage = global::WinformGeneralDeveloperFrame.Properties.Resources.operatingsystem_32x32;
            this.btnabout.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btnabout.ImageOptions.LargeImageIndex")));
            this.btnabout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnabout.ImageOptions.SvgImage")));
            this.btnabout.Name = "btnabout";
            this.btnabout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.ImageOptions.Image = global::WinformGeneralDeveloperFrame.Properties.Resources.mail_16x16;
            this.barButtonItem1.ImageOptions.ImageIndex = ((int)(resources.GetObject("barButtonItem1.ImageOptions.ImageIndex")));
            this.barButtonItem1.ImageOptions.LargeImage = global::WinformGeneralDeveloperFrame.Properties.Resources.mail_32x32;
            this.barButtonItem1.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barButtonItem1.ImageOptions.LargeImageIndex")));
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            resources.ApplyResources(this.barButtonItem2, "barButtonItem2");
            this.barButtonItem2.Id = 10;
            this.barButtonItem2.ImageOptions.ImageIndex = ((int)(resources.GetObject("barButtonItem2.ImageOptions.ImageIndex")));
            this.barButtonItem2.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barButtonItem2.ImageOptions.LargeImageIndex")));
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barStaticItem2
            // 
            resources.ApplyResources(this.barStaticItem2, "barStaticItem2");
            this.barStaticItem2.Id = 11;
            this.barStaticItem2.ImageOptions.ImageIndex = ((int)(resources.GetObject("barStaticItem2.ImageOptions.ImageIndex")));
            this.barStaticItem2.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barStaticItem2.ImageOptions.LargeImageIndex")));
            this.barStaticItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barStaticItem2.ImageOptions.SvgImage")));
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // barButtonItem3
            // 
            resources.ApplyResources(this.barButtonItem3, "barButtonItem3");
            this.barButtonItem3.Id = 12;
            this.barButtonItem3.ImageOptions.Image = global::WinformGeneralDeveloperFrame.Properties.Resources.removepivotfield_16x16;
            this.barButtonItem3.ImageOptions.ImageIndex = ((int)(resources.GetObject("barButtonItem3.ImageOptions.ImageIndex")));
            this.barButtonItem3.ImageOptions.LargeImage = global::WinformGeneralDeveloperFrame.Properties.Resources.removepivotfield_32x32;
            this.barButtonItem3.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barButtonItem3.ImageOptions.LargeImageIndex")));
            this.barButtonItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            resources.ApplyResources(this.ribbonPage1, "ribbonPage1");
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnabout);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonStatusBar1
            // 
            resources.ApplyResources(this.ribbonStatusBar1, "ribbonStatusBar1");
            this.ribbonStatusBar1.ItemLinks.Add(this.bsi_Date);
            this.ribbonStatusBar1.ItemLinks.Add(this.barUserName);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // navBarControl1
            // 
            resources.ApplyResources(this.navBarControl1, "navBarControl1");
            this.navBarControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.StoreDefaultPaintStyleName = true;
            this.navBarControl1.Click += new System.EventHandler(this.navBarControl1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bsi_UserName
            // 
            resources.ApplyResources(this.bsi_UserName, "bsi_UserName");
            this.bsi_UserName.Id = 29;
            this.bsi_UserName.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bsi_UserName.ImageOptions.Image")));
            this.bsi_UserName.ImageOptions.ImageIndex = ((int)(resources.GetObject("bsi_UserName.ImageOptions.ImageIndex")));
            this.bsi_UserName.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("bsi_UserName.ImageOptions.LargeImageIndex")));
            this.bsi_UserName.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bsi_UserName.ImageOptions.SvgImage")));
            this.bsi_UserName.Name = "bsi_UserName";
            this.bsi_UserName.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem1
            // 
            resources.ApplyResources(this.barStaticItem1, "barStaticItem1");
            this.barStaticItem1.Id = 29;
            this.barStaticItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barStaticItem1.ImageOptions.Image")));
            this.barStaticItem1.ImageOptions.ImageIndex = ((int)(resources.GetObject("barStaticItem1.ImageOptions.ImageIndex")));
            this.barStaticItem1.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barStaticItem1.ImageOptions.LargeImageIndex")));
            this.barStaticItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barStaticItem1.ImageOptions.SvgImage")));
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "DevExpress Style";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraBars.BarStaticItem bsi_Date;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.BarListItem barListItem1;
        private DevExpress.XtraBars.BarStaticItem barUserName;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem bsi_UserName;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem btnabout;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}

