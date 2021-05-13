using System.Data.Common;

namespace DataTable.Core.Database.Configuration
{
    /// <summary>
    /// This interface provides structure to UoW implementation.
    /// </summary>
    /// <typeparam name="T">database context object</typeparam>
    public interface IUnitOfWork<T>
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        IDatabaseContextFactory<T> DataContext { get; }

        /// <summary>
        /// Begin database transaction
        /// </summary>
        /// <returns>transaction object</returns>
        DbTransaction BeginTransaction();

        /// <summary>
        /// Commit.
        /// </summary>
        void Commit();
    }
}
