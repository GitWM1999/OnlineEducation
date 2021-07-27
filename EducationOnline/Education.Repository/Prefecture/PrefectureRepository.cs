using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.Prefecture
{
    public class PrefectureRepository : IPrefectureRepository
    {
        DBFactory db = new DBFactory();
        public List<Precinct> GetPrefectureData(string prefectureName, string status, int page, int limit)
        {
            List<Precinct> ls = db.CRUd().Query<Precinct>("select * from Precinct");
            if (prefectureName != null)
            {
                ls = ls.Where(m => m.PrecinctName.Contains(prefectureName)).ToList();
            }
            if (status != null)
            {
                ls = ls.Where(m => m.PrecinctStatus == Convert.ToInt32(status)).ToList();
            }
            return ls;
        }

        public int PrefectureAdd(Precinct prefecture)
        {
            prefecture.Creator = "lsp";
            prefecture.IsDelete = 1;
            prefecture.CreateTime = DateTime.Now;
            int i = db.CRUd().Execute("insert into Precinct(PrecinctId,PrecinctName,PrecinctDetails,PrecinctJump,PrecinctSort,PrecinctStatus,IsDelete,Creator,CreateTime,Updateor,UpdateTime) values (@PrecinctId,@PrecinctName,@PrecinctDetails,@PrecinctJump,@PrecinctSort,@PrecinctStatus,@IsDelete,@Creator,@CreateTime,@Updateor,@UpdateTime)", prefecture);
            return i;
        }

        public int PrefectureDel(int preId)
        {
            int i = db.CRUd().Execute($"delete from Precinct where PrecinctId={preId}");
            return i;
        }

        public int PrefectureEdit(Precinct pre)
        {
            pre.Updateor = "lsp";
            pre.UpdateTime = DateTime.Now;
            int i = db.CRUd().Execute("update Precinct set PrecinctName=@PrecinctName,PrecinctJump=@PrecinctJump,PrecinctStatus=@PrecinctStatus,PrecinctSort=@PrecinctSort,Updateor=@Updateor,UpdateTime=@UpdateTime where PrecinctId=@PrecinctId", pre);
            return i;
        }
    }
}
