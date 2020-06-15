using CongQuanLyDoAn_ThucTap.Areas.Khoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CongQuanLyDoAn_ThucTap.Areas.Khoa.Controllers
{
    public class Khoa_LoginController : Controller
    {
        // GET: Khoa/Khoa_Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Khoa_LoginModel model)
        {
            if (model.Email == "khoa@gmail.com" && model.Matkhau=="123456")
            {
                Session["khoaId"] = "1";
                return RedirectToAction("Index", "Khoa_Home");
            }     
            else
            {
                ModelState.AddModelError("", "Đăng nhập thất bại");
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Khoa_Login");
        }
            
    }
}