using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.ComponentModel;

namespace Updater.Core
{
    /// <summary>
    /// 程序更新事件参数
    /// </summary>
    public class ManifestEventArgs : EventArgs
    {
        public Manifest Manifest { get; set; }
    }

    /// <summary>
    /// 激活安装开始事件参数
    /// </summary>
    public class ActivationStartedEventArgs : EventArgs
    {
        public Manifest Manifest { get; set; }

        public bool Cancel { get; set; }
    }

    /// <summary>
    /// 安装完成事件参数
    /// </summary>
    public class ActivationCompletedEventArgs : AsyncCompletedEventArgs
    {
        public ActivationCompletedEventArgs(Exception error, bool cancelled, object userState)
            : base(error, cancelled, userState)
        {
        }

        public Manifest Manifest { get; set; }
    }

    /// <summary>
    /// 程序自动更新操作类，封装了文件下载、文件复制、文件解压等操作
    /// </summary>
    public class UpdateClass
    {
        #region 变量属性
        private DownloadClass downloader = new DownloadClass();
        private FileCopyClass fileCopyer = new FileCopyClass();
        private UpdaterConfigurationView updateCfgView = new UpdaterConfigurationView();
        private string backupFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backup");

        /// <summary>
        /// 封装的文件下载操作类
        /// </summary>
        public DownloadClass Downloader
        {
            get
            {
                return downloader;
            }
        }

        /// <summary>
        /// 封装的文件复制操作类
        /// </summary>
        public FileCopyClass FileCopyer
        {
            get
            {
                return fileCopyer;
            }
        }
        #endregion

        #region 事件

        /// <summary>
        /// 下载进度
        /// </summary>
        public event EventHandler<DownloadProgressEventArgs> DownloadProgressChanged;

        /// <summary>
        /// 下载完成事件
        /// </summary>
        public event EventHandler<DownloadCompleteEventArgs> DownloadCompleted;

        /// <summary>
        /// 下载错误触发的事件
        /// </summary>
        public event EventHandler<DownloadErrorEventArgs> DownloadError;

        public event EventHandler<ManifestEventArgs> ActivationInitializing;

        public event EventHandler<ActivationCompletedEventArgs> ActivationCompleted;

        public event EventHandler<ActivationStartedEventArgs> ActivationStarted;

        public event EventHandler<FileCopyProgressChangedEventArgs> ActivationProgressChanged;

        public event EventHandler<FileCopyErrorEventArgs> ActivationError;

        #endregion

        #region 下载更新实现

        public UpdateClass()
        {
            downloader.DownloadCompleted += new EventHandler<DownloadCompleteEventArgs>(downloader_DownloadCompleted);
            downloader.DownloadError += new EventHandler<DownloadErrorEventArgs>(downloader_DownloadError);
            downloader.DownloadProgressChanged += new EventHandler<DownloadProgressEventArgs>(downloader_DownloadProgressChanged);
            fileCopyer.FileCopyError += new EventHandler<FileCopyErrorEventArgs>(fileCopyer_FileCopyError);
            fileCopyer.FileCopyCompleted += new EventHandler<FileCopyCompletedEventArgs>(fileCopyer_FileCopyCompleted);
            fileCopyer.FileCopyProgressChanged += new EventHandler<FileCopyProgressChangedEventArgs>(fileCopyer_FileCopyProgressChanged);
        }

        /// <summary>
        /// 是否有最新的版本
        /// </summary>
        public bool HasNewVersion
        {
            get
            {
                var m = CheckForUpdates();
                return m.Length > 0;
            }
        }

        /// <summary>
        /// 检查更新,返回更新清单列表
        /// </summary>
        /// <returns></returns>
        public Manifest[] CheckForUpdates()
        {
            updateCfgView.Refresh();

            Uri uri = new Uri(updateCfgView.ManifestUri);
            string doc = DownLoadFile(uri);
            XmlSerializer xser = new XmlSerializer(typeof(Manifest));
            var manifest = xser.Deserialize(new XmlTextReader(doc, XmlNodeType.Document, null)) as Manifest;
            if (manifest == null ||
                manifest.Version == updateCfgView.Version ||
                manifest.MyApplication.ApplicationId != updateCfgView.ApplicationId)
            {
                return new Manifest[0];
            }
            return new Manifest[] { manifest };
        }

        /// <summary>
        /// 用于远程下载文件清单
        /// </summary>
        /// <param name="uri">文件清单网络路径</param>
        /// <returns></returns>
        private string DownLoadFile(Uri uri)
        {
            WebRequest request = WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            string response = String.Empty;
            using (WebResponse res = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(res.GetResponseStream(), true))
                {
                    response = reader.ReadToEnd();
                }
            }
            return response;
        }

        /// <summary>
        /// 同步下载文件清单中的文件
        /// </summary>
        /// <param name="manifests">下载文件清单</param>
        public void Download(Manifest[] manifests)
        {
            foreach (var m in manifests)
            {
                downloader.Download(m);
            }
        }

        /// <summary>
        /// 异步下载文件清单中的文件
        /// </summary>
        /// <param name="manifests">下载文件清单</param>
        public void DownloadAsync(Manifest[] manifests)
        {
            foreach (var m in manifests)
            {
                downloader.DownloadAsync(m);
            }
        }

        /// <summary>
        /// 下载完毕后执行的启动操作
        /// </summary>
        /// <param name="manifests"></param>
        public void Activate(Manifest[] manifests)
        {
            foreach (var m in manifests)
            {
                OnActivationInitializing(new ManifestEventArgs() { Manifest = m });
                Backup(m);
                ActivationStartedEventArgs e = new ActivationStartedEventArgs() { Manifest = m };
                OnActivationStarted(e);
                if (e.Cancel)
                {
                    Clear();
                    break;
                }
                else
                {
                    fileCopyer.CopyAsync(m, downloader.TempPath);
                }
            }
        }

        /// <summary>
        /// 备份操作
        /// </summary>
        /// <param name="manifest">文件清单</param>
        private void Backup(Manifest manifest)
        {
            try
            {
                string sourcePath = Path.GetFullPath(manifest.MyApplication.Location);
                string s_filename = string.Empty;
                string t_filename = string.Empty;
                if (!Directory.Exists(backupFilePath))
                {
                    Directory.CreateDirectory(backupFilePath);
                }
                foreach (var file in manifest.ManifestFiles.Files)
                {
                    t_filename = Path.Combine(backupFilePath, file.Source);
                    s_filename = Path.Combine(sourcePath, file.Source);
                    if (File.Exists(s_filename))
                    {
                        File.Copy(s_filename, t_filename, true);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 回滚文件下载内容
        /// </summary>
        /// <param name="manifest"></param>
        public void Rollback(Manifest manifest)
        {
            try
            {
                string filename = string.Empty;
                foreach (var file in manifest.ManifestFiles.Files)
                {
                    filename = Path.Combine(backupFilePath, file.Source);
                    File.Copy(filename, Path.Combine(Path.GetFullPath(manifest.MyApplication.Location), file.Source));
                }
                Directory.Delete(backupFilePath, true);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 清除临时文件
        /// </summary>
        private void Clear()
        {
            try
            {
                Directory.Delete(backupFilePath, true);
                Directory.Delete(downloader.TempPath, true);
            }
            catch
            { }
        }

        #endregion

        #region 事件处理

        private void fileCopyer_FileCopyError(object sender, FileCopyErrorEventArgs e)
        {
            OnActivationError(e);
        }

        private void fileCopyer_FileCopyProgressChanged(object sender, FileCopyProgressChangedEventArgs e)
        {
            if (ActivationProgressChanged != null)
            {
                ActivationProgressChanged(sender, e);
            }
        }

        private void fileCopyer_FileCopyCompleted(object sender, FileCopyCompletedEventArgs e)
        {
            Clear();
            try
            {
                updateCfgView.Version = e.Manifest.Version;
            }
            catch
            { }

            if (ActivationCompleted != null)
            {
                ActivationCompletedEventArgs evt = new ActivationCompletedEventArgs(e.Error, e.Cancelled, e.UserState);
                evt.Manifest = e.Manifest;
                OnActivationCompleted(evt);
            }
        }

        private void downloader_DownloadProgressChanged(object sender, DownloadProgressEventArgs e)
        {
            if (DownloadProgressChanged != null)
            {
                DownloadProgressChanged(sender, e);
            }
        }

        private void downloader_DownloadError(object sender, DownloadErrorEventArgs e)
        {
            if (DownloadError != null)
            {
                DownloadError(sender, e);
            }
        }

        private void downloader_DownloadCompleted(object sender, DownloadCompleteEventArgs e)
        {
            if (DownloadCompleted != null)
            {
                DownloadCompleted(sender, e);
            }
        }

        private void OnActivationInitializing(ManifestEventArgs e)
        {
            if (ActivationInitializing != null)
            {
                ActivationInitializing(this, e);
            }
        }

        private void OnActivationStarted(ActivationStartedEventArgs e)
        {
            if (ActivationStarted != null)
            {
                ActivationStarted(this, e);
            }
        }

        private void OnActivationCompleted(ActivationCompletedEventArgs e)
        {
            if (ActivationCompleted != null)
            {
                ActivationCompleted(this, e);
            }
        }

        private void OnActivationError(FileCopyErrorEventArgs e)
        {
            if (ActivationError != null)
            {
                ActivationError(this, e);
            }
        }

        private void OnActivationProgressChanged(FileCopyProgressChangedEventArgs e)
        {
            if (ActivationProgressChanged != null)
            {
                ActivationProgressChanged(this, e);
            }
        }

        #endregion

    }
}
