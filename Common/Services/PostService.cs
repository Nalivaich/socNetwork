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
    public class PostService : IPostService

    {
        private EFUnitOfWork Database;

        public PostService()
        {
            Database = new EFUnitOfWork();
        }

        public PostDTO Get(int id)
        {     
            var post = Database.Posts.Get(id);
            if (post == null)
            {
                throw new ValidationException("Post not found", "");
            }
            Mapper.CreateMap<Post, PostDTO>();

            return Mapper.Map<Post, PostDTO>(post);
        }

        public IEnumerable<PostDTO> GetAll()
        {
            var DBPosts = Database.Posts.GetAll();
            if (DBPosts == null)
            {
                throw new ValidationException("Post not found", "");
            }
            Mapper.CreateMap<Post, PostDTO>();

            return Mapper.Map<IEnumerable<Post>, List<PostDTO>>(DBPosts);
        }

        public IEnumerable<CommentDTO> GetComments(int postId)
        {
            var post = Database.Posts.Get(postId);
            if (post == null)
            {
                throw new ValidationException("Post not found", "");
            }

            return post.Comments.Select(u => Map(u)).ToList();
        }

        private static CommentDTO Map(Comment u)
        {
            return new CommentDTO
            {
                id = u.Id,
                comment = u.Value,
                created = u.Created,
                modified = u.Modified,
                postId = u.PostId,
                pictureId = u.PictureId,
                albumId = u.AlbumId,
                userId = u.UserId
            };
        }

        public IEnumerable<PictureDTO> GetPictures(int postId)
        {
            var post = Database.Posts.Get(postId);
            if (post == null)
            {
                throw new ValidationException("Post not found", "");
            }

            return post.Pictures.Select(Map).ToList();
        }

        private static PictureDTO Map(Picture u)
        {
            return new PictureDTO
            {
                id = u.Id,
                urlSmall = u.UrlSmall,
                urlMedium = u.UrlMedium,
                urlStandart = u.UrlStandart,
                albumId = u.AlbumId,
                likes = u.Likes,
                postId = u.PostId,
                userId = u.UserId
            };
        }

        public int Create(PostDTO item)
        {
            Mapper.CreateMap<PostDTO, Post>();

            int result = Database.Posts.Create(Mapper.Map<PostDTO, Post>(item)).Id;
            Database.Save();
            return result;
        }
        public void Update(PostDTO item)
        {

        }

        public void Delete(int id)
        {
            Database.Posts.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
