using BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class QueryConditionConvert
    {
        private static DateTime DefaultDate = new DateTime(1900, 1, 1);

        public static DateTime DateCdoeToCycleDate(string dateCode, string upn)
        {
            if (string.IsNullOrWhiteSpace(dateCode) || dateCode.Length != 5)
            {
                if (string.IsNullOrWhiteSpace(upn))
                {
                    return DefaultDate;
                }
                string[] upnArry = upn.Split('-');
                if (upnArry.Length != 4)
                {
                    return DefaultDate;
                }
                dateCode = upnArry[2];
            }
            try
            {
                int year = Convert.ToInt32(dateCode.Substring(0, 2)) + 2000;
                string monthCode = dateCode.Substring(2, 1);
                int month = int.Parse(monthCode, System.Globalization.NumberStyles.HexNumber);
                int day = Convert.ToInt32(dateCode.Substring(3));
                return new DateTime(year, month, day);
            }
            catch
            {
                return DefaultDate;
            }
        }
    }
}
