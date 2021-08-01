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

        public int CollectEdit(int ClassId)
        {
            int i = 0;

            List<ClassList> ls = db.CRUD().GetClassLists<ClassList>("select * from ClassList");
            ClassList classList = ls.First(m => m.Class_Id == ClassId);

            if (classList.Class_Collect == 0)
            {
                i = db.CRUD().Execute("update  ClassList set Class_Collect=1 where Class_Id=@Class_Id", classList);
            }
            if (classList.Class_Collect == 1)
            {
                i = db.CRUD().Execute("update  ClassList set Class_Collect=0 where Class_Id=@Class_Id", classList);
            }
            return i;
        }

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


        public List<ClassList> GetClassSecondType(int TypeId)
        {
            List<ClassList> ls = db.CRUD().GetClassLists<ClassList>("select * from ClassList");
            ls = ls.Where(m => m.Class_Second == TypeId).ToList();
            return ls;
        }

       

        public List<ClassList> GetSystemClass(int TypeId, int SecondId)
        {
            List<ClassList> ls = db.CRUD().GetClassLists<ClassList>("select * from ClassList where Class_Price!=0");
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
