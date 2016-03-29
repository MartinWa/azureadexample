
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Threading.Tasks;
using client2;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace client2
{
    public class Startup
    {
        private static readonly string ClientId = ConfigurationManager.AppSettings["ida:clientId"];
        private static readonly string AppKey = ConfigurationManager.AppSettings["ida:appKey"];
        private static readonly string AadInstance = ConfigurationManager.AppSettings["ida:aadInstance"];
        private static readonly string Tenant = ConfigurationManager.AppSettings["ida:tenant"];
        private static readonly string PostLogoutRedirectUri = ConfigurationManager.AppSettings["ida:postLogoutRedirectUri"];
        private static readonly string Authority = $"{AadInstance}{Tenant}";

        // ReSharper disable once UnusedMember.Global  Called by Owin startup
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
        }

        private static void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = ClientId,
                Authority = Authority,
                PostLogoutRedirectUri = PostLogoutRedirectUri,
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    AuthenticationFailed = contex =>
                    {
                        contex.HandleResponse();
                        contex.Response.Redirect("/Home/Error");
                        return Task.FromResult(0);
                    }
                }
            });
        }
    }
}