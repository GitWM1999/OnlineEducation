using AutoMapper;
using Education.DTO.Article;
using Education.Model;
using Education.Repository.ArticleDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.ArticleSer
{
    
    public class ArticleService : IArticleService
    {
        IArticleRepository _article;
        IMapper _mapper;

        public ArticleService(IArticleRepository article,IMapper mapper)
        {
            _article = article;
            _mapper = mapper;
        }
        public int ArticleAdd(ArticleInput article)
        {
            Article article1 = _mapper.Map<Article>(article);

            int i = _article.ArticleAdd(article1);
            return i;
        }

        public int ArticleDel(int ArtId)
        {
            int i = _article.ArticleDel(ArtId);
            return i;
        }

        public int ArticleEdit(ArticleInput art)
        {
            Article article = _mapper.Map<Article>(art);
            int i = _article.ArticleEdit(article);
            return i;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="articleName"></param>
        /// <param name="status"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<ArticleOutput> GetArticleData(string articleName, string status, int page, int limit)
        {
            List<Article> articles = _article.GetArticleData(articleName, status, page, limit);
            var ArticleOutputs = _mapper.Map<List<ArticleOutput>>(articles);
            return ArticleOutputs;
        }
    }
}
