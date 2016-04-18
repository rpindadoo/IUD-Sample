using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using IUD.Api;
using IUD.Api.ErrorHandling;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace IUD.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            DependencyConfig.RegisterDependencies(config);
            AutomapperConfig.RegisterMappings();

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            config.Services.Replace(typeof (IExceptionHandler), new ErrorHandler());
            app.Use<ErrorHandlerMiddleware>().UseWebApi(config);
        }
    }
}