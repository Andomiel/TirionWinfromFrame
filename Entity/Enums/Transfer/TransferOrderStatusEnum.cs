using System.ComponentModel;

namespace BLL.Common
{
    //状态,0 已创单，1 执行中，2 已执行，3 已取消
    public enum TransferOrderStatusEnum
    {
        /// <summary>
        /// 已创单
        /// </summary>
        [Description("已创单")]
        Saved = 0,

        /// <summary>
        /// 执行中
        /// </summary>
        [Description("执行中")]
        Executing = 1,

        /// <summary>
        /// 已执行
        /// </summary>
        [Description("已执行")]
        Finished = 2,

        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        Cancelled = 3
    }
}
