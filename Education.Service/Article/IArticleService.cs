using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.DTO;


namespace Education.Service
{
    public interface IArticleService
    {
        //获取文章信息
        List<ArticleOutPuts> GetArticles(string title = "", int id = 0);

        //获取分类
        List<ArticleTypeOutPut> GetClassTypes(int id = 0, int start = 0);

    }
}
