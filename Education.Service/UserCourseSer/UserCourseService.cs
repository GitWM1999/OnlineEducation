using AutoMapper;
using Education.DTO.UserCourse;
using Education.Model;
using Education.Repository.UserCourseDTO;
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
        private IUserCourseRepository _user;

        public UserCourseService(IMapper mapper, IUserCourseRepository user)
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

        public int Delcollect(int userId, int ClassId, int typeId)
        {
            int i = _user.Delcollect(userId, ClassId, typeId);
            return i;
        }

        public List<UserCourseOutput> GetUserCourse(int userId, int typeId)
        {
            List<UserCourse> userCourses = _user.GetUserCourse(userId, typeId);
            var UserCourseOutputs = _mapper.Map<List<UserCourseOutput>>(userCourses);
            return UserCourseOutputs;
        }
    }
}
