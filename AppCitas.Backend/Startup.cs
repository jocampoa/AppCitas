using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppCitas.Backend.Startup))]
namespace AppCitas.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
