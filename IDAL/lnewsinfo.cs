using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace IDAL
{
    public interface Inewsinfo 
    {
        DataTable shownews();
        DataTable getidshow(int newsid);
        void UpdateVisit(int visittimes, int newsid);
    }
}
