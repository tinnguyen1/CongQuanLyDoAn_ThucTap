using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class PhanNhomDao
    {
        BaoCaoOnlineDbContext db = null;
        public PhanNhomDao()
        {
            db = new BaoCaoOnlineDbContext();
        }
        //==============================================

        public int Insert(Nhom_DA_TT entity)
        {
            db.Nhom_DA_TT.Add(entity);
            db.SaveChanges();
            return entity.MaNhom;
        }
        //==========================================
        public bool Update(Nhom_DA_TT entity)
        {
            try
            {
                var nhom = db.Nhom_DA_TT.Find(entity.MaNhom);
                nhom.MaGV = entity.MaGV;
                nhom.MaSV = entity.MaSV;
                nhom.MaLoaiDA = entity.MaLoaiDA;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Nhom_DA_TT> ListAllPaing( string searchString, int page, int pagesize)
        {

            IQueryable<Nhom_DA_TT> model = db.Nhom_DA_TT;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.SinhVien.TenSV.Contains(searchString) || x.GiangVien.TenGV.Contains(searchString));
            }
            return model.OrderBy(x => x.MaGV).ToPagedList(page, pagesize);
        }
        //========================================================
    }
}
