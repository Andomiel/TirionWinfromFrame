using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DataContext
{
    /// <summary>
    /// Wms_BalanceBarcode
    /// </summary>  
    public class Wms_BalanceBarcode
    {
        #region 公共属性

        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; } = 0;

        /// <summary>
        /// 明细业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 清账单Id
        /// </summary>
        public string BalanceId { get; set; } = string.Empty;

        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialNo { get; set; } = string.Empty;

        /// <summary>
        /// 条码
        /// </summary>
        public string Barcode { get; set; } = string.Empty;

        /// <summary>
        /// 所在库区
        /// </summary>
        public int AreaId { get; set; } = 0;

        /// <summary>
        /// 清账库位
        /// </summary>
        public string BalanceLocation { get; set; } = string.Empty;

        /// <summary>
        /// 清账数量
        /// </summary>
        public int Quantity { get; set; } = 0;

        /// <summary>
        /// 状态,0 未清账，1 已清账，2  已取消
        /// </summary>
        public int OrderStatus { get; set; } = 0;

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
        public Wms_BalanceBarcode Clone()
        {
            return MemberwiseClone() as Wms_BalanceBarcode;
        }

        /// <summary>
        /// 获取Select语句
        /// </summary> 
        public static string GetSelectSql()
        {
            return "SELECT Id, BusinessId, BalanceId, MaterialNo, Barcode, AreaId, BalanceLocation, Quantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Wms_BalanceBarcode WITH(NOLock) WHERE 1=1 ";
        }

        #endregion
    }
}
