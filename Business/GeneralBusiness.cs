using DataBase;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TirionWinfromFrame.Commons;

namespace Business
{
    public static class GeneralBusiness
    {
        public static bool CompareVersion(string currentVersion)
        {
            if (string.IsNullOrWhiteSpace(currentVersion))
            {
                return false;
            }

            string[] currentElements = currentVersion.Split('.');
            string sql = $@"SELECT LastestVersion  FROM Cfg_GeneralConfig ";

            string lastestVersion = Convert.ToString(DbHelper.ExecuteScalar(sql));

            if (string.IsNullOrWhiteSpace(lastestVersion))
            {
                return true;
            }
            string[] latestElements = lastestVersion.Split('.');

            int length = currentElements.Length > latestElements.Length ? currentElements.Length : latestElements.Length;

            for (int i = 0; i < length; i++)
            {
                string current = currentElements.Length > i ? currentElements[i] : string.Empty;
                string latest = latestElements.Length > i ? latestElements[i] : string.Empty;

                if (!CompareElement(current, latest))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CompareElement(string current, string latest)
        {
            int currentValue = TypeParse.StrToInt(current, 0);
            int latestValue = TypeParse.StrToInt(latest, 0);
            return currentValue >= latestValue;
        }

        public static DataTable GetInventoryBarcode(string barcode)
        {
            string newBarcodeSql = $"select * from smt_zd_material where ReelID = '{barcode}' and Status < {(int)BarcodeStatusEnum.Delivered}  ";
            return DbHelper.GetDataTable(newBarcodeSql);
        }
    }
}
