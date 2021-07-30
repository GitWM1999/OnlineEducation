using Education.Common;
using Education.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using Education.Service.NavigationSer;
using Education.DTO.Navigation;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    public class NavigationController : Controller
    {

        private INavigationService _navigation;
        Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public NavigationController(INavigationService navigation)
        {
            _navigation = navigation;
        }

        /// <summary>
        /// 获取导航数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetNavigationData")]
        
        public IActionResult GetNavigationData(string navigationName, string status, int page, int limit)
        {

            List<NavigationOutput> ls = _navigation.GetNavigationData(navigationName, status, page, limit);
            int totalcount = ls.Count();
            if (page != 0 && limit != 0)
            {
                
                ls = ls.Skip((page - 1) * limit).Take(limit).ToList();
            }
            
            return Ok(new { query = ls, total = totalcount });
        }

        /// <summary>
        /// 添加导航
        /// </summary>
        /// <param name="navigation"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("NavigationAdd")]
        public IActionResult NavigationAdd(NavigationInput navigation)
        {
            navigation.Creator = "lsp";
            navigation.CreateTime = DateTime.Now;
            navigation.IsDelete = 1;
            int i = _navigation.NavigationAdd(navigation);
            //if (i > 0)
            //{
            //    RedisClient.redisClient.SetStringKey("key4", "value4", TimeSpan.FromHours(8));

            //}
            return Ok(i);
        }
        /// <summary>
        /// 删除导航
        /// </summary>
        /// <param name="NavId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("NavigationDel")]

        public IActionResult NavigationDel(int NavId)
        {
            int i = _navigation.NavigationDel(NavId);
            return Ok(i);
        }

        /// <summary>
        /// 修改导航
        /// </summary>
        /// <param name="nav"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("NavigationEdit")]

        public IActionResult NavigationEdit(NavigationInput nav)
        {
            nav.Updateor = "lsp";
            nav.UpdateTime = DateTime.Now;
            int i = _navigation.NavigationEdit(nav);
            return Ok(i);
        }
    }
}
