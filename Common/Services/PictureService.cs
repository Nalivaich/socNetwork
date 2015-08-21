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
    public class PictureService
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
            Mapper.CreateMap<picture, PictureDTO>();

            return Mapper.Map<picture, PictureDTO>(picture);
        }

        public IEnumerable<PictureDTO> GetAll()
        {
            var DBPicture = Database.Pictures.GetAll();
            if (DBPicture == null)
            {
                throw new ValidationException("Image not found", "");
            }
            Mapper.CreateMap<picture, PictureDTO>();

            return Mapper.Map<IEnumerable<picture>, List<PictureDTO>>(DBPicture);
        }

        public IEnumerable<CommentDTO> GetComments(int pictureId)
        {
            var picture = Database.Pictures.Get(pictureId);
            if (picture == null)
            {
                throw new ValidationException("Image not found", "");
            }

            return picture.comments.Select(u => new CommentDTO
            {
                id = u.id,
                comment = u.comment1,
                created = u.created,
                modified = u.modified,
                postId = u.postId,
                pictureId = u.pictureId,
                albumId = u.albumId
            }).ToList();
        }

        public void Create(PictureDTO item)
        {
            Mapper.CreateMap<PictureDTO, picture>();

            Database.Pictures.Create(Mapper.Map<PictureDTO, picture>(item));
            Database.Save();
        }
        public void Update(UserDTO item)
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
