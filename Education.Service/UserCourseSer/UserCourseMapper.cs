using AutoMapper;
using Education.DTO.UserCourse;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.UserCourseSer
{
    public class UserCourseMapper: Profile
    {
        public UserCourseMapper()
        {
            CreateMap<UserCourse, UserCourseOutput>();
            CreateMap<UserCourseInput, UserCourse>();
        }
    }
}
