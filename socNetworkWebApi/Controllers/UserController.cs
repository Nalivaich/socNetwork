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
        // GET api/user
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/user/5
        [HttpGet]
        public UserDTO Get(int id)
        {
            UserDTO user = _userSvc.Get(id);
            return user;
        }
        [HttpPost]
        public IEnumerable<UserDTO> Post([FromBody]string value)
        {
            IEnumerable<UserDTO> userList = _userSvc.GetAll();
            return userList;
        }
        
        public class userTable
        {
            public int id { get; set; }
            public string post { get; set; }
            public string album { get; set; }
            public string picture { get; set; }
        }


        //[Route("customers/{customerId}/orders")]
        [HttpPost]
        public Object users(int id, [FromBody] userTable obj)
        {
            if(obj.post != null)
            {
                IEnumerable<PostDTO> userList = _userSvc.GetUserPosts(obj.id);
                return userList;
            }
            if (obj.album != null)
            {
                IEnumerable<AlbumDTO> albumList = _userSvc.GetUserAlbums(obj.id);
                return albumList;
            }
            if (obj.picture != null)
            {
                IEnumerable<PictureDTO> pictureList = _userSvc.GetUserPhotos(obj.id);
                return pictureList;
            }
            return 0;
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
