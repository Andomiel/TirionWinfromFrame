using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public static class DnsHelper
    {

        public static string GetIP()
        {
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            if (ipEntry.AddressList.Length > 0)
            {
                foreach (var item in ipEntry.AddressList)
                {
                    if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return item.ToString();
                    }
                }
            }
            return string.Empty;
        }
    }
}
