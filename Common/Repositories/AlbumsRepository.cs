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
    public class AlbumsRepository : IRepository<album>
    {
        private socNetworkEntities db;

        public AlbumsRepository(socNetworkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<album> GetAll()
        {
            return db.albums;
        }

        public album Get(int id)
        {
            return db.albums.Find(id);
        }

        public int Create(album album)
        {
            db.albums.Add(album);
            db.SaveChanges();
            return album.id;
        }

        public void Update(album album)
        {
            db.Entry(album).State = EntityState.Modified;
        }

        public IEnumerable<album> Find(Func<album, Boolean> predicate)
        {
            return db.albums.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            album album = db.albums.Find(id);
            if (album != null)
                db.albums.Remove(album);
        }
    }
}
