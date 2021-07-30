using Education.DTO.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.NavigationSer
{
    public interface INavigationService
    {
        List<NavigationOutput> GetNavigationData(string navigationName, string status, int page, int limit);
        int NavigationAdd(NavigationInput navigation);

        int NavigationDel(int NavId);

        int NavigationEdit(NavigationInput nav);
    }
}
