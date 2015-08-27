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


        [Route("api/pictures/add")]
        [HttpPost]
        public HttpResponseMessage PutPicture()
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
            HttpContext.Current.Response.Status = "403 Forbidden";
            //the next line is untested - thanks to strider for this line
            HttpContext.Current.Response.StatusCode = 403;
            //the next line can result in a ThreadAbortException
            //Context.Response.End(); 
            HttpContext.Current.ApplicationInstance.CompleteRequest();

            return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

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
