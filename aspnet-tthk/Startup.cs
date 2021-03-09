using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aspnet_tthk.Startup))]
namespace aspnet_tthk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
