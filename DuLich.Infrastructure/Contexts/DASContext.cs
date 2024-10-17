
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dulich.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Travel.Domain;
using Travel.Domain.Models;

namespace Dulich.Infrastructure
{
    public class DASContext : DbContext
    {
        public DASContext(DbContextOptions<DASContext>options) : base(options)
        {

        }
        /// <summary>
        /// Hàm để set các trường mặc định cho bảng
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Base

            modelBuilder.Entity<Menu>(e =>
            {
                e.Property(p => p.IDParent).HasDefaultValue(0);
            });

            modelBuilder.Entity<DatTour>(e =>
            {
                e.Property(p => p.TongGia).HasColumnType("decimal(18,2)");
            });
            modelBuilder.Entity<DiaDiemDuLich>(e =>
            {
                e.Property(p => p.GiaCu).HasColumnType("decimal(18,2)");
            });
            modelBuilder.Entity<DiaDiemDuLich>(e =>
            {
                e.Property(p => p.GiaMoi).HasColumnType("decimal(18,2)");
            });
            #endregion
        }



        #region DbSet

        public DbSet<ThongTinChuyenDi> ThongTinChuyenDis { get; set; }
        public DbSet<ThongTinPhuongTien> ThongTinPhuongTien { get; set; }
        public DbSet<DatPhong> DatPhong { get; set; } 
        public DbSet<KhachSan> KhachSan { get; set; } 
        public DbSet<LoaiPhong> LoaiPhong { get; set; } 
        public DbSet<PhongKS> PhongKS { get; set; } 
        public DbSet<TienIchPhong> TienIchPhong { get; set; } 
        public DbSet<Account> Accounts { get; set; } 
        public DbSet<DatTour> DatTour { get; set; } 
        public DbSet<DiaDiemDuLich> DiaDiemDuLich { get; set; } 
        public DbSet<KhachHang> KhachHang { get; set; } 
        public DbSet<PhanQuyen> PhanQuyen { get; set; } 
        public DbSet<ChucNang> ChucNang { get; set; } 

        #endregion
        //RenderHere
    }
}