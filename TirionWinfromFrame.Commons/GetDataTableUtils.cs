using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirionWinfromFrame.Commons
{
    /// <summary>
    /// 获取datatable帮助类
    /// </summary>
    public class GetDataTableUtils
    {

        public static DataTable SqlTable(string name)
        {
            //string connstring = EncodeHelper.AES_Decrypt(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            string connstring=ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            string sql = "";
            string url = "";
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(connstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"select * from sysDataTable where DataTableName='{name}'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                     sql = dt1.Rows[0]["DataTableSql"].ToString();
                     url = dt1.Rows[0]["DataTableUrl"].ToString();
                     using (var con1 = new SqlConnection(url))
                     {
                         con1.Open();
                         SqlCommand cmd1 = new SqlCommand(sql, con1);
                         cmd1.CommandType = CommandType.Text;
                         SqlDataAdapter sqlda1 = new SqlDataAdapter(cmd1);
                         sqlda1.Fill(dt);
                     }
                }
            }
            return dt;
        }

        public static DataTable SqlTableBySql(string sql)
        {
            //string connstring = EncodeHelper.AES_Decrypt(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            string connstring = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            DataTable dt = new DataTable();
            using (var con = new SqlConnection(connstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.Fill(dt);
            }
            return dt;
        }
    }
}
