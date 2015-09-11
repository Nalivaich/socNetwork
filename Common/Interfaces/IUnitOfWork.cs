using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataProvider;

namespace Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Post> Posts { get; }
        IRepository<Album> Albums { get; }
        IRepository<Picture> Pictures { get; }
        IRepository<Comment> Comments { get; }
        void Save();
    }
}
