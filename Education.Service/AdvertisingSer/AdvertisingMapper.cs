using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;
using Education.DTO.Advertsting;

namespace Education.Service.AdvertisingSer
{
    public class AdvertisingMapper:Profile
    {
        public AdvertisingMapper()
        {
            CreateMap<AdvertstingInput,Advertising>();

            CreateMap<Advertising, AdvertstingOutput>();
        }
    }
}
