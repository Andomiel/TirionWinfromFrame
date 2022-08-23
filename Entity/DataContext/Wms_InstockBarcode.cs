
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DataContext
{
	/// <summary>
	/// Wms_InstockBarcode
	/// </summary>  
	public class Wms_InstockBarcode
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
		/// 入库单明细Id
		/// </summary>
		public string InstockDetailId { get; set; } = string.Empty;

		/// <summary>
		/// 入库库区
		/// </summary>
		public int InstockAreaId { get; set; } = 0;

		/// <summary>
		/// 入库条码
		/// </summary>
		public string Barcode { get; set; } = string.Empty;

		/// <summary>
		/// 入库数量，主要栈板区，不能使用zdmaterial的数量
		/// </summary>
		public int InstockQuantity { get; set; } = 0;

		/// <summary>
		/// 状态,0 未入库，1 已入库
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
		public Wms_InstockBarcode Clone()
		{
			return MemberwiseClone() as Wms_InstockBarcode;
		}

		/// <summary>
		/// 获取Select语句
		/// </summary> 
		public static string GetSelectSql()
		{
			return "SELECT Id, BusinessId, InstockId, InstockDetailId, InstockAreaId, Barcode, InstockQuantity, OrderStatus, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser FROM Wms_InstockBarcode WHERE 1=1 ";
		}

		#endregion
	}
}
