namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bang_DanhGiaFile
    {
        [Key]
        public int MaDanhGia { get; set; }

        public int MaFile { get; set; }

        [Column(TypeName = "text")]
        public string NoiDung { get; set; }

        public DateTime? NgayDang { get; set; }

        public virtual FileBaoCao FileBaoCao { get; set; }
    }
}
