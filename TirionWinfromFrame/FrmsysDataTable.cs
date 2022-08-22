using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using MES.Entity;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace MES.Form
{
	public partial class FrmsysDataTable : FrmBaseForm
    {
		public FrmsysDataTable()
		{
			InitializeComponent();
		}


        private void FrmsysDataTable_Load(object sender, EventArgs e)
        {
            grdListView.OptionsBehavior.Editable = false;
            using (var db=new DB())
            {
                grdList.DataSource = db.sysDataTableInfo.ToList();
            }
            init();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var db = new DB())
            {
                var info = db.sysDataBase.Where(p => p.name.Equals(comboBoxEdit1.Text)).FirstOrDefault();
                if(info!=null)
                    txtDataTableUrl.Text = info.connecturl;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDataTableSql.Text))
            {
                "请填写SQL！".ShowWarning();
                txtDataTableSql.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDataTableUrl.Text))
            {
                "请选择数据源！".ShowWarning();
                comboBoxEdit1.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txtDataTableSql.Text)&&!string.IsNullOrEmpty(txtDataTableUrl.Text))
            {
                gridView1.Columns.Clear();
                try
                {
                    using (SqlConnection connection = new SqlConnection(txtDataTableUrl.Text))
                    {
                        connection.Open();
                        gridControl1.DataSource = SqlTable(txtDataTableSql.Text, connection);
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ShowError();
                }
            }
        }
        /// <summary>
        ///初始化数据连接下拉框
        /// </summary>
        private void init()
        {
            comboBoxEdit1.Properties.Items.Clear();
            using (var con = new DB())
            {
                var data = con.sysDataBase.ToList();
                foreach (var item in data)
                {
                    comboBoxEdit1.Properties.Items.Add(item.name);
                }

                comboBoxEdit1.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDataTableName.Text))
            {
                "请填写数据集名称！".ShowWarning();
                txtDataTableName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDataTableSql.Text))
            {
                "请填写SQL！".ShowWarning();
                txtDataTableSql.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtDataTableUrl.Text))
            {
                "请选择数据源！".ShowWarning();
                comboBoxEdit1.Focus();
                return;
            }

            try
            {
                using (var con = new DB())
                {
                    sysDataTableInfo info = new sysDataTableInfo()
                    {
                        DataTableName = txtDataTableName.Text,
                        DataTableUrl = txtDataTableUrl.Text,
                        DataTableSql = txtDataTableSql.Text,
                        DataSourceName = comboBoxEdit1.Text
                    };
                    con.sysDataTableInfo.AddOrUpdate(info);
                    con.SaveChanges();
                }

                "保存成功！".ShowTips();
                using (var db = new DB())
                {
                    grdList.DataSource = db.sysDataTableInfo.ToList();
                }
            }
            catch (Exception ex)
            {
                ex.StackTrace.ShowError();
            }

        }
        public static DataTable SqlTable(string sql, SqlConnection conn)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.Fill(dt);
            return dt;
        }

        private void txtDataTableName_Leave(object sender, EventArgs e)
        {
            using (var con = new DB())
            {
                var data = con.sysDataTableInfo.Find(txtDataTableName.Text);
                if (null != data)
                {
                    "数据集名称已存在！".ShowWarning();
                    txtDataTableName.Focus();
                }
            }
        }

        private void grdList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var dr = this.grdListView.GetFocusedRow();
            if (dr != null)
            {
                xtraTabControl1.SelectedTabPageIndex = 1;
                sysDataTableInfo info = dr as sysDataTableInfo;
                txtDataTableName.Text = info.DataTableName;
                txtDataTableUrl.Text = info.DataTableUrl;
                txtDataTableSql.Text = info.DataTableSql;
                comboBoxEdit1.Text = info.DataSourceName;
            }
        }
    }
}