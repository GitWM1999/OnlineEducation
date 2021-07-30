using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Education.Model;
using Education.DTO;

namespace Education.Service
{
    public class ArticleMapper:Profile
    {
        public ArticleMapper()
        {
            CreateMap<CustomerArticle, ArticleOutPuts>()
               .ForMember(d => d.OutPutId, m => m.MapFrom(m => m.Id))
               .ForMember(d => d.OutPutArticleTitle, m => m.MapFrom(m => m.ArticleTitle))
               .ForMember(d => d.OutPutArticleContent, m => m.MapFrom(m => m.ArticleContent))
               .ForMember(d => d.OutPutReleaseTime, m => m.MapFrom(m => m.ReleaseTime))
               .ForMember(d => d.OutPutUserPhone, m => m.MapFrom(m => m.UserPhone))
               .ForMember(d => d.OutPutNum, m => m.MapFrom(m => m.Num))
               .ForMember(d => d.OutPutReleaseTimes, m => m.MapFrom(m => m.ReleaseTimes));
            

            CreateMap<ClassType, ArticleTypeOutPut>()
                 .ForMember(d => d.OutPutId, m => m.MapFrom(m => m.Id))
                .ForMember(d => d.OutPutArticleTitle, m => m.MapFrom(m => m.ArticleTitle))
                .ForMember(d => d.OutPutArticleContent, m => m.MapFrom(m => m.ArticleContent))
                .ForMember(d => d.OutPutReleaseTime, m => m.MapFrom(m => m.ReleaseTime))
                .ForMember(d => d.OutPutUserPhone, m => m.MapFrom(m => m.UserPhone));

        }

    }
}
