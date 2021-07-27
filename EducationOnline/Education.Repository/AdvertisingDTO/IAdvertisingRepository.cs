using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.AdvertisingDTO
{
    public interface IAdvertisingRepository
    {
        // 获取广告数据
        List<Advertising> GetAdvertisingData(string advertisingName, string status, int page, int limit);
        //添加广告
        int AdvertisingAdd(Advertising advertising);
        //删除广告
        int AdvertisingDel(int AavId);
        //修改广告
        int AdvertisingEdit(Advertising adv);


    }
}
