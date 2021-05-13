using DataTable.Core.IServices;
using SimpleInjector;

namespace DataTable.BL
{
    /// <summary>
    /// This class registers dependencies with Simple Injector.
    /// </summary>
    public static class ResourceManifest
    {
        /// <summary>
        /// This method register dependencies
        /// </summary>
        /// <param name="container"></param>
        public static void RegisterDependencies(Container container)
        {
            DataTable.DL.ResourceManifest.RegisterDependencies(container);
            container.Register<ITransactionManager, TransactionManager>();
        }
    }
}
