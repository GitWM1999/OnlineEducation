using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Model
{
    public class Advertising
    {
        public int AdvertisingId { get; set; }
        public string AdvertisingPicture { get; set; }
        public string AdvertisingTitle { get; set; }
        public string AdvertisingLink { get; set; }
        public int AdvertisingSort { get; set; }
        public string AdvertisingJump { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AdvertisingStatus { get; set; }
        public int IsDelete { get; set; }
        public string Updateor { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
