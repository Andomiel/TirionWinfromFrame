using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Balance
{
    public class BalanceBarcodeDto
    {
        /// <summary>
        /// 明细业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 清账单Id
        /// </summary>
        public string BalanceId { get; set; } = string.Empty;

        /// <summary>
        /// 条码
        /// </summary>
        public string Barcode { get; set; } = string.Empty;

        /// <summary>
        /// 所在库区
        /// </summary>
        public int AreaId { get; set; } = 0;

        public string AreaDisplay => EnumHelper.GetDescription(typeof(TowerEnum), AreaId);

        /// <summary>
        /// 清账库位
        /// </summary>
        public string BalanceLocation { get; set; } = string.Empty;

        /// <summary>
        /// 清账数量
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// 状态,0 未清账，1 已清账，2  已取消
        /// </summary>
        public int OrderStatus { get; set; } = 0;

        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialNo { get; set; } = string.Empty;

    }
}
