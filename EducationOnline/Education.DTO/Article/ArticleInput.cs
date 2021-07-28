using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO
{
    public class ArticleInput
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public int ArticleSort { get; set; }
        public int ArticleStatus { get; set; }
        public string ArticleDetails { get; set; }
        public int IsDelete { get; set; }
        public string Updateor { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
