
using System;

namespace Entity.DataContext
{
    /// <summary>
    /// Wms_InstockArea
    /// </summary>  
    public class Wms_InstockArea
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
		/// 入库单Id
		/// </summary>
		public string InstockId { get; set; } = string.Empty;

		/// <summary>
		/// 库区Id
		/// </summary>
		public int AreaId { get; set; } = 0;

		/// <summary>
		/// 状态,0 未绑定，1 已绑定
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
		public Wms_InstockArea Clone()
		{
			return MemberwiseClone() as Wms_InstockArea;
		}

		/// <summary>
		/// 获取Select语句
		/// </summary> 
		public static string GetSelectSql()
		{
			return "SELECT Id, BusinessId, InstockId, AreaId, DetailStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Wms_InstockArea WHERE 1=1 ";
		}

		#endregion
	}
}
