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
        Excel导入 = 6,
        /// <summary>
        /// 补货入库
        /// </summary>
        [Description("补货入库")]
        BHRK = 7,
        /// <summary>
        /// 部门退料
        /// </summary>
        [Description("部门退料")]
        BMTL = 8,
        /// <summary>
        /// 采购入库
        /// </summary>
        [Description("采购入库")]
        CGRK = 9,
        /// <summary>
        /// CKD入库
        /// </summary>
        [Description("CKD入库")]
        CKDRK = 10,
        /// <summary>
        /// 换料入库
        /// </summary>
        [Description("换料入库")]
        HLRK = 11,
        /// <summary>
        /// 盘盈
        /// </summary>
        [Description("盘盈")]
        PY = 12,
        /// <summary>
        /// 生产入库
        /// </summary>
        [Description("生产入库")]
        SCRK = 13,
        /// SKD入库
        /// </summary>
        [Description("SKD入库")]
        SKDRK = 14,
        /// 外协退料
        /// </summary>
        [Description("外协退料")]
        WXTL = 15,
        /// 质检还料
        /// </summary>
        [Description("质检还料")]
        ZJHL = 16,
        /// 转移入库
        /// </summary>
        [Description("转移入库")]
        ZYRK = 17,
    }
}
