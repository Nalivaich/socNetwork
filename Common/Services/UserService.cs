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
        private dynamic users;

        public UserService()
        {
            //var eFUnitOfWorkObject = new EFUnitOfWork();
            users = new EFUnitOfWork().Users;
        }

        public UserDTO Get(int id)
        {
           
            var user = users.Get(id);
            if (user == null)
                throw new ValidationException("User not found","");
            Mapper.CreateMap<user, UserDTO>();
            return Mapper.Map<user, UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var DBUsers = users.GetAll();
            //List<UserDTO> userList;
            Mapper.CreateMap<user, UserDTO>();
            return Mapper.Map<DbSet<user>, List<UserDTO>>(DBUsers);
        }
        public IEnumerable<PostDTO> GetUserPosts()
        {
            return new List<PostDTO>();
        }
        public IEnumerable<AlbumDTO> GetUserAlbums()
        {
            return new List<AlbumDTO>();
        }
        public IEnumerable<PictureDTO> GetUserPhotos()
        {
            return new List<PictureDTO>();
        }
        public IEnumerable<string> GetUserRoles(int id)
        {
            return new List<string>();
        }
        
        public void Create(UserDTO item)
        {

        }
        public void Update(UserDTO item)
        {

        }
        public void Delete(int id)
        {

        }
        IUnitOfWork Database { get; set; }
 
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
            if (id == null)
                throw new ValidationException("Не установлено id телефона","");
            var phone = Database.Phones.Get(id.Value);
            if (phone == null)
                throw new ValidationException("Телефон не найден","");
            // применяем автомаппер для проекции Phone на PhoneDTO
            Mapper.CreateMap<Phone, PhoneDTO>();
            return Mapper.Map<Phone, PhoneDTO>(phone);
        }*/
 
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
