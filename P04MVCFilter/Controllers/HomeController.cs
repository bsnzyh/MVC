using P04MVCFilter.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P04MVCFilter.Controllers
{
    //2.0过滤器加在Controller上,还可以加在全局上
    //[MyActionFilterAttribute]
    public class HomeController : Controller
    {
        //1.0过滤器加载
        //[MyActionFilterAttribute]
        public ActionResult Index()
        {
            Response.Write("Action执行中...<br/>");
            return View();
        }

        public ActionResult PlayFun()
        {
            return View();
        }
        //两个过滤器依然会执行,因为过滤器是在执行操作方法,执行操作结果的前后调用.操作结果不一定就是视图
        public void Test()
        {
            Response.Write("Action执行中...<br/>");
        }

        public ActionResult TestLog()
        {
            int a = 0, b = 3;
            int c = b / a;
            int[] d = new int[] { 1, 2, 3 };
            return Content(c.ToString());
        }
    }
}
