using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P04MVCFilter.Filters
{
    public class MyViewFilterAttribute:ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnResultExecuting<hr/>");
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnResultExecuted<hr/>");
            base.OnResultExecuted(filterContext);
        }
    }
}