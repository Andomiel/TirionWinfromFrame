using System.ComponentModel;

namespace Entity.Enums.Transfer
{
    public enum TransferBarcodeStatusEnum
    {
        /// <summary>
        /// 未移库
        /// </summary>
        [Description("未移库")]
        Unfinished = 0,

        /// <summary>
        /// 已移库
        /// </summary>
        [Description("已移库")]
        Finished = 1,

        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        Cancelled = 2,
    }
}
