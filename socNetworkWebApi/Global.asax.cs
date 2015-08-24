using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Parameters;
using Common;
using Common.Interfaces;
using Common.Services;

namespace socNetworkWebApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IAlbumService>().To<AlbumService>();
            kernel.Bind<IPictureService>().To<PictureService>();

            DependencyResolver.SetResolver(new MyDependencyResolver(kernel));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public class MyDependencyResolver : IDependencyResolver
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
}