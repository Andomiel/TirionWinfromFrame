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
        Excel导入 = 8
    }
}
