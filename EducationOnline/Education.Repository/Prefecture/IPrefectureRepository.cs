using Education.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;

namespace Education.Repository.Prefecture
{
    public interface IPrefectureRepository
    {
        List<Precinct> GetPrefectureData(string prefectureName, string status, int page, int limit);
        int PrefectureAdd(Precinct prefecture);
        int PrefectureDel(int preId);

        int PrefectureEdit(Precinct pre);

    }
}
