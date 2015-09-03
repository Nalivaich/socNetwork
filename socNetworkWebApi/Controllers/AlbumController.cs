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
using System.IO;
using socNetworkWebApi.Environment.DataProvider;

namespace socNetworkWebApi.Controllers
{
    public class AlbumController : ApiController
    {
        private IAlbumService _albumSvc;
        private IUserService _userSvc;
        private IPictureService _pictureSvc;

        public AlbumController(IAlbumService albumSvc, IUserService userSvc, IPictureService pictureSvc)
        {
            _albumSvc = albumSvc;
            _userSvc = userSvc;
            _pictureSvc = pictureSvc;
        }

        [Route("api/albums")]
        [HttpGet]
        public IEnumerable<AlbumDTO> GetAll()
        {
            IEnumerable<AlbumDTO> albumList = _albumSvc.GetAll();
            return albumList;
        }

        [Route("api/albums/{id}")]
        [HttpGet]
        public AlbumDTO GetById(int id)
        {
            AlbumDTO album = _albumSvc.Get(id);
            return album;
        }

        [Route("api/albums/{id}/comments")]
        [HttpGet]
        public IEnumerable<CommentDTO> GetComments(int id)
        {
            IEnumerable<CommentDTO> commentList = _albumSvc.GetComments(id);
            return commentList;
        }

        [Route("api/albums/{id}/pictures/add")]
        [HttpPost]
        public HttpResponseMessage AddPictures(int id)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/DownloadResource/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    // NOTE: To store in memory use postedFile.InputStream
                }

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                //HttpContext.Current.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden; //or make this
                /*
                HttpContext.Current.Response.Status = "403 Forbidden";
                HttpContext.Current.Response.StatusCode = 403;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                */
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/albums/add")]
        [HttpPost]
        public void GetComments(AlbumDTO newObj)
        {
            newObj.created = DateTime.Now;
            newObj.modified = DateTime.Now;
            _albumSvc.Create(newObj);
        }

        [Route("api/albums/manage")]
        [HttpPatch]
        public void ManageAlbum(AlbumDTO album)
        {
            album.modified = DateTime.Now;
            _albumSvc.Update(album);
            var names = album.picturesName.ToArray();
            UserDTO user = _userSvc.Get(album.userId);

            string rootPath = HttpContext.Current.Request.MapPath("~/Temp/");
            string tempDirectoryPath = Path.Combine(rootPath, user.email);

            rootPath = HttpContext.Current.Request.MapPath("~/Pictures/");
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

            if (Directory.Exists(tempDirectoryPath))
            {
                var httpRequest = HttpContext.Current.Request;
                if (names.Length > 0)
                {
                    foreach (string name in names)
                    {
                        try
                        {
                            if (!File.Exists(tempDirectoryPath + "/Standart/" + name))
                            {
                                using (FileStream fs = File.Create(tempDirectoryPath + "/Standart/" + name)) { }
                            }
                            /*if (File.Exists(userDirectoryPath + "/Standart/" + name)) // Думаю можно не проверять, имена уникальны
                                File.Delete(userDirectoryPath + "/Standart/" + name);
                            */
                            File.Move(tempDirectoryPath + "/Standart/" + name, userDirectoryPath + "/Standart/" + name);
                            File.Move(tempDirectoryPath + "/Medium/" + name, userDirectoryPath + "/Medium/" + name);
                            File.Move(tempDirectoryPath + "/Small/" + name, userDirectoryPath + "/Small/" + name);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("file has not been moved",e.InnerException);
                        }
                        _pictureSvc.Create(new PictureDTO
                        {
                            urlStandart = Convert.ToString("Pictures/" + user.email + "/Standart/" + name),
                            urlMedium = Convert.ToString("Pictures/" + user.email + "/Medium/" + name),
                            urlSmall = Convert.ToString("Pictures/" + user.email + "/Small/" + name),
                            albumId = album.id,
                            userId = album.userId,
                            likes = 0
                        });
                    }
                }
            }
            else
            {
                throw new Exception();
            }

        }

        // PUT api/album/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("api/albums/update")]
        [HttpPatch]
        public void DeleteAlbum(AlbumDTO newObj)
        {
            // change not nullable fields only
        }


        [Route("api/albums/delete/{id}")]
        [HttpDelete]
        public void PutAlbum(int id)
        {
            _albumSvc.Delete(id);
        }
    }
}
