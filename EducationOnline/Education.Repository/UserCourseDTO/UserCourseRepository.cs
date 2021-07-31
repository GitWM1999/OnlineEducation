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

       
    }
}
