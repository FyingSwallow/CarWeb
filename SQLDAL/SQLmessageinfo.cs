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
    public class messageinfo : Imessageinfo
    {
        public void addmessage(DateTime time, string content, int carid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into leavemessage(time,content,carid) values(@time,@content,@carid)");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@time",SqlDbType.DateTime,100,"time",time),
                                      SQLDbHelper.GetParameter("@content",SqlDbType.NVarChar,50,"content",content),
                                      SQLDbHelper.GetParameter("@carid",SqlDbType.Int,8,"carid",carid)
                                  };

            SQLDbHelper.ExecuteDt(sb.ToString(),param);
            
        }

        public DataTable getidshowmessage(int carid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select top 5 * from leavemessage where carid=@carid  order by time desc");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@carid",SqlDbType.Int,8,"carid",carid)
                                  };
            DataTable table = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            return table;
        }


    }
}
