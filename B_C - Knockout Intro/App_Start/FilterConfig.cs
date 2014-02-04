using System.Web;
using System.Web.Mvc;

namespace B_C___Knockout_Intro
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}