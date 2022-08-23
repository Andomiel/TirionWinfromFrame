using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataContext.DbContext
{
   public class WmsLog
    {
        public string Id { get; set; }

        public string Level { get; set; }

        public DateTime Date { get; set; }

        public string Message { get; set; }

        public string RequestBody { get; set; }

        public string ResponseBody { get; set; }
    }
}
