using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChateauDreams.Startup))]
namespace ChateauDreams
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        
    }
}
