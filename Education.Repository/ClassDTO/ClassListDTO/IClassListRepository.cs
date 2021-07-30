using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.ClassDTO.ClassListDTO
{
    public interface IClassListRepository
    {
        List<ClassList> GetClassList(int TypeId, int SecondId);

        int CollectEdit(int ClassId);

        List<ClassList> GetClassSecondType(int TypeId);

    }
}
