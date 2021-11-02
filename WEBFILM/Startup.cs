using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEBFILM.Startup))]
namespace WEBFILM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
