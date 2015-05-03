using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleLeaflet.Startup))]
namespace SampleLeaflet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
