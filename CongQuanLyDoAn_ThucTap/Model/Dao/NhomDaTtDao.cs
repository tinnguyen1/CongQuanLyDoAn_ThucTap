using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using System.Data;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class NhomDaTtDao
    {
        BaoCaoOnlineDbContext db = null;
        public NhomDaTtDao()
        {
            db = new BaoCaoOnlineDbContext();
        }

        public Nhom_DA_TT GetByMa(int ma)
        {
            return db.Nhom_DA_TT.Find(ma);
        }
        public List<Nhom_DA_TT> ListAll()
        {
            return db.Nhom_DA_TT.OrderByDescending(x => x.NgayPhanNhom).ToList();
        }

        public List<Nhom_DA_TT> TimTheoMa(int ma)
        {
            return db.Nhom_DA_TT.Where(x=>x.MaSV==ma).OrderBy(x=>x.LoaiDA.MaLoaiDA).ToList();
        }

        public List<Nhom_DA_TT> LayDSNhomTheoMaGV(string ma, string searchstring)
        {
            IQueryable<Nhom_DA_TT> model = db.Nhom_DA_TT;
            if (!string.IsNullOrEmpty(searchstring))
            {
                model = model.Where(x => x.SinhVien.Lop.Contains(searchstring)); 
            }
            return model.Where(x=>x.MaGV==ma).OrderBy(x => x.NgayPhanNhom).ToList();
        }

        public List<Nhom_DA_TT> ListDA(int masv)
        {
            return db.Nhom_DA_TT.Where(x=>x.MaSV==masv).OrderBy(x=>x.MaLoaiDA).ToList();
        }
        
        public Nhom_DA_TT TimMaNhom(int id, int loaida)
        {
            var model = db.Nhom_DA_TT.SingleOrDefault(x => x.MaSV == id && x.MaLoaiDA == loaida);
            return model;
        }

        public Nhom_DA_TT TimMagv(int masv, int mada)
        {
            return db.Nhom_DA_TT.SingleOrDefault(x => x.MaSV == masv && x.MaLoaiDA == mada);
        }
        
        public Nhom_DA_TT TimMagvTheoMaNhom(int ma)
        {
            return db.Nhom_DA_TT.SingleOrDefault(x =>x.MaNhom==ma);
        }
        
    }
}
