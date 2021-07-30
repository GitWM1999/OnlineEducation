using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Model
{
    public class UserDisCuss
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DisCussUserId { get; set; }
        public string CommentContent { get; set; }

    }
}
