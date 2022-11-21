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
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 1,

        /// <summary>
        /// 取料
        /// </summary>
        [Description("取料")]
        Delivering = 2,

        /// <summary>
        /// 报警
        /// </summary>
        [Description("报警")]
        Error = 3,
    }
}
