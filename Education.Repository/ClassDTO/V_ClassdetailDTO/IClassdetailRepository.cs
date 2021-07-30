using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.ClassDTO.V_ClassdetailDTO
{
    public interface IClassdetailRepository
    {
        List<V_Classdetail> GetClassDetail(int classId);
    }
}
