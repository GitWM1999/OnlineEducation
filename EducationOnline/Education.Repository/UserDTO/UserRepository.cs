using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.UserDTO
{
    public class UserRepository : IUserRepository
    {
        DBFactory db = new DBFactory();

        static string result = "";
        public int GetUserId(string username, string pwd)
        {
            List<UserInfo> ls = db.CRUD().GetClassLists<UserInfo>($"select * from UserInfo");

            UserInfo userInfo = ls.First(m => m.UserAccount == username && m.UserPass == pwd);

            result = username;

            return userInfo.UserId;
        }

        public List<UserInfo> GetUserInfo()
        {
            var list = db.CRUD().GetClassLists<UserInfo>($"select UserName, Userimg from userinfo where UserAccount = '{result}'");
            return list;
        }

        public int Login(string username, string pwd)
        {
            
            object j = db.CRUD().ExecuteScalar($"select count(*) from UserInfo where UserAccount='{username}' and UserPass='{pwd}'");
            int i = Convert.ToInt32(j);
            return i;
        }
    }
}
