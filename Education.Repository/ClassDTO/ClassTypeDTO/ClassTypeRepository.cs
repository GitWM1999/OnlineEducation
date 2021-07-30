using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.ClassDTO.ClassTypeDTO
{
    public class ClassTypeRepository:IClassTypeRepository
    {
        DBFactory db = new DBFactory();

        public List<ClassType> GetClassType()
        {
            List<ClassType> ls = db.CRUD().GetClassLists<ClassType>("select * from ClassType");
            return ls;
        }
    }
}
