using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VolkerBook.Startup))]
namespace VolkerBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
