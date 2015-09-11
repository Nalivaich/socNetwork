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
    public class AlbumsRepository : BaseRepository<socNetworkEntities, Album>
    {
        public AlbumsRepository(socNetworkEntities context)
            : base(context, GetDbSet)
        {

        }

        public static DbSet<Album> GetDbSet(socNetworkEntities context)
        {
            return context.Albums;
        }
    }
}
