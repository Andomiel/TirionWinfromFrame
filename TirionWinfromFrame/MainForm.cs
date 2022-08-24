using DevExpress.XtraBars.Helpers;
using DevExpress.XtraNavBar;
using MES;
using MES.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using TirionWinfromFrame.Commons;
using Login;

namespace TirionWinfromFrame
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            SplashScreenManager.ShowForm(this, typeof(LoadForm), true, true, false);
            for (int i = 1; i <= 100; i++)
            {
                SplashScreenManager.Default.SendCommand(LoadForm.SplashScreenCommand.SetProgress, i);
                SplashScreenManager.Default.SendCommand(LoadForm.SplashScreenCommand.Command2, "正在加载.." + i + "%");
                //To process commands, override the SplashScreen.ProcessCommand method.
                Thread.Sleep(new Random().Next(1, 20));
            }
            SplashScreenManager.CloseForm(false);
        }

        private void InitData()
        {
            using (var db = new MESDB())
            {
                AppInfo.FunctionList = db.Database.SqlQuery<string>(string.Format(@"SELECT  a.functionCode
                FROM[dbo].[sysFunction] a
                    left join[dbo].[sysRoleFunction] b on a.id = b.functionId
                    left join[dbo].[sysUserRole] c on b.roleId = c.roleId
                    left join[dbo].[sysUser] d on d.id = c.userId
                where d.account = '{0}'", AppInfo.LoginUserInfo.account)).ToListAsync().Result;
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1);
            Init();
            barUserName.Caption = $"用户名:{AppInfo.LoginUserInfo.username}";
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            bsi_Date.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            NavBarItem navBarItem = sender as NavBarItem;
            ChildWinManagement.LoadShowForm(this, typeof(FrmShowForm), navBarItem.Caption, 1);
        }

        private void Init()
        {
            InitData();
            NarBarInit();
        }

        private void NarBarInit()
        {
            navBarControl1.Items.Clear();
            List<sysMenuInfo> menusList = new List<sysMenuInfo>();
            using (var db = new MESDB())
            {
                menusList = db.sysMenuInfo.Where(p => p.isEnabled).ToList();
            }
            foreach (var item in menusList)
            {
                if (item.pid == 0 && AppInfo.FunctionList.Contains(item.functionCode))
                {
                    NavBarGroup gNavBarGroup = new NavBarGroup(item.name);
                    foreach (var itemInfo in menusList)
                    {
                        if (itemInfo.pid == item.id && AppInfo.FunctionList.Contains(itemInfo.functionCode))
                        {
                            NavBarItem navBarItem = new NavBarItem(itemInfo.name);
                            navBarItem.LinkClicked += (sender, args) =>
                            {
                                NavBarItem nav = sender as NavBarItem;
                                SplashScreenManager.ShowForm(typeof(frmLoading));
                                ChildWinManagement.LoadShowForm(this, typeof(FrmShowForm), nav.Caption, itemInfo.id);
                                SplashScreenManager.CloseForm();
                            };
                            NavBarItemLink navBarItemLink = new NavBarItemLink(navBarItem);
                            gNavBarGroup.ItemLinks.Add(navBarItemLink);
                        }
                    }
                    navBarControl1.Groups.Add(gNavBarGroup);
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //使用QQ开放平台的发邮件界面
            string mailUrl = string.Format("mailto:tirion@passioniot.com");

            Process.Start(new ProcessStartInfo("cmd", $"/c start {mailUrl}")
            {
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ("您确定要注销登录吗？".ShowYesNoAndTips() == DialogResult.Yes)
            {
                Application.Exit();
                System.Diagnostics.Process.Start(Application.StartupPath + "\\TirionWinfromFrame.Start.exe");
            }
        }

        private void barBtnChangePwd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmChangePwd pwdFrm = new FrmChangePwd();
            pwdFrm.ShowDialog();
        }
    }
}
