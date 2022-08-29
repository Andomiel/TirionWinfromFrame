﻿using Entity.Enums.Inventory;
using System;

namespace Entity.Dto
{
    public class InventoryBarcodeDto
    {
        /// <summary>
        /// 明细业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 盘点单Id
        /// </summary>
        public string InventoryOrderId { get; set; } = string.Empty;

        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialNo { get; set; } = string.Empty;

        /// <summary>
        /// 盘点条码
        /// </summary>
        public string Barcode { get; set; } = string.Empty;

        /// <summary>
        /// 原始数量，原始数量为0时，标识多料
        /// </summary>
        public int OriginQuantity { get; set; } = 0;

        /// <summary>
        /// 盘后数量，盘后数量为0时，标识缺料
        /// </summary>
        public int RealQuantity { get; set; } = 0;

        /// <summary>
        /// 原储位
        /// </summary>
        public string OriginLocation { get; set; } = string.Empty;

        /// <summary>
        /// 状态,0 待盘点，1 已盘点，2已确认
        /// </summary>
        public int OrderStatus { get; set; } = 0;

        public string OrderStatusDisplay => EnumHelper.GetDescription(typeof(InventoryOrderStatusEnum), OrderStatus);

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

        public string InventoryResult
        {
            get
            {
                if (OriginQuantity <= 0)
                {
                    return "多料";
                }
                else if (RealQuantity <= 0)
                {
                    return "缺料";
                }
                else
                {
                    if (OriginQuantity > RealQuantity)
                    {
                        return "盘亏";
                    }
                    else if (OriginQuantity < RealQuantity)
                    {
                        return "盘盈";
                    }
                    else
                    {
                        return "正常";
                    }
                }
            }
        }
    }
}