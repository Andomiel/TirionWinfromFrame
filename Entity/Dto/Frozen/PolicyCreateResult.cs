using Entity.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class PolicyCreateResult
    {
        public bool Result { get; set; } = false;

        public FrozenPolicy Policy { get; set; }

        public List<FrozenPolicyDetail> Details { get; set; }

        public List<MaterialFrozen> FrozenMaterials { get; set; }
    }
}
