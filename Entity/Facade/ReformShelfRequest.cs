using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Facade
{
   public class ReformShelfRequest
    {
        public string jsonData { get; set; }
    }

    public class JsonData
    {
        public JsonData(string location, string color, int number)
        {
            this.location = location;
            this.color = color;
            locationLightSerialNumber = number;
        }

        /// <summary>
        /// 仓格位置
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 仓格灯 1、2、3
        /// </summary>
        public int locationLightSerialNumber { get; set; }
    }
}
