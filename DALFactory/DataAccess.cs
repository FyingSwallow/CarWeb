using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using IDAL;
namespace DALFactory
{
    public class DataAccess
    {
        private static readonly string path = ConfigurationSettings.AppSettings["SQLDAL"];
        public static Iuserinfo Createuserinfo()
        {
            string className = path + ".userinfo";
            return (Iuserinfo)Assembly.Load(path).CreateInstance(className);
        }
        public static Inewsinfo Createnewsinfo()
        {
            string className = path + ".newsinfo";
            return (Inewsinfo)Assembly.Load(path).CreateInstance(className);
        }
        public static Icarsinfo Createcarsinfo()
        {
            string className = path + ".carsinfo";
            return (Icarsinfo)Assembly.Load(path).CreateInstance(className);
        }
        public static Imessageinfo Createmessageinfo()
        {
            string className = path + ".messageinfo";
            return (Imessageinfo)Assembly.Load(path).CreateInstance(className);
        }
    }
}
