using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eRef.MVC.Startup))]
namespace eRef.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
