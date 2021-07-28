using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.ClassDTO.ClassListDTO
{
    public class ClassListRepository : IClassListRepository
    {
        DBFactory db = new DBFactory();
        public List<ClassList> GetClassList(int TypeId, int SecondId)
        {
            List<ClassList> ls = db.CRUD().GetClassLists<ClassList>("select * from ClassList where Class_Price=0");
            if (TypeId != 0)
            {
                ls = ls.Where(m => m.Class_ClassType == TypeId).ToList();
            }
            if (SecondId != 0)
            {
                ls = ls.Where(m => m.Class_Second == SecondId).ToList();
            }

            return ls;
        }
    }
}
