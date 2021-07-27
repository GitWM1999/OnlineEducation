using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.ClassDTO.ClassSecondDTO
{
    public interface IClassSecondRepository
    {
        List<ClassSecondType> GetClassSecondType(int TypeId);
    }
}
