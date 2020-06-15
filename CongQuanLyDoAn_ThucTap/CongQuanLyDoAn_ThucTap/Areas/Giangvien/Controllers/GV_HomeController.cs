using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CongQuanLyDoAn_ThucTap.Areas.Giangvien.Controllers
{
    public class GV_HomeController : GV_BaseController
    {
        // GET: Giangvien/GV_Home
        public ActionResult Index()
        {
            return View();
        }
    }
}