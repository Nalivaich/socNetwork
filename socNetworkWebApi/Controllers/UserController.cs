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
    public class UserController : ApiController
    {

        private IUserService  _userSvc;

        public UserController(IUserService userSvc)
        {
            _userSvc = userSvc;
        }
        // GET api/user
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/user/5
        public UserDTO Get(int id)
        {
            UserDTO user = _userSvc.Get(id);
            return user;
        }

        public IEnumerable<UserDTO> Post()
        {
            IEnumerable<UserDTO> userList = _userSvc.GetAll();
            return userList;
        }

        // POST api/user
        /*public void Post([FromBody]string value)
        {
        }*/

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
