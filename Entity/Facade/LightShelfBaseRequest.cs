using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Facade
{
    public class LightShelfBaseRequest
    {

        public string user_name { get; set; } = "admin";

        public string user_group_power { get; set; } = "0";

        public string user_language { get; set; } = "zh";
    }
}
