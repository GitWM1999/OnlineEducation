using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Model
{
    public class CustomerArticle
    {
        public int Id { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public DateTime ReleaseTime { get; set; }
        public string ReleaseTimes { get { return ReleaseTime.ToString("yyyy-MM-dd hh:mm:ss"); } }

        public int UserId { get; set; }
        public string UserPhone { get; set; }
        public int ArticleTypeId { get; set; }
        public int UId { get; set; }
        public int AId { get; set; }
        public int Num { get; set; }
    }
}
