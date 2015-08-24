using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public string alias { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string avaUrl { get; set; }
        public bool isRemoved { get; set; }
        public System.DateTime created { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
    }
}
