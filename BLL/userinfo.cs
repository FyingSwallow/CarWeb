using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DALFactory;
namespace BLL
{
    public class userinfo
    {
        private static readonly Iuserinfo user = DataAccess.Createuserinfo();
        public bool validUser(string username, string password)
        {
            return user.validUser(username, password);
        }
        public int modifynews(string title, string author, string datetime, string content)
        {
            return user.modifynews(title, author, datetime, content);
        }
        public int modifcars(string title, string type, int price, string content, string address)
        {
            return user.modifcars(title, type, price, content, address);
        }
        public int modifytype(string type)
        {
            return user.modifytype(type);
        }
        public int deletetype(string type)
        {
            return user.deletetype(type);
        }
        public int modifycarnews(string title, string author, DateTime time, string content, string address)
        {
            return user.modifycarnews(title, author, time, content, address);
        }
        public int Addreview(string content, int messageid)
        {
            return user.Addreview(content, messageid);
        }
    }
}
