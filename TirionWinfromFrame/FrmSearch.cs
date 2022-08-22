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
using TirionWinfromFrame.Commons;

namespace TirionWinfromFrame
{
    public partial class FrmSearch : DevExpress.XtraEditors.XtraForm
    {
        public string sql = string.Empty;
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
        public FrmSearch(Dictionary<string ,string>dic)
        {
            this.fieldDictionary = dic;
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSql.Text))
            {
                sql = txtSql.Text.Substring(0, txtSql.Text.Length - txtrelation.Text.Length);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btncanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtField.Text))
            {
                "字段不能为空！".ShowWarning();
                txtField.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtvalue.Text))
            {
                "值不能为空！".ShowWarning();
                txtvalue.Focus();
                return;
            }

            txtSql.MaskBox.AppendText(makeSql() + "\r\n");
        }

        private string makeSql()
        {
            string strsql = $" {fieldDictionary[txtField.Text]}{txtoperator.Text.Split("-".ToCharArray())[1]}'{txtvalue.Text}' {txtrelation.Text.Split("-".ToCharArray())[1]}";
            return strsql;
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            foreach (var item in fieldDictionary.Keys)
            {
                txtField.Properties.Items.Add(item);
            }
        }
    }
}