using System;

namespace Entity.DataContext
{
	/// <summary>
	/// Wms_LightColorRecord
	/// </summary>  
	public class Wms_LightColorRecord
	{
		#region 公共属性

		/// <summary>
		/// 主键
		/// </summary>
		public long Id { get; set; } = 0;

		/// <summary>
		/// 单据类型，0 入库单，1 出库单，2 移库单，3 盘点单
		/// </summary>
		public int OrderType { get; set; } = 0;

		/// <summary>
		/// 亮灯库区，亮灯货架还是改造货架
		/// </summary>
		public int LightArea { get; set; } = 0;

		/// <summary>
		/// 亮灯颜色
		/// </summary>
		public int LightColor { get; set; } = 0;

		/// <summary>
		/// 单据Id
		/// </summary>
		public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// 单据号
        /// </summary>
        public string OrderNo { get; set; } = string.Empty;

		/// <summary>
		/// 状态,0 已灭灯，1 已亮灯
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
		public Wms_LightColorRecord Clone()
		{
			return MemberwiseClone() as Wms_LightColorRecord;
		}

		/// <summary>
		/// 获取Select语句
		/// </summary> 
		public static string GetSelectSql()
		{
			return "SELECT Id, OrderType, LightArea, LightColor, OrderId, OrderNo, RecordStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Wms_LightColorRecord  WITH(NOLock) WHERE 1=1 ";
		}

		#endregion
	}
}
