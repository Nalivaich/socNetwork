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

    public class UserRepository : IRepository<user>
    {
        private socNetworkEntities db;

        public UserRepository(socNetworkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<user> GetAll()
        {
            return db.users;
        }

        public user Get(int id)
        {
            return db.users.Find(id);
        }

        public void Create(user user)
        {
            db.users.Add(user);
        }

        public void Update(user user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<user> Find(Func<user, Boolean> predicate)
        {
            return db.users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            user user = db.users.Find(id);
            if (user != null)
                db.users.Remove(user);
        }
    }
}
