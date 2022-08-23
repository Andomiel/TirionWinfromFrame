using System.ComponentModel;

namespace Entity.Enums
{
    public enum InOrderTypeEnum
    {
        [Description("调拨入库")]
        DBRK = 0,
        [Description("SMT产线退料")]
        CXTL = 1,
        [Description("生产退料")]
        SCTL = 2,
        [Description("杂项入库")]
        ZX = 3,
        [Description("自制收货")]
        CPGD = 4,
        [Description("移库模式")]
        移库模式 = 5,
        [Description("Excel导入")]
        Excel导入 = 6
    }
}
