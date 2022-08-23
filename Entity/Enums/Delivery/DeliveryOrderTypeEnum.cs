using System.ComponentModel;

namespace Entity.Enums
{
    // 发料类型，0 齐套发料，1 首套料， 2 补料(含超领)
    public enum DeliveryOrderTypeEnum
    {
        /// <summary>
        /// 齐套发料
        /// </summary>
        [Description("齐套发料")]
        TotalSet = 0,
        /// <summary>
        /// 首套料
        /// </summary>
        [Description("首套料")]
        FirstSet = 1,
        /// <summary>
        /// 补料(含超领)
        /// </summary>
        [Description("补料")]
        FeedSet = 2
    }
}
