using DevExpress.XtraLayout;
using DevExpress.XtraTreeList.Nodes;
using MES.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace MES.Form
{
    public partial class FrmsysRole : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
        private List<int> userids = new List<int>();
		public FrmsysRole()
		{
			InitializeComponent();
		}
		private void FrmsysRole_Load(object sender, EventArgs e)
        {
            InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new sysRoleInfo());
            InitSearchDicData();
        }
        /// <summary>
		/// 数据源初始化
		/// </summary>
		/// <returns></returns>
		private void Init()
		{
            txtcompanyId.Properties.DataSource = GetDataTableUtils.SqlTable("部门");     
            repositoryItemTreeListtxtcompanyId.DataSource= GetDataTableUtils.SqlTable("部门");  
            txtcreatorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
            repositoryItemtxtcreatorId.DataSource= GetDataTableUtils.SqlTable("用户");  
            txteditorId.Properties.DataSource = GetDataTableUtils.SqlTable("用户");     
            repositoryItemtxteditorId.DataSource= GetDataTableUtils.SqlTable("用户");
            repositoryItemLookUpEdit1.DataSource = GetDataTableUtils.SqlTable("部门");

            treeList1.DataSource = GetDataTableUtils.SqlTable("角色功能");
            treeList1.OptionsSelection.MultiSelect = true;
            treeList1.OptionsSelection.UseIndicatorForSelection = true;
			treeList1.OptionsView.ShowCheckBoxes = true;
            treeList1.ExpandAll();



            treeList2.DataSource = GetDataTableUtils.SqlTable("用户-角色");
            treeList2.OptionsSelection.MultiSelect = true;
            treeList2.OptionsSelection.UseIndicatorForSelection = true;
            treeList2.OptionsView.ShowCheckBoxes = true;
            treeList2.ExpandAll();
            using (var db = new MESDB())
            {
                ///根据角色id获取用户
                if(!string.IsNullOrEmpty(txtid.Text))
                     userids = db.Database
                    .SqlQuery<int>(
                        $"select u.id from sysuserrole r left join sysuser u on r.userid=u.id where r.roleid={txtid.Text} and u.id is not null").ToListAsync()
                    .Result;
            }
            if (treeList2.Nodes.Count > 0)
            {
                foreach (TreeListNode node in treeList2.Nodes)//拿所有结点
                {
                    DataRowView drv = treeList2.GetDataRecordByNode(node) as DataRowView;//强转选中状态的行
                    if (userids.Contains((int)drv["id"]))
                    {
                        node.Checked = true;
                    }
                }
            }
        }

        public override void gridControlMouseDoubleClickFunction(object sender, EventArgs e)
        {

            treeList1.DataSource = null;
            treeList1.DataSource = GetDataTableUtils.SqlTable("角色功能");
            treeList1.ExpandAll();

            treeList2.DataSource = null;
            treeList2.DataSource = GetDataTableUtils.SqlTable("用户-角色");
            treeList2.ExpandAll();

            gridControl1.DataSource = null;

            sysRoleInfo user = grdListView.GetFocusedRow() as sysRoleInfo;
            if (user != null)
            {
                using (var db = new MESDB())
                {
                    ids = db.Database.SqlQuery<int>($"select functionId from sysRoleFunction where roleId={user.id} and functionId is not null").ToListAsync().Result;
                    ///根据角色id获取用户
                    userids = db.Database
                        .SqlQuery<int>(
                            $"select u.id from sysuserrole r left join sysuser u on r.userid=u.id where r.roleid={user.id} and u.id is not null").ToListAsync()
                        .Result;
                    gridControl1.DataSource = db.sysUserInfo.ToList().Where(p => userids.Contains(p.id));

                }
                if (treeList2.Nodes.Count > 0)
                {
                    foreach (TreeListNode node in treeList2.Nodes)//拿所有结点
                    {
                        DataRowView drv = treeList2.GetDataRecordByNode(node) as DataRowView;//强转选中状态的行
                        if (userids.Contains((int)drv["id"]))
                        {
                            node.Checked = true;
                        }
                    }
                }
                if (treeList1.Nodes.Count > 0)
                {
                    foreach (TreeListNode node in treeList1.Nodes)//拿所有结点
                    {
                        SetCheckStatus(node);
                    }
                }
            }
            
        }
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
			fieldDictionary.Add("ID","id");     
			//fieldDictionary.Add("公司id","companyId");     
			fieldDictionary.Add("公司名称","companyName");     
			fieldDictionary.Add("角色名称","name");     
			//fieldDictionary.Add("创建人","creatorId");     
			fieldDictionary.Add("创建时间","createTime");     
			//fieldDictionary.Add("编辑人","editorId");     
			fieldDictionary.Add("编辑时间","editTime");     
        }
        List<int> ids = new List<int>();//用来存储ID
        /// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            try
            {
                ids.Clear();
                if (treeList1.Nodes.Count > 0)
                {
                    foreach (TreeListNode node in treeList1.Nodes)//拿所有结点
                    {
                        GetCheckedID(node);
                    }
                }

                sysRoleInfo info= (sysRoleInfo)this.ControlDataToModel(new sysRoleInfo());

                using (var db = new MESDB())
                {
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.sysRoleInfo.AddOrUpdate(info);
                            db.SaveChanges();
                            db.Database.ExecuteSqlCommand($"delete from sysRoleFunction where roleId={info.id}");
                            db.Database.ExecuteSqlCommand($"delete from sysUserRole where roleId={info.id}");

                            string sql = "";
                            foreach (var item in ids)
                            {
                                sql += $"INSERT INTO sysRoleFunction VALUES ({info.id},{item});";
                            }
                            if (!string.IsNullOrEmpty(sql))
                                db.Database.ExecuteSqlCommand(sql);
                            var dd = gridControl1.DataSource as IEnumerable<sysUserInfo>;
                            string sql2 = "";
                            foreach (sysUserInfo item in dd)
                            {
                                sql2 += $"INSERT INTO sysUserRole VALUES ({item.id},{info.id});";
                            }
                            if(!string.IsNullOrEmpty(sql2))
                                db.Database.ExecuteSqlCommand(sql2);
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
		public override void InitgrdListDataSource()
        {
            using (var con=new MESDB())
            {
				grdList.DataSource=con.sysRoleInfo.ToList();
            }
            Init();
            if (treeList1.Nodes.Count > 0)
            {
                foreach (TreeListNode node in treeList1.Nodes)//拿所有结点
                {
                    SetCheckStatus(node);
                }
            }
        }

	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtcompanyId.EditValue.ToString()))
			{
				"公司id不能为空".ShowWarning();
				txtcompanyId.Focus();
				return false;
			}
			////if(string.IsNullOrEmpty(txtcompanyName.EditValue.ToString()))
			////{
			////	"公司名称不能为空".ShowWarning();
			////	txtcompanyName.Focus();
			////	return false;
			////}
			if(string.IsNullOrEmpty(txtname.EditValue.ToString()))
			{
				"角色名称不能为空".ShowWarning();
				txtname.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcreatorId.EditValue.ToString()))
			{
				"创建人不能为空".ShowWarning();
				txtcreatorId.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtcreateTime.Text))
			{
				"创建时间不能为空".ShowWarning();
				txtcreateTime.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txteditorId.EditValue.ToString()))
			{
				"编辑人不能为空".ShowWarning();
				txteditorId.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txteditTime.Text))
			{
				"编辑时间不能为空".ShowWarning();
				txteditTime.Focus();
				return false;
			}
			return true;
        }
        /// <summary>
		/// 删除
		/// </summary>
		/// <returns></returns>
		public override bool DelFunction()
        {
            try
            {
                sysRoleInfo info = (sysRoleInfo)this.ControlDataToModel(new sysRoleInfo());
                using (var db = new MESDB())
                {
                   
                    using (var tran = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.Entry(info).State = EntityState.Deleted;
                            db.SaveChanges();


                            db.sysRoleInfo.AddOrUpdate(info);
                            db.SaveChanges();
                            db.Database.ExecuteSqlCommand($"delete from sysRoleFunction where roleId={info.id}");
                            db.Database.ExecuteSqlCommand($"delete from sysUserRole where roleId={info.id}");

                            string sql = "";
                            foreach (var item in ids)
                            {
                                sql += $"INSERT INTO sysRoleFunction VALUES ({info.id},{item});";
                            }
                            db.Database.ExecuteSqlCommand(sql);
                            var dd = gridControl1.DataSource as IEnumerable<sysUserInfo>;
                            string sql2 = "";
                            foreach (sysUserInfo item in dd)
                            {
                                sql2 += $"INSERT INTO sysUserRole VALUES ({item.id},{info.id});";
                            }
                            db.Database.ExecuteSqlCommand(sql2);
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
        /// <summary>
		/// 搜索
		/// </summary>
		/// <returns></returns>
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
                        grdList.DataSource = db.sysRoleInfo.SqlQuery("select * from sysRole").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.sysRoleInfo.SqlQuery($"select * from sysRole where {sql}").ToList();
                    }
                }
            }
        }

        private void btnRefrsh_Click(object sender, EventArgs e)
        {
            treeList1.DataSource = GetDataTableUtils.SqlTable("角色功能");
            treeList1.ExpandAll();
            if (treeList1.Nodes.Count > 0)
            {
                foreach (TreeListNode node in treeList1.Nodes)//拿所有结点
                {
                    SetCheckStatus(node);
                }
            }
        }

        private void GetCheckedID(TreeListNode parentNode)
        {
           
            if (parentNode.Nodes.Count == 0) return;//递归终止
            foreach (TreeListNode node in parentNode.Nodes)
            {
                if (node.CheckState == CheckState.Checked)//判断当前节点选择状态
                {
                    DataRowView drv = treeList1.GetDataRecordByNode(node) as DataRowView;//强转选中状态的行
                    if (drv != null)
                    {
                        int id = (int)drv["ID"];
                        ids.Add(id);
                    }
                }
                GetCheckedID(node);//执行递归
            }
        }

        private void SetCheckStatus(TreeListNode parentNode)
        {
            if (parentNode.Nodes.Count == 0) return;//递归终止
            foreach (TreeListNode node in parentNode.Nodes)
            {
                DataRowView drv = treeList1.GetDataRecordByNode(node) as DataRowView;//强转选中状态的行
                if (ids.Contains((int) drv["ID"]))
                {
                    node.Checked = true;
                }
                SetCheckStatus(node);//执行递归
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {
               treeList2.DataSource= db.sysUserInfo.OrderByDescending(p => p.account.Equals(textEdit1.Text)).ToList();
            }
            using (var db = new MESDB())
            {
                //ids = db.Database.SqlQuery<int>($"select functionId from sysRoleFunction where roleId={txtid.Text}").ToListAsync().Result;
                ///根据角色id获取用户
                userids = db.Database
                    .SqlQuery<int>(
                        $"select u.id from sysuserrole r left join sysuser u on r.userid=u.id where r.roleid={txtid.Text} and u.id is not null").ToListAsync()
                    .Result;
               // gridControl1.DataSource = db.sysUserInfo.ToList().Exists(p => userids.Contains(p.id));

            }
            if (treeList2.Nodes.Count > 0)
            {
                foreach (TreeListNode node in treeList2.Nodes)//拿所有结点
                {
                    sysUserInfo drv = treeList2.GetDataRecordByNode(node) as sysUserInfo;//强转选中状态的行
                    if (userids.Contains(drv.id))
                    {
                        node.Checked = true;
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            List<sysUserInfo> userInfos = new List<sysUserInfo>();

            foreach (TreeListNode node in treeList2.Nodes)
            {
                if (node.Checked)
                {
                    
                    if (treeList2.GetDataRecordByNode(node).GetType() == typeof(DataRowView))
                    {
                        DataRowView drv = treeList2.GetDataRecordByNode(node) as DataRowView;
                        userInfos.Add(new sysUserInfo()
                        {
                            id = drv.Row["id"].ToString().ToInt16(),
                            account = drv.Row["account"].ToString(),
                            username = drv.Row["username"].ToString(),
                            deptId = drv.Row["deptId"].ToString().ToInt16(),
                        });
                    }
                    else
                    {
                        sysUserInfo drv = treeList2.GetDataRecordByNode(node) as sysUserInfo;
                        userInfos.Add(new sysUserInfo()
                        {
                            id = drv.id,
                            account = drv.account,
                            username = drv.username,
                            deptId = drv.deptId,
                        });
                    }
                    
                    
                }
            }
            gridControl1.DataSource = userInfos;
        }
    }
}