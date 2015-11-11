using P04MVCFilter.Controllers;
using P04MVCFilter.Filters;
using System.Web;
using System.Web.Mvc;

namespace P04MVCFilter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MyHandleErrorAttribute());
            filters.Add(new MyActionFilterAttribute());
            filters.Add(new MyViewFilterAttribute());
        }
    }
}