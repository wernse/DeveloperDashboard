using DeveloperDashboard.DbRepository;
using DeveloperDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeveloperDashboard.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        private readonly User _user = new User();

        /// <summary>
        /// GET /User/GetAllUsers
        /// </summary>
        /// <returns>Json list of users</returns>
        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            IEnumerable<User> users = _user.GetAllUsers();
            return Json(users);
        }

    }
}
