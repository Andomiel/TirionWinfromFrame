
using System;

namespace Entity.DataContext
{
    /// <summary>
    /// Wms_InventoryBarcode
    /// </summary>  
    public class Wms_InventoryBarcode
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
        /// 盘点单Id
        /// </summary>
        public string InventoryOrderId { get; set; } = string.Empty;

        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialNo { get; set; } = string.Empty;

        /// <summary>
        /// 盘点条码
        /// </summary>
        public string Barcode { get; set; } = string.Empty;

        /// <summary>
        /// 原始数量，原始数量为0时，标识多料
        /// </summary>
        public int OriginQuantity { get; set; } = 0;

        /// <summary>
        /// 盘后数量，盘后数量为0时，标识缺料
        /// </summary>
        public int RealQuantity { get; set; } = 0;

        /// <summary>
        /// 原储位
        /// </summary>
        public string OriginLocation { get; set; } = string.Empty;

        /// <summary>
        /// 状态,0 待盘点，1 已盘点，2已确认
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
        public Wms_InventoryBarcode Clone()
        {
            return MemberwiseClone() as Wms_InventoryBarcode;
        }

        /// <summary>
        /// 获取Select语句
        /// </summary> 
        public static string GetSelectSql()
        {
            return "SELECT Id, BusinessId, InventoryOrderId, MaterialNo, Barcode, OriginQuantity, RealQuantity, OriginLocation, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Wms_InventoryBarcode WHERE 1=1 ";
        }

        #endregion
    }
}
