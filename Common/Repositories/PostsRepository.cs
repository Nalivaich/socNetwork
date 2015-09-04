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
    public class PostRepository : IRepository<post>
    {
        private socNetworkEntities db;

        public PostRepository(socNetworkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<post> GetAll()
        {
            return db.posts;
        }

        public post Get(int id)
        {
            return db.posts.Find(id);
        }

        public int Create(post post)
        {
            db.posts.Add(post);
            db.SaveChanges();
            return post.id;
        }

        public void Update(post post)
        {
            db.Entry(post).State = EntityState.Modified;
        }

        public IEnumerable<post> Find(Func<post, Boolean> predicate)
        {
            return db.posts.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            post post = db.posts.Find(id);
            if (post != null)
                db.posts.Remove(post);
        }
    }
}
