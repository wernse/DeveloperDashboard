using DeveloperDashboard.DbRepository.NoSQL;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using DeveloperDashboard.App_Start;

namespace DeveloperDashboard
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RavenConfig.Register();
            //NoSQL nosql = new NoSQL();
            //nosql.InitSchedules();
        }
    }
}
