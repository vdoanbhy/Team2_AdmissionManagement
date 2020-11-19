using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Team2_AdmissionManagement.Startup))]
namespace Team2_AdmissionManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
