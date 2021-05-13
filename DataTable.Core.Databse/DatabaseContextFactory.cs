namespace DataTable.Core.Database
{
    /// <summary>
    /// This class implements factory pattern for database context object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DatabaseContextFactory<T> : IDatabaseContextFactory<T>
        where T: IDatabaseContext, new()
    {
        private T dataContext;

        /// <summary>
        /// If data context remain null then initialize new context 
        /// </summary>
        /// <returns>dataContext</returns>
        public T Context()
        {
            if ((dataContext == null))
            {
                dataContext = new T();
            }
            return dataContext;
        }

        /// <summary>
        /// Dispose existing context
        /// </summary>
        public void Dispose()
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        }
    }
}
