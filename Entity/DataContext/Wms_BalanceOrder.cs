using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DataContext
{
    /// <summary>
    /// Wms_BalanceOrder
    /// </summary>  
    public class Wms_BalanceOrder
    {
        #region 公共属性

        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; } = 0;

        /// <summary>
        /// 清账单业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 清账单号
        /// </summary>
        public string BalanceNo { get; set; } = string.Empty;

        /// <summary>
        /// 状态,0 待清账，1 清账中， 2 已清账， 3 已关闭 
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
        public Wms_BalanceOrder Clone()
        {
            return MemberwiseClone() as Wms_BalanceOrder;
        }

        /// <summary>
        /// 获取Select语句
        /// </summary> 
        public static string GetSelectSql()
        {
            return "SELECT Id, BusinessId, BalanceNo, OrderStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Wms_BalanceOrder WHERE 1=1 ";
        }

        #endregion
    }
}
