using System;

namespace Entity.DataContext
{
    /// <summary>
    /// 仓储管理系统内部工单表
    /// </summary>
    public class SMTInStockOrder
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string RK_RKDH { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public string RK_CZRY { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? RK_CZSJ { get; set; }

        /// <summary>
        /// 物资编码
        /// </summary>
        public string WZ_BM { get; set; }

        /// <summary>
        /// 物资条码, UPN
        /// </summary>
        public string WZ_TM { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public string RK_RKSL { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime ADD_TIME { get; set; } = DateTime.Now;

        /// <summary>
        /// 类别，1：、2：、3：
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 默认为空
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 更新时间，默认为空
        /// </summary>
        public DateTime? UPDATE_TIME { get; set; }

        /// <summary>
        /// 数据源类型
        /// </summary>
        public string Type2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImName { get; set; }

        /// <summary>
        /// 默认为空
        /// </summary>
        public string WZ_SSXM { get; set; }
    }
}
