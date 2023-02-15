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
        [Description("烧录IC料架区")]
        LightShelf = 2,

        ///// <summary>
        ///// 栈板区
        ///// </summary>
        //[Description("栈板区")]
        //PalletArea = 3,

        /// <summary>
        /// 线边料架区
        /// </summary>
        [Description("线边料架区")]
        Nearby = 3,

        /// <summary>
        /// BGA料架区
        /// </summary>
        [Description("BGA料架区")]
        ReformShelf = 4,


    }
}
