using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums.General
{
    public enum MaterialTypeEnum
    {
        /// <summary>
        /// IC类
        /// </summary>
        [Description("IC类")]
        IcMaterial = 0,

        /// <summary>
        /// 极管类
        /// </summary>
        [Description("极管类")]
        Diode = 1,

        /// <summary>
        /// LED类
        /// </summary>
        [Description("LED类")]
        Led = 2,

        /// <summary>
        /// 连接器
        /// </summary>
        [Description("连接器")]
        Connector = 3,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 9,
    }
}
