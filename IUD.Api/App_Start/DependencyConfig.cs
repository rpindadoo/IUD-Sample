using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using IUD.DataAccess;
using IUD.Service;

namespace IUD.Api
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers
            //Register any other components required by your code....

            builder.RegisterModule(new DataAccessModule());
            builder.RegisterModule(new ApplicationModule());


            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}