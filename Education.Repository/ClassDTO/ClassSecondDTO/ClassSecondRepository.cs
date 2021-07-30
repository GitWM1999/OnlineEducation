using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.ClassDTO.ClassSecondDTO
{
    public class ClassSecondRepository : IClassSecondRepository
    {
        DBFactory db = new DBFactory();
        public List<ClassSecondType> GetClassSecondType(int TypeId)
        {

            List<ClassSecondType> ls = db.CRUD().GetClassLists<ClassSecondType>("select * from ClassSecondType");
            if (TypeId != 0)
            {
                ls = ls.Where(m => m.Class_ClassType == TypeId).ToList();
            }
            return ls;
        }
    }
}
