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
    public class CommentController : ApiController
    {
        private ICommentService _commentSvc;

        public CommentController(ICommentService commentSvc)
        {
            _commentSvc = commentSvc;
        }

        [Route("api/comments")]
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<CommentDTO> GetAll()
        {
            IEnumerable<CommentDTO> commentList = _commentSvc.GetAll();
            return commentList;
        }

        [Route("api/comments/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public CommentDTO GetById(int id)
        {
            CommentDTO comment = _commentSvc.Get(id);
            return comment;
        }

        [Route("api/comments")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage Add(CommentDTO comment)
        {
            if (comment.comment != null)
            {
                comment.created = DateTime.Now;
                comment.modified = DateTime.Now;
                _commentSvc.Create(comment);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
