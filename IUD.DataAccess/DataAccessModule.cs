using Autofac;
using IUD.DataAccess.Context;
using IUD.DataAccess.Repository;
using IUD.DataAccess.Repository.MsSQL;

namespace IUD.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbEntities>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof (GenericRepository<>)).As(typeof (IRepository<>));

            base.Load(builder);
        }
    }
}