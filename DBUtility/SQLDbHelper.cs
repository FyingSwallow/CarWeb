using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
namespace DBUtility
{
   public class SQLDbHelper
    {
        public SQLDbHelper() { }

        /// <summary>
        /// 返回数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static String GetSqlConnection()
        {
            String conn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            return conn;
        }

        /// <summary>
        ///  获得参数对象 
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="paramType">数据类型</param>
        /// <param name="paramSize">长度</param>
        /// <param name="ColName">源列名称</param>
        /// <param name="paramValue">参数实值</param>
        /// <returns></returns>
        public static SqlParameter GetParameter(String paramName, SqlDbType paramType, Int32 paramSize, String ColName, Object paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramType, paramSize, ColName);
            param.Value = paramValue;
            return param;
        }

        /// <summary>
        /// 获得参数对象
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="paramType">数据类型</param>
        /// <param name="paramSize">长度</param>
        /// <param name="ColName">源列名称</param>
        /// <returns></returns>
        public static SqlParameter GetParameter(String paramName, SqlDbType paramType, Int32 paramSize, String ColName)
        {
            SqlParameter param = new SqlParameter(paramName, paramType, paramSize, ColName);
            return param;
        }

        /// <summary>
        /// 获得参数对象
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="paramType">数据类型</param>
        /// <param name="paramSize">长度</param>
        /// <param name="ColName">源列名称</param>
        /// <returns></returns>
        public static SqlParameter GetParameter(String paramName, SqlDbType paramType, Object paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramType);
            param.Value = paramValue;
            return param;
        }

        /// <summary>
        /// 执行有参SQL语句
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <param name="param">参数对象数组</param>
        /// <returns></returns>
        public static int ExecuteSql(String Sqlstr, SqlParameter[] param)
        {
            String ConnStr = SQLDbHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                cmd.Parameters.AddRange(param);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
        }


        /// <summary>
        /// 执行无参SQL语句
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <returns></returns>
        public static int ExecuteSql(String Sqlstr)
        {
            String ConnStr = SQLDbHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
        }


        /// <summary>
        /// 执行SQL语句并返回数据表
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <returns></returns>
        public static DataTable ExecuteDt(String Sqlstr)
        {
            String ConnStr = SQLDbHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(Sqlstr, conn);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        /// <summary>
        /// 执行SQL语句并返回数据表
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <param name="param">参数对象列表</param>
        /// <returns></returns>
        public static DataTable ExecuteDt(String Sqlstr, SqlParameter[] param)
        {
            String ConnStr = SQLDbHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(Sqlstr, conn);
                cmd.Connection = conn;
                cmd.Parameters.AddRange(param);
                da.SelectCommand = cmd;
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        /// <summary>
        /// 批量执行SQL语句
        /// </summary>
        /// <param name="Sqlstr">SQL语句数组</param>
        /// <param name="param">SQL参数对象数组</param>
        /// <returns></returns>
        public static Int32 ExecuteSqls(String[] Sqlstr, List<SqlParameter[]> param)
        {
            String ConnStr = SQLDbHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {

                SqlCommand cmd = new SqlCommand();
                SqlTransaction tran = null;
                cmd.Transaction = tran;
                try
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    Int32 count = Sqlstr.Length;
                    for (Int32 i = 0; i < count; i++)
                    {
                        cmd.CommandText = Sqlstr[i];
                        cmd.Parameters.AddRange(param[i]);
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    return 1;
                }
                catch
                {
                    tran.Rollback();
                    return 0;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

    }
}
