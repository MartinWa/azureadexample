using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace backend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // Initial lower case in JSON
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc; //add 'Z' at the end of dates so browsers treat them the same way
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true }); // make JSON camel case
        }
    }
}
