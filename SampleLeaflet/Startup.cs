using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeaftletSample.Startup))]
namespace LeaftletSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
