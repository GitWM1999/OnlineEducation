using Education.Repository.UserCourseDTO;
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
        private IUserCourseRepository _userCourseRepository;

        public UserCourseController(IUserCourseRepository userCourseRepository)
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
    }
}
