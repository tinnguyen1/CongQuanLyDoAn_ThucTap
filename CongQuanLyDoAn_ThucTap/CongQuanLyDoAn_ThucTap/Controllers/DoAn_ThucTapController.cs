using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using CongQuanLyDoAn_ThucTap.Common;
using Microsoft.Extensions.Logging;

namespace CongQuanLyDoAn_ThucTap.Controllers
{
    public class DoAn_ThucTapController : BaseController
    {
        public const string Ngay = "Ngay";
        // GET: DoAn_ThucTap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangKyDeTai()
        {
            var dao = new BangDkDaDao();
            var lathongtin = Session[CommonConstants.MaSV_SESSTION];
            var masv = Convert.ToInt32(lathongtin);

            ViewBag.thongtin = dao.LayDSDeTai(masv);
            return View();
        }

        [HttpGet]
        public ActionResult DangKyDeTaiDoAn()
        {
            SetViewBag1();
            return View();
        }
        public void SetViewBag1(int? selectedMa = null)
        {
            var lathongtin = Session[CommonConstants.MaSV_SESSTION];
            var masv = Convert.ToInt32(lathongtin);
            var dao = new NhomDaTtDao();
            ViewBag.MaLoaiDA = new SelectList(dao.ListDA(masv), "MaLoaiDA", "LoaiDA.TenLoai", selectedMa);
        }
        [HttpPost]
        public ActionResult DangKyDeTaiDoAn(Bang_DK_DeTai detai, ThongTinNhom tt)
        {
            // Khai Báo
            var dao = new BangDkDaDao();
            var dao1 = new ThongTinNhomDao();
            var dao2 = new NhomDaTtDao();

            detai.NgayDK = DateTime.Now;
            var getMaNhom = dao2.TimMaNhom(tt.NguoiDangKy, detai.MaLoaiDA);
            tt.MaNhom = getMaNhom.MaNhom;

            //kiem tra thanh vien trong nhom
            if (tt.SoLuongThanhVien == 1)
            {
                tt.ThanhVien2 = 0;
                tt.ThanhVien3 = 0;
            }
            else
            {
                if (tt.SoLuongThanhVien == 2)
                {
                    if (tt.ThanhVien2 == 0)
                    {
                        SetAlert("Thông tin thành viên chưa đủ! vui lòng điền đầy đủ", "error");
                        return RedirectToAction("DangKyDeTaiDoAn", "DoAn_ThucTap");
                    }
                    else
                    {
                        var TimMagv = dao2.TimMagv(tt.ThanhVien2, detai.MaLoaiDA);
                        if (TimMagv == null)
                        {
                            SetAlert("Thành viên không tồn tại vui lòng kiểm tra lại", "error");
                            return RedirectToAction("DangKyDeTaiDoAn", "DoAn_ThucTap");
                        }
                        else
                        {
                            tt.ThanhVien3 = 0;
                        }
                    }
                }
                else
                {
                    if (tt.ThanhVien2 == 0 && tt.ThanhVien3 == 0)
                    {
                        SetAlert("Thông tin thành viên chưa đủ! vui lòng điền đầy đủ", "error");
                        return RedirectToAction("DangKyDeTaiDoAn", "DoAn_ThucTap");
                    }

                    else
                    {
                        if (tt.ThanhVien2 == tt.ThanhVien3)
                        {
                            SetAlert("Thông tin hai thành viên trùng nhau! Vui lòng kiểm tra lại", "error");
                            return RedirectToAction("DangKyDeTaiDoAn", "DoAn_ThucTap");
                        }
                    }
                }
            }

            // Kiểm tra người đăng ký có nhóm hay chưa
            var timmasv = dao1.TimMaSV(tt.NguoiDangKy, detai.MaLoaiDA);

            if (timmasv == null)
            {
                // chen thong tin vao
                int id = dao.Insert(detai);
                if (id > 0)
                {
                    //them vao bang ghi
                    tt.MaDetai = id;
                    int kt = dao1.Insert(tt);
                    if (kt > 0)
                    {
                        SetAlert("Đăng ký đề tài thành công", "success");
                        return RedirectToAction("DangKyDeTai", "DoAn_ThucTap");
                    }
                    else
                    {
                        dao.Delete(id);
                        if (kt == -1)
                        {
                            SetAlert("Thành viên đăng ký không cùng giảng viên hướng dẫn", "error");
                            return RedirectToAction("DangKyDeTaiDoAn", "DoAn_ThucTap");
                        }
                        else
                        {
                            SetAlert("Thêm thành viên thất bại", "error");
                            return RedirectToAction("DangKyDeTaiDoAn", "DoAn_ThucTap");
                        }

                    }
                }
                else
                {
                    SetAlert("Dang ky nhom that bai", "error");
                    return RedirectToAction("DangKyDeTaiDoAn", "DoAn_ThucTap");
                }
            }
            else
            {
                // Kiểm tra loại đồ án đó có tồn tại hay chưa
                var TimMaDA = dao.TimMaDA(detai.MaLoaiDA);
                var TimMaDeTai = dao1.TimMaDetaiTheo(tt.NguoiDangKy, detai.MaLoaiDA);
                for (int i = 0; i < TimMaDA.Count; i++)
                {
                    if (TimMaDA[i].MaDetai != TimMaDeTai.MaDetai)
                    {
                        //them vao bang ghi
                        int id = dao.Insert(detai);
                        if (id > 0)
                        {
                            tt.MaDetai = id;
                            int kt = dao1.Insert(tt);
                            if (kt > 0)
                            {
                                SetAlert("Đăng ký đề tài thành công", "success");
                                return RedirectToAction("DangKyDeTai", "DoAn_ThucTap");
                            }
                            else
                            {
                                dao.Delete(id);
                                if (kt == -1)
                                {
                                    SetAlert("Thành viên đăng ký không cùng giảng viên hướng dẫn", "error");
                                    return RedirectToAction("DangKyDeTaiDoAn", "DoAn_ThucTap");
                                }
                                else
                                {
                                    SetAlert("Thêm thành viên thất bại", "error");
                                    return RedirectToAction("DangKyDeTaiDoAn", "DoAn_ThucTap");
                                }
                            }
                        }
                        else
                        {
                            SetAlert("Thêm thành viên thất bại", "error");
                            return RedirectToAction("DangKyDeTai", "DoAn_ThucTap");
                        }
                    }
                    else
                    {
                        SetAlert("Bạn đã có nhóm đăng ký đồ án này", "error");
                        return RedirectToAction("DangKyDeTai", "DoAn_ThucTap");
                    }
                }

            }
            return View("index");
        }


        [HttpGet]
        public ActionResult ThongTinNhomDoAn()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult ThongTinNhomDoAn(ThongTinNhom tt)
        //{
        //    var dao = new ThongTinNhomDao();
        //    var dao1 = new BangDkDaDao();
        //    var ngay = Session[Ngay];
        //    var thongtin = ObjectToDateTime(ngay);
        //    var madetai = dao1.LayTheoNgay(thongtin);
        //    int ma = madetai[0].MaDetai;
        //    tt.MaDetai = ma;

        //    if (tt.SoLuongThanhVien == 1)
        //    {
        //        tt.ThanhVien2 = 0;
        //        tt.ThanhVien3 = 0;
        //    }
        //    else
        //    {
        //        if (tt.SoLuongThanhVien == 2)
        //        {
        //            if (tt.ThanhVien2 == 0)
        //            {
        //                SetAlert("Thông tin thành viên chưa đủ! vui lòng điền đầy đủ", "error");
        //                return RedirectToAction("ThongTinNhomDoAn", "DoAn_ThucTap");
        //            }
        //            else
        //            {
        //                tt.ThanhVien3 = 0;
        //            }  
        //        }
        //        else
        //        {
        //            if (tt.ThanhVien2 == 0 && tt.ThanhVien3 == 0)
        //            {
        //                SetAlert("Thông tin thành viên chưa đủ! vui lòng điền đầy đủ", "error");
        //                return RedirectToAction("ThongTinNhomDoAn", "DoAn_ThucTap");
        //            }

        //            else
        //            {
        //                if (tt.ThanhVien2 == tt.ThanhVien3)
        //                {
        //                    SetAlert("Thông tin hai thành viên trùng nhau! Vui lòng kiểm tra lại", "error");
        //                    return RedirectToAction("ThongTinNhomDoAn", "DoAn_ThucTap");
        //                }
        //            }
        //        }
        //    }


        //    int id = dao.Insert(tt);
        //    if (id == -1)
        //    {
        //        SetAlert("Thành viên không cùng nhóm hướng dẫn! Vui lòng kiểm tra lại", "error");
        //        return RedirectToAction("ThongTinNhomDoAn", "DoAn_ThucTap");
        //    }
        //    else
        //    {
        //        if (id > 0)
        //        {
        //            SetAlert("Đăng ký nhóm thực hiện đề tài thành công", "success");
        //            return RedirectToAction("index", "Home");
        //        }
        //        else
        //        {

        //            SetAlert("Thành viên nào đó đã đăng ký vui lòng kiểm tra lại", "error");
        //            return RedirectToAction("ThongTinNhomDoAn", "DoAn_ThucTap");
        //        }

        //    }

        //}
        public static DateTime ObjectToDateTime(object o)
        {
            DateTime dt;
            DateTime.TryParse(o.ToString(), out dt);
            return dt;
        }

    }
}