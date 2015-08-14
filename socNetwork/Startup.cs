using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(socNetwork.Startup))]
namespace socNetwork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
