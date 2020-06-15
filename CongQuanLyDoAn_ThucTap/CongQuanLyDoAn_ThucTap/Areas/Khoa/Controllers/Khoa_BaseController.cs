using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CongQuanLyDoAn_ThucTap.Areas.Khoa.Controllers
{
    public class Khoa_BaseController : Controller
    {
        // GET: Khoa/Khoa_Base
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessager"] = message;
            if(type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}