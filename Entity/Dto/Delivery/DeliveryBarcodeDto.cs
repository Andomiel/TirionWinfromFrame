using Entity.Enums;
using System;

namespace Entity.Dto.Delivery
{
    public class DeliveryBarcodeDto
    {
        /// <summary>
        /// 出库单Id
        /// </summary>
        public string DeliveryId { get; set; } = string.Empty;

        /// <summary>
        /// 出库单明细Id
        /// </summary>
        public string DeliveryDetailId { get; set; } = string.Empty;

        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialNo { get; set; } = string.Empty;

        /// <summary>
        /// 箱码
        /// </summary>
        public string BoxNo { get; set; } = string.Empty;

        /// <summary>
        /// 出库条码
        /// </summary>
        public string Barcode { get; set; } = string.Empty;

        /// <summary>
        /// 原厂条码
        /// </summary>
        public string OrigionBarcode { get; set; } = string.Empty;

        /// <summary>
        /// 出库库区
        /// </summary>
        public int DeliveryAreaId { get; set; } = 0;

        /// <summary>
        /// 出库数量
        /// </summary>
        public int DeliveryQuantity { get; set; } = 0;

        /// <summary>
        /// 状态,0 未出库，1 已出库，2 已复核，3 已取消(释放)
        /// </summary>
        public int OrderStatus { get; set; } = 0;

        public string OrderStatusDisplay => EnumHelper.GetDescription(typeof(DeliveryBarcodeStatusEnum), OrderStatus);

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; } = string.Empty;

        public string TowerDisplay => EnumHelper.GetDescription(typeof(TowerEnum), DeliveryAreaId);

        /// <summary>
        /// 最后更新人
        /// </summary>
        public string LastUpdateUser { get; set; } = string.Empty;
    }
}
