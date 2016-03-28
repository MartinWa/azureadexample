using System.Web.Http;
using backend.Models;

namespace backend.Controllers
{
    [RoutePrefix("api/location")]
    [Authorize]
    public class LocationController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var model = new LocationViewModel
            {
                Latitude = 10,
                Longitude = 20
            };
            return Ok(model);
        }
    }
}
