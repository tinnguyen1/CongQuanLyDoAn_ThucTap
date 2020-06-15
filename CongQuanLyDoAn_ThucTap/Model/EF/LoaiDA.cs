namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiDA")]
    public partial class LoaiDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiDA()
        {
            Bang_DK_DeTai = new HashSet<Bang_DK_DeTai>();
            Nhom_DA_TT = new HashSet<Nhom_DA_TT>();
        }

        [Key]
        [DisplayName("Đồ án")]
        public int MaLoaiDA { get; set; }

        [StringLength(100)]
        [DisplayName("Đồ án")]
        public string TenLoai { get; set; }

        [StringLength(20)]
        [DisplayName("Thời gian làm")]
        public string SoNgayLam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bang_DK_DeTai> Bang_DK_DeTai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nhom_DA_TT> Nhom_DA_TT { get; set; }
    }
}
