using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    public enum LightShelfStatusEnum
    {
        /// <summary>
        /// 离线
        /// </summary>
        [Description("离线")]
        OffLine = -1,

        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 1,

        /// <summary>
        /// 超时
        /// </summary>
        [Description("超时")]
        TimeOut = 2,

        /// <summary>
        /// 报警
        /// </summary>
        [Description("报警")]
        Error = 3,

        /// <summary>
        /// 续料
        /// </summary>
        [Description("续料")]
        Appending = 4,

        /// <summary>
        /// 取料
        /// </summary>
        [Description("取料")]
        Delivering = 8,
    }
}
