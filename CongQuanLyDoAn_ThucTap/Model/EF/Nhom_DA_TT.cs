namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nhom_DA_TT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhom_DA_TT()
        {
            BangThongbaos = new HashSet<BangThongbao>();
            ThongTinNhoms = new HashSet<ThongTinNhom>();
        }

        [Key]
        public int MaNhom { get; set; }

        [Required]
        [StringLength(15)]
        public string MaGV { get; set; }

        public int MaSV { get; set; }

        public int MaLoaiDA { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime NgayPhanNhom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangThongbao> BangThongbaos { get; set; }

        public virtual GiangVien GiangVien { get; set; }

        public virtual LoaiDA LoaiDA { get; set; }

        public virtual SinhVien SinhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinNhom> ThongTinNhoms { get; set; }
    }
}
