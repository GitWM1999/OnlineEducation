using Education.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Repository;
using Education.Model;
using AutoMapper;

namespace Education.Service
{
    public class DisCussService : IDiscussService
    {
        private IDisCussRepository _disCussRepository;
        private IMapper _mapper;
        public DisCussService(IDisCussRepository disCussRepository,IMapper mapper)
        {
            _disCussRepository = disCussRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="inPut"></param>
        /// <returns></returns>
        public int AddDisCuss(UserDisCussInPut inPut)
        {
            UserDisCuss userDisCuss = _mapper.Map<UserDisCuss>(inPut);
            int i = _disCussRepository.AddDisCuss(userDisCuss);
            return i;
        }


        /// <summary>
        /// 获取所有评论
        /// </summary>
        /// <returns></returns>
        public List<DisCussOutPut> GetDisCusses(int id=0)
        {
            List<DisCuss> disCusses = _disCussRepository.GetDisCusses(id);
            List<DisCussOutPut> disCussOutPuts = _mapper.Map<List<DisCussOutPut>>(disCusses);
            return disCussOutPuts;
        }


    }
}
