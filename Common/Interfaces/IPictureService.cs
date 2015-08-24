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
    public interface IPictureService
    {
        PictureDTO Get(int id);
        IEnumerable<PictureDTO> GetAll();
        IEnumerable<CommentDTO> GetComments(int id);
        void Create(PictureDTO item);
        void Update(PictureDTO item);
        void Delete(int id);
        void Dispose();
    }
}
