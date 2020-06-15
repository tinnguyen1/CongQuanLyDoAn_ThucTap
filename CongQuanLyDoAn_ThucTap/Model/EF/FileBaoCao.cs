namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FileBaoCao")]
    public partial class FileBaoCao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FileBaoCao()
        {
            Bang_DanhGiaFile = new HashSet<Bang_DanhGiaFile>();
        }

        [Key]
        public int MaFile { get; set; }

        public int MaDetai { get; set; }

        [StringLength(100)]
        public string TenFile { get; set; }

        public DateTime? NgayDang { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [MaxLength(8000)]
        public byte[] Data { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bang_DanhGiaFile> Bang_DanhGiaFile { get; set; }

        public virtual Bang_DK_DeTai Bang_DK_DeTai { get; set; }
    }
}
