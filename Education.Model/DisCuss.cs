using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Model
{
    public class DisCuss
    {
        public int DisCussId { get; set; }
        public int AId { get; set; }
        public int UId { get; set; }
        public string CommentContent { get; set; }
        public DateTime ReleaseTime { get; set; }
        public int IsDelete { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string UserFace { get; set; }
        public string ReleaseTimes { get { return ReleaseTime.ToString("yyyy-MM-dd hh:mm:ss"); } }

    }
}
