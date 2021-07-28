using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO
{
    public class DisCussOutPut
    {
        public int OutPutDisCussId { get; set; }
        public int OutPutAId { get; set; }
        public int OutPutUserId { get; set; }
        public string OutPutCommentContent { get; set; }
        public DateTime OutPutReleaseTime { get; set; }
        public int IsDelete { get; set; }
        public string OutPutUserName { get; set; }
        public string OutPutUserFace { get; set; }

        public string OutPutReleaseTimes { get { return OutPutReleaseTime.ToString("yyyy-MM-dd hh:mm:ss"); } }

    }
}
