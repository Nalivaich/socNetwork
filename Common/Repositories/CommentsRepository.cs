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
    class CommentsRepository : IRepository<comment>
    {
         private socNetworkEntities db;

         public CommentsRepository(socNetworkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<comment> GetAll()
        {
            return db.comments;
        }

        public comment Get(int id)
        {
            return db.comments.Find(id);
        }

        public int Create(comment comment)
        {
            db.comments.Add(comment);
            db.SaveChanges();
            return comment.id;
        }

        public void Update(comment comment)
        {
            db.Entry(comment).State = EntityState.Modified;
        }

        public IEnumerable<comment> Find(Func<comment, Boolean> predicate)
        {
            return db.comments.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            comment comment = db.comments.Find(id);
            if (comment != null)
                db.comments.Remove(comment);
        }
    }
}
