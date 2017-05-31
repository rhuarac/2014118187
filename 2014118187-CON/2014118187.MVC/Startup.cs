using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2014118187.MVC.Startup))]
namespace _2014118187.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
