using System.ComponentModel;

namespace Entity.Enums
{
    public enum SortNoEnum
    {
        /// <summary>
        /// 首盘位
        /// </summary>
        [Description("首盘位")]
        FirstSet = 0,

        /// <summary>
        /// 紧急出料口
        /// </summary>
        [Description("紧急出料口")]
        Emergency = 1,

        /// <summary>
        /// Ng口
        /// </summary>
        [Description("Ng口")]
        Ng = 2,

        /// <summary>
        /// 工单位1
        /// </summary>
        [Description("工单位1")]
        FreeFirst = 3,

        /// <summary>
        /// 工单位2
        /// </summary>
        [Description("工单位2")]
        FreeSecond = 4
    }
}
