using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IDAL;
using DALFactory;

namespace BLL
{
    public class messageinfo
    {
        private static readonly Imessageinfo message = DataAccess.Createmessageinfo();


        public void addmessage(DateTime time, string content, int carid)
        {
            message.addmessage(time,content,carid);
        }

        public DataTable getidshowmessage(int carid)
        {
            return message.getidshowmessage(carid);
        }
       
       
    
    }
}
