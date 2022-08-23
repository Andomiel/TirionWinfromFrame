
using System;

namespace Entity.DataContext
{
    /// <summary>
    /// 
    /// </summary>
    public class SMTPrepareMaterial
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 唯一码
        /// </summary>
        public string UPN { get; set; }

        /// <summary>
        /// 料号
        /// </summary>
        public string PartNumber { get; set; }

        /// <summary>
        /// 工单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 仓库号
        /// </summary>
        public int TowerNo { get; set; }

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? CompleteTime { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public int Source { get; set; }

        /// <summary>
        /// 是否匹配
        /// </summary>
        public int Match { get; set; }

        /// <summary>
        /// 箱号
        /// </summary>
        public string ContainerNo { get; set; }

        /// <summary>
        /// 二维码
        /// </summary>
        public string QRCode { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public string LineNumber { get; set; }

        /// <summary>
        /// 槽位
        /// </summary>
        public string SlotNo { get; set; }
    }
}
