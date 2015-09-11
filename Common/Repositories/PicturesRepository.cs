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
    public class PicturesRepository : IRepository<Picture>
    {
        private socNetworkEntities db;

        public PicturesRepository(socNetworkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Picture> GetAll()
        {
            return db.Pictures;
        }

        public Picture Get(int id)
        {
            return db.Pictures.Find(id);
        }

        public Picture Create(Picture picture)
        {
            db.Pictures.Add(picture);
            return picture;
        }

        public void Update(Picture picture)
        {
            db.Entry(picture).State = EntityState.Modified;
        }

        public IEnumerable<Picture> Find(Func<Picture, Boolean> predicate)
        {
            return db.Pictures.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Picture picture = db.Pictures.Find(id);
            if (picture != null)
                db.Pictures.Remove(picture);
        }

    }
}
