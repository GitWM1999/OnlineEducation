using Education.DTO.Class;
using Education.DTO.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.ClassListSer
{
    public interface IClassListService
    {
        List<ClassListOutput> GetClassList(int TypeId, int SecondId);
        List<ClassSecondTypeOutput> GetClassSecondType(int TypeId);
        List<ClassTypeOutput> GetClassType();
        List<V_ClassdetailOutput> GetClassDetail(int classId);
        List<VideoOutput> GetFreeVideo(int TypeId, int SecondId,int VideoId);
    }
}
