using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quadridge2.Startup))]
namespace Quadridge2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
