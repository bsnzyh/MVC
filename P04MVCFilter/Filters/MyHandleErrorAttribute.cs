using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P04MVCFilter.Controllers
{
    /// <summary>
    /// 异常处理 过滤器
    /// </summary>
    public class MyHandleErrorAttribute : HandleErrorAttribute
    {
        public static Queue<Exception> errorQueue = new Queue<Exception>();
        public override void OnException(ExceptionContext filterContext)
        {
            //1.获取异常对象
            Exception ex = filterContext.Exception;
            //2.记录异常日志
            errorQueue.Enqueue(ex);
            //3.重定向友好页面
            filterContext.Result = new RedirectResult("~/error.html");
            //4.标记异常已经处理完毕,ASP.NET框架不需要再处理异常了
            filterContext.ExceptionHandled = true;
            //base.OnException(filterContext);
        }
    }
}