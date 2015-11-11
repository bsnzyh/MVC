using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P03MVCRoute.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            int a = int.Parse("5");
            return View();
        }

        public ActionResult TestView()
        {
            return View("~/MyViews/Home/TestView.cshtml");
        }

        public ActionResult TestView2()
        {
            return View();
        }

        // home/print/1
        public ActionResult PrintInt(int id)
        {
            return Content(" Id = " + id.ToString());
        }

        // home/print/zyh
        public ActionResult PrintName(string name)
        {
            return Content(" Name = " + name);
        }

       

    }
}
