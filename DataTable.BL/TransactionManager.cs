using DataTable.BE;
using DataTable.Core.IServices;
using System.Collections.Generic;

namespace DataTable.BL
{
    /// <summary>
    /// Transaction Manager
    /// </summary>
    public class TransactionManager : ITransactionManager
    {
        private readonly IDataManager dataManager;

        /// <summary>
        /// Transaction Manager
        /// </summary>
        /// <param name="_dataManager"></param>
        public TransactionManager(IDataManager _dataManager)
        {
            dataManager = _dataManager;
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
            return dataManager.GetPaymentDetails(pageNumber, pageSize, accountSearch, sortColumn, sortOrder);
        }
    }
}
