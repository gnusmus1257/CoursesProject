using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BDCourse.Startup))]
namespace BDCourse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
