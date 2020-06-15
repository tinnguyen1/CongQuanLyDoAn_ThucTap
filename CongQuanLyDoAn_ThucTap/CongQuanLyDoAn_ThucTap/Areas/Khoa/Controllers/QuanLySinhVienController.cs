using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.IO;

namespace CongQuanLyDoAn_ThucTap.Areas.Khoa.Controllers
{
    public class QuanLySinhVienController : Khoa_BaseController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BaoCaoOnlineDbContext"].ConnectionString);
        OleDbConnection Econ;

        //=====================  phương thức lấy danh sách và phân trang ================
        public ActionResult Index(string searchString, int page = 1, int pageSize = 20)
        {
            var dao = new SinhVienDao();
            var model = dao.ListAllPaing(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        
        // ==================== phương thức thêm mới ==========================
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]       
        public ActionResult ThemMoi(SinhVien sinhvien)
        {
            if (ModelState.IsValid)
            {
                var dao = new SinhVienDao();
                int ma;
                Random rd = new Random();
                ma = rd.Next(1, 2000);
                sinhvien.MaSV =1611060000+ma+1;
                sinhvien.MaKhau = "1234";
                long id = dao.Insert(sinhvien);
                if (id > 0)
                {
                    SetAlert("Thêm sinh viên thành công", "success");
                    return RedirectToAction("Index", "QuanLySinhVien");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới sinh viên thất bại");
                }
            }
            return View("Index");
        }
        //======================= hết phần thêm mới =================================

        //=========================phương thức Update================================
        [HttpGet]
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
                    SetAlert("Sửa sinh viên thành công", "success");
                    return RedirectToAction("Index", "QuanLySinhVien");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sinh viên thất bại");
                }
            }
            return View("Index");
        }
        //======================== hết phần update ===========================

        //========================= phương thức delete ========================
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SinhVienDao().Delete(id);
            return RedirectToAction("Index");
        }
        //======================== hết phần delete ===========================
    }
}