using System.Web.Mvc;

namespace CongQuanLyDoAn_ThucTap.Areas.Khoa
{
    public class KhoaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Khoa";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "Khoa_default",
                "Khoa/{controller}/{action}/{id}",
                new { action = "Index",Controller="Khoa_Login", id = UrlParameter.Optional }
            );
        }
    }
}