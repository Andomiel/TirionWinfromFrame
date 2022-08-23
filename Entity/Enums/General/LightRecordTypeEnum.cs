using System.ComponentModel;

namespace Entity.Enums
{
    //单据类型，0 入库单，1 出库单，2 移库单，3 盘点单
    public enum LightRecordTypeEnum
    {
        /// <summary>
        /// 入库单
        /// </summary>
        [Description("入库单")]
        Instock = 0,

        /// <summary>
        /// 出库单
        /// </summary>
        [Description("出库单")]
        Delivery = 1,

        /// <summary>
        /// 移库单
        /// </summary>
        [Description("移库单")]
        Transfer = 2,

        /// <summary>
        /// 盘点单
        /// </summary>
        [Description("盘点单")]
        Inventory = 3
    }
}
