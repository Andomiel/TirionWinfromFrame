using Entity.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class PolicyView : FrozenPolicy
    {
        public bool SelectFlag { get; set; }
        public string PolicyDetail { get; set; }
        public string EnableDes => Enable ? "冻结" : "未冻结";
    }
}
