using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamSite.Startup))]
namespace ExamSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
