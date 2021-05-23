using DataTable.Core.IServices;
using System.Web.Mvc;

namespace DataTable.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    public class BaseController : Controller
    {
        protected readonly ITransactionManager transactionManager;

        /// <summary>
        /// Initialize Base Controller
        /// </summary>
        /// <param name="_transactionManager"></param>
        public BaseController(ITransactionManager _transactionManager)
        {
            transactionManager = _transactionManager;
        }
    }
}