using Education.DTO.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.ArticleSer
{
    public interface IArticleService
    {
        //获取文章数据
        List<ArticleOutput> GetArticleData(string articleName, string status, int page, int limit);

        //添加文章
        int ArticleAdd(ArticleInput article);

        //文章删除
        int ArticleDel(int ArtId);

        //文章修改

        int ArticleEdit(ArticleInput art);
    }
}
