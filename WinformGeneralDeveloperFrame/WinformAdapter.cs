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
    public class WinformAdapter
    {
        private static readonly string templateDir = AppDomain.CurrentDomain.BaseDirectory + @"\Template\Winform\";
        public bool create(string tableName, string NameSpace, string outdir, List<ControlInfo> EntityList)
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
                context.Put("EntityList", EntityList);
                //从文件中读取模板
                Template template = velocityEngine.GetTemplate(@"\FormListDesigner.vm");
                Template template2 = velocityEngine.GetTemplate(@"\FormList.vm");
                Template template3 = velocityEngine.GetTemplate(@"\FormEditDesigner.vm");
                Template template4 = velocityEngine.GetTemplate(@"\FormEdit.vm");
                Template template5 = velocityEngine.GetTemplate(@"\FormDesigner.vm");
                Template template6 = velocityEngine.GetTemplate(@"\Form.vm");
                if (!Directory.Exists(outdir + "\\Winform"))
                {
                    Directory.CreateDirectory(outdir + "\\Winform");
                }
                //合并模板
                //using (StreamWriter writer = new StreamWriter(outdir + $"\\Winform\\FrmList{tableName}.Designer.cs", false))
                //{
                //    template.Merge(context, writer);
                //}
                //using (StreamWriter writer = new StreamWriter(outdir + $"\\Winform\\FrmList{tableName}.cs", false))
                //{
                //    template2.Merge(context, writer);
                //}
                //using (StreamWriter writer = new StreamWriter(outdir + $"\\Winform\\FrmEdit{tableName}.Designer.cs", false))
                //{
                //    template3.Merge(context, writer);
                //}
                //using (StreamWriter writer = new StreamWriter(outdir + $"\\Winform\\FrmEdit{tableName}.cs", false))
                //{
                //    template4.Merge(context, writer);
                //}
                using (StreamWriter writer = new StreamWriter(outdir + $"\\Winform\\Frm{tableName}.Designer.cs", false))
                {
                    template5.Merge(context, writer);
                }
                using (StreamWriter writer = new StreamWriter(outdir + $"\\Winform\\Frm{tableName}.cs", false))
                {
                    template6.Merge(context, writer);
                }
                return true;
            }
    }
}
