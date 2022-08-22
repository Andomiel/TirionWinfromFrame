using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public static class ExceptionExtension
    {
        public static string GetDeepException(this Exception ex)
        {
            if (ex is OppoCoreException)
            {
                return ex.Message;
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                sb.AppendLine(ex.Message);
            }

            sb.AppendLine(ex.StackTrace);
            return sb.ToString();
        }
    }
}
