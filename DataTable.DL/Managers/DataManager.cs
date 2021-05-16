using DataTable.Core.Database;
using DataTable.Core.Database.Configuration;
using System;

namespace DataTable.DL
{
    /// <summary>
    /// Data Manager
    /// </summary>
    public abstract class DataManager<K>
    where K : IDatabaseContext, new()
    {
        /// <summary>
        /// UoW object 
        /// </summary>
        protected readonly IUnitOfWork<K> _uow;

        /// <summary>
        /// Initialize the connection
        /// </summary>
        /// <param name="uow">UnitOfWork</param>
        public DataManager(IUnitOfWork<K> uow)
        {
            if (uow == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            _uow = uow;
        }
    }
}
