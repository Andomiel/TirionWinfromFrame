
using System;

namespace Entity.DataContext
{
    /// <summary>
    /// Wms_DeliveryDetail
    /// </summary>  
    public class Wms_DeliveryDetail
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
        /// 工单明细Id
        /// </summary>
        public string WorkOrderDetailId { get; set; } = string.Empty;

        /// <summary>
        /// 主槽位
        /// </summary>
        public string SlotNo { get; set; } = string.Empty;

        /// <summary>
        /// 行号
        /// </summary>
        public int RowNum { get; set; } = 0;

        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialNo { get; set; } = string.Empty;

        /// <summary>
        /// 出库数量
        /// </summary>
        public int RequireCount { get; set; } = 0;

        /// <summary>
        /// 状态,0 未出库，1 出库中，2 出库完成
        /// </summary>
        public int DetailStatus { get; set; } = 0;

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
        public Wms_DeliveryDetail Clone()
        {
            return MemberwiseClone() as Wms_DeliveryDetail;
        }

        /// <summary>
        /// 获取Select语句
        /// </summary> 
        public static string GetSelectSql()
        {
            return "SELECT Id, BusinessId, DeliveryId, WorkOrderDetailId, SlotNo, RowNum, MaterialNo, RequireCount, DetailStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Wms_DeliveryDetail WHERE 1=1 ";
        }

        #endregion
    }
}
