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
        private IRepository<User> userRepository;
        private IRepository<Post> postRepository;
        private IRepository<Album> albumRepository;
        private IRepository<Picture> pictureRepository;
        private IRepository<Comment> commentRepository;

        public EFUnitOfWork()
        {
            db = new socNetworkEntities();
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new BaseRepository<socNetworkEntities, User>(db, n => n.Users);
                return userRepository;
            }
        }

        public IRepository<Post> Posts
        {
            get
            {
                if (postRepository == null)
                    postRepository = new BaseRepository<socNetworkEntities, Post>(db, n => n.Posts); ;
                return postRepository;
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                if (albumRepository == null)
                    albumRepository = new BaseRepository<socNetworkEntities, Album>(db, n => n.Albums); ;
                return albumRepository;
            }
        }
        public IRepository<Picture> Pictures
        {
            get
            {
                if (pictureRepository == null)
                    pictureRepository = new BaseRepository<socNetworkEntities, Picture>(db, n => n.Pictures); ;
                return pictureRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new BaseRepository<socNetworkEntities, Comment>(db, n => n.Comments); ;
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
