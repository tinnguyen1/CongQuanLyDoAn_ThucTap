namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BangDanhGia_BD
    {
        [Key]
        public int MaDanhGia { get; set; }

        public int MaBangDiem { get; set; }

        [Column(TypeName = "text")]
        public string NoiDung { get; set; }

        public int? NguoiDangTin { get; set; }

        public DateTime? NgayDanhGia { get; set; }

        public virtual BangDiem BangDiem { get; set; }
    }
}
