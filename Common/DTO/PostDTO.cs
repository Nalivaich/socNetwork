using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class PostDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public System.DateTime created { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public Nullable<int> likes { get; set; }
        public int userId { get; set; }
    }
}
