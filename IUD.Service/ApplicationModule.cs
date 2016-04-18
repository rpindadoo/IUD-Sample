using Autofac;
using IUD.Service.Core;

namespace IUD.Service
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (IService<>).Assembly).Where(t => t.Name.EndsWith("Service")).AsClosedTypesOf(typeof (IService<>));
            builder.RegisterGeneric(typeof (BaseService<>)).As(typeof (IService<>));

            base.Load(builder);
        }
    }
}