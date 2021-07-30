using AutoMapper;
using Education.DTO.Class;
using Education.DTO.Video;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.ClassListSer
{
    public class ClassListMapper: Profile
    {
        public ClassListMapper()
        {
            CreateMap<ClassList, ClassListOutput>();
            CreateMap<ClassListInput, ClassList>();
            CreateMap<Video, VideoOutput>();
            CreateMap<ClassType, ClassTypeOutput>();
            CreateMap<ClassSecondType, ClassSecondTypeOutput>();
            CreateMap<V_Classdetail, V_ClassdetailOutput>();
        }
    }
}
