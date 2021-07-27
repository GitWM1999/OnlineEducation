using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.AdvertisingDTO
{
    public class AdvertisingRepository : IAdvertisingRepository
    {
        DBFactory db = new DBFactory();
        public int AdvertisingAdd(Advertising advertising)
        {
            advertising.Creator = "lsp";
            advertising.IsDelete = 1;
            advertising.CreateTime = DateTime.Now;
            int i = db.CRUd().Execute("insert into Advertising(AdvertisingId,AdvertisingPicture,AdvertisingTitle,AdvertisingLink,AdvertisingJump,AdvertisingStatus,AdvertisingSort,BeginTime,EndTime,IsDelete,Creator,CreateTime,Updateor,UpdateTime) values (@AdvertisingId,@AdvertisingPicture,@AdvertisingTitle,@AdvertisingLink,@AdvertisingJump,@AdvertisingStatus,@AdvertisingSort,@BeginTime,@EndTime,@IsDelete,@Creator,@CreateTime,@Updateor,@UpdateTime)", advertising);
            //if (i > 0)
            //{
            //    RedisClient.redisClient.SetStringKey("key4", "value4", TimeSpan.FromHours(8));
            //}
            return i;
        }

        public int AdvertisingDel(int AavId)
        {
            int i = db.CRUd().Execute($"delete from Advertising where AdvertisingId={AavId}");
            return i;
        }

        public int AdvertisingEdit(Advertising adv)
        {
            adv.Updateor = "lsp";
            adv.UpdateTime = DateTime.Now;
            int i = db.CRUd().Execute("update Advertising set AdvertisingPicture=@AdvertisingPicture,AdvertisingTitle=@AdvertisingTitle,AdvertisingJump=@AdvertisingJump,AdvertisingStatus=@AdvertisingStatus,AdvertisingSort=@AdvertisingSort,AdvertisingLink=@AdvertisingLink,BeginTime=@BeginTime,EndTime=@EndTime,Updateor=@Updateor,UpdateTime=@UpdateTime where AdvertisingId=@AdvertisingId", adv);
            return i;
        }

        public List<Advertising> GetAdvertisingData(string advertisingName, string status, int page, int limit)
        {
            List<Advertising> ls = db.CRUd().Query<Advertising>("select * from Advertising");

            if (advertisingName != null)
            {
                ls = ls.Where(m => m.AdvertisingTitle.Contains(advertisingName)).ToList();
            }
            if (status != null)
            {
                ls = ls.Where(m => m.AdvertisingStatus == Convert.ToInt32(status)).ToList();
            }
            return ls;
        }
    }
}
