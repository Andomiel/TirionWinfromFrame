using System.ComponentModel;

namespace Entity.Enums
{
    //状态,0 未出库，1 出库中，2 出库完成
    public enum DeliveryDetailStatusEnum
    {
        /// <summary>
        /// 未出库
        /// </summary>
        [Description("未出库")]
        Undeliver = 0,

        /// <summary>
        /// 出库中
        /// </summary>
        [Description("出库中")]
        Delivering = 1,

        /// <summary>
        /// 出库完成
        /// </summary>
        [Description("出库完成")]
        Delivered = 2
    }
}
