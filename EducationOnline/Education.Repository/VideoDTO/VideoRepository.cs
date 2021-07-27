using Education.Common;
using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.VideoDTO
{
    public class VideoRepository : IVideoRepository
    {
        DBFactory db = new DBFactory();
        public List<Video> GetFreeVideo(int TypeId, int SecondId,int VideoId)
        {
            List<Video> ls = db.CRUd().Query<Video>("select * from Video where CoursePrice=0");
            if (TypeId != 0)
            {
                ls = ls.Where(m => m.Type_Id == TypeId).ToList();
            }
            if (SecondId != 0)
            {
                ls = ls.Where(m => m.SecondId == SecondId).ToList();
            }
            if (VideoId != 0)
            {
                ls = ls.Where(m => m.VideoId == VideoId).ToList();
            }
            return ls;

            
        }
    }
}
