using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.DTO.Precinct
{
    public class PrecinctOutput
    {
        public int PrecinctId { get; set; }
        public string PrecinctName { get; set; }
        public string PrecinctDetails { get; set; }
        public string PrecinctJump { get; set; }
        public int PrecinctSort { get; set; }
        public int PrecinctStatus { get; set; }
        public int IsDelete { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Updateor { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
