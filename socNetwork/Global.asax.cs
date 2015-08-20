using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Parameters;
using Common;


namespace socNetwork
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<ITextService>().To<MyTextService>();

            DependencyResolver.SetResolver(new MyDependencyResolver(kernel));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

    public class MyDependencyResolver: IDependencyResolver
    {
        private IKernel _kernel;
        
        public MyDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType, new IParameter[0]);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType, new IParameter[0]);
        }
        
    }
}
