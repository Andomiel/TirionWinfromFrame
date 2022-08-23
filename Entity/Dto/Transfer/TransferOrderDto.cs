using Entity.Enums;
using Entity.Enums.Transfer;
using System;

namespace Entity.Dto
{
    public class TransferOrderDto
    {

        /// <summary>
        /// 移库单业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 移库单号
        /// </summary>
        public string TransferNo { get; set; } = string.Empty;

        /// <summary>
        /// 分拣口
        /// </summary>
        public string SortingId { get; set; } = string.Empty;

        /// <summary>
        /// 移库类型，0 移入，1 移出
        /// </summary>
        public int TransferType { get; set; } = 0;

        public string TransferTypeDisplay => EnumHelper.GetDescription(typeof(TransferTypeEnum), TransferType);

        /// <summary>
        /// 来源库区
        /// </summary>
        public int SourceAreaId { get; set; } = 0;

        public string SourceAreaDisplay => EnumHelper.GetDescription(typeof(TowerEnum), SourceAreaId);

        /// <summary>
        /// 目标库区
        /// </summary>
        public int TargetAreaId { get; set; } = 0;

        public string TargetAreaDisplay => EnumHelper.GetDescription(typeof(TowerEnum), TargetAreaId);

        /// <summary>
        /// 状态,0 已创单，1 执行中，2 已执行，3 已取消
        /// </summary>
        public int OrderStatus { get; set; } = 0;

        public string OrderStatusDisplay => EnumHelper.GetDescription(typeof(TransferOrderStatusEnum), OrderStatus);

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
