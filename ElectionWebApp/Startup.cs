using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElectionWebApp.Startup))]
namespace ElectionWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
