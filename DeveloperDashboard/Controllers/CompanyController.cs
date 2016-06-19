using DeveloperDashboard.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeveloperDashboard.Controllers
{
    [RoutePrefix("Company")]
    public class CompanyController : ApiController
    {
        private readonly Company _company = new Company();
        /// <summary>
        /// GET	/Company/GetAllCompanies
        /// </summary>
        /// <returns>Json list of companies</returns>
        [HttpGet]
        [Route("GetAllCompanies")]
        public IHttpActionResult GetAllCompanies()
        {
            IEnumerable<Company> companies = _company.GetAllCompanies();
            return Json(companies);
        }

    }
}
