using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopOnlineClient.Startup))]
namespace ShopOnlineClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
