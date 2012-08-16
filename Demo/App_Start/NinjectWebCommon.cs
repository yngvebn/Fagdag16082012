using Demo.Infrastructure.Services;
using DomainEventExtensions;
using DomainEvents.Ninject;
using HttpModuleMagic;
using Ninject.Activation;
using SignalR;
using IDependencyResolver = DomainEventExtensions.IDependencyResolver;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Demo.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Demo.App_Start.NinjectWebCommon), "Stop")]

namespace Demo.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;

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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            kernel.Bind(syntax => syntax
                .FromThisAssembly()
                .SelectAllTypes()
                .InNamespaces("Demo.Infrastructure.DomainEventHandlers")
                .BindAllInterfaces()
                .Configure(binding => binding.InSingletonScope()));
            kernel.Bind<IEmailSender>().To<EmailSender>();
            kernel.Bind(
                syntax => syntax
                    .FromAssemblyContaining<IDomainEvent>()
                    .SelectAllClasses()
                    .BindDefaultInterface()
                    .Configure(binding => binding.InSingletonScope()));
            kernel.Bind<IDependencyResolver>().To<NinjectDependencyResolver>();
            GlobalHost.DependencyResolver = new SignalR.Ninject.NinjectDependencyResolver(kernel);
            RegisterServices(kernel);
            return kernel;
        }


        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }
}
