using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO.Navigation
{
    public class NavigationInput
    {
        public int NavigationId { get; set; }
        public string NavigationTitle { get; set; }
        public string NavigationLink { get; set; }
        public string NavigationJump { get; set; }
        public int NavigationStatus { get; set; }
        public int NavigationSort { get; set; }
        public int IsDelete { get; set; }
        public string Updateor { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
