
using System;

namespace Entity.DataContext
{
    /// <summary>
    /// Wms_Exchange
    /// </summary>  
    public class Wms_Exchange
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
        /// 平账类型 0 入库 1 出库
        /// </summary>
        public int ExchangeType { get; set; } = 0;

        /// <summary>
        /// 关联单号
        /// </summary>
        public string RelatedOrderNo { get; set; } = string.Empty;

        /// <summary>
        /// 平账条码
        /// </summary>
        public string Barcode { get; set; } = string.Empty;

        /// <summary>
        /// 状态,0 未平账 1 平账失败 2 平账成功
        /// </summary>
        public int ExchangeStatus { get; set; } = 0;

        /// <summary>
        /// 平账URL
        /// </summary>
        public string ExchangeUrl { get; set; } = string.Empty;

        /// <summary>
        /// 平账请求原始Json
        /// </summary>
        public string ExchangeRequest { get; set; } = string.Empty;

        /// <summary>
        /// 平账结论
        /// </summary>
        public string ExchangeLog { get; set; } = string.Empty;

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
        public Wms_Exchange Clone()
        {
            return MemberwiseClone() as Wms_Exchange;
        }

        /// <summary>
        /// 获取Select语句
        /// </summary> 
        public static string GetSelectSql()
        {
            return "SELECT Id, BusinessId, ExchangeType, RelatedOrderNo, Barcode, ExchangeStatus, ExchangeUrl, ExchangeRequest, ExchangeLog, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Wms_Exchange WITH(NOLock)  WHERE 1=1 ";
        }

        #endregion
    }
}
