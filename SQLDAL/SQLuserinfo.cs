using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using IDAL;
namespace SQLDAL
{
    public class userinfo : Iuserinfo
    {
        public bool validUser(string username, string password)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from userlogin where username=@username ");
            sb.Append("and userpwd=@password");
            SqlParameter[] param = 
                                    {
                                        SQLDbHelper.GetParameter("@username",SqlDbType.NVarChar,50,"username",username),
                                        SQLDbHelper.GetParameter("@password",SqlDbType.NVarChar,20,"userpwd",password),
                                    };
            DataTable table = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int modifynews(string title, string author, string datetime, string content)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO  message( title, content, time,author) VALUES(@Title, @content ,@AddTime,@Author)");
            SqlParameter[] param = 
                                    {
                                         SQLDbHelper.GetParameter("@Title", SqlDbType.NVarChar,50,"标题",title),
                                        SQLDbHelper.GetParameter("@Author", SqlDbType.NVarChar, 50,"发布者",author),
                                         SQLDbHelper.GetParameter("@AddTime", SqlDbType.DateTime,8,"发布日期",datetime),
                                         SQLDbHelper.GetParameter("@content", SqlDbType.Text,200,"内容",content),
                                       
                                    };
            return SQLDbHelper.ExecuteSql(sb.ToString(), param);
        }
        public int modifcars(string title, string type, int price, string content, string address)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO  car( carname, carprice, carcontent,address,cartype) VALUES(@carname, @carprice ,@carcontent,@address,@cartype)");
            SqlParameter[] param = 
                                    {
                                         SQLDbHelper.GetParameter("@carname", SqlDbType.NVarChar,title),
                                        SQLDbHelper.GetParameter("@carprice", SqlDbType.Int,price),
                                         SQLDbHelper.GetParameter("@carcontent", SqlDbType.Text,content),
                                         SQLDbHelper.GetParameter("@address", SqlDbType.NVarChar,address),
                                         SQLDbHelper.GetParameter("@cartype", SqlDbType.NVarChar,type),
                                       
                                    };
            return SQLDbHelper.ExecuteSql(sb.ToString(), param);

        }
        public int modifycarnews(string title, string author, DateTime time, string content, string address)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO  carnews( title, author, publishtime,visittimes,newscontent,imagepath) VALUES( @title, @author, @pubishtime,0,@newscontent,@imagepath)");
            SqlParameter[] param = 
                                    {
                                         SQLDbHelper.GetParameter("@title", SqlDbType.NVarChar,title),
                                        SQLDbHelper.GetParameter("@author", SqlDbType.NVarChar,author),
                                         SQLDbHelper.GetParameter("@pubishtime", SqlDbType.DateTime,time),
                                         
                                         SQLDbHelper.GetParameter("@newscontent", SqlDbType.NVarChar,content),
                                         SQLDbHelper.GetParameter("@imagepath", SqlDbType.NVarChar,address),
                                       
                                    };
            return SQLDbHelper.ExecuteSql(sb.ToString(), param);
        }
        public int modifytype(string type)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO  carType( cartype) VALUES(@cartype)");
            SqlParameter[] param = 
                                    {
                                       
                                         SQLDbHelper.GetParameter("@cartype", SqlDbType.NVarChar,type),
                                       
                                    };
            return SQLDbHelper.ExecuteSql(sb.ToString(), param);

        }
        public int deletetype(string type)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from carType where cartype=@cartype");
            SqlParameter[] param = 
                                    {
                                       
                                         SQLDbHelper.GetParameter("@cartype", SqlDbType.NVarChar,type),
                                       
                                    };
            return SQLDbHelper.ExecuteSql(sb.ToString(), param);

        }
        public int Addreview(string content,int messageid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  UPDATE leavemessage SET review = @content WHERE messageid = @messageid");
            SqlParameter[] param = 
                                    {
                                       
                                         SQLDbHelper.GetParameter("@content", SqlDbType.NVarChar,content),
                                         SQLDbHelper.GetParameter("@messageid", SqlDbType.Int,messageid),
                                       
                                    };
            return SQLDbHelper.ExecuteSql(sb.ToString(), param);

        }
      


    }
}
