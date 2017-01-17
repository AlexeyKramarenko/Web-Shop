[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebShop.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebShop.App_Start.NinjectWebCommon), "Stop")]

namespace WebShop.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using DAL.Interfaces;
    using DAL;
    using Infrastructure;
    using AutoMapper;
    using ApplicationCore.ApplicationServices;
    using Ninject.Syntax;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Ninject.Parameters;
    using System.Web.Http.Dependencies;
    using Microsoft.AspNet.SignalR;
    using Models;
    using DAL.POCO;
    using ApplicationCore.DomainServices;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
        #region SignalR
        private class NinjectSignalRDependencyResolver : Microsoft.AspNet.SignalR.DefaultDependencyResolver
        {
            private readonly IKernel kernel;
            public NinjectSignalRDependencyResolver(IKernel kernel)
            {
                this.kernel = kernel;
            }

            public override object GetService(Type serviceType)
            {
                return kernel.TryGet(serviceType) ?? base.GetService(serviceType);
            }

            public override System.Collections.Generic.IEnumerable<object> GetServices(Type serviceType)
            {
                return kernel.GetAll(serviceType).Concat(base.GetServices(serviceType));
            }

        }
        private static void RegisterWithSignalr(IKernel kernel)
        {
            GlobalHost.DependencyResolver = new NinjectSignalRDependencyResolver(kernel);
        }
        #endregion
        #region WebAPi
        public class NinjectWebApiResolver : NinjectScope, System.Web.Http.Dependencies.IDependencyResolver
        {
            private readonly IKernel _kernel;
            public NinjectWebApiResolver(IKernel kernel)
                : base(kernel)
            {
                _kernel = kernel;
            }
            public IDependencyScope BeginScope()
            {
                return new NinjectScope(_kernel.BeginBlock());
            }
        }

        public class NinjectScope : System.Web.Http.Dependencies.IDependencyScope
        {
            protected IResolutionRoot resolutionRoot;
            public NinjectScope(IResolutionRoot kernel)
            {
                resolutionRoot = kernel;
            }
            public object GetService(Type serviceType)
            {
                Ninject.Activation.IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
                return resolutionRoot.Resolve(request).SingleOrDefault();
            }
            public IEnumerable<object> GetServices(Type serviceType)
            {
                Ninject.Activation.IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
                return resolutionRoot.Resolve(request).ToList();
            }
            public void Dispose()
            {
                IDisposable disposable = (IDisposable)resolutionRoot;
                if (disposable != null) disposable.Dispose();
                resolutionRoot = null;
            }
        }

        static void RegisterWithWebApi(IKernel kernel)
        {
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectWebApiResolver(kernel);
        }
        #endregion
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            IMapper mapper = config.CreateMapper();

            kernel.Bind<IMapper>().ToConstant(mapper);

            kernel.Bind<IOrderRepository>().To<OrderRepository>().InRequestScope();
            kernel.Bind<IProductRepository>().To<ProductRepository>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IMessageService>().To<MessageService>().InRequestScope();
            kernel.Bind<IOrderService>().To<OrderService>().InRequestScope();
        }
    }
}
