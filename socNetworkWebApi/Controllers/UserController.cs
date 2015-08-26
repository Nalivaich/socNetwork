using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common;
using Common.Interfaces;
using Common.Services;
using Common.DTO;

namespace socNetworkWebApi.Controllers
{
    public class UserController : ApiController 
    {

        private IUserService  _userSvc;

        public UserController(IUserService userSvc)
        {
            _userSvc = userSvc;
        }

        [Route("api/users")]
        [HttpGet]
        public IEnumerable<UserDTO> GetAll()
        {
            IEnumerable<UserDTO> userList = _userSvc.GetAll();
            return userList;
        }

        [Route("api/users/{id}")]
        [HttpGet]
        public UserDTO GetById(int id)
        {
            UserDTO user = _userSvc.Get(id);
            return user;
        }

        [Route("api/users/{id}/posts")]
        [HttpGet]
        public IEnumerable<PostDTO> GetPosts(int id)
        {
            IEnumerable<PostDTO> userList = _userSvc.GetUserPosts(id);
            return userList;
        }

        [Route("api/users/{id}/albums")]
        [HttpGet]
        public IEnumerable<AlbumDTO> GetAlbums(int id)
        {
            IEnumerable<AlbumDTO> albumList = _userSvc.GetUserAlbums(id);
            return albumList;
        }

        [Route("api/users/{id}/pictures")]
        [HttpGet]
        public IEnumerable<PictureDTO> GetPictures(int id)
        {
            IEnumerable<PictureDTO> pictureList = _userSvc.GetUserPhotos(id);
            return pictureList;
        }

        [Route("api/users/{id}/posts/{postId}")]
        public string GetPostById(int id, int postId)
        {
            return "";
        }

        [Route("api/users/{id}/albums{albumId}")]
        public string GetAlbumById(int id, int albumId)
        {
            return "";
        }

        [Route("api/users/{id}/pictures/{pictureId}")]
        public string GetPictureById(int id, int pictureId)
        {
            return "";
        }

        [Route("api/users/add")]
        [HttpPost]
        public UserDTO Add(UserDTO newUser)
        {
            newUser.created = DateTime.Now;
            _userSvc.Create(newUser);
            return newUser;
        }

        [Route("api/users/delete/{id}")]
        [HttpPost]
        public void Add(int id)
        {
            _userSvc.Delete(id);
             // we can change isRemoved flag simply & don`t remove user from DB
        }


        /*[HttpPost]
        public string users(int id, [FromBody] userTable obj)
        {
            return "sdf";
        }*/

        /*public Object PostSec(int id)
        {
        }*/


        // POST api/user
        /*public void Post([FromBody]string value)
        {
        }*/
        [HttpPut]
        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }
        [HttpDelete]
        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
