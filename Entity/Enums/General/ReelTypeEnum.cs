using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    public enum ReelTypeEnum
    {
        /// <summary>
        /// 整盘料
        /// </summary>
        [Description("整盘料")]
        F,
        /// <summary>
        /// 尾数料
        /// </summary>
        [Description("尾数料")]
        S,
        /// <summary>
        ///两节物料
        /// </summary>
        [Description("两节物料")]
        T,
    }
}
