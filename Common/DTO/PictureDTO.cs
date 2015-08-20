using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class PictureDTO
    {
        public int id { get; set; }
        public string urlStandart { get; set; }
        public string urlMedium { get; set; }
        public string urlSmall { get; set; }
        public Nullable<int> likes { get; set; }
        public Nullable<int> postId { get; set; }
        public int albumId { get; set; }
        public int userId { get; set; }
    }
}
