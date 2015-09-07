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
using System.IO;
using System.Web;
using System.Web.Security;

namespace socNetworkWebApi.Controllers
{
    public class PostController : ApiController
    {
        
        private IPostService  _postSvc;
        private IUserService _userSvc;
        private IPictureService _pictureSvc;

        public PostController(IPostService postSvc, IUserService userSvc, IPictureService pictureSvc)
        {
            _postSvc = postSvc;
            _userSvc = userSvc;
            _pictureSvc = pictureSvc;
        }

        [Route("api/posts")]
        [HttpGet]
        [Authorize]
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

        [Route("api/posts/{id}/pictures")]
        [HttpGet]
        public IEnumerable<PictureDTO> GetPictures(int id)
        {
            IEnumerable<PictureDTO> picturesList = _postSvc.GetPictures(id);
            return picturesList;
        }

        [Route("api/posts/{id}/comments")]
        [HttpGet]
        public IEnumerable<CommentDTO> GetComments(int id)
        {
            IEnumerable<CommentDTO> commentList = _postSvc.GetComments(id);
            return commentList;
        }

        [Route("api/posts/add")]
        [HttpPost]
        public void CreatePost(PostDTO post)
        {
            post.created = DateTime.Now;
            post.modified = DateTime.Now;
            int newPostId = _postSvc.Create(post); // i need new post id for next actions

            var names = post.picturesName.ToArray();
            UserDTO user = _userSvc.Get(post.userId);

            string rootPath = HttpContext.Current.Request.MapPath("~/Temp/");
            string tempDirectoryPath = Path.Combine(rootPath, user.email);

            rootPath = HttpContext.Current.Request.MapPath("~/Pictures/");
            string userDirectoryPath = Path.Combine(rootPath, user.email);
            if (!Directory.Exists(userDirectoryPath))
            {
                string standartImageDirectoryPath = Path.Combine(userDirectoryPath, "Standart");
                string mediumImageDirectoryPath = Path.Combine(userDirectoryPath, "Medium");
                string smallImageDirectoryPath = Path.Combine(userDirectoryPath, "Small");
                Directory.CreateDirectory(userDirectoryPath);
                Directory.CreateDirectory(standartImageDirectoryPath);
                Directory.CreateDirectory(mediumImageDirectoryPath);
                Directory.CreateDirectory(smallImageDirectoryPath);
            }

            if (Directory.Exists(tempDirectoryPath))
            {
                var httpRequest = HttpContext.Current.Request;
                if (names.Length > 0)
                {
                    foreach (string name in names)
                    {
                        try
                        {
                            if (!File.Exists(tempDirectoryPath + "/Standart/" + name))
                            {
                                using (FileStream fs = File.Create(tempDirectoryPath + "/Standart/" + name)) { }
                            }
                            File.Move(tempDirectoryPath + "/Standart/" + name, userDirectoryPath + "/Standart/" + name);
                            File.Move(tempDirectoryPath + "/Medium/" + name, userDirectoryPath + "/Medium/" + name);
                            File.Move(tempDirectoryPath + "/Small/" + name, userDirectoryPath + "/Small/" + name);
                        }
                        catch (Exception e)
                        {
                            throw new Exception("file has not been moved", e.InnerException);
                        }
                        _pictureSvc.Create(new PictureDTO
                        {
                            urlStandart = Convert.ToString("Pictures/" + user.email + "/Standart/" + name),
                            urlMedium = Convert.ToString("Pictures/" + user.email + "/Medium/" + name),
                            urlSmall = Convert.ToString("Pictures/" + user.email + "/Small/" + name),
                            postId = newPostId,
                            userId = post.userId,
                            likes = 0
                        });
                    }
                }
            }
            else
            {
                throw new Exception();
            }
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
