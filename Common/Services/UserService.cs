using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Mapper.CreateMap<User, UserDTO>();

            return Mapper.Map<User, UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var DBUsers = Database.Users.GetAll();

            if (DBUsers == null)
            {
                throw new ValidationException("Users not found", "");
            }
            Mapper.CreateMap<User, UserDTO>();

            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(DBUsers);
        }
        public IEnumerable<PostDTO> GetUserPosts(int userId)
        {
            var user = Database.Users.Get(userId);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }

            return user.Posts.Select(u => new PostDTO
            {
                id = u.Id,
                name = u.Name,
                created = u.Created,
                modified = u.Modified,
                likes = u.Likes,
                userId = u.UserId
            }).ToList();
                
        }
        public IEnumerable<AlbumDTO> GetUserAlbums(int userId)
        {
            var user = Database.Users.Get(userId);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }

            return user.Albums.Select(u => new AlbumDTO
            {
                id = u.Id,
                name = u.Name,
                created = u.Created,
                modified = u.Modified,
                likes = u.Likes,
                @private = u.Private,
                userId = u.UserId
            }).ToList();
        }
        public IEnumerable<PictureDTO> GetUserPhotos(int userId)
        {
            var user = Database.Users.Get(userId);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }

            return user.Pictures.Select(u => new PictureDTO
            {
                id = u.Id,
                urlStandart = u.UrlStandart,
                urlMedium = u.UrlMedium,
                urlSmall = u.UrlSmall,
                likes = u.Likes,
                postId = u.PostId,
                albumId = u.AlbumId,
                userId = u.UserId
            }).ToList();
        }
        public IEnumerable<RoleDTO> GetUserRoles(int userId)
        {
            var user = Database.Users.Get(userId);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }

            return user.UserRoles.Select(u => new RoleDTO
            {
                roleName = u.RoleName,
                id = u.UserId
            }).ToList().Where(u => u.id == userId);
        }

        public int GetMaxId()
        {
            var DBUsers = Database.Users.GetAll();
            var allId = DBUsers.Select(u => u.Id).ToList();
            return allId.Max();
        }
        
        public int Create(UserDTO item)
        {
            Mapper.CreateMap<UserDTO, User>();
 
            int result = Database.Users.Create(Mapper.Map<UserDTO, User>(item)).Id;
            Database.Save();
            return result;
        }

        public UserDTO Find(Login userInfo)
        {
            var DBUsers = Database.Users.GetAll();
            IEnumerable<UserDTO> users =  DBUsers.Select(u => new UserDTO
                {
                    id = u.Id,
                    name = u.Name,
                    surName = u.SurName,
                    alias = u.Alias,
                    password = u.Password,
                    address = u.Address,
                    avaUrl = u.AvaUrl,
                    email = u.Email,
                    created = u.Created,
                    isRemoved = u.IsRemoved,
                    phoneNumber = u.PhoneNumber
                }).ToList().Where(u => u.password == userInfo.password && (u.alias == userInfo.name || u.email == userInfo.name));
            if(users.ToArray().Length == 1)
            {
                return users.First();
            }
            return new UserDTO();
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
