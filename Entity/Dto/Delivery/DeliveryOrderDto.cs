using Entity.Enums;
using System;

namespace Entity.Dto.Delivery
{
    public class DeliveryOrderDto
    {
        /// <summary>
        /// 出库单业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 出库单号
        /// </summary>
        public string DeliveryNo { get; set; } = string.Empty;

        /// <summary>
        /// 产品料号
        /// </summary>
        public string ProductNo { get; set; } = string.Empty;

        /// <summary>
        /// 产线(目的地)
        /// </summary>
        public string LineId { get; set; } = string.Empty;

        /// <summary>
        /// 分拣口
        /// </summary>
        public string SortingId { get; set; } = string.Empty;

        /// <summary>
        /// 发料类型，0 齐套发料，1 首套料， 2 补料(含超领)
        /// </summary>
        public int OrderType { get; set; } = 0;

        public string OrderTypeDisplay => EnumHelper.GetDescription(typeof(DeliveryOrderTypeEnum), OrderType);

        /// <summary>
        /// 出库类型，1 调拨出库，2 拣料单出库，3 杂项出库，4 生产领料，5 辅料出库，6 移库， 7 盘点，8 Excel导入
        /// </summary>
        public int DeliveryType { get; set; } = 0;

        public string DeliveryTypeDisplay => EnumHelper.GetDescription(typeof(OutOrderTypeEnum), DeliveryType);

        /// <summary>
        /// 状态,0 已接收，1 计算中， 2 已计算，3 发料中，4 已发料 ，5 已复核， 9 已关闭 
        /// </summary>
        public int OrderStatus { get; set; } = 0;

        public string OrderStatusDisplay => EnumHelper.GetDescription(typeof(DeliveryOrderStatusEnum), OrderStatus);

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

        public string OperationText => OrderStatus == (int)DeliveryOrderStatusEnum.Delivered ? "复核" : string.Empty;
    }
}
