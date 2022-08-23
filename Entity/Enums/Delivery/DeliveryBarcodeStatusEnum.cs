using System.ComponentModel;

namespace Entity.Enums
{
    //状态,0 未出库，1 已出库，2 已复核，3 已取消(释放)
    public enum DeliveryBarcodeStatusEnum
    {
        /// <summary>
        /// 未出库
        /// </summary>
        [Description("未出库")]
        Undeliver = 0,

        /// <summary>
        /// 已出库
        /// </summary>
        [Description("已出库")]
        Delivered = 1,

        /// <summary>
        /// 已复核
        /// </summary>
        [Description("已复核")]
        Reviewed = 2,

        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        Cancelled = 3
    }
}
