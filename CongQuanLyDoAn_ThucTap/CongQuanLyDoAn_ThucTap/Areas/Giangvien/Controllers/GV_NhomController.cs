using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using CongQuanLyDoAn_ThucTap.Common;
using System.Web.Script.Serialization;

namespace CongQuanLyDoAn_ThucTap.Areas.Giangvien.Controllers
{
    public class GV_NhomController : GV_BaseController
    {
        // GET: Giangvien/GV_Nhom
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DSNhom(string searchString)
        {
            if (searchString != null)
            {
                searchString = searchString.Substring(2);
            }
            
            var dao = new NhomDaTtDao();
            var laythongtin = Session[CommonConstants.MaGV_SESSTION];
            string id = new JavaScriptSerializer().Serialize(laythongtin);
            string magv = laythongtin.ToString();

            var dsnhom = dao.LayDSNhomTheoMaGV(magv, searchString);
            if (dsnhom.Count > 0)
            {
                return View(dsnhom);
            }
            else
            {
                dsnhom = null;
                return View(dsnhom);
            }
            
        }

        //[HttpGet]
        //public ActionResult Thanhviennhom(int id)
        //{
        //    var dao = new CtNhomDao();
        //    var sinhvien = dao.ListAllSinhVien(id);
        //    if (sinhvien == null)
        //    {
        //        SetAlert("Không có thành viên trong nhóm! Liên hệ khoa CNTT để giải quyết", "error");
        //        return RedirectToAction("DSNhom", "GV_Nhom");
        //    }
        //    else
        //    {
        //        return View(sinhvien);
        //    }
        //}
    }
}