using AutoMapper;
using Education.DTO.Navigation;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.NavigationSer
{
    public class NavigationMapper: Profile
    {
        public NavigationMapper()
        {
            CreateMap<Navigation, NavigationOutput>();
            CreateMap<NavigationInput, Navigation>();
        }
    }
}
