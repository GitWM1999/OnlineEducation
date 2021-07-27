using AutoMapper;
using Education.DTO.Precinct;
using Education.Model;
using Education.Repository.Prefecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.PrecinctSer
{
    public class PrecinctService : IPrecinctService
    {
        IPrefectureRepository _prefecture;
        IMapper _mapper;

        public PrecinctService(IPrefectureRepository prefecture, IMapper mapper)
        {
            _prefecture = prefecture;
            _mapper = mapper;
        }
        public List<PrecinctOutput> GetPrefectureData(string prefectureName, string status, int page, int limit)
        {
            List<Precinct> precincts = _prefecture.GetPrefectureData(prefectureName, status, page, limit);
            var PrecinctOutputs = _mapper.Map<List<PrecinctOutput>>(precincts);
            return PrecinctOutputs;
        }

        public int PrefectureAdd(PrecinctInput prefecture)
        {
            Precinct precinct = _mapper.Map<Precinct>(prefecture);
            int i = _prefecture.PrefectureAdd(precinct);
            return i;
        }

        public int PrefectureDel(int preId)
        {
            int i = _prefecture.PrefectureDel(preId);
            return i;
        }

        public int PrefectureEdit(PrecinctInput pre)
        {
            Precinct precinct = _mapper.Map<Precinct>(pre);
            int i = _prefecture.PrefectureEdit(precinct);
            return i;
        }
    }
}
