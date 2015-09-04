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
    public interface IAlbumService
    {
        AlbumDTO Get(int id);
        IEnumerable<AlbumDTO> GetAll();
        IEnumerable<CommentDTO> GetComments(int id);
        IEnumerable<PictureDTO> GetPictures(int id);
        int Create(AlbumDTO item);
        void Update(AlbumDTO item);
        void Delete(int id);
        void Dispose();
    }
}
