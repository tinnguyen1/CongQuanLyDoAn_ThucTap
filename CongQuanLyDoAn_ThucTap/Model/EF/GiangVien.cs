namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiangVien")]
    public partial class GiangVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiangVien()
        {
            BangLienLacs = new HashSet<BangLienLac>();
            Nhom_DA_TT = new HashSet<Nhom_DA_TT>();
        }

        [Key]
        [StringLength(15)]
        public string MaGV { get; set; }

        [StringLength(50)]
        [DisplayName("Họ và tên")]
        public string TenGV { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(5)]
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(15)]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Matkhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangLienLac> BangLienLacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nhom_DA_TT> Nhom_DA_TT { get; set; }
    }
}
