using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    //状态,0 已接收，1 计算中， 2 已计算，3 发料中，4 已发料 ，5 已复核， 9 已关闭 
    public enum DeliveryOrderStatusEnum
    {
        /// <summary>
        /// 待出库
        /// </summary>
        [Description("待出库")]
        Received = 0,
        /// <summary>
        /// 计算中
        /// </summary>
        [Description("计算中")]
        Calculating = 1,
        /// <summary>
        /// 已计算
        /// </summary>
        [Description("已计算")]
        Calculated = 2,
        /// <summary>
        /// 发料中
        /// </summary>
        [Description("发料中")]
        Delivering = 3,
        /// <summary>
        /// 已发料
        /// </summary>
        [Description("已发料")]
        Delivered = 4,
        /// <summary>
        /// 已复核
        /// </summary>
        [Description("已复核")]
        Reviewed = 5,
        /// <summary>
        /// 已关闭
        /// </summary>
        [Description("已关闭")]
        Closed = 9
    }
}
