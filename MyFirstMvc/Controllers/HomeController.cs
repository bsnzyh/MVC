using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewData["aa"] = "bb";
            return View();
        }

        public ViewResult TestViewStart()
        {
            return View();
        }

    }
}
