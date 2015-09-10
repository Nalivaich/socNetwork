using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataProvider;
using System.Data.Entity;
using Common.EF;
using Common.Interfaces;

namespace Common.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private socNetworkEntities db;
        private UserRepository userRepository;
        private PostRepository postRepository;
        private AlbumsRepository albumRepository;
        private PicturesRepository pictureRepository;
        private CommentsRepository commentRepository;

        public EFUnitOfWork()
        {
            db = new socNetworkEntities();
        }
        public IRepository<user> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<post> Posts
        {
            get
            {
                if (postRepository == null)
                    postRepository = new PostRepository(db);
                return postRepository;
            }
        }

        public IRepository<album> Albums
        {
            get
            {
                if (albumRepository == null)
                    albumRepository = new AlbumsRepository(db);
                return albumRepository;
            }
        }
        public IRepository<picture> Pictures
        {
            get
            {
                if (pictureRepository == null)
                    pictureRepository = new PicturesRepository(db);
                return pictureRepository;
            }
        }

        public IRepository<comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentsRepository(db);
                return commentRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
