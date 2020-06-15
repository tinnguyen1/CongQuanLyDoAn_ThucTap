using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BangDkDaDao
    {
        BaoCaoOnlineDbContext db = null;
        public BangDkDaDao()
        {
            db = new BaoCaoOnlineDbContext();
        }

        public int Insert(Bang_DK_DeTai entity)
        {
            //var dao2 = new NhomDaTtDao();
            //var dao3 = new GiangVienDao();
            //var dao4 = new LoaiDaDao();

            db.Bang_DK_DeTai.Add(entity);
            db.SaveChanges();
            return entity.MaDetai;

            //if (manhom == null)
            //{
            //    return -2;
            //}
            //else
            //{
            //    var magv = dao2.TimTheoMa(manhom.MaNhom);
            //    int maloai = magv.MaLoaiDA;
            //    var maloaida = dao4.GetById(maloai);
            //    int ma = maloaida.MaLoaiDA;
            //    entity.MaLoaiDA = ma;

            //    ThongTinNhom kt1 = db.ThongTinNhoms.SingleOrDefault(x => x.ThanhVien2 == entity.MaDetai && x.Bang_DK_DeTai.MaLoaiDA == maloaida.MaLoaiDA);
            //    ThongTinNhom kt2 = db.ThongTinNhoms.SingleOrDefault(x => x.ThanhVien3 == entity.MaDetai && x.Bang_DK_DeTai.MaLoaiDA == maloaida.MaLoaiDA);
            //    ThongTinNhom kt3 = db.ThongTinNhoms.SingleOrDefault(x => x.NguoiDangKy == entity.MaDetai && x.Bang_DK_DeTai.MaLoaiDA == maloaida.MaLoaiDA);

            //    if (kt1 != null || kt2 != null || kt3 != null)
            //    {
            //        return -1;
            //    }
            //    else
            //    {
            //        entity.MaDetai = 0;

            //    }
            //}
        }

        public List<Bang_DK_DeTai> LayTheoNgay(DateTime ngay)
        {
            var list = db.Bang_DK_DeTai.Where(x => x.NgayDK > ngay).OrderBy(x => x.NgayDK).ToList();
            return list;
        }

        public List<Bang_DK_DeTai> TimMaDA(int madt)
        {
            return db.Bang_DK_DeTai.Where(x => x.MaLoaiDA == madt).OrderBy(x=>x.NgayDK).ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var sinhvien = db.Bang_DK_DeTai.Find(id);
                db.Bang_DK_DeTai.Remove(sinhvien);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<ThongTinNhom> LayDSDeTai(int ma)
        {
           var tt = db.ThongTinNhoms.Where(x => x.NguoiDangKy == ma).OrderBy(x => x.Bang_DK_DeTai.MaLoaiDA).ToList();
            return tt;
        }
    }
}
