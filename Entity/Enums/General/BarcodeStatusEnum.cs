using System.ComponentModel;

namespace Entity.Enums
{
    //条码状态，0 预入库，1 已入库，2 锁定（移库或出库或盘点锁定），3 已出库
    public enum BarcodeStatusEnum
    {
        /// <summary>
        /// 预入库
        /// </summary>
        [Description("预入库")]
        PreSave = 0,

        /// <summary>
        /// 已入库
        /// </summary>
        [Description("已入库")]
        Saved = 1,

        /// <summary>
        /// 锁定（移库或出库或盘点锁定）
        /// </summary>
        [Description("已分配")]
        Locked = 2,

        /// <summary>
        /// 已出库
        /// </summary>
        [Description("已出库")]
        Delivered = 3
    }
}
