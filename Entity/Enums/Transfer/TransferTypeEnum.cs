using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums.Transfer
{
    public enum TransferTypeEnum
    {
        /// <summary>
        /// 移入
        /// </summary>
        [Description("移入")]
        TransferIn = 0,

        /// <summary>
        /// 移出
        /// </summary>
        [Description("移出")]
        TransferOut = 1
    }
}
