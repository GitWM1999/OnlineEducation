using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.UserCourseDTO
{
    public interface IUserCourseRepository
    {
        int AddCollect(int userId, int ClassId,int typeId);

        int AddCar(int userId, int ClassId,int typeId);

      


    }
}
