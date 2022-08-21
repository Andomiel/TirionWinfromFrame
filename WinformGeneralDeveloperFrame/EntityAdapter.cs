using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons.Collections;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using WinformGeneralDeveloperFrame.Commons;

namespace WinformGeneralDeveloperFrame
{
    public class EntityAdapter
    {
        private static readonly string templateDir = AppDomain.CurrentDomain.BaseDirectory+ @"\Template\Entity\";
        public bool create(string tableName,string NameSpace,string outdir,List<ControlInfo> EntityList)
        {
           
                VelocityEngine velocityEngine = new VelocityEngine();
                ExtendedProperties props = new ExtendedProperties();
                props.AddProperty(RuntimeConstants.RESOURCE_LOADER, @"file");
                props.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, templateDir);
                props.AddProperty(RuntimeConstants.INPUT_ENCODING, "utf-8");
                props.AddProperty(RuntimeConstants.OUTPUT_ENCODING, "utf-8");
                //模板的缓存设置
                props.AddProperty(RuntimeConstants.FILE_RESOURCE_LOADER_CACHE, true);              //是否缓存
                props.AddProperty("file.resource.loader.modificationCheckInterval", (Int64)30);    //缓存时间(秒)
                velocityEngine.Init(props);
                //为模板变量赋值
                VelocityContext context = new VelocityContext();
                context.Put("tableName", tableName);
                context.Put("NameSpace", NameSpace);
                context.Put("outdir", outdir);
                context.Put("EntityList", EntityList);
                //  Template template = velocityEngine.GetTemplate(@"D:\ProgrammingFolder\C#\NVelocityDemo\NVelocityDemo\bin\Debug\Template");
                //从文件中读取模板
                Template template = velocityEngine.GetTemplate(@"\Entity.vm");
                if (!Directory.Exists(outdir + "\\Entity"))
                {
                    Directory.CreateDirectory(outdir + "\\Entity");
                }
                //合并模板
                using (StreamWriter writer = new StreamWriter(outdir + $"\\Entity\\{tableName}Info.cs", false))
                {
                    template.Merge(context, writer);
                }
                return true;
        }
    }
}
