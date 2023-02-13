using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Facade
{
    /// <summary>
    /// 校验UPN请求
    /// </summary>
    public class CheckUpnRequest
    {
        /// <summary>
        /// 出库单号
        /// </summary>
        public string OrderNo { get; set; } = string.Empty;

        /// <summary>
        /// 料盘二维码
        /// </summary>
        public string Qrcode { get; set; } = string.Empty;
    }
}
