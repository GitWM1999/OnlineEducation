using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO.Video
{
    public class VideoInput
    {
        public int VideoId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public decimal CoursePrice { get; set; }
        public int VideoState { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Type_Id { get; set; }
        public DateTime VideoTrueBeginTime { get; set; }
        public DateTime VideoTrueEndTime { get; set; }
        public int VideoShowModel { get; set; }

        public int VideoCollect { get; set; }
        public string VideoImg { get; set; }
        public int Teacher_Id { get; set; }
        public int SecondId { get; set; }
    }
}
