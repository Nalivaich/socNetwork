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
        IRepository<user> Users { get; }
        IRepository<post> Posts { get; }
        IRepository<album> Albums { get; }
        IRepository<picture> Pictures { get; }
        IRepository<comment> Comments { get; }
        void Save();
    }
}
