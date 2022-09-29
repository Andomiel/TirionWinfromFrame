
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DataContext
{
    /// <summary>
    /// Wms_TransferBarcode
    /// </summary>  
    public class Wms_TransferBarcode
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
        /// 移库单Id
        /// </summary>
        public string TransferOrderId { get; set; } = string.Empty;

        /// <summary>
        /// 移库条码
        /// </summary>
        public string Barcode { get; set; } = string.Empty;

        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialNo { get; set; } = string.Empty;

        /// <summary>
        /// 移库数量
        /// </summary>
        public int TransferQuantity { get; set; } = 0;

        /// <summary>
        /// 状态,0 未移库，1 已移库
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
        /// 执行结果
        /// </summary>
        public int ExecuteResult { get; set; } = 0;

        #endregion

        #region 公共方法

        /// <summary>
        /// 深度复制此对象
        /// </summary> 
        public Wms_TransferBarcode Clone()
        {
            return MemberwiseClone() as Wms_TransferBarcode;
        }

        /// <summary>
        /// 获取Select语句
        /// </summary> 
        public static string GetSelectSql()
        {
            return "SELECT Id, BusinessId, TransferOrderId, Barcode, MaterialNo, TransferQuantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser, ExecuteResult FROM Wms_TransferBarcode WHERE 1=1 ";
        }

        #endregion
    }
}
