using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Facade
{
    public class LightShelfLocationRequest
    {
        /// <summary>
        /// 条码
        /// </summary>
        public string Barcode { get; set; } = string.Empty;

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// 货架库位码
        /// </summary>
        public string ShelfPosition { get; set; } = string.Empty;
    }
}
