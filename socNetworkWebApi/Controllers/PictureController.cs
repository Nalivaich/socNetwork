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
    public class PictureController : ApiController
    {

        private IPictureService  _pictureSvc;

        public PictureController(IPictureService pictureSvc)
        {
            _pictureSvc = pictureSvc;
        }

        [Route("api/pictures")]
        [HttpGet]
        public IEnumerable<PictureDTO> GetAll()
        {
            IEnumerable<PictureDTO> picturetList = _pictureSvc.GetAll();
            // In this case we must return all pictures files (not references!).
            return picturetList;
        }

        [Route("api/pictures/{id}")]
        [HttpGet]
        public PictureDTO GetById(int id)
        {
            PictureDTO picture = _pictureSvc.Get(id);
            return picture;
        }

        [Route("api/pictures/{id}/comments")]
        [HttpGet]
        public IEnumerable<CommentDTO> GetComments(int id)
        {
            IEnumerable<CommentDTO> pictureList = _pictureSvc.GetComments(id);
            return pictureList;
        }

        // PUT api/picture/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/picture/5
        public void Delete(int id)
        {
        }
    }
}
