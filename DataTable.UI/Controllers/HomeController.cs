using DataTable.BE;
using DataTable.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTable.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : BaseController
    {

        public HomeController(ITransactionManager _transactionManager)
            :base(_transactionManager)
        {

        }

        public ActionResult Index()
        {
            ICollection<PayementDetails> details = this.transactionManager.GetPaymentDetails(1, 20, null, null, null);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}