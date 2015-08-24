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
    public interface IPostService
    {
        PostDTO Get(int id);
        IEnumerable<PostDTO> GetAll();
        IEnumerable<CommentDTO> GetComments(int id);
        void Create(PostDTO item);
        void Update(PostDTO item);
        void Delete(int id);
        void Dispose();
    }
}
