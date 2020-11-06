using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharedFood.Startup))]
namespace SharedFood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
