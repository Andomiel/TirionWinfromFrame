using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    public enum BakeStateEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,

        /// <summary>
        /// 待烘烤
        /// </summary>
        [Description("待烘烤")]
        WaitForBake = 1,

        /// <summary>
        /// 烘烤中
        /// </summary>
        [Description("烘烤中")]
        Baking = 2,
    }
}
