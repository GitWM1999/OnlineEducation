using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.ArticleDTO
{
    public class ArticleRepository : IArticleRepository
    {
        DBFactory db = new DBFactory();
        public int ArticleAdd(Article article)
        {
            article.Creator = "lsp";
            article.IsDelete = 1;
            article.CreateTime = DateTime.Now;
            int i = db.CRUD().Execute("insert into Article(ArticleId,ArticleName,ArticleSort,ArticleStatus,ArticleDetails,IsDelete,Creator,CreateTime,Updateor,UpdateTime) values (@ArticleId,@ArticleName,@ArticleSort,@ArticleStatus,@ArticleDetails,@IsDelete,@Creator,@CreateTime,@Updateor,@UpdateTime)", article);
            return i;
        }

        public int ArticleDel(int ArtId)
        {
            int i = db.CRUD().Execute($"delete from Article where ArticleId={ArtId}");
            return i;
        }

        public int ArticleEdit(Article art)
        {
            art.Updateor = "lsp";
            art.UpdateTime = DateTime.Now;
            int i = db.CRUD().Execute("update Article set  ArticleName=@ArticleName,ArticleSort=@ArticleSort,ArticleStatus=@ArticleStatus,ArticleDetails=@ArticleDetails,Updateor=@Updateor,UpdateTime=@UpdateTime where ArticleId=@ArticleId", art);
            return i;
        }

        public List<Article> GetArticleData(string articleName, string status, int page, int limit)
        {
            
            List<Article> ls = db.CRUD().GetClassLists<Article>("select * from Article");
            //var advertisting = _mapper.Map<List<ArticleDTO>>(ls);
            if (articleName != null)
            {
                ls = ls.Where(m => m.ArticleName.Contains(articleName)).ToList();
            }
            if (status != null)
            {
                ls = ls.Where(m => m.ArticleStatus == Convert.ToInt32(status)).ToList();
            }

            return ls;
        }
    }
}
