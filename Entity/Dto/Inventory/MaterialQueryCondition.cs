using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class MaterialQueryCondition
    {
        /// <summary>
        /// 库区
        /// </summary>
        public int TowerNo { get; set; }
        /// <summary>
        /// UPN
        /// </summary>
        public string UPN { get; set; }
        /// <summary>
        /// 料号
        /// </summary>
        public string PartNumber { get; set; }
        /// <summary>
        /// 智能仓AB面
        /// </summary>
        public string ABSide { get; set; }
        /// <summary>
        /// 货架编号
        /// </summary>
        public string MachineId { get; set; }
        /// <summary>
        /// 冻结状态
        /// </summary>
        public string HoldState { get; set; }
        /// <summary>
        /// 供货厂家
        /// </summary>
        public string Supplier { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime SaveTimeStart { get; set; }
        public DateTime SaveTimeEnd { get; set; }
        public bool haveSaveTimeQuery { get; set; }
        //周期
        public bool haveCycleQuery { get; set; }
        public DateTime CycleStart { get; set; }
        public DateTime CycleEnd { get; set; }
        //料盘类型
        public string MateType { get; set; }
        //MSD
        public string MSD { get; set; }
        //流水号
        public string SerialNoStart { get; set; }
        public string SerialNoEnd { get; set; }
        //超期
        public int ExceedStart { get; set; }
        public int ExceedEnd { get; set; }


        public bool EmptyCondition => CheckConditionEmpty();

        private bool CheckConditionEmpty()
        {
            return TowerNo == -1
                && (ExceedStart == 0 || ExceedEnd == 0)
                && !haveSaveTimeQuery
                && !haveCycleQuery
                && string.IsNullOrWhiteSpace(UPN)
                && string.IsNullOrWhiteSpace(PartNumber)
                && string.IsNullOrWhiteSpace(ABSide)
                && string.IsNullOrWhiteSpace(MachineId)
                && string.IsNullOrWhiteSpace(HoldState)
                && string.IsNullOrWhiteSpace(Supplier)
                && string.IsNullOrWhiteSpace(MateType)
                && string.IsNullOrWhiteSpace(MSD)
                && string.IsNullOrWhiteSpace(SerialNoStart)
                && string.IsNullOrWhiteSpace(SerialNoEnd);
        }
    }
}
