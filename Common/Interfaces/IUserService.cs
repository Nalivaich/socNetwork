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
    public interface IUserService
    {
        UserDTO Get(int id);
        IEnumerable<UserDTO> GetAll();
        IEnumerable<PostDTO> GetUserPosts(int userId);
        IEnumerable<AlbumDTO> GetUserAlbums(int userId);
        IEnumerable<PictureDTO> GetUserPhotos(int userId);
        IEnumerable<RoleDTO> GetUserRoles(int userId);
        void Create(UserDTO item);
        void Update(UserDTO item);
        void Delete(int id);
        void Dispose();
    }
}
