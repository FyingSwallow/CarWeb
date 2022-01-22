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
    public class carsinfo
    {
        private static readonly Icarsinfo cars = DataAccess.Createcarsinfo();


        public DataTable showcars()
        {
            return cars.showcars();
        }
        public DataTable showcarsbytype(string type)
        {
            return cars.showcarsbytype(type);
        }
        public DataTable getidshowcars(int id) 
        {
            return cars.getidshowcars(id);
        }
    
    }
}
