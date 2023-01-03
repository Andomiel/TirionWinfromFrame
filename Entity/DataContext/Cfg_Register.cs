using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataContext
{
    /// <summary>
    /// Cfg_Register
    /// </summary>  
    public class Cfg_Register
    {
        #region 公共属性

        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; } = 0;

        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialNo { get; set; } = string.Empty;

        /// <summary>
        /// 状态,0 无效，1 有效
        /// </summary>
        public int RecordStatus { get; set; } = 0;

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
        public Cfg_Register Clone()
        {
            return MemberwiseClone() as Cfg_Register;
        }

        /// <summary>
        /// 获取Select语句
        /// </summary> 
        public static string GetSelectSql()
        {
            return "SELECT Id, MaterialNo, RecordStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Cfg_Register WHERE 1=1 ";
        }

        #endregion
    }
}
