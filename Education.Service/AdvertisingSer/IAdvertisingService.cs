using Education.DTO.Advertsting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Service.AdvertisingSer
{
    public interface IAdvertisingService
    {
        // 获取广告数据
        List<AdvertstingOutput> GetAdvertisingData(string advertisingName, string status, int page, int limit);
        //添加广告
        int AdvertisingAdd(AdvertstingInput advertising);
        //删除广告
        int AdvertisingDel(int AavId);
        //修改广告
        int AdvertisingEdit(AdvertstingInput adv);
    }
}
