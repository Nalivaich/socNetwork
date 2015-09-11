//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFDataProvider
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Albums = new HashSet<Album>();
            this.Comments = new HashSet<Comment>();
            this.Pictures = new HashSet<Picture>();
            this.Posts = new HashSet<Post>();
            this.UserRoles = new HashSet<UserRole>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Alias { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string AvaUrl { get; set; }
        public bool IsRemoved { get; set; }
        public System.DateTime Created { get; set; }
    
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
