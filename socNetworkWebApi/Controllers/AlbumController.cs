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

        // GET api/album
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public AlbumDTO Get(int id)
        {
            AlbumDTO album = _albumSvc.Get(id);
            return album;
        }

        public IEnumerable<AlbumDTO> Post()
        {
            IEnumerable<AlbumDTO> albumList = _albumSvc.GetAll();
            return albumList;
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
