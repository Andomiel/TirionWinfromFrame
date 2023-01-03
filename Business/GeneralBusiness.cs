using DataBase;
using Entity.DataContext;
using Entity.Enums;
using Entity.Enums.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public static IEnumerable<Cfg_Register> GetAllRegisterCfg(string materialNo, int cfgStatus)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            sb.AppendLine(Cfg_Register.GetSelectSql());
            if (!string.IsNullOrWhiteSpace(materialNo.Trim()))
            {
                sb.AppendLine("AND MaterialNo LIKE @MaterialNo ");
                parameters.Add(new SqlParameter("@MaterialNo", materialNo.Trim()));
            }
            if (cfgStatus > 0)
            {
                sb.AppendLine(" AND RecordStatus = @RecordStatus ");
                parameters.Add(new SqlParameter("@RecordStatus", cfgStatus));
            }
            return DbHelper.GetDataTable(sb.ToString(), parameters.ToArray()).DataTableToList<Cfg_Register>();
        }

        public static void DelRegisterCfg(long id)
        {
            string sql = $" delete from Cfg_Register where Id = {id} ";

            DbHelper.ExecuteNonQuery(sql);
        }

        public static void InsertRegisterCfg(string materialNo, string remark, bool isValid, string userName)
        {
            int status = isValid ? (int)RegisterStatusEnum.Valid : (int)RegisterStatusEnum.Invalid;
            string sql = $@" INSERT INTO Cfg_Register
(MaterialNo, RecordStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
VALUES(@MaterialNo, {status}, @Remark, getdate(), '{userName}', getdate(), '{userName}') ";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaterialNo", materialNo));
            parameters.Add(new SqlParameter("@Remark", remark));

            DbHelper.ExecuteNonQuery(sql, parameters.ToArray());
        }

        public static void UpdateRegisterCfg(string materialNo, string remark, bool isValid, long id, string userName)
        {
            int status = isValid ? (int)RegisterStatusEnum.Valid : (int)RegisterStatusEnum.Invalid;
            string sql = $@"UPDATE Cfg_Register
SET MaterialNo=@MaterialNo, RecordStatus={status}, Remark=@Remark,  LastUpdateTime=getdate(), LastUpdateUser='{userName}'
WHERE Id={id}";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaterialNo", materialNo));
            parameters.Add(new SqlParameter("@Remark", remark));

            DbHelper.ExecuteNonQuery(sql, parameters.ToArray());
        }
    }
}
