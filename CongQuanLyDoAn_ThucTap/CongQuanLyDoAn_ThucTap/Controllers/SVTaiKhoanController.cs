using CongQuanLyDoAn_ThucTap.Areas.Khoa.Controllers;
using CongQuanLyDoAn_ThucTap.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CongQuanLyDoAn_ThucTap.Controllers
{
    public class SVTaiKhoanController : BaseController
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ThongTinCaNhan()
        {
            var laythongtin = Session[CommonConstants.MaSV_SESSTION];
            int id = Convert.ToInt32(laythongtin);

            var dao = new SinhVienDao();
            var sinhvien = dao.LayThongTin(id);
            return View(sinhvien);
        }

        [HttpGet]
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoiMatKhau(SinhVien sv,string nhaplai)
        {
            var dao = new SinhVienDao();
            if (sv.MaKhau != nhaplai)
            {
                SetAlert("Mời nhập lại! Mật khẩu mới và nhập lại không trùng nhau", "error");
                return RedirectToAction("DoiMatKhau", "SVTaiKhoan");
            }
            else
            {
                var result = dao.DoiMatKhau(sv);
                if (result)
                {
                    SetAlert("Đổi mật khẩu thành công", "success");
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    SetAlert("Đổi mật khẩu thất bại", "error");
                    return RedirectToAction("DoiMatKhau", "SVTaiKhoan");
                }
            }
            
        }

        public ActionResult Edit(int id)
        {
            var dao = new SinhVienDao();
            var sinhvien = dao.ViewDentail(id);
            return View(sinhvien);
        }
        [HttpPost]
        public ActionResult Edit(SinhVien sinhvien)
        {
            if (ModelState.IsValid)
            {
                var dao = new SinhVienDao();
                var result = dao.Update(sinhvien);
                if (result)
                {
                    SetAlert("Cập nhật thông tin thành công", "success");
                    return RedirectToAction("ThongTinCaNhan", "SVTaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin thất bại");
                    return RedirectToAction("Edit", "SVTaiKhoan");
                }
            }
            return RedirectToAction("Edit", "SVTaiKhoan");
        }
    }
}