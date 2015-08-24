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
    public class PostController : ApiController
    {
        
        private IPostService  _postSvc;

        public PostController(IPostService postSvc)
        {
            _postSvc = postSvc;
        }


        // GET api/post
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/post/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/post
        public void Post([FromBody]string value)
        {
        }

        // PUT api/post/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/post/5
        public void Delete(int id)
        {
        }
    }
}
