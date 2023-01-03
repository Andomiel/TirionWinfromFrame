using System.ComponentModel;

namespace Entity.Enums.Instock
{
    //状态,0 未入库，1 已入库
    public enum InstockBarcodeStatusEnum
    {
        /// <summary>
        /// 未入库
        /// </summary>
        [Description("未入库")]
        NotReceived = 0,

        /// <summary>
        /// 已入库
        /// </summary>
        [Description("已入库")]
        Received = 1,

        /// <summary>
        /// 已回传
        /// </summary>
        [Description("已回传")]
        Exchanged = 2
    }
}
