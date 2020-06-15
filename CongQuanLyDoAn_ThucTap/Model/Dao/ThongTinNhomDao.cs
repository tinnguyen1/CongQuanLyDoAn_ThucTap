using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ThongTinNhomDao
    {
        BaoCaoOnlineDbContext db = null;
        public ThongTinNhomDao()
        {
            db = new BaoCaoOnlineDbContext();
        }

        public int Insert(ThongTinNhom entity)
        {
            var dao = new NhomDaTtDao();
            var magv = dao.TimMagvTheoMaNhom(entity.MaNhom);
            var mada = magv.MaLoaiDA;

            ////kiem tra ma nhom tung thanh vien
            if (entity.SoLuongThanhVien == 1)
            {
                db.ThongTinNhoms.Add(entity);
                db.SaveChanges();
                return entity.STT;
            }

            else
            {
                if (entity.SoLuongThanhVien == 2)
                {
                    var nhomtv2 = dao.TimMagv(entity.ThanhVien2, mada);
                    var ttb = nhomtv2.MaGV;

                    if (magv.MaGV != ttb)
                    {
                        return -1;
                    }
                    else
                    {
                        ThongTinNhom bien1 = db.ThongTinNhoms.SingleOrDefault(x => x.ThanhVien2 == entity.ThanhVien2);
                        ThongTinNhom bien2 = db.ThongTinNhoms.SingleOrDefault(x => x.ThanhVien3 == entity.ThanhVien2);
                        ThongTinNhom bien3 = db.ThongTinNhoms.SingleOrDefault(x => x.NguoiDangKy == entity.ThanhVien2);


                        if (bien1 != null || bien2 != null)
                        {
                            return 0;
                        }
                        else
                        {
                            db.ThongTinNhoms.Add(entity);
                            db.SaveChanges();
                            return entity.STT;
                        }
                    }
                }
                else
                {

                    var nhomtv2 = dao.TimMagv(entity.ThanhVien2, mada);
                    var nhomtv3 = dao.TimMagv(entity.ThanhVien3, mada);

                    if (magv.MaGV != nhomtv2.MaGV || magv.MaGV != nhomtv3.MaGV)
                    {
                        return -1;
                    }
                    else
                    {
                        ThongTinNhom bien1 = db.ThongTinNhoms.SingleOrDefault(x => x.ThanhVien2 == entity.ThanhVien2);
                        ThongTinNhom bien2 = db.ThongTinNhoms.SingleOrDefault(x => x.ThanhVien2 == entity.ThanhVien3);
                        ThongTinNhom bien3 = db.ThongTinNhoms.SingleOrDefault(x => x.ThanhVien3 == entity.ThanhVien2);
                        ThongTinNhom bien4 = db.ThongTinNhoms.SingleOrDefault(x => x.ThanhVien3 == entity.ThanhVien3);

                        if (bien1 != null || bien2 != null || bien3 != null || bien4 != null)
                        {
                            return 0;
                        }
                        else
                        {
                            db.ThongTinNhoms.Add(entity);
                            db.SaveChanges();
                            return entity.STT;
                        }
                    }
                }
            }
        }
         public ThongTinNhom TimMaSV(int ma, int mada)
        {
            var ma1 = db.ThongTinNhoms.SingleOrDefault(x => x.NguoiDangKy == ma && x.Bang_DK_DeTai.MaLoaiDA==mada);
            return ma1;
        }
        public ThongTinNhom TimMaDeTaiTheoMaSV(int ma)
        {
            var ma1 = db.ThongTinNhoms.SingleOrDefault(x => x.NguoiDangKy==ma);
            return ma1;
        }
        public ThongTinNhom TimMaDetaiTheo(int ma,int dt)
        {
            return db.ThongTinNhoms.Where(x => x.NguoiDangKy == ma).SingleOrDefault(x => x.Bang_DK_DeTai.MaLoaiDA == dt);
        }
    }
}
