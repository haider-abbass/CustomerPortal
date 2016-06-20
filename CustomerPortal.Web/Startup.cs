using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerPortal.Web.Startup))]
namespace CustomerPortal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
