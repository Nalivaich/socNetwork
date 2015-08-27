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

namespace socNetworkWebApi.Controllers
{
    public class AlbumController : ApiController
    {
        private IAlbumService _albumSvc;

        public AlbumController(IAlbumService albumSvc)
        {
            _albumSvc = albumSvc;
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
