using System.Data.Common;

namespace DataTable.Core.Database
{
    /// This interface proides a base structure to various Database context objects.
    /// </summary>
    public interface IDatabaseContext
    {
        /// <summary>
        /// Connection property
        /// </summary>
        DbConnection Connection { get; }

        /// <summary>
        /// clean up resources
        /// </summary>
        void Dispose();
    }
}
