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
    public class carsinfo : Icarsinfo
    {
        public DataTable showcars()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from car order by id Desc");

            DataTable table = SQLDbHelper.ExecuteDt(sb.ToString());
            return table;
        }
        public DataTable showcarsbytype(string type)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from car order by id Desc where type=@type");
            SqlParameter[] param = 
                                    {
                                       
                                         SQLDbHelper.GetParameter("@type", SqlDbType.NVarChar,type),
                                       
                                       
                                    };
            DataTable table = SQLDbHelper.ExecuteDt(sb.ToString());
            return table;
        }
        public DataTable getidshowcars(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from car where id=@id ");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@id",SqlDbType.Int,8,"id",id)
                                  };
            DataTable table = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            return table;
        }
    

    }
}
