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
    public class AlbumService : IAlbumService
    {
        private EFUnitOfWork Database;

        public AlbumService()
        {
            Database = new EFUnitOfWork();
        }

        public AlbumDTO Get(int id)
        {     
            var album = Database.Albums.Get(id);
            if (album == null)
            {
                throw new ValidationException("Album not found", "");
            }
            Mapper.CreateMap<album, AlbumDTO>();

            return Mapper.Map<album, AlbumDTO>(album);
        }

        public IEnumerable<AlbumDTO> GetAll()
        {
            var DBAlbum = Database.Albums.GetAll();
            if (DBAlbum == null)
            {
                throw new ValidationException("Album not found", "");
            }
            Mapper.CreateMap<album, AlbumDTO>();

            return Mapper.Map<IEnumerable<album>, List<AlbumDTO>>(DBAlbum);
        }

        public IEnumerable<CommentDTO> GetComments(int albumId)
        {
            var album = Database.Albums.Get(albumId);
            if (album == null)
            {
                throw new ValidationException("Album not found", "");
            }

            return album.comments.Select(u => new CommentDTO
            {
                id = u.id,
                comment = u.comment1,
                created = u.created,
                modified = u.modified,
                postId = u.postId,
                pictureId = u.pictureId,
                albumId = u.albumId,
                userId = u.userId
            }).ToList();
        }

        public void Create(AlbumDTO item)
        {
            Mapper.CreateMap<AlbumDTO, album>();

            Database.Albums.Create(Mapper.Map<AlbumDTO, album>(item));
            Database.Save();
        }
        public void Update(AlbumDTO item)
        {
            Mapper.CreateMap<AlbumDTO, album>();

            Database.Albums.Update(Mapper.Map<AlbumDTO, album>(item));
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Albums.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
