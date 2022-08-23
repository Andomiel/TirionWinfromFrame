using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    //状态,0 已接收，1 入库中，2 已入库，3 已关闭
    public enum InstockOrderStatusEnum
    {
        /// <summary>
        /// 已接收
        /// </summary>
        [Description("已接收")]
        Received = 0,
        /// <summary>
        /// 入库中
        /// </summary>
        [Description("入库中")]
        Processing = 1,
        /// <summary>
        /// 已入库
        /// </summary>
        [Description("已入库")]
        Finished = 2,
        /// <summary>
        /// 已关闭
        /// </summary>
        [Description("已关闭")]
        Closed = 3
    }
}
