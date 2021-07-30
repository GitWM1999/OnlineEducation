using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Common;

namespace Education.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        DBFactory db = new DBFactory();

        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <returns></returns>
        public List<CustomerArticle> GetArticles(string title = "", int id = 0)
        {
            string sql = "";

            sql = $"select (select count(*) from UserArticle where UserArticle.aid=CustomerArticle.id ) as num , CustomerArticle.ArticleTitle,customerarticle.ArticleContent,customerarticle.ReleaseTime from CustomerArticle where 1=1";
            if (!string.IsNullOrEmpty(title))
            {
                sql += $" and articletitle like concat('%',@title,'%')";
            }
            if (id != 0)
            {
                sql += $" and Id=@id";
            }
            sql += " limit 5";

            return db.CRUD().GetClassLists<CustomerArticle>(sql, new { @title = title, @id = id });
        }


        /// <summary>
        /// 获取分类的信息
        /// </summary>
        /// <returns></returns>
        public List<ClassType> GetClassTypes(int id = 0, int start = 0)
        {
            string sql = "";
            if (start == 1)
            {
                sql = $"select * from ClassType";
            }
            if (start == 2)
            {
                sql = $"select * from CustomerArticle join ClassType on CustomerArticle.ArticleTypeId=ClassType.Type_Id join userinfo on customerarticle.UserId=userinfo.UserId where 1=1";
                if (id != 0)
                {
                    sql += $" and ClassType.Type_Id=@id";
                }
            }


            return db.CRUD().GetClassLists<ClassType>(sql, new { @id = id });
        }

    }
}
