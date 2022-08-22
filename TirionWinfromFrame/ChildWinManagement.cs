using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using MES.Form;
using TirionWinfromFrame.Commons;
namespace TirionWinfromFrame
{
    public sealed class ChildWinManagement
    {
        private ChildWinManagement()
        {
        }

        public static bool ExistWin(System.Windows.Forms.Form MDIwin, string caption)
        {
            bool flag = false;
            foreach (System.Windows.Forms.Form mdiChild in MDIwin.MdiChildren)
            {
                if (mdiChild.Text == caption)
                {
                    flag = true;
                    mdiChild.Show();
                    mdiChild.Activate();
                    break;
                }
            }

            return flag;
        }

        public static System.Windows.Forms.Form LoadMdiForm(System.Windows.Forms.Form mainDialog, Type formType,string code)
        {

            bool flag = false;
            System.Windows.Forms.Form form = (System.Windows.Forms.Form)null;
            foreach (System.Windows.Forms.Form mdiChild in mainDialog.MdiChildren)
            {
                if (mdiChild.GetType() == formType)
                {
                    flag = true;
                    form = mdiChild;
                    break;
                }
            }

            if (!flag)
            {
               
                form = (System.Windows.Forms.Form)Activator.CreateInstance(formType);
                var dd = form.GetType().GetBaseType().GetField("menucode");
                dd.SetValue(form, code);
                form.MdiParent = mainDialog;
                form.Show();
            }


            form.BringToFront();
            form.Activate();
            return form;
        }
        public static System.Windows.Forms.Form LoadShowForm(System.Windows.Forms.Form mainDialog, Type formType, string caption, int formId)
        {

            bool flag = false;
            System.Windows.Forms.Form form = (System.Windows.Forms.Form)null;
            foreach (System.Windows.Forms.Form mdiChild in mainDialog.MdiChildren)
            {
                if (mdiChild.GetType() == formType)
                {
                    flag = true;
                    form = mdiChild;
                    break;
                }
            }

            if (!flag)
            {
                form = (System.Windows.Forms.Form)Activator.CreateInstance(formType);
                form.MdiParent = mainDialog;
            }
            FrmShowForm frmShowForm = form as FrmShowForm;
            frmShowForm.Text = caption;
            frmShowForm.formId = formId;
            frmShowForm.Init();
            frmShowForm.Show();
            MainForm manForm = mainDialog as MainForm;
            frmShowForm.mainform = manForm;
            form.BringToFront();
            form.Activate();
            return form;
        }
        public static void PopControlForm(Type control, string caption)
        {
            object instance = ReflectionUtil.CreateInstance(control);
            if (!typeof(Control).IsAssignableFrom(instance.GetType()))
                return;
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            form.WindowState = FormWindowState.Maximized;
            form.ShowIcon = false;
            form.Text = caption;
            form.ShowInTaskbar = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            Control control1 = instance as Control;
            control1.Dock = DockStyle.Fill;
            form.Controls.Add(control1);
            int num = (int)form.ShowDialog();
        }

        public static void PopDialogForm(Type type)
        {
            object instance = ReflectionUtil.CreateInstance(type);
            if (!typeof(System.Windows.Forms.Form).IsAssignableFrom(instance.GetType()))
                return;
            System.Windows.Forms.Form form = instance as System.Windows.Forms.Form;
            form.ShowInTaskbar = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            int num = (int)form.ShowDialog();
        }
    }
}