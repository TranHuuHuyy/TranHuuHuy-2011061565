using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tranhuuhuy_2011061565.Startup))]
namespace tranhuuhuy_2011061565
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
