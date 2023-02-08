using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Balance
{
    public class BalanceReportDto
    {
        /// <summary>
        /// 上一次清账日期
        /// </summary>
        public DateTime LastDate { get; set; } = DateTime.Today.AddDays(-1);

        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialNo { get; set; } = string.Empty;
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; } = string.Empty;
        /// <summary>
        /// 昨日结存
        /// </summary>
        public int LastQuantity { get; set; } = 0;
        /// <summary>
        /// 手工点料
        /// </summary>
        public int ManualInQuantity { get; set; } = 0;
        /// <summary>
        /// 调拨入库
        /// </summary>
        public int AllocateInQuantity { get; set; } = 0;
        /// <summary>
        /// 自制收货
        /// </summary>
        public int SelfMadeInQuantity { get; set; } = 0;
        /// <summary>
        /// 杂项入库
        /// </summary>
        public int OtherInQuantity { get; set; } = 0;
        /// <summary>
        /// 生产退料
        /// </summary>
        public int RefundInQuantity { get; set; } = 0;
        /// <summary>
        /// 盘盈
        /// </summary>
        public int ProfitInQuantity { get; set; } = 0;
        /// <summary>
        /// 拣料单出库
        /// </summary>
        public int JldOutQuantity { get; set; } = 0;
        /// <summary>
        /// 调拨出库
        /// </summary>
        public int AllocateOutQuantity { get; set; } = 0;
        /// <summary>
        /// 杂项出库
        /// </summary>
        public int OtherOutQuantity { get; set; } = 0;
        /// <summary>
        /// 生产领料
        /// </summary>
        public int ProduceOutQuantity { get; set; } = 0;
        /// <summary>
        /// 辅料出库
        /// </summary>
        public int FlOutQuantity { get; set; } = 0;
        /// <summary>
        /// 盘亏
        /// </summary>
        public int LossOutQuantity { get; set; } = 0;
        /// <summary>
        /// 当日结存
        /// </summary>
        public int CurrentBalance => LastQuantity + ManualInQuantity + AllocateInQuantity + SelfMadeInQuantity + OtherInQuantity + RefundInQuantity + ProfitInQuantity
            - JldOutQuantity - AllocateOutQuantity - OtherOutQuantity - ProduceOutQuantity - FlOutQuantity - LossOutQuantity;
        /// <summary>
        /// 今日实盘
        /// </summary>
        public int TodayBalance { get; set; } = 0;
        /// <summary>
        /// 对账差异
        /// </summary>
        public int Balance => TodayBalance - CurrentBalance;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
