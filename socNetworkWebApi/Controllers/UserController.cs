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
using Newtonsoft.Json.Linq;
using AutoMapper;
using System.Web.Helpers;
using ExtensionMethods;
using Newtonsoft.Json;
using System.Web.Http.Results;
using System.Web.Security;

namespace socNetworkWebApi.Controllers
{
    public class FilesUploadResult
    {
        [JsonProperty("files")]
        public List<FileUploadResult> Files { get; set; }
    }

    [JsonObject]
    public class FileUploadResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("newName")]
        public string NewName { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }
        [JsonProperty("deleteUrl")]
        public string DeleteUrl { get; set; }
        [JsonProperty("deleteType")]
        public string DeleteType { get; set; }
    }
    public class UserController : ApiController
    {

        private IUserService _userSvc;
        private IPictureService _pictureSvc;

        public UserController(IUserService userSvc, IPictureService pictureSvc)
        {
            _userSvc = userSvc;
            _pictureSvc = pictureSvc;
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
            string rootPath = HttpContext.Current.Request.MapPath("~/");
            var pictureList = _userSvc.GetUserPhotos(id);
            foreach(PictureDTO picture in pictureList)
            {
                picture.urlStandart = Path.Combine(rootPath, picture.urlStandart);
                picture.urlMedium = Path.Combine(rootPath, picture.urlMedium);
                picture.urlSmall = Path.Combine(rootPath, picture.urlSmall);
            }
            return pictureList;
            /*IEnumerable<PictureDTO> pictureList = _userSvc.GetUserPhotos(id);
            return pictureList;*/
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

        [Route("api/users")]
        [HttpPost]
        public string LogIn( Login user)
        {
            if (ModelState.IsValid)
            {
                //UserManager UM = new UserManager();

                UserDTO foundUser = _userSvc.FindUser(user); // add new method in UserRervice for comparing user`s name & password 

                if (string.IsNullOrEmpty(foundUser.alias) || string.IsNullOrEmpty(foundUser.password))
                {
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                }
                else
                {
                    if (user.password.Equals(foundUser.password))
                    {
                        FormsAuthentication.SetAuthCookie(user.name, false);
                        //return RedirectToAction("Welcome", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }

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
        public FilesUploadResult LoadPostPictures(int id)
        {
            List<string> result = new List<string>();
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
                FilesUploadResult res = new FilesUploadResult { };
                foreach (string file in httpRequest.Files)
                {

                    var postedFile = httpRequest.Files[file];
                    result.Add(Convert.ToString(Guid.NewGuid() + Path.GetExtension(postedFile.FileName)));
                    var standartImagePath = HttpContext.Current.Server.MapPath("~/temp/" + user.email + "/Standart/" + result.Last());
                    var mediumImagePath = HttpContext.Current.Server.MapPath("~/temp/" + user.email + "/Medium/" + result.Last());
                    var smallImagePath = HttpContext.Current.Server.MapPath("~/temp/" + user.email + "/Small/" + result.Last());
                    postedFile.SaveAs(standartImagePath);
                    PictureProvider.SaveMiniatureImage(standartImagePath, mediumImagePath, 200);
                    PictureProvider.SaveMiniatureImage(standartImagePath, smallImagePath, 100);
                    res.Files = new List<FileUploadResult>
                        {
                            new FileUploadResult {
                                Name = postedFile.FileName,
                                Size = postedFile.ContentLength,
                                Url = "/temp/" + user.email + "/Standart/" + result.Last(),
                                DeleteUrl = "http://test",
                                DeleteType = "DELETE",
                                ThumbnailUrl = "/temp/" + user.email + "/Medium/" + result.Last(),
                                NewName = result.Last()
                            }
                        };

                }
                //return result;
                return res;

                //List<FileUploadResult> images = new List<FileUploadResult>{
                //  new FileUploadResult{name = "picture1.jpg", size = 902604, url = "Gurthie", thumbnailUrl = "" , deleteUrl = "",deleteType = ""}
                //  };
                //var jsonUser = images.ToJSON(); //= JsonConvert.SerializeObject(new FileUploadResult { name = "picture1.jpg", size = 902604, url = "Gurthie", thumbnailUrl = "", deleteUrl = "", deleteType = "" });
                ////return jsonUser;
                ////return Json(new Responce { name = "picture1.jpg", size = 902604, url = "Gurthie", thumbnailUrl = "", deleteUrl = "", deleteType = "" });

                //return Request.CreateResponse(HttpStatusCode.Created, jsonUser);
                //return images.ToJSON(); 
                /*       {"files": [
                              {
                                "name": "picture1.jpg",
                                "size": 902604,
                                "url": "http:\/\/example.org\/files\/picture1.jpg",
                                "thumbnailUrl": "http:\/\/example.org\/files\/thumbnail\/picture1.jpg",
                                "deleteUrl": "http:\/\/example.org\/files\/picture1.jpg",
                                "deleteType": "DELETE"
                              },
                              {
                                "name": "picture2.jpg",
                                "size": 841946,
                                "url": "http:\/\/example.org\/files\/picture2.jpg",
                                "thumbnailUrl": "http:\/\/example.org\/files\/thumbnail\/picture2.jpg",
                                "deleteUrl": "http:\/\/example.org\/files\/picture2.jpg",
                                "deleteType": "DELETE"
                              }
                            ]}*/
            }
            else
            {
                throw new Exception();
                //return Json(new Responce { name = "picture1.jpg", size = 902604, url = "Gurthie", thumbnailUrl = "", deleteUrl = "", deleteType = "" });
                //return result;
                //return Request.CreateResponse(HttpStatusCode.BadRequest);
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


        [Route("api/users/{id}/albums/{albumId}/manage")]
        [HttpPatch]
        public void CreatePost(int id, int albumId, Object json)
        {
            //string str = json.name;
            //JObject jObject = JObject.Parse((String)json);
            //_userSvc.Delete(id);
            // we can change isRemoved flag simply & don`t remove user from DB
        }

        [Route("api/users/{id}/posts/create")]
        [HttpPatch]
        public void ManagingAlbum(int id, int postId)
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
