using CongQuanLyDoAn_ThucTap.Common;
using CongQuanLyDoAn_ThucTap.Models;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace CongQuanLyDoAn_ThucTap.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult KtLogin(LoginModel model)
        {
            if(ModelState.IsValid) //kiểm tra form rổng
            {
                var dao = new SinhVienDao();
                var result = dao.Login(model.MaSV, model.Matkhau);
                if (result==1)
                {
                    var sinhvien = dao.GetById(model.MaSV);
                    var SinhvienSesstion = new SinhvienLogin();
                    Session["TenSV"] = sinhvien.TenSV;
                    Session["MaSV"] = sinhvien.MaSV;
                    Session["Email"] = sinhvien.Email;

                    Session[CommonConstants.MaSV_SESSTION] = sinhvien.MaSV;
                    SinhvienSesstion.TenSV = sinhvien.TenSV;
                    SinhvienSesstion.MaSV = sinhvien.MaSV;

                    Session.Add(CommonConstants.TENSV_SESSTION,SinhvienSesstion);

                    return RedirectToAction("Index", "Home");
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
            return View("Login");
        }

        public ActionResult QuenMatKhau()
        {
            return View();
        }

        public ActionResult LogOut(LoginModel model)
        {
            Session.Add(CommonConstants.TENSV_SESSTION, null);
            return RedirectToAction("Login", "Login");
        }
    }
}