using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.UserDTO
{
    public interface IUserRepository
    {
        int Login(string username, string pwd);

        int GetUserId(string username, string pwd);

        List<UserInfo> GetUserInfo();
    }
}
