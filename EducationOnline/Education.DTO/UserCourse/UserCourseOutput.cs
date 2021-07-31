using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO.UserCourse
{
    public class UserCourseOutput
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int Car { get; set; }
        public int Collect { get; set; }
        public int Lcourse { get; set; }
        public int Vcourse { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Updateor { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
