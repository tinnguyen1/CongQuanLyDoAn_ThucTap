using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CongQuanLyDoAn_ThucTap.Common;
using Model.Dao;
using Model.EF;

namespace CongQuanLyDoAn_ThucTap.Areas.Giangvien.Controllers
{
    public class TaiKhoanController : GV_BaseController
    {
        // GET: Giangvien/TaiKhoan
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ThongTinCaNhan()
        {
            var dao = new GiangVienDao();
            var laythongtin = Session[CommonConstants.MaGV_SESSTION];
            string id = new JavaScriptSerializer().Serialize(laythongtin);
            string magv = laythongtin.ToString();

            var Giangvien = dao.LayThongTin(magv);
            return View(Giangvien);
        }

        public ActionResult Edit(string id)
        {
            var dao = new GiangVienDao();
            var giangvien = dao.ViewDentail(id);
            return View(giangvien);
        }
        [HttpPost]
        public ActionResult Edit(GiangVien giangvien)
        {
            if (ModelState.IsValid)
            {
                var dao = new GiangVienDao();

                var result = dao.Update(giangvien);
                if (result)
                {
                    SetAlert("Cập nhật thông tin thành công", "success");
                    return RedirectToAction("ThongTinCaNhan", "TaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin thất bại");
                    return RedirectToAction("Edit", "TaiKhoan");
                }
            }
            return RedirectToAction("Edit", "TaiKhoan");
        }

        [HttpGet]
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoiMatKhau(GiangVien gv, string nhaplai)
        {
            var dao = new GiangVienDao();
            if (gv.Matkhau != nhaplai)
            {
                SetAlert("Mời nhập lại! Mật khẩu mới và nhập lại không trùng nhau", "error");
                return RedirectToAction("DoiMatKhau", "TaiKhoan");
            }
            else
            {
                var result = dao.DoiMatKhau(gv);
                if (result)
                {
                    SetAlert("Đổi mật khẩu thành công", "success");
                    return RedirectToAction("index", "GV_Home");
                }
                else
                {
                    SetAlert("Đổi mật khẩu thất bại", "error");
                    return RedirectToAction("DoiMatKhau", "TaiKhoan");
                }
            }
        }
    }
}