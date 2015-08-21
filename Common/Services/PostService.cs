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
    public class PostService
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
            Mapper.CreateMap<post, PostDTO>();

            return Mapper.Map<post, PostDTO>(post);
        }

        public IEnumerable<PostDTO> GetAll()
        {
            var DBPosts = Database.Posts.GetAll();
            if (DBPosts == null)
            {
                throw new ValidationException("Post not found", "");
            }
            Mapper.CreateMap<post, PostDTO>();

            return Mapper.Map<IEnumerable<post>, List<PostDTO>>(DBPosts);
        }

        public IEnumerable<CommentDTO> GetComments(int postId)
        {
            var post = Database.Posts.Get(postId);
            if (post == null)
            {
                throw new ValidationException("Post not found", "");
            }

            return post.comments.Select(u => new CommentDTO
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

        public void Create(PostDTO item)
        {
            Mapper.CreateMap<PostDTO, post>();

            Database.Posts.Create(Mapper.Map<PostDTO, post>(item));
            Database.Save();
        }
        public void Update(UserDTO item)
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
