namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangThongbao")]
    public partial class BangThongbao
    {
        [Key]
        public int MaThongBao { get; set; }

        public int MaNhom { get; set; }

        [StringLength(100)]
        public string TenThongBao { get; set; }

        [Column(TypeName = "text")]
        public string NoiDung { get; set; }

        public DateTime? NgayDang { get; set; }

        public virtual Nhom_DA_TT Nhom_DA_TT { get; set; }
    }
}
