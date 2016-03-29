using System.Configuration;
using System.IdentityModel.Tokens;
using System.Threading.Tasks;
using backend;
using Microsoft.Owin;
using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.Owin.Security.OAuth;
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
                },
                Provider = new OAuthBearerAuthenticationProvider
                {
                    OnValidateIdentity = context =>
                    {
                        return Task.FromResult(0);
                    },
                    OnApplyChallenge = context =>
                    {
                        return Task.FromResult(0);
                    },
                    OnRequestToken = context =>
                    {
                        return Task.FromResult(0);
                    }
                }
            };
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(activeDirectoryBearerAuthenticationOptions);
        }
    }
}