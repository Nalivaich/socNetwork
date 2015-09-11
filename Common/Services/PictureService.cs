using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataProvider;
using System.Data.Entity;
using Common;
using Common.Repositories;
using Common.Interfaces;
using Common.DTO;
using Common.Infrastructure;
using AutoMapper;

namespace Common.Services
{
    public class PictureService : IPictureService
    {
        private EFUnitOfWork Database;

        public PictureService()
        {
            Database = new EFUnitOfWork();
        }

        public PictureDTO Get(int id)
        {     
            var picture = Database.Pictures.Get(id);
            if (picture == null)
            {
                throw new ValidationException("Image not found", "");
            }
            Mapper.CreateMap<Picture, PictureDTO>();

            return Mapper.Map<Picture, PictureDTO>(picture);
        }

        public IEnumerable<PictureDTO> GetAll()
        {
            var DBPicture = Database.Pictures.GetAll();
            if (DBPicture == null)
            {
                throw new ValidationException("Image not found", "");
            }
            Mapper.CreateMap<Picture, PictureDTO>();

            return Mapper.Map<IEnumerable<Picture>, List<PictureDTO>>(DBPicture);
        }

        public IEnumerable<CommentDTO> GetComments(int pictureId)
        {
            var picture = Database.Pictures.Get(pictureId);
            if (picture == null)
            {
                throw new ValidationException("Image not found", "");
            }

            return picture.Comments.Select(u => new CommentDTO
            {
                id = u.Id,
                comment = u.Value,
                created = u.Created,
                modified = u.Modified,
                postId = u.PostId,
                pictureId = u.PictureId,
                albumId = u.AlbumId,
                userId = u.UserId
            }).ToList();
        }

        public int Create(PictureDTO item)
        {
            Mapper.CreateMap<PictureDTO, Picture>();

            int result = Database.Pictures.Create(Mapper.Map<PictureDTO, Picture>(item)).Id;
            Database.Save();
            return result;
        }
        public void Update(PictureDTO item)
        {

        }

        public void Delete(int id)
        {
            Database.Pictures.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
