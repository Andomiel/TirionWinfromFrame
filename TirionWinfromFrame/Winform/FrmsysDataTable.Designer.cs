
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;

namespace MES.Form
{
    partial class  FrmsysDataTable
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
												this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			 									this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			 									this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			 						
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabDataList = new DevExpress.XtraTab.XtraTabPage();
            this.tabDataDetail = new DevExpress.XtraTab.XtraTabPage();
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.grdListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();    
            
          
             this.txtDataTableName=new  DevExpress.XtraEditors.TextEdit();
             this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
              this.txtDataTableSql=new  DevExpress.XtraEditors.TextEdit();
             this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
              this.txtDataTableUrl=new  DevExpress.XtraEditors.TextEdit();
             this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
                         
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();

            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();            
            ((System.ComponentModel.ISupportInitialize)(this.txtDataTableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.txtDataTableSql.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.txtDataTableUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
                        
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListView)).BeginInit();
            this.tabDataDetail.SuspendLayout();

            this.SuspendLayout();

            // layoutControl1
            //             

            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            layoutControl1.AutoScroll=true; 
            this.layoutControl1.Size = new System.Drawing.Size(605, 363);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";

            this.layoutControl1.Controls.Add(this.txtDataTableName);
             this.layoutControl1.Controls.Add(this.txtDataTableSql);
             this.layoutControl1.Controls.Add(this.txtDataTableUrl);
 //TextEdit
//DateEdit
//SimpleButton
//CheckEdit
//MemoEdit
//PictureEdit
//LookUpEdit
//ComboBoxEdit
            // 
            // txt${ColumnInfo.Name.Alias.ToCapit()}
            // 
            this.txtDataTableName.Location = new System.Drawing.Point(112, 12);
            this.txtDataTableName.Name = "txtDataTableName";
            this.txtDataTableName.Size = new System.Drawing.Size(481, 20);
            this.txtDataTableName.StyleController = this.layoutControl1;
            this.txtDataTableName.TabIndex = 1;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDataTableName;
            this.layoutControlItem1.CustomizationFormText = "数据集名称";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem1.Text = "数据集名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(96, 14);  

             // 
            // txt${ColumnInfo.Name.Alias.ToCapit()}
            // 
            this.txtDataTableSql.Location = new System.Drawing.Point(112, 36);
            this.txtDataTableSql.Name = "txtDataTableSql";
            this.txtDataTableSql.Size = new System.Drawing.Size(481, 20);
            this.txtDataTableSql.StyleController = this.layoutControl1;
            this.txtDataTableSql.TabIndex = 2;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDataTableSql;
            this.layoutControlItem2.CustomizationFormText = "数据集sql";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem2.Text = "数据集sql";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(96, 14);  

             // 
            // txt${ColumnInfo.Name.Alias.ToCapit()}
            // 
            this.txtDataTableUrl.Location = new System.Drawing.Point(112, 60);
            this.txtDataTableUrl.Name = "txtDataTableUrl";
            this.txtDataTableUrl.Size = new System.Drawing.Size(481, 20);
            this.txtDataTableUrl.StyleController = this.layoutControl1;
            this.txtDataTableUrl.TabIndex = 3;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtDataTableUrl;
            this.layoutControlItem3.CustomizationFormText = "数据集连接";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem3.Text = "数据集连接";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(96, 14);  

 
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
	        this.layoutControlItem1
	 	       ,this.layoutControlItem2
	 	       ,this.layoutControlItem3
	        });
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(605, 363);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;          


            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 34);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabDataList;
            this.xtraTabControl1.Size = new System.Drawing.Size(585, 436);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabDataList,
            this.tabDataDetail});
            // 
            // tabDataList
            // 
            this.tabDataList.Controls.Add(this.grdList);
            this.tabDataList.Name = "tabDataList";
            this.tabDataList.Size = new System.Drawing.Size(579, 407);
            this.tabDataList.Text = "数据列表";
            // 
            // tabDataDetail
            // 
            this.tabDataDetail.Controls.Add(this.panelControl2);
            this.tabDataDetail.Name = "tabDataDetail";
            this.tabDataDetail.Size = new System.Drawing.Size(579, 407);
            this.tabDataDetail.Text = "数据编辑";
            // 
            // grdList
            // 
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(0, 0);
            this.grdList.MainView = this.grdListView;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(579, 407);
            this.grdList.TabIndex = 0;
            this.grdList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdListView});
            // 
            // grdListView
            // 
			this.grdListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
												this.gridColumn1,
			 									this.gridColumn2,
			 									this.gridColumn3,
			 						});
            this.grdListView.GridControl = this.grdList;
            this.grdListView.Name = "grdListView";
            this.grdListView.OptionsView.ColumnAutoWidth=false;
            this.grdListView.BestFitColumns();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.layoutControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(579, 407);
            this.panelControl2.TabIndex = 0;

												// 
			// gridColumn$count.cap
			//  gridColumn$count1
			(this.gridColumn1).Caption = "数据集名称";
			(this.gridColumn1).Name = "gridColumn1";
			(this.gridColumn1).FieldName =  "DataTableName";
            (this.gridColumn1).Visible = true;
            (this.gridColumn1).VisibleIndex = 1;
			 									// 
			// gridColumn$count.cap
			//  gridColumn$count1
			(this.gridColumn2).Caption = "数据集sql";
			(this.gridColumn2).Name = "gridColumn2";
			(this.gridColumn2).FieldName =  "DataTableSql";
            (this.gridColumn2).Visible = true;
            (this.gridColumn2).VisibleIndex = 2;
			 									// 
			// gridColumn$count.cap
			//  gridColumn$count1
			(this.gridColumn3).Caption = "数据集连接";
			(this.gridColumn3).Name = "gridColumn3";
			(this.gridColumn3).FieldName =  "DataTableUrl";
            (this.gridColumn3).Visible = true;
            (this.gridColumn3).VisibleIndex = 3;
			 						
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = " FrmsysDataTable";
            this.Text = " FrmsysDataTable";
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabDataList.ResumeLayout(false);
            this.tabDataDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.txtDataTableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txtDataTableSql.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txtDataTableUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();            
 
            this.ResumeLayout(false);

        }

        #endregion

        private XtraTabControl xtraTabControl1;
        private XtraTabPage tabDataList;
        private XtraTabPage tabDataDetail;
        private DevExpress.XtraGrid.GridControl grdList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdListView;
        private PanelControl panelControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;

		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
 		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
 		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
         private DevExpress.XtraEditors.TextEdit txtDataTableName;
         private DevExpress.XtraEditors.TextEdit txtDataTableSql;
         private DevExpress.XtraEditors.TextEdit txtDataTableUrl;
 
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
     }
}