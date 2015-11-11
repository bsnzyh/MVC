using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace P02MVCAjax.Controllers
{
    public class AjaxHelperController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Part()
        {
            Thread.Sleep(3000);
            return PartialView();
        }

        public ActionResult GetTime()
        {
            string text = Request["Text"];
            Thread.Sleep(3000);
            return Content(text + DateTime.Now.ToString());
        }

    }
}
