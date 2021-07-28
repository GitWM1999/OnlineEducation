using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.DTO;

namespace Education.Service
{
    public interface IDiscussService
    {
        //获取评论
        List<DisCussOutPut> GetDisCusses(int id=0);

        //添加评论
        int AddDisCuss(UserDisCussInPut inPut);

    }
}
