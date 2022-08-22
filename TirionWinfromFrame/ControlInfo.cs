using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars.Ribbon.Drawing;

namespace TirionWinfromFrame
{
    public class ControlInfo
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string tableName { set; get; }
        /// <summary>
        /// 数据库字段名称
        /// </summary>
        public string dataBaseFieldName { set; get; }
        /// <summary>
        /// 数据库字段类型
        /// </summary>
        public string dataBaseFieldType { set; get; }

        /// <summary>
        /// 数据库字段说明
        /// </summary>
        public string dataBaseFieldDDesr { set; get; }
        /// <summary>
        /// c#字段类型
        /// </summary>
        public string CSharpFieldType { set; get; }
        /// <summary>
        /// C#字段名称
        /// </summary>
        public string CSharpFieldName { set; get; }
        /// <summary>
        /// 控件类型
        /// </summary>
        public string controlType { set; get; }

        /// <summary>
        /// 控件labelname
        /// </summary>
        public string controlLabelName { set; get; }
        /// <summary>
        /// 控件name
        /// </summary>
        public string controlName { set; get; }

        /// <summary>
        /// 是否可见
        /// </summary>
        public bool isVisible { set; get; } = true;

        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool isEdit { set; get; } = true;
        /// <summary>
        /// 是否可为空
        /// </summary>
        public bool isNull { set; get; }
        /// <summary>
        ///是否主键
        /// </summary>
        public bool isKey { set; get; }
        /// <summary>
        /// 是否自增字段
        /// </summary>
        public bool isIdentity{ set; get; }

        /// <summary>
        /// 是否搜索列
        /// </summary>
        public bool isSearch { set; get; } = true;
        /// <summary>
        /// 数据源Name
        /// </summary>
        public string DataTableName { set; get; }

        /// <summary>
        /// 是否为空检验
        /// </summary>
        public bool isCheck { set; get; } = true;
    }
}
