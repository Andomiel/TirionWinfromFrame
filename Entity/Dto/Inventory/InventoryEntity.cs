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

        /// <summary>
        /// 规格型号
        /// </summary>
        public string Specification { get; set; }

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
        public string TowerDes { get; set; }
        /// <summary>
        /// 巷道
        /// </summary>
        public string ABSide { get; set; }
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
        /// 供货厂家
        /// </summary>
        public string Supplier { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public string SaveTime { get; set; }
        /// <summary>
        /// 料盘类型
        /// </summary>
        public string UpnCate { get; set; }
        public string ReelTypeDes => EnumHelper.GetDescription(typeof(ReelTypeEnum), UpnCate);
        public string MSD { get; set; }
        public string DateCode { get; set; } = string.Empty;
        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNo { get; set; }
        /// <summary>
        /// 冻结状态
        /// </summary>
        public string HoldState { get; set; }

        /// <summary>
        /// DateCode对应的日期
        /// </summary>
        public DateTime DateCodeDate => QueryConditionConvert.DateCdoeToCycleDate(DateCode, UPN);

        public string Lot { get; set; }

        public int MinPacking { get; set; }

    }
}
