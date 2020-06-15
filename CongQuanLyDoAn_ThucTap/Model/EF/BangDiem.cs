namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangDiem")]
    public partial class BangDiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BangDiem()
        {
            BangDanhGia_BD = new HashSet<BangDanhGia_BD>();
            CT_BangDiem = new HashSet<CT_BangDiem>();
        }

        [Key]
        public int MaBangDiem { get; set; }

        [StringLength(100)]
        public string TenBangDiem { get; set; }

        public DateTime? NgayDang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDanhGia_BD> BangDanhGia_BD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_BangDiem> CT_BangDiem { get; set; }
    }
}
