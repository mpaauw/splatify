using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Splatify.SPA.Startup))]
namespace Splatify.SPA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
