using AutoMapper;
using Education.DTO.Navigation;
using Education.Model;
using Education.Repository.NavigationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.NavigationSer
{
    public class NavigationService : INavigationService
    {
        private INavigationRepository _navigation;
        private IMapper _mapper;
        public NavigationService(INavigationRepository navigation,IMapper mapper)
        {
            _navigation = navigation;
            _mapper = mapper;
        }
        public List<NavigationOutput> GetNavigationData(string navigationName, string status, int page, int limit)
        {
            List<Navigation> navigations = _navigation.GetNavigationData(navigationName, status, page, limit);
            var NavigationOutputs = _mapper.Map<List<NavigationOutput>>(navigations);
            return NavigationOutputs;
        }

        public int NavigationAdd(NavigationInput navigation)
        {
            Navigation navigations = _mapper.Map<Navigation>(navigation);
            int i = _navigation.NavigationAdd(navigations);
            return i;
        }

        public int NavigationDel(int NavId)
        {
            int i = _navigation.NavigationDel(NavId);
            return i;
        }

        public int NavigationEdit(NavigationInput nav)
        {
            Navigation navigation = _mapper.Map<Navigation>(nav);
            int i = _navigation.NavigationEdit(navigation);
            return i;
        }
    }
}
