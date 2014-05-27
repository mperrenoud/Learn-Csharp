using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LCS101_002.Startup))]
namespace LCS101_002
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
