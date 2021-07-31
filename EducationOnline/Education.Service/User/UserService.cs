using AutoMapper;
using Education.DTO.Userinfo;
using Education.Model;
using Education.Repository.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public int GetUserId(string username, string pwd)
        {
            int i = _userRepository.GetUserId(username, pwd);
            return i;
        }

        public List<UserinfoOutput> GetUserInfo()
        {
            List<UserInfo> navigations = _userRepository.GetUserInfo();
            var UserinfoOutputs = _mapper.Map<List<UserinfoOutput>>(navigations);
            return UserinfoOutputs;
        }

        public int Login(string username, string pwd)
        {
            int i = _userRepository.Login(username, pwd);
            return i;
        }
    }
}
