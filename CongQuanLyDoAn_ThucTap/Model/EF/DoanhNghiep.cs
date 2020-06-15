namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoanhNghiep")]
    public partial class DoanhNghiep
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoanhNghiep()
        {
            CT_ThucTap = new HashSet<CT_ThucTap>();
        }

        [Key]
        public int MaDoanhNgiep { get; set; }

        [StringLength(100)]
        public string TenDoanhNgiep { get; set; }

        [StringLength(50)]
        public string NguoiQuanLy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_ThucTap> CT_ThucTap { get; set; }
    }
}
