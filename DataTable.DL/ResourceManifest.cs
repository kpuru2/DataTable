using DataTable.Core.IServices;
using DataTable.DL.Converters;
using SimpleInjector;

namespace DataTable.DL
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
            DataTable.Core.Database.ResourceManifest.RegisterDependencies(container);
            container.Register<IDataManager, TransactionManager>();
            container.Register<IConverter, TransactionConverter>();
        }
    }
}
