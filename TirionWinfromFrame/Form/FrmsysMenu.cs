using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;
using DevExpress.XtraLayout;
using MES.Entity;

namespace MES.Form
{
    
    public partial class FrmsysMenu : FrmBaseForm
    {
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmsysMenu()
		{
			InitializeComponent();
            
		}
		private void FrmsysMenu_Load(object sender, EventArgs e)
        {
            InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new sysMenuInfo());
            InitSearchDicData();
        }

        public override void InitgrdListDataSource()
        {
            using (var con = new MESDB())///
            {
                grdList.DataSource = con.sysMenuInfo.ToList();
            }
            Init();
        }
        private void Init()
		{
            txtpid.Properties.DataSource = GetDataTableUtils.SqlTable("菜单tree");     
			repositoryItemTreeListtxtpid.DataSource= GetDataTableUtils.SqlTable("菜单tree");
            //txttoolList.Properties.DataSource = GetDataTableUtils.SqlTable("功能按钮");     
            repositoryItemCheckedComboBoxEdit1.DataSource= GetDataTableUtils.SqlTable("功能按钮");
            txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
			repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");  
			txteditorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");
            repositoryItemtxteditorId.DataSource = GetDataTableUtils.SqlTable("用户");
        }
        private void InitSearchDicData()
        {
            fieldDictionary.Add("菜单名称", "name");
            //fieldDictionary.Add("创建时间", "createTime");
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string file = GetIconPath();
            if (!string.IsNullOrEmpty(file))
            {
                this.txticon.Text = file;
            }
        }
        private string GetIconPath()
        {
            string file = FileDialogHelper.Open("选择图标文件", FileDialogHelper.ImageFilter, "", Application.StartupPath+"\\Images");
            string result = "";
            if (!string.IsNullOrEmpty(file))
            {
                result = file.Replace(Application.StartupPath, "").Trim('\\');
            }

            return result;
        }

        public override bool SaveFunction()
        {
            try
            {
                sysMenuInfo info= (sysMenuInfo)this.ControlDataToModel(new sysMenuInfo());
                using (var db = new MESDB())
                {
                    db.Database.Log = Console.WriteLine;
                    db.sysMenuInfo.AddOrUpdate(info);
                    db.SaveChanges();
                    txtid.Text = info.id.ToString();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ShowError();
                return false;
            }
            return true;
        }

        public override bool DelFunction()
        {
            try
            {
                sysMenuInfo info = (sysMenuInfo)this.ControlDataToModel(new sysMenuInfo());
                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.Entry(info).State = EntityState.Deleted;
                            db.SaveChanges();
                            db.Database.ExecuteSqlCommand($"delete from sysRoleFunction where roleId={info.id}");
                            db.Database.ExecuteSqlCommand($"delete from sysUserRole where roleId={info.id}");
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            ex.Message.ShowError();
                        }
                        finally
                        {
                            tran.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ShowError();
                return false;
            }
            return true;
        }

        public override void SearchFunction()
        {
            FrmSearch frm = new FrmSearch(fieldDictionary);
            if (frm.ShowDialog()==DialogResult.OK)
            {
                string sql = frm.sql;
                using (var db = new MESDB())
                {
                    if (string.IsNullOrEmpty(sql))
                    {
                        grdList.DataSource = db.sysMenuInfo.SqlQuery("select * from sysMenu").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.sysMenuInfo.SqlQuery($"select * from sysMenu where {sql}").ToList();
                    }
                }
            }
        }
    }
}