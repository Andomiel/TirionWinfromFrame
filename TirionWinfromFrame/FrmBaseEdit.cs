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
    public partial class FrmBaseEdit : DevExpress.XtraEditors.XtraForm
    {
        public FrmBaseEdit()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Save())
                "保存成功".ShowTips();
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            Exit();
            this.Close();
        }

        public virtual bool Save()
        {
            return false;
        }
        public virtual void Exit()
        {
            
        }
    }
}