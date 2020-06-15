namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BaoCaoOnlineDbContext : DbContext
    {
        public BaoCaoOnlineDbContext()
            : base("name=BaoCaoOnlineDbContext")
        {
        }

        public virtual DbSet<Bang_DanhGiaFile> Bang_DanhGiaFile { get; set; }
        public virtual DbSet<Bang_DK_DeTai> Bang_DK_DeTai { get; set; }
        public virtual DbSet<BangDanhGia_BD> BangDanhGia_BD { get; set; }
        public virtual DbSet<BangDiem> BangDiems { get; set; }
        public virtual DbSet<BangLienLac> BangLienLacs { get; set; }
        public virtual DbSet<BangThongbao> BangThongbaos { get; set; }
        public virtual DbSet<CT_BangDiem> CT_BangDiem { get; set; }
        public virtual DbSet<CT_ThucTap> CT_ThucTap { get; set; }
        public virtual DbSet<DoanhNghiep> DoanhNghieps { get; set; }
        public virtual DbSet<FileBaoCao> FileBaoCaos { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<LoaiDA> LoaiDAs { get; set; }
        public virtual DbSet<Nhom_DA_TT> Nhom_DA_TT { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<ThongTinNhom> ThongTinNhoms { get; set; }
        public virtual DbSet<TrangThai> TrangThais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bang_DanhGiaFile>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<Bang_DK_DeTai>()
                .HasMany(e => e.CT_BangDiem)
                .WithRequired(e => e.Bang_DK_DeTai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bang_DK_DeTai>()
                .HasMany(e => e.CT_ThucTap)
                .WithRequired(e => e.Bang_DK_DeTai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bang_DK_DeTai>()
                .HasMany(e => e.FileBaoCaos)
                .WithRequired(e => e.Bang_DK_DeTai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bang_DK_DeTai>()
                .HasMany(e => e.ThongTinNhoms)
                .WithRequired(e => e.Bang_DK_DeTai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BangDanhGia_BD>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<BangDiem>()
                .HasMany(e => e.BangDanhGia_BD)
                .WithRequired(e => e.BangDiem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BangDiem>()
                .HasMany(e => e.CT_BangDiem)
                .WithRequired(e => e.BangDiem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BangLienLac>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<BangLienLac>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<BangThongbao>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<CT_BangDiem>()
                .Property(e => e.ChuThich)
                .IsUnicode(false);

            modelBuilder.Entity<DoanhNghiep>()
                .HasMany(e => e.CT_ThucTap)
                .WithRequired(e => e.DoanhNghiep)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FileBaoCao>()
                .Property(e => e.TenFile)
                .IsUnicode(false);

            modelBuilder.Entity<FileBaoCao>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<FileBaoCao>()
                .HasMany(e => e.Bang_DanhGiaFile)
                .WithRequired(e => e.FileBaoCao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.GioiTinh)
                .IsUnicode(false);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<GiangVien>()
                .HasMany(e => e.BangLienLacs)
                .WithRequired(e => e.GiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiangVien>()
                .HasMany(e => e.Nhom_DA_TT)
                .WithRequired(e => e.GiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiDA>()
                .Property(e => e.SoNgayLam)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiDA>()
                .HasMany(e => e.Bang_DK_DeTai)
                .WithRequired(e => e.LoaiDA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiDA>()
                .HasMany(e => e.Nhom_DA_TT)
                .WithRequired(e => e.LoaiDA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nhom_DA_TT>()
                .Property(e => e.MaGV)
                .IsUnicode(false);

            modelBuilder.Entity<Nhom_DA_TT>()
                .HasMany(e => e.BangThongbaos)
                .WithRequired(e => e.Nhom_DA_TT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nhom_DA_TT>()
                .HasMany(e => e.ThongTinNhoms)
                .WithRequired(e => e.Nhom_DA_TT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.Lop)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.GioiTinh)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MaKhau)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.BangLienLacs)
                .WithRequired(e => e.SinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.Nhom_DA_TT)
                .WithRequired(e => e.SinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrangThai>()
                .HasMany(e => e.BangLienLacs)
                .WithRequired(e => e.TrangThai)
                .WillCascadeOnDelete(false);
        }
    }
}
