using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entity.Enums
{
    /// <summary>
    /// 状态,0 待清账，1 清账中， 2 已清账， 9 已关闭 
    /// </summary>
    public enum BalanceOrderStatusEnum
    {
        /// <summary>
        /// 待清账
        /// </summary>
        [Description("待清账")]
        Draft = 0,
        /// <summary>
        /// 清账中
        /// </summary>
        [Description("清账中")]
        Executing = 1,
        /// <summary>
        /// 已清账
        /// </summary>
        [Description("已清账")]
        Finished = 2,
        /// <summary>
        /// 已关闭
        /// </summary>
        [Description("已关闭")]
        Closed = 9
    }
}
