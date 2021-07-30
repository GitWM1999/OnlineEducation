using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO
{
    public class ArticleTypeOutPut
    {

        public int Type_Id { get; set; }
        public string Type_Name { get; set; }
        public int Type_State { get; set; }
        public int Type_Sort { get; set; }
        public string Type_Remark { get; set; }

        public int OutPutId { get; set; }
        public string OutPutArticleTitle { get; set; }
        public string OutPutArticleContent { get; set; }
        public DateTime OutPutReleaseTime { get; set; }
        public int OutPutUserId { get; set; }
        public string OutPutUserPhone { get; set; }
    }
}
