using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LojaVirtualMVC.Startup))]
namespace LojaVirtualMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
