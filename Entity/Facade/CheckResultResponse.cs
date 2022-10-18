using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Facade
{
    /// <summary>
    /// 用于复核check接口的响应实体
    /// </summary>
    public class CheckResultResponse
    {
        /// <summary>
        /// 校验结果
        /// </summary>
        public bool Result { get; set; } = false;

        /// <summary>
        /// 异常的原始文本
        /// </summary>
        public string ErrMessage { get; set; } = string.Empty;

        public string ApiTitle { get; set; } = string.Empty;
    }

}
