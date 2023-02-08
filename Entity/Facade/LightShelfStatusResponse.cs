using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Facade
{
    public class LightShelfStatusResponse
    {
        public int result { get; set; } = 0;

        public List<LightShelfStatus> data { get; set; } = new List<LightShelfStatus>();
    }

    public class LightShelfStatus
    {
        public int id { get; set; } = 0;

        public string shelf_id { get; set; } = string.Empty;

        public int state { get; set; } = 1;
    }
}
