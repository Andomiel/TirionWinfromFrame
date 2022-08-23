using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Facade
{
    public class LightShelfResponse
    {
        public int Code { get; set; }

        public string Msg { get; set; }

        public List<string> ErrorPickListID { get; set; }

        public string order_id { get; set; }
    }
}
