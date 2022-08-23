using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    public enum InstockAreaBindingStatusEnum
    {
        /// <summary>
        /// 解绑
        /// </summary>
        [Description("解绑")]
        Unbound = 0,

        /// <summary>
        /// 绑定
        /// </summary>
        [Description("绑定")]
        Bound = 1,
    }
}
