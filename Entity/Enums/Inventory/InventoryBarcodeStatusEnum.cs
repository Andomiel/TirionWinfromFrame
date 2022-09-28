using System.ComponentModel;

namespace Entity.Enums.Inventory
{
    //状态,0 待盘点，1 已盘点，2已确认
    public enum InventoryBarcodeStatusEnum
    {
        /// <summary>
        /// 待盘点
        /// </summary>
        [Description("待盘点")]
        Waiting = 0,

        /// <summary>
        /// 盘点中
        /// </summary>
        [Description("盘点中")]
        Executing = 1,

        /// <summary>
        /// 已盘点
        /// </summary>
        [Description("已盘点")]
        Executed = 2,

        /// <summary>
        /// 已确认
        /// </summary>
        [Description("已确认")]
        Confirmed = 3,

        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        Cancelled = 4,

    }
}
