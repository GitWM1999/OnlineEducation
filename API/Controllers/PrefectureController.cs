using Education.Common;
using Education.DTO.Precinct;
using Education.Model;
using Education.Repository.Prefecture;
using Education.Service.PrecinctSer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    public class PrefectureController : Controller
    {
        private  IPrecinctService _prefecture;
        public PrefectureController(IPrecinctService prefecture)
        {
            _prefecture = prefecture;
        }

        /// <summary>
        /// 获取专区数据
        /// </summary>
        /// <param name="prefectureName"></param>
        /// <param name="status"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        /// 


        [HttpGet]
        [Route("GetPrefectureData")]
        public IActionResult GetPrefectureData(string prefectureName, string status, int page, int limit)
        {
            List<PrecinctOutput> ls = _prefecture.GetPrefectureData(prefectureName, status, page, limit);
            int totalcount = ls.Count();
            ls = ls.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new { query = ls, total = totalcount });
        }

        /// <summary>
        /// 添加专区
        /// </summary>
        /// <param name="navigation"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PrefectureAdd")]
        public IActionResult PrefectureAdd(PrecinctInput prefecture)
        {
            int i = _prefecture.PrefectureAdd(prefecture);
            return Ok(i);
        }

        /// <summary>
        /// 删除专区
        /// </summary>
        /// <param name="preId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PrefectureDel")]

        public IActionResult PrefectureDel(int preId)
        {
            int i = _prefecture.PrefectureDel(preId);
            return Ok(i);
        }


        /// <summary>
        /// 修改专区
        /// </summary>
        /// <param name="nav"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PrefectureEdit")]

        public IActionResult PrefectureEdit(PrecinctInput pre)
        {
            int i = _prefecture.PrefectureEdit(pre);
            return Ok(i);
        }
    }
}
