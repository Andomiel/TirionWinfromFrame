
using System;

namespace Entity.DataContext
{
    /// <summary>
    /// Wms_TransferOrder
    /// </summary>  
    public class Wms_TransferOrder
    {
        #region 公共属性

        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; } = 0;

        /// <summary>
        /// 移库单业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 移库单号
        /// </summary>
        public string TransferNo { get; set; } = string.Empty;

        /// <summary>
        /// 分拣口
        /// </summary>
        public string SortingId { get; set; } = string.Empty;

        /// <summary>
        /// 移库类型，0 移入，1 移出
        /// </summary>
        public int TransferType { get; set; } = 0;

        /// <summary>
        /// 来源库区
        /// </summary>
        public int SourceAreaId { get; set; } = 0;

        /// <summary>
        /// 目标库区
        /// </summary>
        public int TargetAreaId { get; set; } = 0;

        /// <summary>
        /// 状态,0 已创单，1 执行中，2 已执行，3 已取消
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
        public Wms_TransferOrder Clone()
        {
            return MemberwiseClone() as Wms_TransferOrder;
        }

        /// <summary>
        /// 获取Select语句
        /// </summary> 
        public static string GetSelectSql()
        {
            return "SELECT Id, BusinessId, TransferNo, SortingId, TransferType, SourceAreaId, TargetAreaId, OrderStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Wms_TransferOrder WHERE 1=1 ";
        }

        #endregion
    }
}
