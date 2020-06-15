namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinNhom")]
    public partial class ThongTinNhom
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNhom { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDetai { get; set; }

        public int NguoiDangKy { get; set; }

        public int ThanhVien2 { get; set; }

        public int ThanhVien3 { get; set; }

        public int? SoLuongThanhVien { get; set; }

        public virtual Bang_DK_DeTai Bang_DK_DeTai { get; set; }

        public virtual Nhom_DA_TT Nhom_DA_TT { get; set; }
    }
}
