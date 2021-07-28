using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Service;
using Education.DTO;
using Education.Common;

namespace Education.API.Controllers
{
   
    [ApiController]
    public class DisCussController : ControllerBase
    {
        private IDiscussService _discussService;
        public DisCussController(IDiscussService discussService)
        {
            _discussService = discussService;
        }


        /// <summary>
        /// 获取所有评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetDisCuss")]
        public ResultData GetDisCuss(int id=0)
        {
            List<DisCussOutPut> disCussOutPuts = _discussService.GetDisCusses(id);
            return APIResultHelper.Success(disCussOutPuts);
        }


        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="disCussInPut"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddDisCuss")]
        public ResultData AddDisCuss(UserDisCussInPut disCussInPut)
        {
            int i = _discussService.AddDisCuss(disCussInPut);
            return APIResultHelper.Success(i);
        }




    }
}
