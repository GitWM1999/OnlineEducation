using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.UserCourseDTO
{
    public class UserCourseRepository : IUserCourseRepository
    {
        DBFactory db = new DBFactory();
        
        public int AddCar(int userId, int ClassId,int typeId)
        {
            List<UserInfo> ls = db.CRUD().GetClassLists<UserInfo>("select * from UserInfo");

            UserInfo info = ls.First(m => m.UserId == userId);
            UserCourse user = new UserCourse();
            //判断直播录播
            if (typeId == 0)
            {
                user.Lcourse = 1;
            }
            if (typeId == 1)
            {
                user.Vcourse = 1;
            }
            user.UserId = userId;
            user.CourseId = ClassId;
            user.Car = 1;
            user.Creator = info.UserAccount;
            user.CreateTime = DateTime.Now;

            int i = db.CRUD().Execute("insert into UserCourse(UserId,CourseId,Car,Creator,CreateTime,Lcourse,Vcourse) values(@UserId,@CourseId,@Car,@Creator,@CreateTime,@Lcourse,@Vcourse)", user);
            return i;
        }

        public int AddCollect(int userId, int ClassId, int typeId)
        {
            List<UserInfo> ls = db.CRUD().GetClassLists<UserInfo>("select * from UserInfo");

            UserInfo info = ls.First(m => m.UserId == userId);
            UserCourse user = new UserCourse();
            //判断直播录播
            if (typeId == 0)
            {
                user.Lcourse = 1;
            }
            if (typeId == 1)
            {
                user.Vcourse = 1;
            }
            user.UserId = userId;
            user.CourseId = ClassId;
            user.Collect = 1;
            user.Creator = info.UserAccount;
            user.CreateTime = DateTime.Now;

            int i = db.CRUD().Execute("insert into UserCourse(UserId,CourseId,Collect,Creator,CreateTime,Lcourse,Vcourse) values(@UserId,@CourseId,@Collect,@Creator,@CreateTime,@Lcourse,@Vcourse)", user);
            return i;
        }

        public int Delcollect(int userId, int ClassId, int typeId)
        {
            List<UserCourse> ls = db.CRUD().GetClassLists<UserCourse>("select * from UserCourse");
            UserCourse course = new UserCourse();
            int i = 0;
            if (typeId == 0)
            {
                 course = ls.First(m => m.UserId == userId && m.Lcourse == 1&&m.CourseId==ClassId);
                i = db.CRUD().Execute("delete from UserCourse where UserId=@UserId  and CourseId=@CourseId and Lcourse=@Lcourse",course);
                
            }
            if (typeId == 1)
            {
                 course = ls.First(m => m.UserId == userId && m.Vcourse == 1&&m.CourseId==ClassId);
                i = db.CRUD().Execute("delete from UserCourse where UserId=@UserId and CourseId=@CourseId and Vcourse=@Vcourse", course);
            }
            return i;


        }

        public List<UserCourse> GetUserCourse(int userId, int typeId)
        {
            List<UserCourse> ls = db.CRUD().GetClassLists<UserCourse>("select * from UserCourse");
            if (typeId == 0)
            {
                ls = ls.Where(m => m.UserId == userId && m.Lcourse == 1).ToList();
            }
            if (typeId == 1)
            {
                ls = ls.Where(m => m.UserId == userId && m.Vcourse == 1).ToList();
            }
            return ls;
        }
    }
}
