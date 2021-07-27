using AutoMapper;
using Education.Common;
using Education.DTO.Article;
using Education.Model;
using Education.Service.ArticleSer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private IArticleService _article;
        private IMapper _mapper;
        public ArticleController(IArticleService article, IMapper mapper)
        {
            _article = article;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取文章数据
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("GetArticleData")]
        public IActionResult GetArticleData(string articleName, string status, int page, int limit)
        {

            List<ArticleOutput> ls = _article.GetArticleData(articleName, status, page, limit);
            //var advertisting = _mapper.Map<List<ArticleDTO>>(ls);
            int totalcount = ls.Count();
            ls = ls.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new { query = ls, total = totalcount });
        }
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ArticleAdd")]
        public IActionResult ArticleAdd(ArticleInput article)
        {
            int i = _article.ArticleAdd(article);
            //if (i > 0)
            //{
            //    RedisClient.redisClient.SetStringKey("key4", "value4", TimeSpan.FromHours(8));
            //}
            return Ok(i);
        }
        /// <summary>
        /// 文章删除
        /// </summary>
        /// <param name="ArtId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ArticleDel")]

        public IActionResult ArticleDel(int ArtId)
        {
            int i = _article.ArticleDel(ArtId);
            return Ok(i);
        }
        /// <summary>
        /// 文章修改
        /// </summary>
        /// <param name="art"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ArticleEdit")]

        public IActionResult ArticleEdit(ArticleInput art)
        {
            int i = _article.ArticleEdit(art);
            return Ok(i);
        }
    }
}
