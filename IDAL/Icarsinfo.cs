using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace IDAL
{
    public interface Icarsinfo
    {
        DataTable showcars();
        DataTable showcarsbytype(string type);
        DataTable getidshowcars(int id);
    }
}
