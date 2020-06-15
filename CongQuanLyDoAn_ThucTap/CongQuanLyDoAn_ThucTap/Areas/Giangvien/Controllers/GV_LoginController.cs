using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using CongQuanLyDoAn_ThucTap.Common;
using CongQuanLyDoAn_ThucTap.Areas.Giangvien.Models;

namespace CongQuanLyDoAn_ThucTap.Areas.Giangvien.Controllers
{
    public class GV_LoginController : Controller
    {
        // GET: Giangvien/GV_Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Gv_LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new GiangVienDao();
                var result = dao.Login(model.MaGV, model.Matkhau);
                if (result == 1)
                {
                    var giangvien = dao.GetById(model.MaGV);
                    Session["TenGV"] = giangvien.TenGV;
                    Session["MaGV"] = giangvien.MaGV;
                    Session["Email"] = giangvien.Email;

                    var GiangvienSesstion = new GiangVienLogin();
                    GiangvienSesstion.TenGV = giangvien.TenGV;
                    GiangvienSesstion.MaGV = giangvien.MaGV;

                    Session[CommonConstants.MaGV_SESSTION] = giangvien.MaGV;
                    Session.Add(CommonConstants.TENGV_SESSTION, GiangvienSesstion);
                    return RedirectToAction("Index", "GV_Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else
                {
                    ModelState.AddModelError("", "Sai mật khẩu");
                }
            }
            return View("Index");
        }
        public ActionResult LogOut(Gv_LoginModel model)
        {
            Session.Add(CommonConstants.TENGV_SESSTION,null);
            return RedirectToAction("Index", "GV_Login");
        }
    }
}