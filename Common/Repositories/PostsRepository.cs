using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataProvider;
using System.Data.Entity;
using Common.Interfaces;
using Common.EF;

namespace Common.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private socNetworkEntities db;

        public PostRepository(socNetworkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Post> GetAll()
        {
            return db.Posts;
        }

        public Post Get(int id)
        {
            return db.Posts.Find(id);
        }

        public Post Create(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
            return post;
        }

        public void Update(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
        }

        public IEnumerable<Post> Find(Func<Post, Boolean> predicate)
        {
            return db.Posts.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Post post = db.Posts.Find(id);
            if (post != null)
                db.Posts.Remove(post);
        }
    }
}
