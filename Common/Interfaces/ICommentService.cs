using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataProvider;
using System.Data.Entity;
using Common.DTO;


namespace Common.Interfaces
{
    public interface ICommentService
    {
        CommentDTO Get(int id);
        IEnumerable<CommentDTO> GetAll();
        int Create(CommentDTO item);
        void Update(CommentDTO item);
        void Delete(int id);
        void Dispose();
    }
}
