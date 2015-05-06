using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quacka.Startup))]
namespace Quacka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
