using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Service;
using Education.Common;
using Education.DTO;

namespace Education.API.Controllers
{
    
    [ApiController]
    public class LearnArticleController : ControllerBase
    {
        private IArticleService _articleService;
        public LearnArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetArticle")]
        public ResultData GetArticle(string title = "", int id = 0)
        {
            List<ArticleOutPuts> outputArticle = _articleService.GetArticles(title, id);
            return APIResultHelper.Success(outputArticle);
        }


        /// <summary>
        /// 获取分类的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetClassType")]
        public ResultData GetClassType(int id = 0, int start = 0)
        {
            List<ArticleTypeOutPut> typeOutputs = _articleService.GetClassTypes(id, start);
            return APIResultHelper.Success(typeOutputs);
        }




    }
}
