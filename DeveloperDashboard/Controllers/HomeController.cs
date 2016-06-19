using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeveloperDashboard.Controllers
{
    public class HomeController : Controller
    {
        [Route("~/", Name = "default")]
        public ActionResult Index()
        {
            return View();
        }
    }
}