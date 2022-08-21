using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using MES;
using WinformGeneralDeveloperFrame;
using WinformGeneralDeveloperFrame.Commons;

namespace WinformGeneralDeveloperFrame
{
    public partial class XtraForm1 : FrmBaseForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {

        }

        private void grdListView_DoubleClick(object sender, EventArgs e)
        {

        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {
                //treeList1.DataSource = db.sysMenuInfo.ToList();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var con=ExtensionMethod.getControl(this, "checkedComboBoxEdit1");
        }

        public override  bool CheckInput()
        {
            return true;
        }
    }
}