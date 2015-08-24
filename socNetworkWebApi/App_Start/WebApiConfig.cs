using Common.Interfaces;
using Common.Services;
using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace socNetworkWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IAlbumService>().To<AlbumService>();
            kernel.Bind<IPictureService>().To<PictureService>();

            config.DependencyResolver = new MyDependencyResolver(kernel);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }

        public class MyDependencyResolver : IDependencyResolver, IDependencyScope
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


            public void Dispose()
            {
                
            }

            public IDependencyScope BeginScope()
            {
                return this;
            }
        }
    }
}
