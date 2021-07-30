using AutoMapper;
using Education.DTO.Precinct;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.PrecinctSer
{
    public class PrecinctMapper: Profile
    {
        public PrecinctMapper()
        {
            CreateMap<Precinct, PrecinctOutput>();
            CreateMap<PrecinctInput, Precinct>();
        }
    }
}
