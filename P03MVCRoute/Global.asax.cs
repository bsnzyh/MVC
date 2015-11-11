using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace P03MVCRoute
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            AreaRegistration.RegisterAllAreas();

            ViewEngines.Engines.RemoveAt(0);
            ViewEngineCollection vec = ViewEngines.Engines;
            RazorViewEngine razor = vec[0] as RazorViewEngine;
            razor.ViewLocationFormats = new string[]{
                 "~/Views/{1}/{0}.cshtml",
                 "~/Views/Shared/{0}.cshtml",
                  "~/MyViews/{1}/{0}.cshtml"   
            };
            //string[] newPaths = new string[oldPaths.Length + 1];
            //oldPaths.CopyTo(newPaths, 0);
            //newPaths[newPaths.Length - 1] = "~/MyViews/{1}/{0}.cshtml";
            //PureViewEngines();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        #region 1.0 保留razor视图引擎，其它的都去掉 -void PureViewEngines()
        /// <summary>
        /// 保留razor视图引擎，其它的都去掉
        /// </summary>
        void PureViewEngines()
        {
            //System.Web.Razor.RazorCodeLanguage.Languages.Remove("vbhtml");

            //移除 集合中 默认添加的 WebFormViewEngine
            ViewEngines.Engines.RemoveAt(0);

            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new RazorViewEngine());

            RazorViewEngine razor = ViewEngines.Engines[0] as RazorViewEngine;

            //移除RazorViewEngine中的 vbhtml 路径模版。

            razor.FileExtensions = new string[] { "cshtml" };
            razor.AreaViewLocationFormats = new string[] { "~/Areas/{2}/Views/{1}/{0}.cshtml", "~/Areas/{2}/Views/Shared/{0}.cshtml" };
            razor.AreaMasterLocationFormats = new string[]{
                 "~/Areas/{2}/Views/{1}/{0}.cshtml",
                 "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            razor.AreaPartialViewLocationFormats = new string[]{
                 "~/Areas/{2}/Views/{1}/{0}.cshtml",
                 "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

            razor.MasterLocationFormats = new string[]{
                 "~/Views/{1}/{0}.cshtml",
                 "~/Views/Shared/{0}.cshtml"
            };

            razor.PartialViewLocationFormats = new string[]{
                 "~/Views/{1}/{0}.cshtml",
                 "~/Views/Shared/{0}.cshtml"
            };

            razor.ViewLocationFormats = new string[]{
                 "~/Views/{1}/{0}.cshtml",
                 "~/Views/Shared/{0}.cshtml"    
            };
        }
        #endregion
    }
}