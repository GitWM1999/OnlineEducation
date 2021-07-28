using AutoMapper;
using Education.DTO;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.ArticleSer
{
    public class ArticleMapper: Profile
    {
        public ArticleMapper()
        {
            CreateMap<Article, ArticleOutput>();
            CreateMap<ArticleInput, Article>();
        }
    }
}
