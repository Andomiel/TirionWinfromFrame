using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums.General
{
    public enum OperateTypeEnum
    {
        /// <summary>
        /// 手动取料
        /// </summary>
        [Description("手动取料")]
        ManualOut = 0,

        /// <summary>
        /// 工单取料
        /// </summary>
        [Description("工单取料")]
        OrderOut = 1,

        /// <summary>
        /// 移库
        /// </summary>
        [Description("移库")]
        Transfer = 2,

        /// <summary>
        /// 盘点
        /// </summary>
        [Description("盘点")]
        InstockTaking = 3
    }
}
