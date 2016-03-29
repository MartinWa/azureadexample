using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace client2.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {
        private static readonly string ClientId = ConfigurationManager.AppSettings["ida:clientId"];
        private static readonly string AppKey = ConfigurationManager.AppSettings["ida:appKey"];
        private static readonly string AadInstance = ConfigurationManager.AppSettings["ida:aadInstance"];
        private static readonly string Tenant = ConfigurationManager.AppSettings["ida:tenant"];
        private static readonly string Authority = $"{AadInstance}{Tenant}";
        private static readonly AuthenticationContext AuthContext = new AuthenticationContext(Authority);
        private static readonly ClientCredential ClientCredential = new ClientCredential(ClientId, AppKey);

        // appID of the web api
        private static readonly string ServiceResourceId = ConfigurationManager.AppSettings["ida:serviceResourceId"];
        private const string ServiceBaseAddress = "https://localhost:44310/"; // base url of the web api

        // GET: Location
        public async Task<ActionResult> Index()
        {
            AuthenticationResult result = null;

            var retryCount = 0;
            bool retry;
            do
            {
                retry = false;
                try
                {
                    result = AuthContext.AcquireToken(ServiceResourceId, ClientCredential);
                }
                catch (AdalException ex)
                {
                    if (ex.ErrorCode != "temporarily_unavailable") continue;
                    retry = true;
                    retryCount++;
                    Thread.Sleep(3000);
                }
            } while (retry && (retryCount < 3));


            if (result == null)
            {
                ViewBag.ErrorMessage = "UnexpectedError";
                return View("Index");
            }

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, ServiceBaseAddress + "api/location?cityName=dc");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var r = await response.Content.ReadAsStringAsync();
                ViewBag.Results = r;
                return View("Index");
            }
            await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                AuthContext.TokenCache.Clear();
            }
            ViewBag.ErrorMessage = "AuthorizationRequired";
            return View("Index");
        }
    }
}