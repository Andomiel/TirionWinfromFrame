using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    //状态,0 未入库，1 入库中，2 入库完成
    public enum InstockDetailStatusEnum
    {
        /// <summary>
        /// 未入库
        /// </summary>
        [Description("未入库")]
        NotReceived = 0,

        /// <summary>
        /// 入库中
        /// </summary>
        [Description("入库中")]
        Receiving = 1,

        /// <summary>
        /// 入库完成
        /// </summary>
        [Description("入库完成")]
        Received = 2
    }
}
