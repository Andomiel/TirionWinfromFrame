using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums.General
{
    public enum RegisterStatusEnum
    {
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        Invalid = 0,

        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        Valid = 1
    }
}
