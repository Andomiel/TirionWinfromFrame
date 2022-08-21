using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Updater.Core
{
    /// <summary>
    /// 文件清单对象
    /// </summary>
    [XmlRoot("manifest")]
    public class Manifest
    {
        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("fileBytes")]
        public long FileBytes { get; set; }

        [XmlElement("myapplication")]
        public MyApplication MyApplication { get; set; }

        [XmlElement("files")]
        public ManifestFiles ManifestFiles { get; set; }
    }

    /// <summary>
    /// 更新的文件列表
    /// </summary>
    public class ManifestFiles
    {
        [XmlElement("file")]
        public ManifestFile[] Files { get; set; }

        [XmlAttribute("base")]
        public string BaseUrl { get; set; }
    }

    /// <summary>
    /// 更新的单个文件对象
    /// </summary>
    public class ManifestFile
    {
        [XmlAttribute("source")]
        public string Source
        {
            get;
            set;
        }

        [XmlAttribute("hash")]
        public string Hash
        {
            get;
            set;
        }

        [XmlAttribute("unzip")]
        public string Unzip
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 更新的程序对象
    /// </summary>
    public class MyApplication
    {
        [XmlAttribute("applicationId")]
        public string ApplicationId { get; set; }

        [XmlElement("location")]
        public string Location { get; set; }

        [XmlElement("entryPoint")]
        public EntryPoint EntryPoint { get; set; }
    }

    /// <summary>
    /// 程序启动对象
    /// </summary>
    public class EntryPoint
    {
        [XmlAttribute("file")]
        public string File { get; set; }

        [XmlAttribute("parameters")]
        public string Parameters { get; set; }
    }

    /// <summary>
    /// 客户端配置文件对象
    /// </summary>
    public class UpdaterConfigurationView
    {
        private static XmlDocument document = new XmlDocument();
        private static readonly string xmlFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "updateconfiguration.config");

        static UpdaterConfigurationView()
        {
            document.Load(xmlFileName);
        }

        /// <summary>
        /// 刷新配置文件信息
        /// </summary>
        public void Refresh()
        {
            document.RemoveAll();
            document.Load(xmlFileName);
        }

        /// <summary>
        /// 程序版本
        /// </summary>
        public string Version
        {
            get
            {
                return document.SelectSingleNode("applicationUpdater").Attributes["version"].Value;
            }
            set
            {
                document.SelectSingleNode("applicationUpdater").Attributes["version"].Value = value;
                document.Save(xmlFileName);
            }
        }

        /// <summary>
        /// 应用程序唯一标识
        /// </summary>
        public string ApplicationId
        {
            get
            {
                return document.SelectSingleNode("applicationUpdater").Attributes["applicationId"].Value;
            }
            set
            {
                document.SelectSingleNode("applicationUpdater").Attributes["applicationId"].Value = value;
                document.Save(xmlFileName);
            }
        }

        /// <summary>
        /// 远程更新文件的清单路径
        /// </summary>
        public string ManifestUri
        {
            get
            {
                return document.SelectSingleNode("applicationUpdater").Attributes["manifestUri"].Value;
            }
            set
            {
                document.SelectSingleNode("applicationUpdater").Attributes["manifestUri"].Value = value;
                document.Save(xmlFileName);
            }
        }

        /// <summary>
        /// 程序名称
        /// </summary>
        public string Title
        {
            get
            {
                return document.SelectSingleNode("applicationUpdater").Attributes["title"].Value;
            }
            set
            {
                document.SelectSingleNode("applicationUpdater").Attributes["title"].Value = value;
                document.Save(xmlFileName);
            }
        }
    }
}
