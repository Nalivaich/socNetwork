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
    public class PicturesRepository : IRepository<picture>
    {
        private socNetworkEntities db;

        public PicturesRepository(socNetworkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<picture> GetAll()
        {
            return db.pictures;
        }

        public picture Get(int id)
        {
            return db.pictures.Find(id);
        }

        public void Create(picture picture)
        {
            db.pictures.Add(picture);
        }

        public void Update(picture picture)
        {
            db.Entry(picture).State = EntityState.Modified;
        }

        public IEnumerable<picture> Find(Func<picture, Boolean> predicate)
        {
            return db.pictures.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            picture picture = db.pictures.Find(id);
            if (picture != null)
                db.pictures.Remove(picture);
        }

    }
}
