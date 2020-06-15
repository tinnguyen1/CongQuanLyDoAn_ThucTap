using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using Model.EF;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Model.BaoCaoOnlineViewModel;

namespace CongQuanLyDoAn_ThucTap.Areas.Khoa.Controllers
{
    public class PhanNhomController : Khoa_BaseController
    {
        // GET: Khoa/PhanNhom
        public ActionResult Index( string searchString, int page = 1, int pageSize = 20)
        {
            var dao = new PhanNhomDao();
            var model = dao.ListAllPaing( searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        //====================================================================

        // ==================== phương thức thêm mới nhóm ==========================
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //SetViewBag();
            ViewBag.listgv = new GiangVienDao().ListAll();
            SetViewBag1();
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(Nhom_DA_TT nhom)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhanNhomDao();
                nhom.NgayPhanNhom = DateTime.Now;
                int id = dao.Insert(nhom);
                if (id > 0)
                {
                    SetAlert("Thêm nhóm thành công", "success");
                    return RedirectToAction("Index", "PhanNhom");
                }
                else
                {
                    SetAlert("Thêm thất bại", "error");
                }
            }
            SetViewBag();
            SetViewBag1();
            return View("Index");
        }
        //======================= hết phần thêm mới =================================
        public void SetViewBag(string selectedMa = null)
        {
            var dao = new GiangVienDao();
            ViewBag.MaGV = new SelectList(dao.ListAll(),"MaGV", "TenGV", selectedMa);
        }
        public void SetViewBag1(int? selectedMa = null)
        {
            var dao = new LoaiDaDao();
            ViewBag.MaLoaiDA = new SelectList(dao.ListAll(), "MaLoaiDA", "TenLoai", selectedMa);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new NhomDaTtDao();
            var nhom = dao.GetByMa(id);
            var magv = nhom.MaGV;
            ViewBag.listg = new GiangVienDao().ListAll();
            //SetViewBag(magv);
            SetViewBag1(nhom.MaLoaiDA);
            return View(nhom);

        }
        [HttpPost]
        public ActionResult Edit(Nhom_DA_TT model)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhanNhomDao();
                model.NgayPhanNhom = DateTime.Now;
                var result = dao.Update(model);
                if (result)
                {
                    return RedirectToAction("Index", "PhanNhom");
                }
                else
                {
                    SetAlert("Cập nhật thất bại", "error");
                    return RedirectToAction("Edit", "PhanNhom");
                }
            }
            SetViewBag(model.MaGV);
            SetViewBag1(model.MaLoaiDA);
            return View();
        }


        //=================== Thêm sinh viên vào nhóm ================================

        //public ActionResult Them_SV_Nhom()
        //{
        //    List<sinhvienview> jc = new List<sinhvienview>();
        //    string conn = ConfigurationManager.ConnectionStrings["BaoCaoOnlineDbContext"].ConnectionString;
        //    SqlConnection sqlcon = new SqlConnection(conn);
        //    string sqlquery = "Select * From SinhVien Where SinhVien.MaSV Not In (Select MaSV From Ct_Nhom)";
        //    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlcon);
        //    SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        sinhvienview sv = new sinhvienview();
        //        sv.Stt = int.Parse(dr["Stt"].ToString());
        //        sv.MaSV = int.Parse(dr["MaSV"].ToString());
        //        sv.TenSV = dr["TenSV"].ToString();
        //        sv.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
        //        sv.GioiTinh = dr["GioiTinh"].ToString();
        //        sv.DiaChi = dr["DiaChi"].ToString();
        //        sv.SDT = dr["SDT"].ToString();
        //        sv.Email = dr["Email"].ToString();
        //        sv.MaKhau = dr["MaKhau"].ToString();
        //        jc.Add(sv);
        //    }

        //    return View(jc);
        //}

        //[HttpGet]
        //public ActionResult ThemSinhVienVaoNhom(int id)
        //{
        //    var dao = new CtNhomDao();
        //    var dao1 = new NhomDaTtDao();
        //    var manhom = dao1.ListAll();
        //    var them = new Ct_Nhom();
        //    them.MaNhom = manhom[0].MaNhom;
        //    them.MaSV = id;
        //    them.NgayLap = DateTime.Now;
        //    int ids = dao.Insert(them);
        //    if (ids > 0)
        //    {
        //        SetAlert("Thêm thành công", "success");
        //        return RedirectToAction("Them_SV_Nhom", "PhanNhom");
        //    }
        //    else
        //    {
        //        SetAlert("Sinh viên đã có nhóm", "error");
        //        return RedirectToAction("Them_SV_Nhom", "PhanNhom");
        //    }
        //}

        //[HttpGet]
        //public ActionResult EditSV_Nhom()
        //{
        //    var dao = new CtNhomDao();
        //    var LayMaNhom = new NhomDaTtDao().ListAll();
        //    int manhom = LayMaNhom[0].MaNhom;
        //    var sinhvien = dao.ListAllSinhVien(manhom);
        //    if (sinhvien == null)
        //    {
        //        return View("Chưa có thành viên");
        //    }
        //    return View(sinhvien);
        //}
        //[HttpGet]
        //public ActionResult Xem(int id)
        //{
        //    var dao = new NhomDaTtDao();
        //    var dao1 = new CtNhomDao();

        //    var nhom = dao.GetByMa(id);
        //    ViewBag.sinhvien = dao1.ListAllSinhVien(id);
        //    SetViewBag(nhom.MaGV);
        //    SetViewBag1(nhom.MaLoaiDA);
        //    return View(nhom);

        //}
        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    var dao = new CtNhomDao();
        //    dao.Delete(id);
        //    return RedirectToAction("index");
        //}
    }
}