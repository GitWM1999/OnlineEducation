using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.NavigationDTO
{
    public class NavigationRepository : INavigationRepository
    {
        DBFactory db = new DBFactory();
        public List<Navigation> GetNavigationData(string navigationName, string status, int page, int limit)
        {
            List<Navigation> ls = db.CRUd().Query<Navigation>("select * from navigation");
            if (navigationName != null)
            {
                ls = ls.Where(m => m.NavigationTitle.Contains(navigationName)).ToList();
            }
            if (status != null)
            {
                ls = ls.Where(m => m.NavigationStatus == Convert.ToInt32(status)).ToList();
            }
            return ls;
        }

        public int NavigationAdd(Navigation navigation)
        {
            navigation.Creator = "lsp";
            navigation.CreateTime = DateTime.Now;
            navigation.IsDelete = 1;
            int i = db.CRUd().Execute("insert into Navigation(NavigationId,NavigationTitle,NavigationLink,NavigationJump,NavigationStatus,NavigationSort,IsDelete,Creator,CreateTime,Updateor,UpdateTime) values (@NavigationId,@NavigationTitle,@NavigationLink,@NavigationJump,@NavigationStatus,@NavigationSort,@IsDelete,@Creator,@CreateTime,@Updateor,@UpdateTime)", navigation);
            return i;
        }

        public int NavigationDel(int NavId)
        {
            int i = db.CRUd().Execute($"delete from Navigation where NavigationId={NavId}");
            return i;
        }

        public int NavigationEdit(Navigation nav)
        {
            nav.Updateor = "lsp";
            nav.UpdateTime = DateTime.Now;
            int i = db.CRUd().Execute("update Navigation set NavigationTitle=@NavigationTitle,NavigationJump=@NavigationJump,NavigationStatus=@NavigationStatus,NavigationSort=@NavigationSort,Updateor=@Updateor,UpdateTime=@UpdateTime where NavigationId=@NavigationId", nav);
            return i;
        }
    }
}
