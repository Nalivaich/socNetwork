//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace socNetwork
{
    using System;
    using System.Collections.Generic;
    
    public partial class picture
    {
        public picture()
        {
            this.comments = new HashSet<comment>();
        }
    
        public int id { get; set; }
        public string urlStandart { get; set; }
        public string urlMedium { get; set; }
        public string urlSmall { get; set; }
        public Nullable<int> likes { get; set; }
        public Nullable<int> postId { get; set; }
        public int albumId { get; set; }
        public int userId { get; set; }
    
        public virtual album album { get; set; }
        public virtual ICollection<comment> comments { get; set; }
        public virtual post post { get; set; }
        public virtual user user { get; set; }
    }
}