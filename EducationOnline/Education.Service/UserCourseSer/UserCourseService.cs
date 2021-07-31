using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.UserCourseSer
{
    public class UserCourseService : IUserCourseService
    {
        private IMapper _mapper;
        private IUserCourseService _user;

        public UserCourseService(IMapper mapper,IUserCourseService user)
        {
            _mapper = mapper;
            _user = user;
        }

        public int AddCar(int userId, int ClassId, int typeId)
        {
            int i = _user.AddCar(userId, ClassId, typeId);
            return i;
        }


        public int AddCollect(int userId, int ClassId, int typeId)
        {
            int i = _user.AddCollect(userId, ClassId, typeId);
            return i;
        }
    }
}
