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
    public class CommentService : ICommentService
    {
        private EFUnitOfWork Database;

        public CommentService()
        {
            Database = new EFUnitOfWork();
        }

        public CommentDTO Get(int id)
        {     
            var comment = Database.Comments.Get(id);
            if (comment == null)
            {
                throw new ValidationException("Comment not found", "");
            }
            Mapper.CreateMap<comment, CommentDTO>();

            return Mapper.Map<comment, CommentDTO>(comment);
        }

        public IEnumerable<CommentDTO> GetAll()
        {
            var DBComment = Database.Comments.GetAll();
            if (DBComment == null)
            {
                throw new ValidationException("Album not found", "");
            }
            Mapper.CreateMap<comment, CommentDTO>();

            return Mapper.Map<IEnumerable<comment>, List<CommentDTO>>(DBComment);
        }
        
        public int Create(CommentDTO item)
        {
            Mapper.CreateMap<CommentDTO, comment>();
            var DBresult = Mapper.Map<CommentDTO, comment>(item);
            DBresult.comment1 = item.comment;
            int result = Database.Comments.Create(DBresult);
            Database.Save();
            return result;
        }
        public void Update(CommentDTO item)
        {
            Mapper.CreateMap<CommentDTO, comment>();

            Database.Comments.Update(Mapper.Map<CommentDTO, comment>(item));
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Comments.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
