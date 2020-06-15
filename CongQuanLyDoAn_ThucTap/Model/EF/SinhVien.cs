namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            BangLienLacs = new HashSet<BangLienLac>();
            Nhom_DA_TT = new HashSet<Nhom_DA_TT>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Stt { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSV { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Họ và tên")]
        public string TenSV { get; set; }

        [StringLength(20)]
        [DisplayName("Lớp")]
        public string Lop { get; set; }

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
        public string MaKhau { get; set; }

        [StringLength(50)]
        [DisplayName("Chuyên ngành")]
        public string ChuyenNganh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangLienLac> BangLienLacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nhom_DA_TT> Nhom_DA_TT { get; set; }
    }
}
