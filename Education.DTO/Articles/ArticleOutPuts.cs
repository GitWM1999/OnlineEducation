using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO
{
    public class ArticleOutPuts
    {
        public int OutPutId { get; set; }
        public string OutPutArticleTitle { get; set; }
        public string OutPutArticleContent { get; set; }
        public DateTime OutPutReleaseTime { get; set; }
        public string OutPutReleaseTimes { get { return OutPutReleaseTime.ToString("yyyy-MM-dd hh:mm:ss"); } }
        public int OutPutUserId { get; set; }
        public string OutPutUserPhone { get; set; }
        public int OutPutUId { get; set; }
        public int OutPutAId { get; set; }
        public int OutPutNum { get; set; }


    }
}
