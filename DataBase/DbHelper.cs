using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace DataBase
{
    public static class DbHelper
    {
        static readonly string constr = ConfigurationManager.AppSettings["connectionString"];

        //执行非查询的sql语句，返回受影响的行数
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        cmd.CommandTimeout = 120;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    DbLog.Log(cmdText, ex.Message, ex.StackTrace);
                    throw;
                }
            }
        }

        //执行非查询的sql语句，返回第一行第一列的值
        public static object ExecuteScalar(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);
                        return cmd.ExecuteScalar();
                    }
                }
                catch (SqlException ex)
                {
                    DbLog.Log(cmdText, ex.Message, ex.StackTrace);
                    throw;
                }
            }
        }

        //执行查询语句，返回查询到的结果
        public static DataTable GetDataTable(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        DataTable dt = new DataTable();
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt;
                    }
                }
                catch (SqlException ex)
                {
                    DbLog.Log(cmdText, ex.Message, ex.StackTrace);
                    throw;
                }
            }
        }


        public static int ExcuteWithTransaction(string cmdText, out string error, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();
                int count = 0;
                try
                {
                    error = string.Empty;
                    using (SqlCommand cmd = new SqlCommand(cmdText, con, trans))
                    {
                        cmd.CommandTimeout = 120;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);
                        count = cmd.ExecuteNonQuery();
                        trans.Commit();
                        return count;
                    }
                }
                catch (SqlException ex)
                {
                    error = ex.Message;
                    count = -1;
                    trans.Rollback();
                    DbLog.Log(cmdText, ex.Message, ex.StackTrace);
                    throw;
                }
            }
        }


        public static int Insert(string sql)
        {
            int i = ExecuteNonQuery(sql);
            return i;
        }

        public static int Update(string sql)
        {
            int i = ExecuteNonQuery(sql);
            return i;
        }

        public static int Delete(string sql)
        {
            int i = ExecuteNonQuery(sql);
            return i;
        }
    }
}
