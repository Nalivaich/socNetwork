using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class CommentDTO
    {
        public int id { get; set; }
        public string comment { get; set; }
        public System.DateTime created { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public Nullable<int> postId { get; set; }
        public Nullable<int> albumId { get; set; }
        public Nullable<int> pictureId { get; set; }
        public int userId { get; set; }
    }
}
