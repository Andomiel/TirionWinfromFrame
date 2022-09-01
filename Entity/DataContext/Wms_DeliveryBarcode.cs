
using System;

namespace Entity.DataContext
{
    /// <summary>
    /// Wms_DeliveryBarcode
    /// </summary>  
    public class Wms_DeliveryBarcode
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
        /// 出库单Id
        /// </summary>
        public string DeliveryId { get; set; } = string.Empty;

        /// <summary>
        /// 出库单明细Id
        /// </summary>
        public string DeliveryDetailId { get; set; } = string.Empty;

        /// <summary>
        /// 箱码
        /// </summary>
        public string BoxNo { get; set; } = string.Empty;

        /// <summary>
        /// 出库条码
        /// </summary>
        public string Barcode { get; set; } = string.Empty;

        /// <summary>
        /// 原厂条码
        /// </summary>
        public string OrigionBarcode { get; set; } = string.Empty;

        /// <summary>
        /// 出库库区
        /// </summary>
        public int DeliveryAreaId { get; set; } = 0;

        /// <summary>
        /// 出库数量
        /// </summary>
        public int DeliveryQuantity { get; set; } = 0;

        /// <summary>
        /// 状态,0 未出库，1 已出库，2 已复核，3 已取消(释放)
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

        /// <summary>
        /// 发料位置
        /// </summary>
        public string DeliveryLocation { get; set; } = string.Empty;

        #endregion

        #region 公共方法

        /// <summary>
        /// 深度复制此对象
        /// </summary> 
        public Wms_DeliveryBarcode Clone()
        {
            return MemberwiseClone() as Wms_DeliveryBarcode;
        }

        /// <summary>
        /// 获取Select语句
        /// </summary> 
        public static string GetSelectSql()
        {
            return "SELECT Id, BusinessId, DeliveryId, DeliveryDetailId, BoxNo, Barcode, OrigionBarcode, DeliveryAreaId, DeliveryLocation, DeliveryQuantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Wms_DeliveryBarcode WHERE 1=1 ";
        }

        #endregion
    }
}
