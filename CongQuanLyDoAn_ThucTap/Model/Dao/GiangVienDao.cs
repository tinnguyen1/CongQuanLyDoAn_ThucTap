using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class GiangVienDao
    {
        BaoCaoOnlineDbContext db = null;
        public GiangVienDao()
        {
            db = new BaoCaoOnlineDbContext();
        }
        //==============================================

        public int Insert(GiangVien entity)
        {
            db.GiangViens.Add(entity);
            db.SaveChanges();
            return 1;
        }
        //==========================================


        public GiangVien GetById(string ma)
        {
            return db.GiangViens.SingleOrDefault(x => x.MaGV == ma);
        }
        //====================================================


        public int Login(string ma, string matKhau)
        {
            var result = db.GiangViens.SingleOrDefault(x => x.MaGV == ma);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Matkhau == matKhau)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
        //========================================================

        public IEnumerable<GiangVien> ListAllPaing(string searchString, int page, int pagesize)
        {
            IQueryable<GiangVien> model = db.GiangViens;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenGV.Contains(searchString) || x.SDT.Contains(searchString));
            }
            return model.OrderBy(x => x.MaGV).ToPagedList(page, pagesize);
        }
        //========================================================

        public GiangVien ViewDentail(string Ma)
        {
            return db.GiangViens.Find(Ma);
        }
        //========================================================

        public bool Update(GiangVien entity)
        {
            try
            {
                var gianvien = db.GiangViens.Find(entity.MaGV);
                gianvien.TenGV = entity.TenGV;
                gianvien.NgaySinh = entity.NgaySinh;
                gianvien.GioiTinh = entity.GioiTinh;
                gianvien.DiaChi = entity.DiaChi;
                gianvien.SDT = entity.SDT;
                gianvien.Email = entity.Email;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //===================================================

        //phương thức delete
        public bool Delete(int id)
        {
            try
            {
                var Giangvien = db.GiangViens.Find(id);
                db.GiangViens.Remove(Giangvien);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<GiangVien> ListAll()
        {
            return db.GiangViens.ToList();
        }

        public List<GiangVien> LayThongTin(string ma)
        {
            var list = db.GiangViens.Where(x => x.MaGV == ma).OrderBy(x => x.MaGV).ToList();
            return list;
        }

        public bool DoiMatKhau(GiangVien entity)
        {
            try
            {
                var giangvien = db.GiangViens.SingleOrDefault(x => x.Email == entity.Email);
                giangvien.Matkhau = entity.Matkhau;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
