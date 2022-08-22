using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using Login;
using TirionWinfromFrame.Commons;
using Commons;

namespace TirionWinfromFrame.Start
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.测试  1
        /// </summary>
        [STAThread]
        static void Main()
        {
            string str = EncodeHelper.AES_Encrypt("Data Source=123.60.77.182:1433;Initial Catalog=iWmsTest;User ID=sa;Password=p@ssw0rd;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            string str1 = EncodeHelper.AES_Decrypt(str);//
            DevExpress.Skins.SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Office 2007 Silver");
            BonusSkins.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            LoginView dlg = new LoginView();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                if (dlg.bLogin)
                {
                    Application.Run(new MainForm());
                }
            }
            dlg.Dispose();
        }
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            string exContent = ex.Exception.GetDeepException();
            if (DialogResult.Yes == $"系统发生错误，您需要退出系统吗？{Environment.NewLine}{exContent}".ShowYesNoAndError())
            {
                Application.Exit();
            }
        }

    }
}