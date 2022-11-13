using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using MES.Entity;
using TirionWinfromFrame.Commons;
using MES;


namespace TirionWinfromFrame
{
    public partial class FrmBaseForm : XtraForm
    {
        public string ID = string.Empty;  // 主键
        private XtraTabControl xtraTab;
        private GridControl gridControl;
        private GridControl gridControlDetail;
        private TreeList treeList;
        private GridView gridView;
        private GridView gridViewDetail;
        private LayoutControlGroup[] controlGroups;
        private object DataType;
        public string menucode;
        /// <summary>
        /// 值自动生成控件name
        /// </summary>
        private string[] readonlycon = new string[] { };
        public FrmBaseForm()
        {
            InitializeComponent();
        }

        public void InitFrom(XtraTabControl xtraTab, GridControl gridControl, GridView gridView, LayoutControlGroup[] controlGroups, object DataType)
        {
            InitFrom(xtraTab, gridControl, gridView, controlGroups);
            this.DataType = DataType;
        }
        public void InitFrom(XtraTabControl xtraTab, GridControl gridControl, GridView gridView, LayoutControlGroup[] controlGroups, object DataType, string[] readcontrols)
        {
            InitFrom(xtraTab, gridControl, gridView, controlGroups);
            this.DataType = DataType;
            readonlycon = readcontrols;
        }
        public void InitFrom(XtraTabControl xtraTab, GridControl gridControl, GridView gridView, LayoutControlGroup[] controlGroups)
        {
            initTools();
            this.xtraTab = xtraTab;
            this.gridControl = gridControl;
            this.gridView = gridView;
            this.gridView.BestFitColumns();
            this.controlGroups = controlGroups;
            InitFormFunction();
            InitToolBtntatus(EFormStatus.eInit);
            InitEvent();
        }
        public void InitFrom(XtraTabControl xtraTab, GridControl gridControl, GridView gridView, LayoutControlGroup[] controlGroups, object DataType, TreeList treeList, string[] readcontrols)
        {
            if (treeList != null)
            {
                this.treeList = treeList;
                if (treeList.ContextMenuStrip != null)
                    treeList.ContextMenuStrip.Enabled = false;
                treeList.OptionsBehavior.Editable = false;
            }
            readonlycon = readcontrols;
            InitFrom(xtraTab, gridControl, gridView, controlGroups, DataType);
        }

        public void InitFrom(XtraTabControl xtraTab, GridControl gridControl, GridView gridView, LayoutControlGroup[] controlGroups, object DataType, GridControl griddetail, string[] readcontrols)
        {
            if (griddetail != null)
            {
                gridControlDetail = griddetail;
                gridViewDetail = griddetail.FocusedView as GridView;
                gridViewDetail.OptionsBehavior.Editable = false;
                if (gridControlDetail.ContextMenuStrip != null)
                    gridControlDetail.ContextMenuStrip.Enabled = false;
            }
            readonlycon = readcontrols;
            InitFrom(xtraTab, gridControl, gridView, controlGroups, DataType);
        }
        public void InitEvent()
        {
            xtraTab.SelectedPageChanged += xtraTabControl1_SelectedPageChanged;
            gridControl.MouseDoubleClick += gridControl_MouseDoubleClick;
            if (gridViewDetail != null)
                gridViewDetail.KeyDown += GridViewDetail_KeyDown;
        }

        private void GridViewDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.C)
            {
                Clipboard.SetDataObject(gridViewDetail.GetFocusedRowCellValue(gridViewDetail.FocusedColumn));
                e.Handled = true;
            }
        }
        public virtual void InitFormFunction()
        {

        }
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {

        }
        private void gridControl_MouseDoubleClick(object sender, EventArgs e)
        {
            var dr = this.gridView.GetFocusedRow();
            if (dr != null)
            {
                this.ModelDataToControl(dr);
                gridControlMouseDoubleClickFunction(sender, e);
                xtraTab.SelectedTabPageIndex = 1;
                SetControlStatus(controlGroups, true);
                InitToolBtntatus(EFormStatus.eView);
            }

            if (gridViewDetail != null)
            {
                gridViewDetail.BestFitColumns();
            }
            if (treeList != null)
            {
                treeList.BestFitColumns();
            }
        }
        public virtual void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            xtraTab.SelectedTabPageIndex = 1;
            xtraTab.TabPages[0].PageEnabled = false;
            ClearScreen();
            DateEdit dt = (DateEdit)this.getControl("txtcreateTime");
            if (dt != null)
                dt.DateTime = DateTime.Now;
            LookUpEditBase look = (LookUpEditBase)this.getControl("txtcreatorId");
            DateEdit dt1 = (DateEdit)this.getControl("txteditTime");
            if (dt1 != null)
                dt1.DateTime = DateTime.Now;
            LookUpEditBase look1 = (LookUpEditBase)this.getControl("txteditorId");
            if (look1 != null)
                look1.EditValue = AppInfo.LoginUserInfo.id;
            if (look != null)
                look.EditValue = AppInfo.LoginUserInfo.id;
            SetControlStatus(controlGroups, false);
            InitToolBtntatus(EFormStatus.eAdd);
            AddFunction();
        }
        public virtual void AddFunction()
        {

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            xtraTab.TabPages[0].PageEnabled = false;
            DateEdit dt = (DateEdit)this.getControl("txteditTime");
            if (dt != null)
                dt.DateTime = DateTime.Now;
            LookUpEditBase look = (LookUpEditBase)this.getControl("txteditorId");
            if (look != null)
                look.EditValue = AppInfo.LoginUserInfo.id;
            SetControlStatus(controlGroups, false);
            InitToolBtntatus(EFormStatus.eEdit);
            EditFunction();
        }
        public virtual void EditFunction()
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            xtraTab.TabPages[0].PageEnabled = true;
            if (CheckInput() && SaveFunction())
            {
                "保存成功！".ShowTips();

                InitToolBtntatus(EFormStatus.eView);
                InitgrdListDataSourceFunction();
                SetControlStatus(controlGroups, true);
            }

        }
        public void initTools()
        {

            List<sysToolButtonInfo> list = null;
            using (var db = new MESDB())
            {
                list = db.sysToolButtonInfo.ToList();
            }
            //int i = 1;
            int width = 0;
            foreach (sysToolButtonInfo info in list)
            {
                if (AppInfo.FunctionList.Contains(menucode + "-" + info.btnCode))
                {
                    SimpleButton button = new SimpleButton();
                    button.Name = "btn" + info.btnCode;
                    button.Text = info.btnName;
                    button.Location = new Point(width, 5);
                    button.PaintStyle = PaintStyles.Light;
                    button.AutoSize = true;
                    button.ImageOptions.Image = Image.FromFile(Application.StartupPath + "\\" + info.btnIcon);
                    button.Click += (sender, e) =>
                    {
                        ToolFunction(sender, e);
                    };
                    this.panelControl1.AddControl(button);
                    width += button.Width;
                }
            }
        }
        public virtual void ToolFunction(object sender, EventArgs e)

        {
            string FunctionId = ((SimpleButton)sender).Name;
            switch (FunctionId)
            {
                case "btnAdd": btnAdd_Click(sender, e); break;
                case "btnEdit": btnEdit_Click(sender, e); break;
                case "btnSearch": btnSearch_Click(sender, e); break;
                case "btnCanle": btnCanel_Click(sender, e); break;
                case "btnSave": btnSave_Click(sender, e); break;
                case "btnDel": btnDel_Click(sender, e); break;

            }
        }

        public void InitgrdListDataSourceFunction()
        {
            if (gridView != null)
            {
                gridView.BestFitColumns();
            }
            if (gridViewDetail != null)
            {
                gridViewDetail.BestFitColumns();
            }
            InitgrdListDataSource();
        }
        public virtual void InitgrdListDataSource()
        {

        }
        public virtual bool SaveFunction()
        {
            return true;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //InitToolBtntatus(EFormStatus.e);

            SearchFunction();
        }
        public virtual void SearchFunction()
        {
        }
        private void btnCanel_Click(object sender, EventArgs e)
        {
            xtraTab.TabPages[0].PageEnabled = true;
            InitToolBtntatus(EFormStatus.eCanel);
            CanelFunction();
            SetControlStatus(controlGroups, true);
        }
        public virtual void CanelFunction()
        {

        }

        public virtual bool CheckInput()
        {
            return true;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if ("确定删除？".ShowYesNoAndTips() == DialogResult.Yes)
            {
                if (DelFunction())
                {
                    InitToolBtntatus(EFormStatus.eDelete);
                    InitgrdListDataSourceFunction();
                    ClearScreen();
                }
            }
        }

        public virtual bool DelFunction()
        {
            return true;
        }
        public void SetControlStatus(LayoutControlGroup[] controlGroups, bool flag)
        {
            if (controlGroups != null)
            {
                foreach (LayoutControlGroup col in controlGroups)
                {
                    SetLayoutControlReadOnly(flag, col);
                }
            }
        }

        public void InitToolBtntatus(EFormStatus status)
        {
            switch (status)
            {
                case EFormStatus.eInit:
                    {
                        foreach (var button in panelControl1.Controls)
                        {
                            if (button.GetType().Name == "SimpleButton")
                            {
                                var btn = (SimpleButton)button;
                                if (btn.Name == "btnAdd" || btn.Name == "btnSearch")
                                {
                                    btn.Enabled = true;
                                }
                                else
                                {
                                    btn.Enabled = false;
                                }
                            }
                        }

                        if (gridControlDetail != null)
                        {
                            gridViewDetail.OptionsBehavior.Editable = false;
                            if (gridControlDetail.ContextMenuStrip != null)
                                gridControlDetail.ContextMenuStrip.Enabled = false;
                        }
                        if (treeList != null)
                        {
                            treeList.OptionsBehavior.Editable = false;
                            if (treeList.ContextMenuStrip != null)
                                treeList.ContextMenuStrip.Enabled = false;
                        }
                    }; break;
                case EFormStatus.eView:
                    {
                        foreach (var button in panelControl1.Controls)
                        {
                            if (button.GetType().Name == "SimpleButton")
                            {
                                var btn = (SimpleButton)button;
                                if (btn.Name == "btnAdd" || btn.Name == "btnDel" || btn.Name == "btnEdit" || btn.Name == "btnSearch")
                                {
                                    btn.Enabled = true;
                                }
                                else
                                {
                                    btn.Enabled = false;
                                }
                            }
                        }

                        if (gridControlDetail != null)
                        {
                            if (gridControlDetail.ContextMenuStrip != null)
                                gridControlDetail.ContextMenuStrip.Enabled = false;
                            gridViewDetail.OptionsBehavior.Editable = false;
                        }
                        if (treeList != null)
                        {
                            if (treeList.ContextMenuStrip != null)
                                treeList.ContextMenuStrip.Enabled = false;
                            treeList.OptionsBehavior.Editable = false;
                        }
                    }; break;
                case EFormStatus.eViewTab:
                    {
                        foreach (var button in panelControl1.Controls)
                        {
                            if (button.GetType().Name == "SimpleButton")
                            {
                                var btn = (SimpleButton)button;
                                if (btn.Name == "btnAdd")
                                {
                                    btn.Enabled = true;
                                }
                                else
                                {
                                    btn.Enabled = false;
                                }
                            }
                        }

                        if (gridControlDetail != null)
                        {
                            if (gridControlDetail.ContextMenuStrip != null)
                                gridControlDetail.ContextMenuStrip.Enabled = false;
                            gridViewDetail.OptionsBehavior.Editable = false;
                        }
                        if (treeList != null)
                        {
                            if (treeList.ContextMenuStrip != null)
                                treeList.ContextMenuStrip.Enabled = false;
                            treeList.OptionsBehavior.Editable = false;
                        }
                    }; break;
                case EFormStatus.eAdd:
                    {
                        foreach (var button in panelControl1.Controls)
                        {
                            if (button.GetType().Name == "SimpleButton")
                            {
                                var btn = (SimpleButton)button;
                                if (btn.Name == "btnCanle" || btn.Name == "btnSave")
                                {
                                    btn.Enabled = true;
                                }
                                else
                                {
                                    btn.Enabled = false;
                                }
                            }
                        }

                        if (gridControlDetail != null)
                        {
                            if (gridControlDetail.ContextMenuStrip != null)
                                gridControlDetail.ContextMenuStrip.Enabled = true;
                            gridViewDetail.OptionsBehavior.Editable = true;
                        }
                        if (treeList != null)
                        {
                            if (treeList.ContextMenuStrip != null)
                                treeList.ContextMenuStrip.Enabled = true;
                            treeList.OptionsBehavior.Editable = true;
                        }
                    }; break;
                case EFormStatus.eDelete:
                    {
                        foreach (var button in panelControl1.Controls)
                        {
                            if (button.GetType().Name == "SimpleButton")
                            {
                                var btn = (SimpleButton)button;
                                if (btn.Name == "btnAdd" || btn.Name == "btnSearch")
                                {
                                    btn.Enabled = true;
                                }
                                else
                                {
                                    btn.Enabled = false;
                                }
                            }
                        }

                        if (gridControlDetail != null)
                        {
                            if (gridControlDetail.ContextMenuStrip != null)
                                gridControlDetail.ContextMenuStrip.Enabled = false;
                            gridViewDetail.OptionsBehavior.Editable = false;
                        }
                        if (treeList != null)
                        {
                            if (treeList.ContextMenuStrip != null)
                                treeList.ContextMenuStrip.Enabled = false;
                            treeList.OptionsBehavior.Editable = false;
                        }
                    }; break;
                case EFormStatus.eEdit:
                    {
                        foreach (var button in panelControl1.Controls)
                        {
                            if (button.GetType().Name == "SimpleButton")
                            {
                                var btn = (SimpleButton)button;
                                if (btn.Name == "btnCanle" || btn.Name == "btnSave")
                                {
                                    btn.Enabled = true;
                                }
                                else
                                {
                                    btn.Enabled = false;
                                }
                            }
                        }

                        if (gridControlDetail != null)
                        {
                            if (gridControlDetail.ContextMenuStrip != null)
                                gridControlDetail.ContextMenuStrip.Enabled = true;
                            gridViewDetail.OptionsBehavior.Editable = true;
                        }
                        if (treeList != null)
                        {
                            if (treeList.ContextMenuStrip != null)
                                treeList.ContextMenuStrip.Enabled = true;
                            treeList.OptionsBehavior.Editable = true;
                        }
                    }; break;
                case EFormStatus.eCanel:
                    {
                        foreach (var button in panelControl1.Controls)
                        {
                            if (button.GetType().Name == "SimpleButton")
                            {
                                var btn = (SimpleButton)button;
                                if (btn.Name == "btnAdd" || btn.Name == "btnDel" || btn.Name == "btnEdit")
                                {
                                    btn.Enabled = true;
                                }
                                else
                                {
                                    btn.Enabled = false;
                                }
                            }
                        }

                        if (gridControlDetail != null)
                        {
                            if (gridControlDetail.ContextMenuStrip != null)
                                gridControlDetail.ContextMenuStrip.Enabled = false;
                            gridViewDetail.OptionsBehavior.Editable = false;
                        }
                        if (treeList != null)
                        {
                            if (treeList.ContextMenuStrip != null)
                                treeList.ContextMenuStrip.Enabled = false;
                            treeList.OptionsBehavior.Editable = false;
                        }
                    }; break;
            }
        }

        public void SetLayoutControlReadOnly(bool flag, LayoutControlGroup col)
        {
            foreach (var con1 in col.Items)
            {
                if (con1.GetType().Name == "LayoutControlItem")
                {
                    LayoutControlItem con = con1 as LayoutControlItem;
                    if (con.Control == null) continue;
                    {
                        DevExpress.XtraEditors.BaseEdit d = con.Control as BaseEdit;
                        if (d != null && !string.IsNullOrEmpty(d.Name))
                        {
                            if (d.Name.Substring(3) == "creatorId" || d.Name.Substring(3) == "createTime" || d.Name.Substring(3) == "editorId" || d.Name.Substring(3) == "editTime" || d.Name.Substring(3) == "id" || readonlycon.Contains(d.Name))
                            {
                                d.ReadOnly = true;
                            }
                            else
                            {
                                d.ReadOnly = flag;
                            }
                        }
                    }
                }
            }
        }
        public void ClearScreen()
        {
            this.ID = "";////需要设置为空，表示新增
            ClearControlValue(this);
        }
        public void ClearControlValue(System.Windows.Forms.Control ctrl)
        {
            ClearSinglelValue(ctrl);
            if (ctrl.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.Control control in ctrl.Controls)
                {
                    ClearControlValue(control);
                }
            }
        }
        public void ClearSinglelValue(System.Windows.Forms.Control ctrl)
        {
            switch (ctrl.GetType().Name)
            {
                case "TextEdit":
                case "MemoEdit":
                    (ctrl).Text = "";
                    break;
                case "LookUpEdit":
                    ((LookUpEdit)ctrl).EditValue = "";
                    ((LookUpEdit)ctrl).Properties.NullText = "";
                    break;
                case "CheckEdit":
                    ((CheckEdit)ctrl).Checked = false;
                    break;

                case "ComboBoxEdit":
                    ((ComboBoxEdit)ctrl).EditValue = "";
                    break;
                case "TreeListLookUpEdit":
                    ((TreeListLookUpEdit)ctrl).EditValue = "";
                    break;
                case "CheckedComboBoxEdit":
                    ((CheckedComboBoxEdit)ctrl).SetEditValue("");
                    break;
                case "DateEdit":
                    ((DateEdit)ctrl).EditValue = null;
                    break;
            }
        }

        private void FrmBaseForm_Load(object sender, EventArgs e)
        {
            InitgrdListDataSourceFunction();
        }

        protected void ShowRowIndex(DataGridView dgv, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgv.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgv.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgv.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
    /// <summary>
    /// 窗体状态
    /// </summary>
    public enum EFormStatus
    {
        eViewTab = 5,//tab切换
        eView = 0,//详情
        eAdd = 1,//新增
        eEdit = 2,//编辑
        eDelete = 3,//删除
        eCanel = 6,//取消
        eInit = 7//初始化
    }
}