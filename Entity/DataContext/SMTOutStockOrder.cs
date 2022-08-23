using System;

namespace Entity.DataContext
{
    public class SMTOutStockOrder
    {
        public int ID { get; set; }

        /// <summary>
        /// 出库单号
        /// </summary>
        public string CK_CKDH { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public string CK_CZRY { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? CK_CZSJ { get; set; }

        /// <summary>
        /// 料号
        /// </summary>
        public string WZ_BM { get; set; }

        /// <summary>
        /// 物料唯一码
        /// </summary>
        public string CK_WZTM { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        public string CK_CKSL { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? ADD_TIME { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 出库方式，如DBCK
        /// </summary>
        public string Type2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DestinationNo { get; set; }

        /// <summary>
        /// 槽位
        /// </summary>
        public string SlotNo { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public string LineNumber { get; set; }

        /// <summary>
        /// Y:首套
        /// </summary>
        public bool FirstPerDay { get; set; }

        /// <summary>
        /// 操作人员名字
        /// </summary>
        public string ImName { get; set; }
    }
}
