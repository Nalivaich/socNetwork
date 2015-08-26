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

        // PUT api/album/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/album/5
        public void Delete(int id)
        {
        }
    }
}
