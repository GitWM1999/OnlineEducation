using AutoMapper;
using Education.DTO.Advertsting;
using Education.Model;
using Education.Repository.AdvertisingDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.AdvertisingSer
{
    public class AdvertisingService : IAdvertisingService
    {
        IAdvertisingRepository _advertising;
        private IMapper _mapper;

        public AdvertisingService(IAdvertisingRepository advertising,IMapper mapper)
        {
            _advertising = advertising;
            _mapper = mapper;
        }
        public int AdvertisingAdd(AdvertstingInput advertising)
        {
            Advertising list = _mapper.Map<Advertising>(advertising);
            int i = _advertising.AdvertisingAdd(list);
            return i;
        }

        public int AdvertisingDel(int AavId)
        {
            int i = _advertising.AdvertisingDel(AavId);
            return i;
        }

        public int AdvertisingEdit(AdvertstingInput adv)
        {
            Advertising list = _mapper.Map<Advertising>(adv);
            int i = _advertising.AdvertisingEdit(list);
            return i;
        }

        public List<AdvertstingOutput> GetAdvertisingData(string advertisingName, string status, int page, int limit)
        {
            List<Advertising> advertisings = _advertising.GetAdvertisingData( advertisingName,status,page,limit);
            List<AdvertstingOutput> advertstingOutputs = _mapper.Map<List<AdvertstingOutput>>(advertisings);
            return advertstingOutputs;
        }
    }
}
