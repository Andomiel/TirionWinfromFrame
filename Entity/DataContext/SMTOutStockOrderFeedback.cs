namespace Entity.DataContext
{
    /// <summary>
    /// IWMS出库反馈
    /// </summary>
    public class SMTOutStockOrderFeedback
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 状态，true: 已反馈，false: 未反馈
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 目的地
        /// </summary>
        public string DestinationNo { get; set; }
    }
}
