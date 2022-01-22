using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace IDAL
{
    public interface Imessageinfo
    {
        void addmessage(DateTime time, string content, int carid);
        DataTable getidshowmessage(int carid);
        

    }
}
