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
    public class newsinfo : Inewsinfo
    {
        public DataTable shownews()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from carnews order by publishtime Desc");
            
            DataTable table = SQLDbHelper.ExecuteDt(sb.ToString());
            return table;
        }
        public DataTable getidshow(int newsid) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from carnews where newsid=@newsid ");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@newsid",SqlDbType.Int,8,"newsid",newsid)
                                  };
            DataTable table = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            return table;
        }
        public void UpdateVisit(int visittimes,int newsid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update carnews set visittimes=@visittimes where  newsid=@newsid");
            SqlParameter[] param ={
                                     SQLDbHelper.GetParameter("@newsid",SqlDbType.Int,8,"newsid",newsid),
                                     SQLDbHelper.GetParameter("@visittimes",SqlDbType.Int,8,"visittimes",visittimes)
                                  };
            SQLDbHelper.ExecuteDt(sb.ToString(), param);
        }

        
    }
}
