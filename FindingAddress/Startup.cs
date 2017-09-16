using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FindingAddress.Startup))]
namespace FindingAddress
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
