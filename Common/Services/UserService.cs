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
    public class UserService : IUserService
    {
        private EFUnitOfWork Database; 

        public UserService()
        {
            Database = new EFUnitOfWork();
        }

        public UserDTO Get(int id)
        {
            var user = Database.Users.Get(id);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }
            Mapper.CreateMap<user, UserDTO>();

            return Mapper.Map<user, UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var DBUsers = Database.Users.GetAll();

            if (DBUsers == null)
            {
                throw new ValidationException("Users not found", "");
            }
            Mapper.CreateMap<user, UserDTO>();

            return Mapper.Map<IEnumerable<user>, List<UserDTO>>(DBUsers);
        }
        public IEnumerable<PostDTO> GetUserPosts(int userId)
        {
            var user = Database.Users.Get(userId);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }

            return user.posts.Select(u => new PostDTO
            {
                id = u.id,
                name = u.name,
                created = u.created,
                modified = u.modified,
                likes = u.likes
            }).ToList();
                
        }
        public IEnumerable<AlbumDTO> GetUserAlbums(int userId)
        {
            var user = Database.Users.Get(userId);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }

            return user.albums.Select(u => new AlbumDTO
            {
                id = u.id,
                name = u.name,
                created = u.created,
                modified = u.modified,
                likes = u.likes,
                @private = u.@private
            }).ToList();
        }
        public IEnumerable<PictureDTO> GetUserPhotos(int userId)
        {
            var user = Database.Users.Get(userId);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }

            return user.pictures.Select(u => new PictureDTO
            {
                id = u.id,
                urlStandart = u.urlStandart,
                urlMedium = u.urlMedium,
                urlSmall = u.urlSmall,
                likes = u.likes,
                postId = u.postId,
                albumId = u.albumId
            }).ToList();
        }
        public IEnumerable<RoleDTO> GetUserRoles(int userId)
        {
            var user = Database.Users.Get(userId);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }

            return user.userRoles.Select(u => new RoleDTO
            {
                roleName = u.roleName,
                id = u.userId
            }).ToList().Where(u => u.id == userId);
        }
        
        public void Create(UserDTO item)
        {
            Mapper.CreateMap<UserDTO, user>();
 
            Database.Users.Create(Mapper.Map<UserDTO, user>(item));
            Database.Save();
        }
        public void Update(UserDTO item)
        {

        }
        public void Delete(int id)
        {
            Database.Users.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }


 
        /*
        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            Phone phone = Database.Phones.Get(orderDto.PhoneId);
 
            // валидация
            if (phone == null)
                throw new ValidationException("Телефон не найден","");
            // применяем скидку
            decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                PhoneId = phone.Id,
                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }
 
        public IEnumerable<PhoneDTO> GetPhones()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            Mapper.CreateMap<Phone, PhoneDTO>();
            return Mapper.Map<IEnumerable<Phone>, List<PhoneDTO>>(Database.Phones.GetAll());
        }
 
        public PhoneDTO GetPhone(int? id)
        {

            var phone = Database.Phones.Get(id.Value);
            if (phone == null)
                throw new ValidationException("Телефон не найден","");
            // применяем автомаппер для проекции Phone на PhoneDTO
            Mapper.CreateMap<Phone, PhoneDTO>();
            return Mapper.Map<Phone, PhoneDTO>(phone);
        }*/

    }
}
