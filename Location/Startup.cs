using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Location.Startup))]
namespace Location
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
