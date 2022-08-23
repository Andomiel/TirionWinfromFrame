using System.ComponentModel;

namespace Entity.Enums.Inventory
{
    //盘点类型，0 数量 1 比例
    public enum InventoryOrderTypeEnum
    {
        /// <summary>
        /// 固定
        /// </summary>
        [Description("固定")]
        Numeric = 0,

        /// <summary>
        /// 抽盘
        /// </summary>
        [Description("抽盘")]
        Percent = 1,

    }
}
