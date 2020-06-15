using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class SinhVienDao
    {
        BaoCaoOnlineDbContext db = null;
        public SinhVienDao()
        {
            db = new BaoCaoOnlineDbContext();
        }

        //phương thức thêm mới sinh viên
        public int Insert(SinhVien entity)
        {
            db.SinhViens.Add(entity);
            db.SaveChanges();
            return entity.MaSV;
        }

        //phương thức update dư liệu
        public bool Update(SinhVien entity)
        {
            try
            {
                var sinhvien = db.SinhViens.Find(entity.MaSV);
                sinhvien.TenSV = entity.TenSV;
                sinhvien.NgaySinh = entity.NgaySinh;
                sinhvien.GioiTinh = entity.GioiTinh;
                sinhvien.DiaChi = entity.DiaChi;
                sinhvien.SDT = entity.SDT;
                sinhvien.Email = entity.Email;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //phương thức lấy danh sách sinh viên
        public List<SinhVien> DsSinhVienPN()
        {
            return db.SinhViens.ToList();
        }
        public IEnumerable<SinhVien> ListAllPaing(string searchString, int page, int pagesize)
        {
            IQueryable<SinhVien> model = db.SinhViens;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenSV.Contains(searchString) || x.SDT.Contains(searchString));
            }
            return model.OrderBy(x => x.Stt).ToPagedList(page, pagesize);
        }

        //phương thức tìm thông tin theo email
        public SinhVien GetById(int masv)
        {
            return db.SinhViens.SingleOrDefault(x => x.MaSV == masv);
        }


        // phương thức lấy thông tin theo mã
        public SinhVien ViewDentail(int Ma)
        {
            return db.SinhViens.Find(Ma);
        }

        //phương thức delete
        public bool Delete(int id)
        {
            try
            {
                var sinhvien = db.SinhViens.Find(id);
                db.SinhViens.Remove(sinhvien);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //phương thức login vào tài khoản
        public int Login(int masv, string matKhau)
        {
            var result = db.SinhViens.SingleOrDefault(x => x.MaSV == masv);
            //nếu đăng nhập nhiều nơi thì có thể dùng chung nên trả về >0
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.MaKhau == matKhau)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
        public List<SinhVien> LayThongTin(int ma)
        {
            var list = db.SinhViens.Where(x => x.MaSV == ma).OrderBy(x => x.Stt).ToList();
            return list;
        }

        public bool DoiMatKhau(SinhVien entity)
        {
            try
            {
                var sinhvien = db.SinhViens.SingleOrDefault(x => x.Email == entity.Email);
                sinhvien.MaKhau = entity.MaKhau;
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
