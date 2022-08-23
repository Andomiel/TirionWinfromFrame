using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class InstockAreaDto
    {

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
		/// 入库单号
		/// </summary>
		public string InstockNo { get; set; } = string.Empty;
	}
}
