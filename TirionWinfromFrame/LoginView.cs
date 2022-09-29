using Business;
using DevExpress.XtraEditors;
using MES;
using MES.Entity;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TirionWinfromFrame.Commons;
using Updater.Core;

namespace Login
{
    public partial class LoginView : XtraForm
    {
        //private BackgroundWorker updateWorker;
        public bool bLogin = false; //判断用户是否登录
        public LoginView()
        {
            InitializeComponent();

            lblVersion.Text = $"V{Application.ProductVersion}";

            #region 解决闪烁问题
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            #endregion
        }

        #region 解决闪烁问题
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014) // 禁掉清除背景消息
                return;
            base.WndProc(ref m);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        private void LoginView_Load(object sender, EventArgs e)
        {
            //updateWorker = new BackgroundWorker();
            //updateWorker.DoWork += new DoWorkEventHandler(updateWorker_DoWork);
            //updateWorker.RunWorkerAsync();
            ValidateVersion();
        }

        private void ValidateVersion()
        {
            string currentVersion = Application.ProductVersion;

            if (!GeneralBusiness.CompareVersion(currentVersion))
            {
                $"当前版本{currentVersion}低于最新版本，请在打开的页面下载最新版本安装！".ShowTips();

                System.Diagnostics.Process.Start("http://10.21.177.80:8088/VersionLogs.html");

                Application.Exit();
            }
        }

        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                UpdateClass update = new UpdateClass();
                bool newVersion = update.HasNewVersion;
                if (newVersion)
                {
                    //if (MessageUtil.ShowYesNoAndTips(Portal.gc.DicLag["Version"].Where(p => p.Name == Portal.gc.Language).First().Value) == DialogResult.Yes)
                    {
                        //Thread.Sleep(1500);
                        Process.Start(Path.Combine(Application.StartupPath, "Update.exe"), "121");
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show(ex.Message);
                ex.GetDeepException().ShowError();
            }
        }

        private void User_MouseEnter(object sender, EventArgs e)
        {
            skinPanel2.BackColor = Color.FromArgb(69, 159, 176);
        }

        private void User_MouseLeave(object sender, EventArgs e)
        {
            skinPanel2.BackColor = Color.FromArgb(127, 127, 127);
        }

        private void Password_MouseHover(object sender, EventArgs e)
        {

        }

        private void Password_MouseEnter(object sender, EventArgs e)
        {
            skinPanel1.BackColor = Color.FromArgb(69, 159, 176);
        }

        private void Password_MouseLeave(object sender, EventArgs e)
        {
            skinPanel1.BackColor = Color.FromArgb(127, 127, 127);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            LoginFunction();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Password.Focus();
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginFunction();
            }
        }

        private void LoginFunction()
        {
            if (CheckInput())
            {
                using (var db = new MESDB())
                {
                    sysUserInfo user = db.sysUserInfo.Where(p => p.account == User.Text).FirstOrDefault();
                    if (user == null)
                    {
                        "账号不存在！".ShowTips();
                        return;
                    }
                    else if (!user.password.Equals(MD5Utils.GetMD5_32(Password.Text)))
                    {
                        "密码错误！！".ShowTips();
                        return;
                    }
                    else
                    {
                        bLogin = true;
                        AppInfo.LoginUserInfo = user;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(User.Text))
            {
                User.Focus();
                "请输入账号！".ShowTips();
                return false;
            }
            if (string.IsNullOrEmpty(Password.Text))
            {
                Password.Focus();
                "请输入密码！".ShowTips();
                return false;
            }
            return true;
        }

        private void LoginView_Shown(object sender, EventArgs e)
        {
            User.Focus();
        }
    }
}
