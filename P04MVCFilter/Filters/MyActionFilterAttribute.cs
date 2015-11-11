using P04MVCFilter.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace P04MVCFilter.Filters
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //1. RouteData 中 保存了 当前请求 匹配的 路由信息和路由对象
            //             如果本次请求 是请求了某个 区域 里的 控制器方法，还可以通过filterContext.RouteData.DataTokens["area"]获取区域名

            //string strArea = filterContext.RouteData.DataTokens["area"].ToString();
            string strController = filterContext.RouteData.Values["controller"].ToString();
            string strAction = filterContext.RouteData.Values["action"].ToString();
            //filterContext.RouteData.GetRequiredString

            //2.另一种方式 获取 请求的 类名和方法名
            string strAction2 = filterContext.ActionDescriptor.ActionName;
            string strController2 = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            //2.1检查 被请求方法 是否 加了 MoneyAttribute 特性
            if (filterContext.ActionDescriptor.IsDefined(typeof(MoneyAttribute), false))
            {
                //直接为 请求 设置 返回结果，而不执行 对应的 Action 方法，也不执行 OnActionExcuted，但是，会执行 Result过滤器和 生成视图
                filterContext.Result = new ContentResult() { Content = "<br/>哈哈哈，直接被跳过了吧~~~！<br/>" };
            }
            
            filterContext.HttpContext.Response.Write("OnActionExecuting<hr/>");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnActionExecuted<hr/>");
            base.OnActionExecuted(filterContext);
        }
    }
}