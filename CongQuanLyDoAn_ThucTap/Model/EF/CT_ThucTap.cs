namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_ThucTap
    {
        [Key]
        [Column(Order = 0)]
        public int MaCT { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDetai { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDoanhNgiep { get; set; }

        public DateTime? NgayBd { get; set; }

        public DateTime? NgayKT { get; set; }

        public virtual Bang_DK_DeTai Bang_DK_DeTai { get; set; }

        public virtual DoanhNghiep DoanhNghiep { get; set; }
    }
}
