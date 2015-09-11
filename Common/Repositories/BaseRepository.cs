using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.EF;

namespace Common.Repositories
{
    public class BaseRepository<TContext, TModel> : IRepository<TModel>
        where TContext : DbContext
        where TModel: class

    {
        public BaseRepository(TContext context, Func<TContext, DbSet<TModel>> tableAccessor)
        {
            Context = context;

            Table = tableAccessor(Context);
        }

        public TContext Context { get; private set; }

        public DbSet<TModel> Table { get; private set; }

        public IEnumerable<TModel> GetAll()
        {
            return Table;
        }

        public virtual TModel Get(int id)
        {
            return Table.Find(id);
        }

        public TModel Create(TModel entity)
        {
            Table.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public void Update(TModel album)
        {
            Context.Entry(album).State = EntityState.Modified;
        }

        public IEnumerable<TModel> Find(Func<TModel, Boolean> predicate)
        {
            return Table.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TModel album = Table.Find(id);
            if (album != null)
                Table.Remove(album);
        }
    }
}
