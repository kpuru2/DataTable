using DataTable.Core.Database;
using DataTable.Core.Database.Configuration;
using DataTable.Core.IServices;
using System;
using System.Collections.Generic;
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

    }
}
