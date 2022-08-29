using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class LogDto
    {
        [BrowsableAttribute(false)]
        public string Id { get; set; }

        [CategoryAttribute("日志")]
        [DisplayNameAttribute("时间")]
        [DescriptionAttribute("日志记录的发生时间。")]
        public DateTime LogTime { get; set; }

        [CategoryAttribute("日志")]
        [DisplayNameAttribute("主题")]
        [DescriptionAttribute("日志记录的主题。")]
        public string LogTitle { get; set; }

        [CategoryAttribute("请求")]
        [DisplayNameAttribute("请求")]
        [DescriptionAttribute("日志记录的请求体，可能包含完整的url和request。")]
        [Editor(typeof(PropertyGridRichText), typeof(UITypeEditor))]
        public string RequestBody { get; set; }

        [CategoryAttribute("响应")]
        [DisplayNameAttribute("响应")]
        [DescriptionAttribute("日志发生的所有响应，可能有多条。")]
        [Editor(typeof(PropertyGridRichText), typeof(UITypeEditor))]
        public string ResponseBody { get; set; }

        //[BrowsableAttribute(false)]
        public string RequestLimit => RequestBody.Length > 20 ? $"{RequestBody.Substring(0, 20)}..." : RequestBody;

        //[BrowsableAttribute(false)]
        public string ResponseLimit => ResponseBody.Length > 20 ? $"{ResponseBody.Substring(0, 20)}..." : ResponseBody;


    }
}
