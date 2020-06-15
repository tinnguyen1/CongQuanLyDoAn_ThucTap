using System.Web.Mvc;

namespace CongQuanLyDoAn_ThucTap.Areas.Giangvien
{
    public class GiangvienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Giangvien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Giangvien_default",
                "Giangvien/{controller}/{action}/{id}",
                new { action = "Index", Controller="GV_Login", id = UrlParameter.Optional }
            );
        }
    }
}