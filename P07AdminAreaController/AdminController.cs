using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
namespace P07AdminAreaController
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View("~/MyViews/Home/TestView.cshtml");
        }
    }
}
