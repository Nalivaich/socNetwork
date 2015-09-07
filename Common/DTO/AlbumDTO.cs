using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class AlbumDTO
    {
        [Column("Id")]
        public int id { get; set; }
        [Column("Name")]
        public string name { get; set; }
        [Column("Created")]
        public System.DateTime created { get; set; }
        [Column("Modified")]
        public Nullable<System.DateTime> modified { get; set; }
        [Column("Likes")]
        public Nullable<int> likes { get; set; }
        [Column("@Private")]
        public bool @private { get; set; }
        [Column("UserId")]
        public int userId { get; set; }
        [Column("PicturesName")]
        public IEnumerable<string> picturesName { get; set; }
    }
}
