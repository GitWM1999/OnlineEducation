using AutoMapper;
using Education.DTO.Class;
using Education.DTO.Video;
using Education.Model;
using Education.Repository.ClassDTO.ClassListDTO;
using Education.Repository.ClassDTO.ClassSecondDTO;
using Education.Repository.ClassDTO.ClassTypeDTO;
using Education.Repository.ClassDTO.V_ClassdetailDTO;
using Education.Repository.VideoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.ClassListSer
{
    public class ClassListService:IClassListService
    {
        private IClassListRepository _classList;

        private IClassTypeRepository _classType;
        private IClassSecondRepository _classSecond;
        private IClassdetailRepository _classdetail;
        private IVideoRepository _video;
        private IMapper _mapper;
        public ClassListService(IClassListRepository classList, IClassTypeRepository classType, IClassSecondRepository classSecond, IClassdetailRepository classdetail, IVideoRepository video,IMapper mapper)
        {
            _classList = classList;
            _classType = classType;
            _classSecond = classSecond;
            _classdetail = classdetail;
            _mapper = mapper;
            _video = video;
        }
        public List<ClassListOutput> GetClassList(int TypeId, int SecondId)
        {
            List<ClassList> classLists = _classList.GetClassList(TypeId, SecondId);
            var ClassListOutputs = _mapper.Map<List<ClassListOutput>>(classLists);
            return ClassListOutputs;
        }

        public List<ClassSecondTypeOutput> GetClassSecondType(int TypeId)
        {

            List<ClassSecondType> classSecondTypes = _classSecond.GetClassSecondType(TypeId);
            var ClassSecondTypeOutputs = _mapper.Map<List<ClassSecondTypeOutput>>(classSecondTypes);
            return ClassSecondTypeOutputs;
        }


            public List<ClassTypeOutput> GetClassType()
            {
            List<ClassType> classTypes = _classType.GetClassType();
            var ClassTypeOutputs = _mapper.Map<List<ClassTypeOutput>>(classTypes);
            return ClassTypeOutputs;
            }
        public List<ClassListOutput> GetClassSecond(int TypeId)
        {
            List<ClassList> classLists = _classList.GetClassSecondType(TypeId);
            var ClassListOutputs = _mapper.Map<List<ClassListOutput>>(classLists);
            return ClassListOutputs;
        }
        public List<V_ClassdetailOutput> GetClassDetail(int classId)
        {
            List<V_Classdetail> v_Classdetails = _classdetail.GetClassDetail(classId);
            var ClassdetailOutputs = _mapper.Map<List<V_ClassdetailOutput>>(v_Classdetails);
            return ClassdetailOutputs;
        }

        public List<VideoOutput> GetFreeVideo(int TypeId, int SecondId,int VideoId)
        {
            List<Video> videos = _video.GetFreeVideo(TypeId, SecondId, VideoId);
            var VideoOutputs = _mapper.Map<List<VideoOutput>>(videos);
            return VideoOutputs;


        }

        public int CollectEdit(int ClassId)
        {
            int i = _classList.CollectEdit(ClassId);
            return i;
        }
    }
}
