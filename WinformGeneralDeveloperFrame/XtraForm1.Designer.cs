
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;

namespace WinformGeneralDeveloperFrame
{
    partial class XtraForm1
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
            this.grdList = new DevExpress.XtraGrid.GridControl();
            this.grdListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdList
            // 
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Location = new System.Drawing.Point(0, 34);
            this.grdList.MainView = this.grdListView;
            this.grdList.Name = "grdList";
            this.grdList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.grdList.Size = new System.Drawing.Size(1074, 615);
            this.grdList.TabIndex = 1;
            this.grdList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdListView});
            // 
            // grdListView
            // 
            this.grdListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.grdListView.GridControl = this.grdList;
            this.grdListView.Name = "grdListView";
            this.grdListView.OptionsBehavior.Editable = false;
            this.grdListView.OptionsView.ColumnAutoWidth = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "id";
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 10;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "产品名称";
            this.gridColumn2.FieldName = "productid";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 201;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "规格型号";
            this.gridColumn3.FieldName = "spec";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 201;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "报价数量";
            this.gridColumn4.FieldName = "number";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 201;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "计量单位";
            this.gridColumn5.FieldName = "unit";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 201;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "单价";
            this.gridColumn6.FieldName = "unitprice";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 201;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "金额";
            this.gridColumn7.FieldName = "money";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 201;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "仓库";
            this.gridColumn8.FieldName = "stockid";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 201;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "产品编号";
            this.gridColumn9.FieldName = "productcode";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 201;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "报价单号";
            this.gridColumn10.FieldName = "quotationcode";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            this.gridColumn10.Width = 201;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "报价单";
            this.gridColumn11.FieldName = "quotationid";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "备注";
            this.gridColumn12.FieldName = "remark";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            this.gridColumn12.Width = 201;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 649);
            this.Controls.Add(this.grdList);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            this.Controls.SetChildIndex(this.grdList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdListView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}