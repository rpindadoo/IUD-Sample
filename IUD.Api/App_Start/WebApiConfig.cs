using System.Web.Http;

namespace IUD.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApiActionName", "api/{controller}/{action}/{id}", new {id = RouteParameter.Optional}, new {action = @"^[a-zA-Z]+$"});

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}