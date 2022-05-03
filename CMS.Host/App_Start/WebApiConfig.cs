using System.Web.Http;

namespace CMS.Host
{
    class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            configuration.Formatters.Add(new BrowserJsonFormatter());
        }
    }
}
