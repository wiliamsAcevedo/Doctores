using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DOCTORESPAGINA.Startup))]
namespace DOCTORESPAGINA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
