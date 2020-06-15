using System.Web;
using System.Web.Mvc;

namespace CongQuanLyDoAn_ThucTap
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
