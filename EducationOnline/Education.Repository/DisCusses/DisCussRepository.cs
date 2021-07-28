using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;
using Education.Common;

namespace Education.Repository
{
    public class DisCussRepository : IDisCussRepository
    {

        DBFactory db = new DBFactory();


        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="userDisCuss"></param>
        /// <returns></returns>
        public int AddDisCuss(UserDisCuss userDisCuss)
        {
            string sql = $"insert into UserDisCuss values (null,@userid,@discussid,@content)";
            return db.CRUD().Execute(sql, new { @userid = userDisCuss.UserId, @discussid = userDisCuss.DisCussUserId, @content = userDisCuss.CommentContent });

        }


        /// <summary>
        /// 获取所有评论
        /// </summary>
        /// <returns></returns>
        public List<DisCuss> GetDisCusses(int id=0)
        {
            string sql = $"select * from discuss join userinfo on discuss.uid=userinfo.UserId";
            if (id != 0)
            {
                sql += $" and DisCuss.AId=@id";
            }
            return db.CRUD().GetClassLists<DisCuss>(sql,new { @id=id});
        }



    }
}
