using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    public enum OutOrderTypeEnum
    {
        [Description("调拨出库")]
        DBCK = 1,
        [Description("拣料单出库")]
        JLDCK = 2,
        [Description("杂项出库")]
        ZF = 3,
        [Description("生产领料")]
        SCLL = 4,
        [Description("辅料出库")]
        FLCK = 5,
        [Description("移库模式")]
        移库模式 = 6,
        [Description("盘点模式")]
        盘点模式 = 7,
        [Description("Excel导入")]
        Excel导入 = 8,
        /// <summary>
        /// 补货出库
        /// </summary>
        [Description("补货出库")]
        BHCK = 9,
        /// <summary>
        /// 部门领料
        /// </summary>
        [Description("部门领料")]
        BMLL = 10,
        /// <summary>
        /// 超市发料
        /// </summary>
        [Description("超市发料")]
        CSFL = 11,
        /// <summary>
        /// 换料出库
        /// </summary>
        [Description("换料出库")]
        HLCK = 12,
        /// <summary>
        /// 品检退货
        /// </summary>
        [Description("品检退货")]
        PJTH = 13,
        /// <summary>
        /// 生产备料
        /// </summary>
        [Description("生产备料")]
        SCBL = 14,
        /// <summary>
        /// 外购退货PO
        /// </summary>
        [Description("外购退货PO")]
        WGTH_PO = 15,
        /// <summary>
        /// 外购退货SO
        /// </summary>
        [Description("外购退货SO")]
        WGTH_SO = 16,
        /// <summary>
        /// 外协领料
        /// </summary>
        [Description("外协领料")]
        WXLL = 17,
        /// <summary>
        /// 销售出库
        /// </summary>
        [Description("销售出库")]
        XSCK = 18,
        /// <summary>
        /// 质检出库
        /// </summary>
        [Description("质检出库")]
        ZJCK = 19,
        /// <summary>
        /// 转移出库
        /// </summary>
        [Description("转移出库")]
        ZYCK = 20,
    }
}
