using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Model;

namespace Education.Repository
{
    public interface IDisCussRepository
    {
        //获取评论
        List<DisCuss> GetDisCusses(int id=0);

        //添加评论
        int AddDisCuss(UserDisCuss userDisCuss);

    }
}
