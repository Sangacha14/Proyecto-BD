using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pagina_Agripac.Startup))]
namespace Pagina_Agripac
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
