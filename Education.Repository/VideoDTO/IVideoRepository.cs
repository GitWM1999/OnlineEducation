using Education.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Repository.VideoDTO
{
    public interface IVideoRepository
    {
        List<Video> GetFreeVideo(int TypeId, int SecondId, int VideoId);

        int EditVideoCollect(int VideoId);
    }
}
