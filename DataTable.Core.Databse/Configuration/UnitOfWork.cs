using System;
using System.Data.Common;

namespace DataTable.Core.Database.Configuration
{
    /// <summary>
    /// This class implments UoW pattern for sharing database context across repositories.
    /// </summary>
    /// <typeparam name="T">Type of Database context object</typeparam>
    public sealed class UnitOfWork<T> : IUnitOfWork<T>
        where T : IDatabaseContext, new()
    {
        private readonly IDatabaseContextFactory<T> _databaseFactory;
        private T _context;

        /// <summary>
        /// Transaction to database
        /// </summary>
        public DbTransaction Transaction { get; private set; }

        /// <summary>
        /// Constructor which will initialize the datacontext factory
        /// </summary>
        /// <param name="_factory">datacontext factory</param>
        public UnitOfWork(IDatabaseContextFactory<T> _factory)
        {
            _databaseFactory = _factory;
            _context = _factory.Context();
        }

        /// <summary>
        /// Following method will use to Commit or Rollback memory data into database
        /// </summary>
        public void Commit()
        {
            if (Transaction != null)
            {
                try
                {
                    Transaction.Commit();
                }
                catch (Exception)
                {
                    Transaction.Rollback();
                }
                Transaction.Dispose();
                Transaction = null;
            }
            else
            {
                throw new NullReferenceException("Tryed commit not opened transaction");
            }
        }

        /// <summary>
        /// Define a property of context class
        /// </summary>
        public IDatabaseContextFactory<T> DataContext
        {
            get
            {
                return _databaseFactory;
            }
        }

        /// <summary>
        /// Begin a database transaction
        /// </summary>
        /// <returns>Transaction</returns>
        public DbTransaction BeginTransaction()
        {
            if (Transaction != null)
            {
                throw new NullReferenceException("Not finished previous transaction");
            }
            Transaction = _context.Connection.BeginTransaction();
            return Transaction;
        }

        /// <summary>
        /// dispose a Transaction.
        /// </summary>
        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
            }
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
