using backend;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace backend
{
    public class Startup
    {
        // ReSharper disable once UnusedMember.Global  Called by Owin startup
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private static void ConfigureAuth(IAppBuilder app)
        {
        }
    }
}
