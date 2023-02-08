
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DataContext
{
    /// <summary>
    /// Wms_DeliveryOrder
    /// </summary>  
    public class Wms_DeliveryOrder
    {
        #region 公共属性

        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; } = 0;

        /// <summary>
        /// 出库单业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 出库单号
        /// </summary>
        public string DeliveryNo { get; set; } = string.Empty;

        /// <summary>
        /// 工单Id
        /// </summary>
        public string WorkOrderId { get; set; } = string.Empty;

        /// <summary>
        /// 分拣口
        /// </summary>
        public string SortingId { get; set; } = string.Empty;

        /// <summary>
        /// 产品料号
        /// </summary>
        public string ProductNo { get; set; } = string.Empty;

        /// <summary>
        /// 产线(目的地)
        /// </summary>
        public string LineId { get; set; } = string.Empty;

        /// <summary>
        /// 发料类型，0 齐套发料，1 首套料， 2 补料(含超领)
        /// </summary>
        public int OrderType { get; set; } = 0;

        /// <summary>
        /// 出库类型，1 调拨出库，2 拣料单出库，3 杂项出库，4 生产领料，5 辅料出库，6 移库， 7 盘点，8 Excel导入
        /// </summary>
        public int DeliveryType { get; set; } = 0;

        /// <summary>
        /// 状态,0 已接收，1 计算中， 2 已计算，3 发料中，4 已发料 ，5 已复核， 9 已关闭 
        /// </summary>
        public int OrderStatus { get; set; } = 0;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; } = string.Empty;

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// 最后更新人
        /// </summary>
        public string LastUpdateUser { get; set; } = string.Empty;

        #endregion

        #region 公共方法

        /// <summary>
        /// 深度复制此对象
        /// </summary> 
        public Wms_DeliveryOrder Clone()
        {
            return MemberwiseClone() as Wms_DeliveryOrder;
        }

        /// <summary>
        /// 获取Select语句
        /// </summary> 
        public static string GetSelectSql()
        {
            return "SELECT Id, BusinessId, DeliveryNo, WorkOrderId, SortingId, ProductNo, LineId, OrderType, DeliveryType, OrderStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Wms_DeliveryOrder WITH(NOLock)  WHERE 1=1 ";
        }

        #endregion
    }
}
