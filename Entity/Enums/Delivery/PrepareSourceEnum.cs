using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    public enum PrepareSourceEnum
    {
        [Description("系统备料")]
        Recommend = 1,
        [Description("复核新增")]
        ReviewNew = 2,
        [Description("拣料新增")]
        TakeNew = 3,
    }
}
