using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P02MVCAjax.Controllers
{
    public class HtmlController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Part()
        {
            ViewData["data"] = "哈哈哈";
            return PartialView();
        }

        public ActionResult Bundle()
        {
            return View();
        }
    }
}
