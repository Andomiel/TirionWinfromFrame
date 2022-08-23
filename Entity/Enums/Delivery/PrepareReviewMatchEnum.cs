using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enums
{
    public enum PrepareReviewMatchEnum
    {
        [Description("免复核")]
        Exemption = -1,
        [Description("未复核")]
        Not = 0,
        [Description("复核匹配")]
        Done = 1,
    }
}
