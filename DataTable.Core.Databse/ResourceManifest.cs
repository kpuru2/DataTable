using DataTable.Core.Database.Configuration;
using SimpleInjector;

namespace DataTable.Core.Database
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
            container.Register<IUnitOfWork<SqlDatabaseContext>, UnitOfWork<SqlDatabaseContext>>();
            container.Register<IDatabaseContextFactory<SqlDatabaseContext>, DatabaseContextFactory<SqlDatabaseContext>>();
        }
    }
}
