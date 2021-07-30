
using Education.Common;
using Education.DTO.Advertsting;
using Education.Model;
using Education.Service.AdvertisingSer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    public class AdvertisingController : Controller
    {

        private IAdvertisingService _advertising;

        private IHostingEnvironment _hosting;

        public AdvertisingController(IAdvertisingService advertising, IHostingEnvironment hosting)
        {
            _advertising = advertising;
            _hosting = hosting;

        }

        /// <summary>
        /// 获取广告数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAdvertisingData")]
        
        public IActionResult GetAdvertisingData(string advertisingName, string status, int page, int limit)
        {
            
            List<AdvertstingOutput> ls = _advertising.GetAdvertisingData(advertisingName, status, page, limit);

            int totalcount = ls.Count();
            ls = ls.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new { query = ls, total = totalcount });
        }

        /// <summary>
        /// 添加广告
        /// </summary>
        /// <param name="navigation"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdvertisingAdd")]
        public IActionResult AdvertisingAdd(AdvertstingInput advertising)
        {
            int i = _advertising.AdvertisingAdd(advertising);
            //if (i > 0)
            //{
            //    RedisClient.redisClient.SetStringKey("key4", "value4", TimeSpan.FromHours(8));
            //}
            return Ok(i);
        }
        /// <summary>
        /// 删除广告
        /// </summary>
        /// <param name="NavId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdvertisingDel")]

        public IActionResult AdvertisingDel(int AavId)
        {
            int i = _advertising.AdvertisingDel(AavId);
            return Ok(i);
        }

        /// <summary>
        /// 修改广告
        /// </summary>
        /// <param name="nav"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdvertisingEdit")]

        public IActionResult AdvertisingEdit(AdvertstingInput adv)
        {
            adv.Updateor = "lsp";
            adv.UpdateTime = DateTime.Now;
            int i = _advertising.AdvertisingEdit(adv);
            return Ok(i);
        }
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("PhotoUpload")]
        public string PhotoUpload()
        {

            IFormFile file = Request.Form.Files[0];
            UploadFilesHelper filesHelper = new UploadFilesHelper(_hosting, "img");
            var Url = filesHelper.Main(file);
            return Url;
        }
    }
}
