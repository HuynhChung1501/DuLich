
using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dulich.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using Travel.Domain;
using Travel.Domain.Models;

namespace Dulich.Infrastructure
{
    public class DASContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DASContext(DbContextOptions<DASContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
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
                e.Property(p => p.GiaMoi).HasColumnType("decimal(18,2)");

            });

            #endregion
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("IdUser")?.Value;
                if (!string.IsNullOrEmpty(userIdClaim) && int.TryParse(userIdClaim, out int userId))
                {

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((BaseModel)entityEntry.Entity).CreatedDate = DateTime.Now;
                        ((BaseModel)entityEntry.Entity).CreatedBy = int.Parse(userIdClaim);
                    }
                    else if (entityEntry.State == EntityState.Modified)
                    {
                        ((BaseModel)entityEntry.Entity).UpdatedDate = DateTime.Now;
                        ((BaseModel)entityEntry.Entity).UpdatedBy = int.Parse(userIdClaim);
                    }
                }
                else
                {
                    // Xử lý trường hợp userIdClaim là null hoặc không phải là số nguyên
                    // Ví dụ: ném một ngoại lệ hoặc ghi lại một cảnh báo
                    throw new InvalidOperationException("User ID claim is missing or invalid.");

                }

            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("IdUser")?.Value;
                if (!string.IsNullOrEmpty(userIdClaim) && int.TryParse(userIdClaim, out int userId))
                {

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((BaseModel)entityEntry.Entity).CreatedDate = DateTime.Now;
                        ((BaseModel)entityEntry.Entity).CreatedBy = int.Parse(userIdClaim);
                    }
                    else if (entityEntry.State == EntityState.Modified)
                    {
                        ((BaseModel)entityEntry.Entity).UpdatedDate = DateTime.Now;
                        ((BaseModel)entityEntry.Entity).UpdatedBy = int.Parse(userIdClaim);
                    }
                }
                else
                {
                    // Xử lý trường hợp userIdClaim là null hoặc không phải là số nguyên
                    // Ví dụ: ném một ngoại lệ hoặc ghi lại một cảnh báo
                    throw new InvalidOperationException("User ID claim is missing or invalid.");

                }

            }

            return await base.SaveChangesAsync(cancellationToken);
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
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Menu> Menus { get; set; }

        #endregion
        //RenderHere
    }
}