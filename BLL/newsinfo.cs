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
    public class newsinfo
    {
        private static readonly Inewsinfo news = DataAccess.Createnewsinfo();


        public DataTable shownews() 
        {
            return news.shownews();
        }
        public DataTable getidshow(int newsid) 
        {
            return news.getidshow(newsid);
        }
        public void UpdateVisit(int visittimes, int newsid)
        {
            news.UpdateVisit(visittimes, newsid);
        }
    }
}
