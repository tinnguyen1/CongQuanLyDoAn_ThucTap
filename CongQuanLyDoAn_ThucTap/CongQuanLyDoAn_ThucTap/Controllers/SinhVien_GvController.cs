using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CongQuanLyDoAn_ThucTap.Common;

namespace CongQuanLyDoAn_ThucTap.Controllers
{
    public class SinhVien_GvController : BaseController
    {
        // GET: SinhVien_Gv
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ThongTinCaNhanGiangVien()
        {
            var dao2 = new NhomDaTtDao();
            var dao3 = new GiangVienDao();
            var dao4 = new LoaiDaDao();

            var lathongtin = Session[CommonConstants.MaSV_SESSTION];
            var masv = Convert.ToInt32(lathongtin);

            // tìm mã nhóm
            string ng1, ng2, ng3, ng4;
            var manhom = dao2.TimTheoMa(masv);
            for(int i=0;i<manhom.Count;i++)
            {
                manhom[i].NgayPhanNhom.AddDays(14);
                var tt = manhom[i].LoaiDA.SoNgayLam;
                int ngay =int.Parse(tt);

                if (manhom[i].MaLoaiDA == 1)
                {
                    DateTime ng = manhom[i].NgayPhanNhom.AddDays(ngay);
                    ng1 = String.Format("{0:dd/MM/yyyy}", ng);
                    ViewBag.ngaykt1 = ng1;
                }
                if (manhom[i].MaLoaiDA == 2)
                {
                    DateTime ng = manhom[i].NgayPhanNhom.AddDays(ngay);
                    ng2 = String.Format("{0:dd/MM/yyyy}", ng);
                    ViewBag.ngaykt2 = ng2;
                }
                if (manhom[i].MaLoaiDA == 3)
                {
                    DateTime ng = manhom[i].NgayPhanNhom.AddDays(ngay);
                    ng3 = String.Format("{0:dd/MM/yyyy}", ng);
                    ViewBag.ngaykt3 = ng3;
                }
                if (manhom[i].MaLoaiDA == 4)
                {
                    DateTime ng = manhom[i].NgayPhanNhom.AddDays(ngay);
                    ng4 = String.Format("{0:dd/MM/yyyy}", ng);
                    ViewBag.ngaykt4 = ng4;
                }
                
            }
            return View(manhom);
        }
    }
}