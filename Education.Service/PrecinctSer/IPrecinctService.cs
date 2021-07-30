using Education.DTO.Precinct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.PrecinctSer
{
    public interface IPrecinctService
    {
        List<PrecinctOutput> GetPrefectureData(string prefectureName, string status, int page, int limit);
        int PrefectureAdd(PrecinctInput prefecture);
        int PrefectureDel(int preId);

        int PrefectureEdit(PrecinctInput pre);
    }
}
