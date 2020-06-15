using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class LoaiDaDao
    {
        BaoCaoOnlineDbContext db = null;
        public LoaiDaDao()
        {
            db = new BaoCaoOnlineDbContext();
        }
        public List<LoaiDA> ListAll()
        {
            return db.LoaiDAs.ToList();
        }
        public LoaiDA GetById(int ma)
        {
            return db.LoaiDAs.SingleOrDefault(x => x.MaLoaiDA == ma);
        }
    }
}
