using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Bai_Thi_Ky_02_2019_2020.Models
{
    public partial class qlclContext : DbContext
    {
        public qlclContext()
        {
        }

        public qlclContext(DbContextOptions<qlclContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CnTc> CnTc { get; set; }
        public virtual DbSet<Congnhan> Congnhan { get; set; }
        public virtual DbSet<Diemcachly> Diemcachly { get; set; }
        public virtual DbSet<Trieuchung> Trieuchung { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ADMIN;Database=qlcl;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CnTc>(entity =>
            {
                entity.HasKey(e => new { e.MaCongNhan, e.MaTrieuChung })
                    .HasName("CN_TC_pk");

                entity.ToTable("CN_TC");

                entity.Property(e => e.MaCongNhan).HasMaxLength(10);

                entity.Property(e => e.MaTrieuChung).HasMaxLength(10);

                entity.HasOne(d => d.MaCongNhanNavigation)
                    .WithMany(p => p.CnTc)
                    .HasForeignKey(d => d.MaCongNhan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cn");

                entity.HasOne(d => d.MaTrieuChungNavigation)
                    .WithMany(p => p.CnTc)
                    .HasForeignKey(d => d.MaTrieuChung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tc");
            });

            modelBuilder.Entity<Congnhan>(entity =>
            {
                entity.HasKey(e => e.MaCongNhan)
                    .HasName("PK__CONGNHAN__3DD895CABC00233F");

                entity.ToTable("CONGNHAN");

                entity.Property(e => e.MaCongNhan).HasMaxLength(10);

                entity.Property(e => e.MaDiemCachLy).HasMaxLength(10);

                entity.Property(e => e.NuocVe).HasMaxLength(30);

                entity.Property(e => e.TenCongNhan).HasMaxLength(30);

                entity.HasOne(d => d.MaDiemCachLyNavigation)
                    .WithMany(p => p.Congnhan)
                    .HasForeignKey(d => d.MaDiemCachLy)
                    .HasConstraintName("FK_dcl");
            });

            modelBuilder.Entity<Diemcachly>(entity =>
            {
                entity.HasKey(e => e.Madiemcachly)
                    .HasName("PK__DIEMCACH__07C3DDD466AC2165");

                entity.ToTable("DIEMCACHLY");

                entity.Property(e => e.Madiemcachly)
                    .HasColumnName("madiemcachly")
                    .HasMaxLength(10);

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(40);

                entity.Property(e => e.Tendiemcachly)
                    .HasColumnName("tendiemcachly")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Trieuchung>(entity =>
            {
                entity.HasKey(e => e.MaTrieuChung)
                    .HasName("PK__TRIEUCHU__F21EFBE278581B5F");

                entity.ToTable("TRIEUCHUNG");

                entity.Property(e => e.MaTrieuChung).HasMaxLength(10);

                entity.Property(e => e.TenTrieuChung).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
