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
using System.Web.Security;
using System.Security.Principal;

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
            kernel.Bind<ICommentService>().To<CommentService>();

            DependencyResolver.SetResolver(new MyDependencyResolver(kernel));

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs args)
        {
            if (FormsAuthentication.CookiesSupported)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(
                          Request.Cookies[FormsAuthentication.FormsCookieName].Value);

                        args.User = new System.Security.Principal.GenericPrincipal(
                          new FormsIdentity(ticket),
                          new string[0]);
                    }
                    catch (Exception e)
                    {
                        // Decrypt method failed.
                    }
                }
            }
            else
            {
                throw new HttpException("Cookieless Forms Authentication is not " +
                                        "supported for this application.");
            }
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
        protected void Application_AuthenticateRequest(Object sender, EventArgs e) {
        // Extract the forms authentication cookie
        string cookieName = FormsAuthentication.FormsCookieName;
        HttpCookie authCookie = Context.Request.Cookies[cookieName];
        //if(authCookie.Name == "gigs")
        
        if(null == authCookie) {
        // There is no authentication cookie.
            return;
        }
        FormsAuthenticationTicket authTicket = null;
        try {
            authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        } catch(Exception ex) {
        // Log exception details (omitted for simplicity)
            return;
        }
        if (null == authTicket) {
        // Cookie failed to decrypt.
            return;
        }
        // When the ticket was created, the UserData property was assigned
        // a pipe delimited string of role names.
            
        string[] roles = new string[2];
        roles[0] = "user";
        // Create an Identity object
        FormsIdentity id = new FormsIdentity( authTicket );
        // This principal will flow throughout the request.
        GenericPrincipal principal = new GenericPrincipal(id, roles);
        // Attach the new principal object to the current HttpContext object
        Context.User = principal;
        }
            
        protected void Application_Error(Object sender, EventArgs e)
        {
            Response.Write("Error encountered.");
        }

    }
}