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
using System.Web;
using System.Security.AccessControl;
using System.IO;
using System.Drawing;
using socNetworkWebApi.Environment.DataProvider;

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

        [Route("api/users1/{str}")]
        [HttpPost]
        public string GetAll1(string str)
        {
            
            return "";
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


        
        [Route("api/users/{id}/pictures/add")]
        [HttpPost]
        public HttpResponseMessage LoadPostPictures(int id)
        {
            UserDTO user = _userSvc.Get(id);
            string rootPath = HttpContext.Current.Request.MapPath("~/Temp/");
            string userDirectoryPath = Path.Combine(rootPath, user.email);

            if (!Directory.Exists(userDirectoryPath))
            {

                string standartImageDirectoryPath = Path.Combine(userDirectoryPath, "Standart");
                string mediumImageDirectoryPath = Path.Combine(userDirectoryPath, "Medium");
                string smallImageDirectoryPath = Path.Combine(userDirectoryPath, "Small");
                Directory.CreateDirectory(userDirectoryPath);
                Directory.CreateDirectory(standartImageDirectoryPath);
                Directory.CreateDirectory(mediumImageDirectoryPath);
                Directory.CreateDirectory(smallImageDirectoryPath);
            }

            
            var httpRequest = HttpContext.Current.Request;
            
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var standartImagePath = HttpContext.Current.Server.MapPath("~/temp/" + user.email + "/Standart/" +   postedFile.FileName);
                    var mediumImagePath = HttpContext.Current.Server.MapPath("~/temp/" + user.email + "/Medium/" + postedFile.FileName);
                    var smallImagePath = HttpContext.Current.Server.MapPath("~/temp/" + user.email + "/Small/" + postedFile.FileName);
                    postedFile.SaveAs(standartImagePath);
                    PictureProvider.SaveMiniatureImage(standartImagePath, mediumImagePath, 200);
                    PictureProvider.SaveMiniatureImage(standartImagePath, smallImagePath, 100);

                }

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/users/{id}/pictures/rollback")]
        [HttpDelete]
        public HttpResponseMessage DeleteTemporaryFolders(int id)
        {
            UserDTO user = _userSvc.Get(id);
            string rootPath = HttpContext.Current.Request.MapPath("~/Temp/");
            string userDirectoryPath = Path.Combine(rootPath, user.email);

            if (Directory.Exists(userDirectoryPath))
            {
                var dir = new DirectoryInfo(userDirectoryPath);
                dir.Delete(true);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/users/{id}/posts/{postId}/pictures/add")]
        [HttpPost]
        public void LoadAlbumPictures(int id, int postId)
        {
            //_userSvc.Delete(id);
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
