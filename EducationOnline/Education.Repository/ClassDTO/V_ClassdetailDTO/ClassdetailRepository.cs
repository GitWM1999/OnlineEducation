using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.ClassDTO.V_ClassdetailDTO
{
    public class ClassdetailRepository : IClassdetailRepository
    {
        DBFactory db = new DBFactory();
        public List<V_Classdetail> GetClassDetail(int classId)
        {
            List<V_Classdetail> ls = db.CRUD().GetClassLists<V_Classdetail>($"select * from V_Classdetail where Class_Id = {classId}");
            return ls;
        }
    }
}
