using System.Configuration;
using System.IdentityModel.Tokens;
using backend;
using Microsoft.Owin;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace backend
{
    public class Startup
    {
        // ReSharper disable once UnusedMember.Global  Called by Owin startup
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
        }

        private static void ConfigureAuth(IAppBuilder app)
        {
            var activeDirectoryBearerAuthenticationOptions = new WindowsAzureActiveDirectoryBearerAuthenticationOptions
            {
                Tenant = ConfigurationManager.AppSettings["ida:tenant"],
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = ConfigurationManager.AppSettings["ida:audience"]
                }
            };
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(activeDirectoryBearerAuthenticationOptions);
        }
    }
}