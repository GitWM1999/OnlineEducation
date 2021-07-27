using Education.DTO.Class;
using Education.DTO.Video;
using Education.Model;
using Education.Service.ClassListSer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    public class FreeclassesController : Controller
    {
        private IClassListService _classListService;

        public FreeclassesController (IClassListService classListService)
        {
            _classListService = classListService;
        }
        /// <summary>
        /// 获取课程类型
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("GetClassType")]
        public IActionResult GetClassType()
        {
            List<ClassTypeOutput> ls = _classListService.GetClassType();
            return Ok(ls);
        }
        /// <summary>
        /// 获取课程二级类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClassSecondType")]
        public IActionResult GetClassSecondType(int TypeId)
       {

            List<ClassSecondTypeOutput> ls = _classListService.GetClassSecondType(TypeId);
            return Ok(ls);
        }
        /// <summary>
        /// 获取免费课程
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClassList")]
        public IActionResult GetClassList(int TypeId,int SecondId)
        {
            List<ClassListOutput> ls = _classListService.GetClassList(TypeId, SecondId);
            return Ok(ls);
        }
        /// <summary>
        /// 免费课程详情
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClassDetail")]
        public IActionResult GetClassDetail(int classId)
        {
            List<V_ClassdetailOutput> ls = _classListService.GetClassDetail(classId);
            return Ok(ls);
        }

        [HttpGet]
        [Route("GetFreeVideo")]

        public IActionResult GetFreeVideo(int TypeId,int SecondId,int VideoId)
        {
            List<VideoOutput> ls = _classListService.GetFreeVideo(TypeId, SecondId,VideoId);
            var query = from s in ls
                        select new
                        {
                            VideoId = s.VideoId,
                            Teacher_Id = s.Teacher_Id,
                            VideoImg = s.VideoImg,
                            CourseTitle = s.CourseTitle,
                            CourseDescription = s.CourseDescription,
                            BeginTime = s.BeginTime,
                            EndTime = s.EndTime,
                            Type_Id = s.Type_Id,
                            VideoShowModel = s.VideoShowModel,
                            VideoTrueBeginTime = s.VideoTrueBeginTime,
                            StrVideoTrueBeginTime=s.VideoTrueBeginTime.ToString("yyyy-MM-dd HH:mm"),
                            VideoTrueEndTime = s.VideoTrueEndTime,
                            VideoState = s.VideoState,
                            CoursePrice = s.CoursePrice,
                            Appointment = s.VideoTrueBeginTime > DateTime.Now ? 1 : 0,
                            DistanceTime = (s.VideoTrueBeginTime - DateTime.Now).TotalMilliseconds




                        };
            return Ok(query);
        }


    }
}
