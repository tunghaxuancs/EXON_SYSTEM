using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EXON.Web.Startup))]
namespace EXON.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
