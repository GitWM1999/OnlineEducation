using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.NavigationDTO
{
    public interface INavigationRepository
    {
        List<Navigation> GetNavigationData(string navigationName, string status, int page, int limit);
        int NavigationAdd(Navigation navigation);

        int NavigationDel(int NavId);

        int NavigationEdit(Navigation nav);
    }
}
