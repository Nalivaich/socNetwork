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
        // GET api/picture
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/picture/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/picture
        public void Post([FromBody]string value)
        {
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
