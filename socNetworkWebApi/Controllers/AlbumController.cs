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

        public AlbumController(IAlbumService albumSvc, IUserService userSvc)
        {
            _albumSvc = albumSvc;
            _userSvc = userSvc;
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
            var names = album.picturesName.ToArray();
            List<string> result = new List<string>();
            UserDTO user = _userSvc.Get(album.userId);
            string rootPath = HttpContext.Current.Request.MapPath("~/Temp/");
            string userDirectoryPath = Path.Combine(rootPath, user.email);
            if (Directory.Exists(userDirectoryPath))
            {
                var httpRequest = HttpContext.Current.Request;
                if (names.Length > 0)
                {
                    //FilesUploadResult res = new FilesUploadResult { };
                    foreach (string name in names)
                    {

                        var pp =  System.IO.Directory.GetFiles(userDirectoryPath + "/Standart/", name);
                        /*var postedFile = httpRequest.Files[file];
                        result.Add(Convert.ToString(Guid.NewGuid() + Path.GetExtension(postedFile.FileName)));
                        var standartImagePath = HttpContext.Current.Server.MapPath("~/temp/" + user.email + "/Standart/" + result.Last());
                        var mediumImagePath = HttpContext.Current.Server.MapPath("~/temp/" + user.email + "/Medium/" + result.Last());
                        var smallImagePath = HttpContext.Current.Server.MapPath("~/temp/" + user.email + "/Small/" + result.Last());
                        postedFile.SaveAs(standartImagePath);
                        PictureProvider.SaveMiniatureImage(standartImagePath, mediumImagePath, 200);
                        PictureProvider.SaveMiniatureImage(standartImagePath, smallImagePath, 100);*/

                        /*res.Files = new List<FileUploadResult>
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
                        };*/

                    }
                    //return res;

                }
            }

            else
            {
                throw new Exception();
            }



            //string str = json.name;
            //JObject jObject = JObject.Parse((String)json);
            //_userSvc.Delete(id);
            // we can change isRemoved flag simply & don`t remove user from DB
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
