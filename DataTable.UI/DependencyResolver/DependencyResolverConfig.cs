using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Http;

namespace DataTable.DependencyResolver
{
    /// <summary>
    /// DependencyResolverConfig
    /// </summary>
    public static class DependencyResolverConfig
    {
        /// <summary>
        /// Register Resolver
        /// </summary>
        /// <param name="configuration"></param>
        public static void RegisterResolver()
        {
            var container = new Container();
            

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();

            // Register dependencies
            DataTable.BL.ResourceManifest.RegisterDependencies(container);

            container.Verify();

            System.Web.Mvc.DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}