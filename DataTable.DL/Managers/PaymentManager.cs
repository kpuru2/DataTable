using Dapper;
using DataTable.BE;
using DataTable.Core.Database;
using DataTable.Core.Database.Configuration;
using DataTable.Core.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTable.DL
{
    /// <summary>
    /// Payment Manager
    /// </summary>
    public sealed class PaymentManager : DataManager<SqlDatabaseContext>, IDataManager
    {
        /// <summary>
        /// Initialize the connection
        /// </summary>
        /// <param name="uow">UnitOfWork</param>
        public PaymentManager(IUnitOfWork<SqlDatabaseContext> uow)
            : base(uow)
        {
            
        }

        /// <summary>
        /// Get Payment Details
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="accountSearch"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public ICollection<PayementDetails> GetPaymentDetails(int pageNumber, int pageSize, string accountSearch, string sortColumn, string sortOrder)
        {
            try
            {
                var para = new DynamicParameters();
                para.Add(Constants.StoredProcedure.GetPaymentDetails.Parameters.PageNumber, pageNumber, DbType.Int32);
                para.Add(Constants.StoredProcedure.GetPaymentDetails.Parameters.PageSize, pageSize, DbType.Int32);
                para.Add(Constants.StoredProcedure.GetPaymentDetails.Parameters.AccountSearch, accountSearch, DbType.String);
                para.Add(Constants.StoredProcedure.GetPaymentDetails.Parameters.SortColumn, sortColumn, DbType.String);
                para.Add(Constants.StoredProcedure.GetPaymentDetails.Parameters.SortOrder, sortOrder, DbType.String);

                return _uow.DataContext.Context().Connection.Query<PayementDetails>(Constants.StoredProcedure.GetPaymentDetails.Name,
                                                                             para, commandType: CommandType.StoredProcedure).ToList();
            }
            finally
            {
                _uow.DataContext.Context().Connection.Close();
            }
        }
    }
}
