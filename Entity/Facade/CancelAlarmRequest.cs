using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Facade
{
    public class CancelAlarmRequest : LightShelfBaseRequest
    {
        //{"user_name":"admin","user_group_power":"0","user_language":"zh"}
        /// <summary>
        /// 料架编号，示例：SWHY001
        /// </summary>
        public string shelf_id { get; set; } = string.Empty;
    }
}
