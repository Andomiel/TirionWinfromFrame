using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Updater.Core;

namespace Update
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        //主程序传入的参数，系统标示 是否需要重新启动主程序
        //private string[] args;
        ////表示主程序打开时传入的参数
        //private readonly static string OPEN_FLAG = "121";
        //private bool isComplete = true;

        private UpdateClass updater;
        private List<Manifest> mList = new List<Manifest>();
        private int mLen = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {

                System.Threading.Thread.Sleep(10);
                //progressBarControl1.PerformStep();
                progressBarControl1.Position = i;
                lab_percent.Text = i + "%";
                //progressBarControl1.EditValue = i + 1;
                //处理当前消息队列中的所有windows消息,不然进度条会不同步
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                updater = new UpdateClass();
                updater.ActivationCompleted += new EventHandler<ActivationCompletedEventArgs>(ActivationCompleted);
                updater.ActivationError += new EventHandler<FileCopyErrorEventArgs>(ActivationError);
                updater.ActivationInitializing += new EventHandler<ManifestEventArgs>(ActivationInitializing);
                updater.ActivationProgressChanged += new EventHandler<FileCopyProgressChangedEventArgs>(ActivationProgressChanged);
                updater.ActivationStarted += new EventHandler<ActivationStartedEventArgs>(ActivationStarted);
                updater.DownloadCompleted += new EventHandler<DownloadCompleteEventArgs>(DownloadCompleted);
                updater.DownloadError += new EventHandler<DownloadErrorEventArgs>(DownloadError);
                updater.DownloadProgressChanged += new EventHandler<DownloadProgressEventArgs>(DownloadProgressChanged);

                InitUpdater();
            }
            catch (Exception ex)
            {
                Log.Write("更新错误：" + ex.Message);
                XtraMessageBox.Show("更新错误", "系统提示");
            }
        }
        void ActivationCompleted(object sender, ActivationCompletedEventArgs e)
        {
            //安装完成
            //isComplete = true;
            lab_filename.Text = "安装完成";
            lab_percent.Text = "100%";
            if (progressBarControl1.Position != 100)
            {
                progressBarControl1.Position = 100;
            }
            if (e.Error != null)
            {
                lab_filename.Text += "，但出现错误";
                lab_filename.Update();
            }
            else
            {
                lab_filename.Update();
                System.Threading.Thread.Sleep(3000);
                string filename = GetFileName(e.Manifest.MyApplication.Location, e.Manifest.MyApplication.EntryPoint.File);
                Startup(filename, e.Manifest.MyApplication.EntryPoint.Parameters);
                //if (args != null && args.Length > 0)
                {
                    Exit();
                }
            }
        }
        private string GetFileName(string location, string file)
        {
            return Path.Combine(Path.GetFullPath(location), file);
        }

        void ActivationError(object sender, FileCopyErrorEventArgs e)
        {
            Log.Write("安装过程中出现错误，错误描述：" + e.Error.Message + System.Environment.NewLine + "Version:" + e.Manifest.Version);
            XtraMessageBox.Show(this, "安装错误：" + e.Error.Message, "系统提示");
            lab_filename.Text = "系统正在回滚";
            updater.Rollback(e.Manifest);
        }
        void ActivationInitializing(object sender, ManifestEventArgs e)
        {
            lab_filename.Text = "正在初始化安装，请稍后......";
            lab_filename.Update();
            lab_percent.Text = "0%";
            lab_percent.Update();
            lab_fileinfo.Text = "";
            lab_fileinfo.Update();
            //progressBar1.Value = 0;
        }
        void ActivationProgressChanged(object sender, FileCopyProgressChangedEventArgs e)
        {
            progressBarControl1.Position = e.ProgressPercentage;
            lab_percent.Text = e.ProgressPercentage.ToString() + "%";
            lab_percent.Update();
            lab_fileinfo.Text = string.Format("字节数:{0}/{1}", e.BytesToCopy, e.TotalBytesToCopy);
            lab_fileinfo.Update();
            lab_filename.Text = "正在安装：" + e.SourceFileName;
            lab_filename.Update();
        }

        void ActivationStarted(object sender, ActivationStartedEventArgs e)
        {
            lab_filename.Text = "开始安装，请稍后......";
            lab_filename.Update();
            e.Cancel = CheckActivation();
            if (e.Cancel)
            {
                lab_filename.Text = "安装已被取消";
                //isComplete = true;
            }
        }
        private bool CheckActivation()
        {
            bool cancel = false;
            //检查主程序（进程名称）是否打开，如果打开则提示
            string[] processName = { "Client", "Server" };
            foreach (string name in processName)
            {
                System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(name);
                if (processes != null && processes.Length != 0)
                {
                    if (XtraMessageBox.Show(string.Format("进程{0}正在运行中，请关闭后重试。", name), "系统提示",
                         MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        cancel = true;
                        break;
                    }
                    else
                    {
                        return CheckActivation();
                    }
                }
            }
            return cancel;
        }

        /// <summary>
        /// 文件下载完毕执行的操作
        /// </summary>
        void DownloadCompleted(object sender, DownloadCompleteEventArgs e)
        {
            mList.Add(e.Manifest);
            if (mList.Count == mLen)
            {
                updater.Activate(mList.ToArray());
                mList.Clear();
            }
        }
        void DownloadError(object sender, DownloadErrorEventArgs e)
        {
            Log.Write("下载过程中出现错误，错误描述：" + e.Error.Message + System.Environment.NewLine + "Version:" + e.Manifest.Version);
            XtraMessageBox.Show("下载出错：" + e.Error.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void DownloadProgressChanged(object sender, DownloadProgressEventArgs e)
        {
            progressBarControl1.Position = e.ProgressPercentage;
            lab_percent.Text = e.ProgressPercentage.ToString() + "%";
            lab_percent.Update();
            lab_fileinfo.Text = string.Format("字节数:{0}/{1}", e.BytesReceived, e.TotalBytesToReceive);
            lab_fileinfo.Update();
            lab_filename.Text = "正在下载文件：" + e.FileName;
            lab_filename.Update();
        }
        private void InitUpdater()
        {
            //从配置文件动态设置更新标题
            UpdaterConfigurationView updateCfgView = new UpdaterConfigurationView();

            var manifests = updater.CheckForUpdates();
            mLen = manifests.Length;
            if (updater.HasNewVersion)
            {
                //显示本次更新内容
                string updateDescription = manifests[0].Description;
                this.lblUpdateLog.Text = string.Format("更新说明：{0}", updateDescription);

                //if (args != null && args.Length > 0)
                {
                    #region 关闭主程序
                    try
                    {
                        string entryPoint = manifests[0].MyApplication.EntryPoint.File;
                        KillProcessDos(entryPoint);
                    }
                    catch (Exception ex)
                    {
                        Log.Write(ex.ToString());

                    }
                    #endregion
                }
                //isComplete = false;
                updater.DownloadAsync(manifests);
            }
            else
            {
                lab_filename.Text = "";
                XtraMessageBox.Show("您当前的版本已经是最新，不需要更新。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Exit();
            }
        }
        /// <summary>
        /// 使用DOS关闭进程
        /// </summary>
        /// <param name="processName">进程名称</param>
        private void KillProcessDos(string processName)
        {
            RunCmd("taskkill /im " + processName + " /f ");
        }
        /// <summary>
        /// 系统退出
        /// </summary>
        private void Exit()
        {
            this.Close();
            Environment.Exit(0);
        }
        /// <summary>
        /// 带参数启动指定的应用程序
        /// </summary>
        /// <param name="entryPoint">入口的应用程序</param>
        /// <param name="parameters">程序启动参数</param>
        private void Startup(string entryPoint, string parameters)
        {
            try
            {
                // if (args != null && args.Length > 0)
                {
                    // if (args[0] == OPEN_FLAG)
                    {
                        //关闭主程序
                        ExeCommand("taskkill /im " + Path.GetFileName(entryPoint) + " /f ");
                        //启动主程序
                        System.Threading.Thread.Sleep(1000);
                        System.Diagnostics.Process.Start(entryPoint, parameters);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        /// <summary>
        /// DOS命令运行函数
        /// </summary>
        /// <param name="commandText"></param>
        private void ExeCommand(string commandText)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            try
            {
                p.Start();
                p.StandardInput.WriteLine(commandText);
                p.StandardInput.WriteLine("exit");
                //p.StandardOutput.ReadToEnd();
            }
            catch
            {

            }
        }
        /// <summary>
        /// 运行DOS命令
        /// DOS关闭进程命令(ntsd -c q -p PID )PID为进程的ID
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private void RunCmd(string command)
        {
            //實例一個Process類，啟動一個獨立進程
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            //Process類有一個StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：
            p.StartInfo.FileName = "cmd.exe";           //設定程序名
            p.StartInfo.Arguments = "/c " + command;    //設定程式執行參數
            p.StartInfo.UseShellExecute = false;        //關閉Shell的使用
            p.StartInfo.RedirectStandardInput = true;   //重定向標準輸入
            p.StartInfo.RedirectStandardOutput = true;  //重定向標準輸出
            p.StartInfo.RedirectStandardError = true;   //重定向錯誤輸出
            p.StartInfo.CreateNoWindow = true;          //設置不顯示窗口
            p.Start();   //啟動

            //p.StandardInput.WriteLine(command);       //也可以用這種方式輸入要執行的命令
            //p.StandardInput.WriteLine("exit");        //不過要記得加上Exit要不然下一行程式執行的時候會當機
            p.StandardOutput.ReadToEnd();        //從輸出流取得命令執行結果

            while (!p.HasExited)
            {
                p.WaitForExit(1000);
            }
        }

    }
}
