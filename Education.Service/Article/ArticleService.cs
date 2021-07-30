using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Repository;
using Education.DTO;
using Education.Model;
using AutoMapper;


namespace Education.Service
{
    public class ArticleService:IArticleService
    {
        IArticleRepository _article;
        private IMapper _mapper;
        public ArticleService(IArticleRepository article,IMapper mapper)
        {
            _article = article;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取文章的信息
        /// </summary>
        /// <returns></returns>
        public List<ArticleOutPuts> GetArticles(string title="",int id=0)
        {
            List<CustomerArticle> articles = _article.GetArticles(title,id);
            List<ArticleOutPuts> articleOuts = _mapper.Map<List<ArticleOutPuts>>(articles);
            return articleOuts;
        }


        /// <summary>
        /// 获取分类的信息
        /// </summary>
        /// <returns></returns>
        public List<ArticleTypeOutPut> GetClassTypes(int id=0, int start = 0)
        {
            List<ClassType> classTypes = _article.GetClassTypes(id,start);
            List<ArticleTypeOutPut> typeOutputs = _mapper.Map<List<ArticleTypeOutPut>>(classTypes);
            return typeOutputs;
        }



    }
}
