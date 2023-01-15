using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using Login;
using System;
using System.Windows.Forms;
using TirionWinfromFrame.Commons;
using TirionWinfromFrame.Profiles;

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
            DevExpress.Skins.SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Office 2007 Silver");
            BonusSkins.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            MapperProfile.ConfigGlobalMapper();
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