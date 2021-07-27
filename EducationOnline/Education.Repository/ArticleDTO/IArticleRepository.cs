using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.ArticleDTO
{
    public interface IArticleRepository
    {
        //获取文章数据
        List<Article> GetArticleData(string articleName, string status, int page, int limit);

        //添加文章
        int ArticleAdd(Article article);

        //文章删除
        int ArticleDel(int ArtId);

        //文章修改

        int ArticleEdit(Article art);
    }
}
