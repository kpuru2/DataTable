﻿using DataTable.BE;
using System.Collections.Generic;

namespace DataTable.Core.IServices
{
    /// <summary>
    /// ITransaction Manager
    /// </summary>
    public interface ITransactionManager
    {
        /// <summary>
        /// Get Payment Details
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="accountSearch"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        ICollection<PayementDetails> GetPaymentDetails(int pageNumber, int pageSize, string accountSearch, string sortColumn, string sortOrder);
    }
}
