using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ships6.Startup))]
namespace Ships6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
