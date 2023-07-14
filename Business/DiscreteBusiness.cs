using DataBase;
using Entity.DataContext;
using Entity.Enums.General;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TirionWinfromFrame.Commons;

namespace Business
{
    public static class DiscreteBusiness
    {
        public static IEnumerable<Cfg_Discrete> GetAllDiscreteCfg(string materialNo, int cfgStatus)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();

            sb.AppendLine(Cfg_Discrete.GetSelectSql());
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
            return DbHelper.GetDataTable(sb.ToString(), parameters.ToArray()).DataTableToList<Cfg_Discrete>();
        }

        public static void DelDiscreteCfg(long id)
        {
            string sql = $" delete from Cfg_Discrete where Id = {id} ";

            DbHelper.ExecuteNonQuery(sql);
        }

        public static void InsertDiscreteCfg(string materialNo, string remark, bool isValid, string userName)
        {
            int status = isValid ? (int)DiscreteStatusEnum.Valid : (int)DiscreteStatusEnum.Invalid;
            string sql = $@" INSERT INTO Cfg_Discrete
(MaterialNo, RecordStatus, Remark, CreateTime, CreateUser, LastUpdateTime, LastUpdateUser)
VALUES(@MaterialNo, {status}, @Remark, getdate(), '{userName}', getdate(), '{userName}') ";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaterialNo", materialNo));
            parameters.Add(new SqlParameter("@Remark", remark));

            DbHelper.ExecuteNonQuery(sql, parameters.ToArray());
        }

        public static void UpdateDiscreteCfg(string materialNo, string remark, bool isValid, long id, string userName)
        {
            int status = isValid ? (int)RegisterStatusEnum.Valid : (int)RegisterStatusEnum.Invalid;
            string sql = $@"UPDATE Cfg_Discrete
SET MaterialNo=@MaterialNo, RecordStatus={status}, Remark=@Remark,  LastUpdateTime=getdate(), LastUpdateUser='{userName}'
WHERE Id={id}";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaterialNo", materialNo));
            parameters.Add(new SqlParameter("@Remark", remark));

            DbHelper.ExecuteNonQuery(sql, parameters.ToArray());
        }

        public static IEnumerable<Cfg_Discrete> GetValidDiscreteConfig()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Cfg_Discrete.GetSelectSql());
            sb.AppendLine($" RecordStatus = {(int)DiscreteStatusEnum.Valid} ");

            return DbHelper.GetDataTable(sb.ToString()).DataTableToList<Cfg_Discrete>();
        }
    }
}
