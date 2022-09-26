using Entity.Enums;
using Entity.Enums.Inventory;
using System;

namespace Entity.Dto
{
    public class InventoryOrderDto
    {
        /// <summary>
        /// 盘点单业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 盘点单号
        /// </summary>
        public string InventoryNo { get; set; } = string.Empty;

        /// <summary>
        /// 盘点类型，0 数量 1 比例
        /// </summary>
        public int InventoryType { get; set; } = 0;

        public string InventoryTypeDisplay => EnumHelper.GetDescription(typeof(InventoryOrderTypeEnum), InventoryType);

        /// <summary>
        /// 盘点计划数，当模式是比例时，代表百分比的比值，当盘量时，代表盘数或者条码数
        /// </summary>
        public int InventoryQuantity { get; set; } = 0;

        /// <summary>
        /// 盘点库区
        /// </summary>
        public int InventoryArea { get; set; } = 0;

        public string InventoryAreaDisplay => EnumHelper.GetDescription(typeof(TowerEnum), InventoryArea);

        /// <summary>
        /// 二级库区，货架码或者栈板号，或者料架编号
        /// </summary>
        public string SubArea { get; set; } = string.Empty;

        /// <summary>
        /// 分拣口
        /// </summary>
        public string SortingId { get; set; } = string.Empty;

        /// <summary>
        /// 状态,0 已创单，1 执行中，2 已执行，3 已取消
        /// </summary>
        public int OrderStatus { get; set; } = 0;

        public string OrderStatusDisplay => EnumHelper.GetDescription(typeof(InventoryOrderStatusEnum), OrderStatus);

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; } = string.Empty;

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// 最后更新人
        /// </summary>
        public string LastUpdateUser { get; set; } = string.Empty;
    }
}
