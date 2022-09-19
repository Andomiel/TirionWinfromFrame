using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    public enum TowerEnum
    {
        /// <summary>
        /// 理料区
        /// </summary>
        [Description("理料区")]
        SortingArea = 0,

        /// <summary>
        /// 智能仓
        /// </summary>
        [Description("智能仓")]
        ASRS = 1,

        /// <summary>
        /// 亮灯料架
        /// </summary>
        [Description("亮灯料架")]
        LightShelf = 2,

        ///// <summary>
        ///// 栈板区
        ///// </summary>
        //[Description("栈板区")]
        //PalletArea = 3,

        /// <summary>
        /// 改造货架
        /// </summary>
        [Description("改造货架")]
        ReformShelf = 4,


    }
}
