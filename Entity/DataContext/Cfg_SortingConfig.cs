using System;

namespace Entity.DataContext
{
    /// <summary>
    /// Cfg_SortingConfig
    /// </summary>  
    public class Cfg_SortingConfig
    {
        #region 公共属性

        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; } = 0;

        /// <summary>
        /// 业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 分拣口编号
        /// </summary>
        public string SortingNo { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = string.Empty;

        /// <summary>
        /// 状态,0 关闭 1 打开
        /// </summary>
        public int SortingStatus { get; set; } = 0;

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
        public Cfg_SortingConfig Clone()
        {
            return MemberwiseClone() as Cfg_SortingConfig;
        }

        /// <summary>
        /// 获取Select语句
        /// </summary> 
        public static string GetSelectSql()
        {
            return "SELECT Id, BusinessId, SortingNo, Remark, SortingStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Cfg_SortingConfig WITH(NOLock)  WHERE 1=1 ";
        }

        #endregion
    }
}
