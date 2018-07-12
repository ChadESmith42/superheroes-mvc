using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperheroesInc.UI.MVC.Startup))]
namespace SuperheroesInc.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
