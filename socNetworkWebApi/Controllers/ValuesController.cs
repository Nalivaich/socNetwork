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
    public class ValuesController : ApiController 
    {

        private IUserService  _userSvc;
        private IAlbumService _albumSvc;
        private IPostService _postSvc;
        private IPictureService _pictureSvc;



        public ValuesController(IUserService userSvc, IAlbumService albumSvc, IPostService postSvc, IPictureService pictureSvc)
        {
            _userSvc = userSvc;
            _albumSvc = albumSvc;
            _postSvc = postSvc;
            _pictureSvc = pictureSvc;
        }


        // GET api/values
        public IEnumerable<string> Get(string cmd)
        {
            return new string[] { "value1", "value2" };
        }

        public IEnumerable<UserDTO> Post()
        {
            IEnumerable<UserDTO> userList = _userSvc.GetAll();
            return userList;
        }
        // GET api/values
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        // GET api/values/5
        /*public string Get(int id)
        {
            return "value";
        }*/

        // POST api/values
        /*public void Post([FromBody]string value)
        {
        }*/

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}