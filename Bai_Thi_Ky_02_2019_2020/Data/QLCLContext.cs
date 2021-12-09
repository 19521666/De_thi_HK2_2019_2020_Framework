using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bai_Thi_Ky_02_2019_2020.Models;

namespace Bai_Thi_Ky_02_2019_2020.Data
{
    public class QLCLContext :DbContext
    {
        public QLCLContext(DbContextOptions<QLCLContext> options) : base(options)
        {

        }
        public DbSet<Diemcachly> DiemCachLies { get; set; }
        public DbSet<Congnhan> CongNhans { get; set; }
        public DbSet<Trieuchung> TrieuChungs { get; set; }

        public DbSet<CnTc> CnTcs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diemcachly>().ToTable("Diemcachly");
            modelBuilder.Entity<Congnhan>().ToTable("Congnhan");
            modelBuilder.Entity<Trieuchung>().ToTable("Trieuchung");
            modelBuilder.Entity<CnTc>().ToTable("Cn_Tc").HasKey(c => new { c.MaCongNhan, c.MaTrieuChung });


        }

    }
}
