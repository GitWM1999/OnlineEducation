using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO
{
    public class UserDisCussInPut
    {
        public int InPutId { get; set; }
        public int InPutUserId { get; set; }
        public int InPutDisCussUserId { get; set; }
        public string InPutCommentContent { get; set; }

    }
}
