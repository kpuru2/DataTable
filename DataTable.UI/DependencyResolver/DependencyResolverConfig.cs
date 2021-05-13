using SimpleInjector;
using System.Web.Http;

namespace DataTable.DependencyResolver
{
    /// <summary>
    /// DependencyResolverConfig
    /// </summary>
    public static class DependencyResolverConfig
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="configuration"></param>
        public static void Register(HttpConfiguration configuration)
        {
            var container = new Container();
            DataTable.BL.ResourceManifest.RegisterDependencies(container);
        }
    }
}