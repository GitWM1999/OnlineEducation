﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.UserCourseSer
{
    public interface IUserCourseService
    {
        int AddCollect(int userId, int ClassId,int typeId);

        int AddCar(int userId, int ClassId, int typeId);
    }
}
