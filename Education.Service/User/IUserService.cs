using Education.DTO.Userinfo;
using Education.Repository.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service
{
    public interface IUserService
    {
        
        int Login(string username, string pwd);

        int GetUserId(string username, string pwd);

        List<UserinfoOutput> GetUserInfo();
    }
}
