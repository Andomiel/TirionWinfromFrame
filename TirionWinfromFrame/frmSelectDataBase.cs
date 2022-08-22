using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using TirionWinfromFrame.Commons;

namespace TirionWinfromFrame
{
    public partial class frmSelectDataBase : FrmBaseForm
    {
        public frmSelectDataBase()
        {
            InitializeComponent();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var con = new DB())
            {
                string name= cmbDataBaseList.Text.Split("-".ToCharArray())[0];
                var data = con.sysDataBase.Where(p => p.name.Equals(name)).ToList();
                if (data.Count > 0)
                {
                    sysDataBase info = data.First();
                    txtConnurl.Text = info.connecturl;
                }
                else
                {
                    txtConnurl.Text = "";
                }
            }
        }
        /// <summary>
        ///初始化数据连接下拉框
        /// </summary>
        private void init()
        {
            cmbDataBaseList.Properties.Items.Clear();
            using (var con=new DB())
            {
                var data= con.sysDataBase.ToList();
                foreach (var item in data)
                {
                    cmbDataBaseList.Properties.Items.Add($"{item.name}-{item.serverip}-{item.databasename}");
                }
                cmbDataBaseList.SelectedIndex = 0;
                var data2 = con.sysDataTableInfo.ToList();
                foreach (var item in data2)
                {
                    repositoryItemComboBox2.Items.Add(item.DataTableName);
                }
                cmbDataBaseList.SelectedIndex = 0;
            }
        }

        private void frmSelectDataBase_Load(object sender, EventArgs e)
        {
            init();
            repositoryItemComboBox1.SelectedIndexChanged += repositoryItemComboBox1SelectedIndexChanged;
        }
        private void repositoryItemComboBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            var com = sender as ComboBoxEdit;
            string type= com.SelectedItem.ToString();
            ControlInfo info=  gridView1.GetFocusedRow() as ControlInfo;
            info.controlType = com.EditValue.ToString();
            //info.controlName = getControlName(info.dataBaseFieldName, info.controlType);
            gridView1.PostEditor();
        }
        /// <summary>
        /// 新建数据连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCreateDataBaseConn frm = new FrmCreateDataBaseConn();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                init();
                cmbDataBaseList.Text = $"{frm.dbEntity.name}-{frm.dbEntity.serverip}-{frm.dbEntity.databasename}";
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textEdit1.Text))
            {
                "请填写命名空间".ShowWarning();
                textEdit1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textEdit2.Text))
            {
                "请选择输出目录".ShowWarning();
                textEdit2.Focus();
                return;
            }
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            List<ControlInfo> list = gridControl1.DataSource as List<ControlInfo>;
            EntityAdapter adp = new EntityAdapter();
            WinformAdapter winform = new WinformAdapter();
            DBAdapter dbAdapter = new DBAdapter();
            var dic=list.GroupBy(p => p.tableName);
            try
            {
                List<string> tableList = new List<string>();
                foreach (var item in dic)
                {
                    if(isEntity.Checked)
                        adp.create(item.Key, textEdit1.Text, textEdit2.Text, item.ToList());
                    if(isWinform.Checked)
                        winform.create(item.Key, textEdit1.Text, textEdit2.Text, item.ToList());
                    tableList.Add(item.Key);
                }
                if(isDB.Checked)
                    dbAdapter.create(textEdit1.Text, textEdit2.Text, tableList);
                "生成成功！".ShowTips();
            }
            catch (Exception ex)
            {
                ex.StackTrace.ShowError();
            }
            

            SplashScreenManager.CloseForm();
        }
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (wizardControl1.SelectedPageIndex ==0)
            {
                cmbtablelist.Properties.Items.Clear();
                using (SqlConnection con = new SqlConnection(txtConnurl.Text))
                {
                    con.Open();
                    string sqlGetAllTables = "select TABLE_NAME from INFORMATION_SCHEMA.TABLES order by TABLE_NAME";
                    SqlCommand sqlCommand = new SqlCommand(sqlGetAllTables,con);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())  //如果能读到数据，一行一行地读
                    {
                        string tablename = reader["TABLE_NAME"].ToString();
                        cmbtablelist.Properties.Items.Add(tablename);
                    }
                    reader.Close();
                }
            }
            if (wizardControl1.SelectedPageIndex == 1)
            {
                var data = cmbtablelist.Properties.Items.Where(p=>p.CheckState==CheckState.Checked).ToList();
                if (data.Count > 0)
                {
                    SplashScreenManager.ShowForm(typeof(WaitForm1));
                    List<ControlInfo> list = new List<ControlInfo>();
                    using (SqlConnection con = new SqlConnection(txtConnurl.Text))
                    {
                        con.Open();
                        foreach (var item in data)
                        {

                            string strsql2 = $"SELECT TABLE_NAME,COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='{item.Value}'";
                            List<string> keysList = new List<string>();
                            SqlCommand sqlCommand2 = new SqlCommand(strsql2, con);
                            SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                            while (reader2.Read())  //如果能读到数据，一行一行地读
                            {
                                keysList.Add(reader2["COLUMN_NAME"].ToString());
                            }
                            reader2.Close();

                            string strsql3 = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.columns WHERE TABLE_NAME='{item.Value}' AND  COLUMNPROPERTY( OBJECT_ID('{item.Value}'),COLUMN_NAME,'IsIdentity')=1";
                            List<string> IdentityList = new List<string>();
                            SqlCommand sqlCommand3 = new SqlCommand(strsql3, con);
                            SqlDataReader reader3 = sqlCommand3.ExecuteReader();
                            while (reader3.Read())  //如果能读到数据，一行一行地读
                            {

                                IdentityList.Add(reader3["COLUMN_NAME"].ToString());
                            }
                            reader3.Close();

                            string sqlGetAllTables = @"SELECT 
                            字段名 = convert(varchar(100), a.name),
                            表名 = convert(varchar(50), d.name),
                            类型 = CONVERT(varchar(50), b.name),
                            库名 = 'ServerModeXpoDemo',
                            字段说明 = convert(varchar(50), isnull(g.[value], ''))
                            FROM dbo.syscolumns a
                            left join dbo.systypes b on a.xusertype = b.xusertype
                            inner join dbo.sysobjects d on a.id = d.id and d.xtype = 'U' and d.name <> 'dtproperties'
                            left join dbo.syscomments e on a.cdefault = e.id
                            left join sys.extended_properties g on a.id = g.major_id and a.colid = g.minor_id
                            left join sys.extended_properties f on d.id = f.major_id and f.minor_id = 0 "+ $"where d.name = '{item.Value}'";
                            SqlCommand sqlCommand = new SqlCommand(sqlGetAllTables, con);
                            SqlDataReader reader = sqlCommand.ExecuteReader();
                            while (reader.Read())  //如果能读到数据，一行一行地读
                            {
                                ControlInfo info = new ControlInfo()
                                {
                                    tableName = reader["表名"].ToString(),
                                    dataBaseFieldName = reader["字段名"].ToString(),
                                    dataBaseFieldType = reader["类型"].ToString(),
                                    CSharpFieldType = SqlserverDataTypeToModelDataType.ChangedType(reader["类型"].ToString()),
                                    CSharpFieldName = reader["字段名"].ToString(),
                                    controlName ="txt"+ reader["字段名"],
                                    dataBaseFieldDDesr= reader["字段说明"].ToString(),
                                    controlLabelName =  string.IsNullOrEmpty(reader["字段说明"].ToString()) ? reader["字段名"].ToString() : reader["字段说明"].ToString(),
                                    controlType = "TextEdit",
                                    // isNull = reader["IS_NULLABLE"].ToString().ToBoolean(),
                                    isKey = keysList.Contains(reader["字段名"].ToString()),
                                    isIdentity = IdentityList.Contains(reader["字段名"].ToString())
                                };
                                list.Add(info);
                            }
                            reader.Close();
                        }

                        gridControl1.DataSource = list;
                    }
                    SplashScreenManager.CloseForm();
                }
                else
                {
                    "请选择至少一张表！".ShowWarning();
                    e.Handled = true;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (xtraFolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textEdit2.Text = xtraFolderBrowserDialog1.SelectedPath;
            }
        }

        private string getControlName(string controlname,string type)
        {
            string name = string.Empty;
            switch (type)
            {
                case "TextEdit":
                    name = "txt" + controlname;
                    break;
                case "DateEdit":
                    name = "txt" + controlname;
                    break;
                case "SimpleButton":
                    name = "txt" + controlname;
                    break;
                case "CheckEdit":
                    name = "txt" + controlname;
                    break;
                case "MemoEdit":
                    name = "txt" + controlname;
                    break;
                case "LookUpEdit":
                    name = "txt" + controlname;
                    break;
                case "ComboBoxEdit":
                    name = "txt" + controlname;
                    break;
                case "PictureEdit":
                    name = "txt" + controlname;
                    break;
                case "TreeListLookUpEdit":
                    name = "txt" + controlname;
                    break;
            }
            return name;
        }
    }
}