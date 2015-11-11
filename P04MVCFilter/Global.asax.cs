using log4net;
using P04MVCFilter.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace P04MVCFilter
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();//读取Log4Net配置信息
            AreaRegistration.RegisterAllAreas();
            //开启一个线程扫描日志队列
            ThreadPool.QueueUserWorkItem(e=>
            {
                while (true)//不断扫描日志队列.
                {
                    if (MyHandleErrorAttribute.errorQueue.Count() > 0)//判断队列中是否有数据
                    {
                        Exception ex = MyHandleErrorAttribute.errorQueue.Dequeue();//出队,
                        if (ex!=null)
                        {
                            ILog logger = LogManager.GetLogger("errorMsg");
                            logger.Error(ex.ToString());//将异常信息写到磁盘上.
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        Thread.Sleep(1000);//如果队列中没有数据，让当前线程休息，避免造成CUP空转.
                    }
                }
            
            }
            );
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}