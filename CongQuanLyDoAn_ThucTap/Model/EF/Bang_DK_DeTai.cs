namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bang_DK_DeTai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bang_DK_DeTai()
        {
            CT_BangDiem = new HashSet<CT_BangDiem>();
            CT_ThucTap = new HashSet<CT_ThucTap>();
            FileBaoCaos = new HashSet<FileBaoCao>();
            ThongTinNhoms = new HashSet<ThongTinNhom>();
        }

        [Key]
        public int MaDetai { get; set; }

        [StringLength(100)]
        [DisplayName("Tên đề tài")]
        public string TenDeTai { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime NgayDK { get; set; }

        public int MaLoaiDA { get; set; }

        [DisplayName("Đồ án")]
        public virtual LoaiDA LoaiDA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_BangDiem> CT_BangDiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_ThucTap> CT_ThucTap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileBaoCao> FileBaoCaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinNhom> ThongTinNhoms { get; set; }
    }
}
