using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entity.Enums
{
    /// <summary>
    /// 状态,0 未清账，1 已清账，2  已取消
    /// </summary>
    public enum BalanceBarcodeStatusEnum
    {
        /// <summary>
        /// 未清账
        /// </summary>
        [Description("未清账")]
        Draft = 0,

        /// <summary>
        /// 已清账
        /// </summary>
        [Description("已清账")]
        Finished = 1,

        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        Cancelled = 2
    }
}
