using Entity.Enums;
using System;
using System.Collections.Generic;

namespace Entity.Dto
{
    public class InstockOrderDto
    {

        public bool IsSelected { get; set; } = false;

        public long Id { get; set; } = 0;

        /// <summary>
        /// 入库单业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 入库单号
        /// </summary>
        public string InstockNo { get; set; } = string.Empty;

        /// <summary>
        /// 入库类型，1 调拨入库，2 SMT产线退料，3 生产退料，4 杂项入库，5 自制收货，6 移库， 7 Excel导入
        /// </summary>
        public int InstockType { get; set; } = 0;

        /// <summary>
        /// 状态,0 已接收，1 入库中，2 已入库，3 已关闭 
        /// </summary>
        public int OrderStatus { get; set; } = 0;

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

        public string OperationText => OrderStatus < (int)InstockOrderStatusEnum.Finished ? "入库" : string.Empty;

        public string OrderTypeDisplay => EnumHelper.GetDescription(typeof(InOrderTypeEnum), InstockType);

        public string OrderStatusDisplay => EnumHelper.GetDescription(typeof(InstockOrderStatusEnum), OrderStatus);

        public List<InstockDetailDto> Details { get; set; } = new List<InstockDetailDto>();

    }
}
