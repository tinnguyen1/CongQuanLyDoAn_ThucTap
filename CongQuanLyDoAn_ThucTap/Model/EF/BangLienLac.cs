namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangLienLac")]
    public partial class BangLienLac
    {
        [Key]
        public int MaTinNhan { get; set; }

        [Required]
        [StringLength(15)]
        public string MaGV { get; set; }

        public int MaTrangThai { get; set; }

        [Column(TypeName = "text")]
        public string NoiDung { get; set; }

        public DateTime? ThoiGianDang { get; set; }

        public int? NguoiDang { get; set; }

        public int MaSV { get; set; }

        public virtual TrangThai TrangThai { get; set; }

        public virtual GiangVien GiangVien { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
