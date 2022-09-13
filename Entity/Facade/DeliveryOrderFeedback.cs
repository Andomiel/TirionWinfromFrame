using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Facade
{
    /// <summary>
    /// 请求立即反馈的实体
    /// </summary>
    public class DeliveryOrderFeedback
    {
        /// <summary>
        /// 出库单号
        /// </summary>
        public string DeliveryNo { get; set; } = string.Empty;

        /// <summary>
        /// 出库单类型-枚举文本
        /// </summary>
        public string DeliveryType { get; set; }

        /// <summary>
        /// 出库目的地
        /// </summary>
        public string LineId { get; set; } = string.Empty;
    }
}
