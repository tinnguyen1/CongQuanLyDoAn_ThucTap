using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CongQuanLyDoAn_ThucTap
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Trang chu",
            //    url: "Home/{action}",
            //    defaults: new { Controller = "Home", action = "index", id = UrlParameter.Optional }
            //    );

            //routes.MapRoute(
            //    name: "Thong tin ca nhan giang vien 1",
            //    url: "Home/ThongTinCaNhanGiangVien/{id}",
            //    defaults: new { Controller = "SinhVien_Gv", action = "ThongTinCaNhanGiangVien", id = UrlParameter.Optional }
            //    );
            //routes.MapRoute(
            //    name: "Thong tin ca nhan giang vien 2",
            //    url: "SinhVien_Gv/ThongTinCaNhanGiangVien/{id}",
            //    defaults: new { Controller = "SinhVien_Gv", action = "ThongTinCaNhanGiangVien", id = UrlParameter.Optional }
            //    );

            //routes.MapRoute(
            //    name: "Thong tin ca nhan sinh vien 1",
            //    url: "Home/ThongTinCaNhan/{id}",
            //    defaults: new { Controller = "TaiKhoan", action = "ThongTinCaNhan", id = UrlParameter.Optional }
            //    );
            //routes.MapRoute(
            //    name: "Thong tin ca nhan sinh vien 2",
            //    url: "TaiKhoan/ThongTinCaNhan",
            //    defaults: new { Controller = "SVTaiKhoan", action = "ThongTinCaNhan", id = UrlParameter.Optional }

            //    );

            routes.MapRoute(
                name: "Trang chu sinh vien",
                url: "Sinhvien/{action}",
                defaults: new { Controller = "Login", action = "Login" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
