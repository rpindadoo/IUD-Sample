using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Autofac;

namespace IUD.Api
{
    public class AutofacWebApiDependenceResolver : IDependencyResolver
    {
        private readonly IComponentContext container;

        public AutofacWebApiDependenceResolver(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }
            object ret = container.ResolveOptional(serviceType);
            return ret;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }
            Type enumerableType = typeof (IEnumerable<>).MakeGenericType(serviceType);
            var ret = (IEnumerable<object>) container.ResolveOptional(enumerableType);
            return ret;
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}