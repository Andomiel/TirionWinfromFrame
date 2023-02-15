using Entity.Enums;
using System;

namespace Entity.Dto
{
    public class InventoryEntity
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }

        public string UPN { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string PartNumber { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// 库区
        /// </summary>
        public int Tower { get; set; }
        /// <summary>
        /// 库区
        /// </summary>
        public string TowerDes => EnumHelper.GetDescription(typeof(TowerEnum), Tower);

        /// <summary>
        /// 二级库区
        /// </summary>
        public string SubArea { get; set; } = string.Empty;

        /// <summary>
        /// 货位
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        public string StatusDisplay
        {
            get
            {
                int.TryParse(Status, out int status);
                return EnumHelper.GetDescription(typeof(BarcodeStatusEnum), status);
            }
        }

        /// <summary>
        /// 原物料料号
        /// </summary>
        public string FactoryCode { get; set; } = string.Empty;
        /// <summary>
        /// IC料号
        /// </summary>
        public string BatchNo { get; set; } = string.Empty;
        /// <summary>
        /// 入库时间
        /// </summary>
        public string SaveTime { get; set; }

        /// <summary>
        /// 供应商色块
        /// </summary>
        public string DateCode { get; set; } = string.Empty;
        /// <summary>
        /// 批次
        /// </summary>
        public string Lot { get; set; }

        /// <summary>
        /// 工单号
        /// </summary>
        public string WorkOrderNo { get; set; } = string.Empty;


    }
}
