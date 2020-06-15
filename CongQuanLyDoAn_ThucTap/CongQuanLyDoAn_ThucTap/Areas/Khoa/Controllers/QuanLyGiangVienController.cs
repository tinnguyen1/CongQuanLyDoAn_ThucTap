using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Globalization;

namespace CongQuanLyDoAn_ThucTap.Areas.Khoa.Controllers
{
    public class QuanLyGiangVienController : Khoa_BaseController
    {
        //=====================  phương thức lấy danh sách và phân trang ================
        public ActionResult Index(string searchString, int page = 1, int pageSize = 20)
        {
            var dao = new GiangVienDao();
            var model = dao.ListAllPaing(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        //===================== hết phần lấy danh sách và phân trang =======================

        // ==================== phương thức thêm mới ==========================
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult ThemMoi(GiangVien giangvien)
        {
            if (ModelState.IsValid)
            {
                DateTime? gv = giangvien.NgaySinh;
                var st = String.Format("{0:dd/MM/yy}", gv);
                var ngay = st.ToString();
                string[] ngay1 = ngay.Split('-');
                string chuoingay = "";
                for (int i = 0; i < ngay1.Length; i++)
                {
                    string Str1 = ngay1[i].Substring(0);
                    chuoingay += Str1;
                }

                string str = giangvien.TenGV;
                string[] arrListStr = str.Split(' ');
                string chuoiten="";
                for (int i = 0; i < arrListStr.Length; i++)
                {
                    string Str1 = arrListStr[i].Substring(0, 1);
                    Str1 = Str1.ToUpper();
                    chuoiten += Str1;
                }

                giangvien.MaGV = chuoiten + chuoingay;
                var dao = new GiangVienDao();
                giangvien.Matkhau = "1234";
                long id = dao.Insert(giangvien);
                if (id > 0)
                {
                    SetAlert("Thêm giảng viên thành công", "success");
                    return RedirectToAction("Index", "QuanLyGiangVien");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới Giảng viên thất bại");
                }
            }
            return View("Index");
        }
        //======================= hết phần thêm mới =================================

        //======================== phương thức update ===============================\
        [HttpGet]
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
                    SetAlert("Cập nhật giảng viên thành công", "success");
                    return RedirectToAction("Index", "QuanLyGiangVien");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật giảng viên thất bại");
                }
            }
            return View("Index");
        }
        // ======================= hết phần update ==================================

        //=================== Phần delete ============================
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new GiangVienDao().Delete(id);
            return RedirectToAction("Index");
        }
        //=================== Hết phần delete ========================
    }
}