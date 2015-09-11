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
            Mapper.CreateMap<Album, AlbumDTO>();

            return Mapper.Map<Album, AlbumDTO>(album);
        }

        public IEnumerable<AlbumDTO> GetAll()
        {
            var DBAlbum = Database.Albums.GetAll();
            if (DBAlbum == null)
            {
                throw new ValidationException("Album not found", "");
            }
            Mapper.CreateMap<Album, AlbumDTO>();

            return Mapper.Map<IEnumerable<Album>, List<AlbumDTO>>(DBAlbum);
        }

        public IEnumerable<CommentDTO> GetComments(int albumId)
        {
            var album = Database.Albums.Get(albumId);
            if (album == null)
            {
                throw new ValidationException("Album not found", "");
            }

            return album.Comments.Select(u => new CommentDTO
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

        public IEnumerable<PictureDTO> GetPictures(int albumId)
        {
            var album = Database.Albums.Get(albumId);
            if (album == null)
            {
                throw new ValidationException("Album not found", "");
            }

            return album.Pictures.Select(u => new PictureDTO
            {
                id = u.Id,
                albumId = u.AlbumId,
                likes = u.Likes,
                urlStandart = u.UrlStandart,
                urlMedium = u.UrlMedium,
                urlSmall = u.UrlSmall,
                postId = u.PostId,
                userId = u.UserId
            }).ToList();
        }
        

        public int Create(AlbumDTO item)
        {
            Mapper.CreateMap<AlbumDTO, Album>();

            int result = Database.Albums.Create(Mapper.Map<AlbumDTO, Album>(item)).Id;
            Database.Save();
            return result;
        }
        public void Update(AlbumDTO item)
        {
            Mapper.CreateMap<AlbumDTO, Album>();

            Database.Albums.Update(Mapper.Map<AlbumDTO, Album>(item));
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
