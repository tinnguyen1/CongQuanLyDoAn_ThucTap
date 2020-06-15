namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_BangDiem
    {
        [Key]
        [Column(Order = 0)]
        public int MaCt { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDetai { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaBangDiem { get; set; }

        [StringLength(50)]
        public string TenSV { get; set; }

        public double? Diem { get; set; }

        [Column(TypeName = "text")]
        public string ChuThich { get; set; }

        public virtual Bang_DK_DeTai Bang_DK_DeTai { get; set; }

        public virtual BangDiem BangDiem { get; set; }
    }
}
