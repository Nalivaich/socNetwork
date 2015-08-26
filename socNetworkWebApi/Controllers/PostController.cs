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


        [Route("api/posts")]
        [HttpGet]
        public IEnumerable<PostDTO> GetAll()
        {
            IEnumerable<PostDTO> postList = _postSvc.GetAll();
            return postList;
        }

        [Route("api/posts/{id}")]
        [HttpGet]
        public PostDTO GetById(int id)
        {
            PostDTO post = _postSvc.Get(id);
            return post;
        }

        [Route("api/posts/{id}/comments")]
        [HttpGet]
        public IEnumerable<CommentDTO> GetComments(int id)
        {
            IEnumerable<CommentDTO> commentList = _postSvc.GetComments(id);
            return commentList;
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
