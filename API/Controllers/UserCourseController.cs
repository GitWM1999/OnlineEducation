using Education.DTO.UserCourse;
using Education.Repository.UserCourseDTO;
using Education.Service.UserCourseSer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    public class UserCourseController : Controller
    {
        private IUserCourseService _userCourseRepository;

        public UserCourseController(IUserCourseService userCourseRepository)
        {
            _userCourseRepository = userCourseRepository;
        }
        
        [Route("AddCar")]
        [HttpPost]
        public IActionResult AddCar(int userId,int classId,int typeId)
        {
            int i = _userCourseRepository.AddCar(userId, classId, typeId);
            return Ok(i);
        }

        [Route("AddCollect")]
        [HttpPost]
        public IActionResult AddCollect(int userId, int classId, int typeId)
        {
            int i = _userCourseRepository.AddCollect(userId, classId, typeId);
            return Ok(i);
        }

        [Route("Delcollect")]
        [HttpPost]

        public IActionResult Delcollect(int userId, int classId, int typeId)
        {
            int i = _userCourseRepository.Delcollect(userId, classId, typeId);
            return Ok(i);
        }

        [Route("GetUserCourse")]
        [HttpGet]

        public IActionResult GetUserCourse(int userId, int typeId)
        {
            List<UserCourseOutput> ls = _userCourseRepository.GetUserCourse(userId, typeId);
            return Ok(ls);
        }
    }
}
