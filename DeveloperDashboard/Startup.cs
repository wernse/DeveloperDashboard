using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeveloperDashboard.Startup))]
namespace DeveloperDashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
