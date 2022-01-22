using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Iuserinfo
    {
        bool validUser(string username, string password);
        int modifynews(string title, string author, string datetime, string content);
         int modifcars(string title, string type, int price, string content, string address);
         int modifytype(string type);
         int deletetype(string type);
         int modifycarnews(string title, string author, DateTime time, string content, string address);
         int Addreview(string content, int messageid);
    }
}
