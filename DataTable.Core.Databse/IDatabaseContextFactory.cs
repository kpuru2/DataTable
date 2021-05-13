namespace DataTable.Core.Database
{
    /// <summary>
    /// This interface provides structure to a factory implementation of Database Context
    /// </summary>
    /// <typeparam name="T">Type of Database context object.</typeparam>
    public interface IDatabaseContextFactory<T>
    {
        /// <summary>
        /// get Database context reference
        /// </summary>
        /// <returns>Type of Database context object</returns>
        T Context();
    }
}
