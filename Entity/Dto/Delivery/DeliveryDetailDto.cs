using Entity.DataContext;
using Entity.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Entity.Dto.Delivery
{
    public class DeliveryDetailDto
    {
        /// <summary>
        /// 明细业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 出库单Id
        /// </summary>
        public string DeliveryId { get; set; } = string.Empty;

        /// <summary>
        /// 工单明细Id
        /// </summary>
        public string WorkOrderDetailId { get; set; } = string.Empty;

        /// <summary>
        /// 主槽位
        /// </summary>
        public string SlotNo { get; set; } = string.Empty;

        /// <summary>
        /// 行号
        /// </summary>
        public int RowNum { get; set; } = 0;

        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialNo { get; set; } = string.Empty;

        /// <summary>
        /// 出库数量
        /// </summary>
        public int RequireCount { get; set; } = 0;

        /// <summary>
        /// 状态,0 未出库，1 出库中，2 出库完成
        /// </summary>
        public int DetailStatus { get; set; } = 0;

        public string DetailStatusDisplay => EnumHelper.GetDescription(typeof(DeliveryDetailStatusEnum), DetailStatus);

        public List<Wms_DeliveryBarcode> Barcodes { get; set; } = new List<Wms_DeliveryBarcode>();

        public int OrderStatus { get; set; } = -1;

        public string DeliveryStatusDisplay
        {
            get
            {
                string deliveryStatus = "未出库";
                switch (OrderStatus)
                {
                    case (int)DeliveryOrderStatusEnum.Calculating:
                    case (int)DeliveryOrderStatusEnum.Calculated:
                        {
                            int barcodeStatus = (int)DeliveryBarcodeStatusEnum.Undeliver;
                            int totalCount = Barcodes.Where(p => p.OrderStatus == barcodeStatus).Sum(p => p.DeliveryQuantity);
                            if (RequireCount > totalCount)
                            {
                                deliveryStatus = "不足";
                            }
                            else if (RequireCount == totalCount)
                            {
                                deliveryStatus = "充足";
                            }
                            else
                            {
                                deliveryStatus = "超领";
                            }
                        }
                        break;
                    case (int)DeliveryOrderStatusEnum.Delivering:
                    case (int)DeliveryOrderStatusEnum.Delivered:
                        {
                            int barcodeStatus = (int)DeliveryBarcodeStatusEnum.Reviewed;
                            int totalCount = Barcodes.Where(p => p.OrderStatus < barcodeStatus).Sum(p => p.DeliveryQuantity);
                            if (RequireCount > totalCount)
                            {
                                deliveryStatus = "短发";
                            }
                            else if (RequireCount == totalCount)
                            {
                                deliveryStatus = "正常";
                            }
                            else
                            {
                                deliveryStatus = "超发";
                            }
                        }
                        break;
                    case (int)DeliveryOrderStatusEnum.Reviewed:
                        {
                            int barcodeStatus = (int)DeliveryBarcodeStatusEnum.Reviewed;
                            int totalCount = Barcodes.Where(p => p.OrderStatus == barcodeStatus).Sum(p => p.DeliveryQuantity);
                            if (RequireCount > totalCount)
                            {
                                deliveryStatus = "短发";
                            }
                            else if (RequireCount == totalCount)
                            {
                                deliveryStatus = "正常";
                            }
                            else
                            {
                                deliveryStatus = "超发";
                            }
                        }
                        break;
                    case (int)DeliveryOrderStatusEnum.Received:
                    case (int)DeliveryOrderStatusEnum.Closed:
                    default:
                        break;
                }
                return deliveryStatus;
            }
        }
    }
}
