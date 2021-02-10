using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PatientenAkte.Web.Startup))]
namespace PatientenAkte.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
