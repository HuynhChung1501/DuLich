
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dulich.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

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
            #endregion
        }



        #region DbSet

        public DbSet<Dulieu> DuLieus { get; set; }
        public DbSet<ThongTinChuyenDi> ThongTinChuyenDis { get; set; }
        public DbSet<PhuongTien> PhuongTiens { get; set; }
        public DbSet<DatPhong> DatPhong { get; set; } 
        public DbSet<KhachSan> KhachSan { get; set; } 
        public DbSet<LoaiPhong> LoaiPhong { get; set; } 
        public DbSet<PhongKS> PhongKS { get; set; } 
        public DbSet<TienIchPhong> TienIchPhong { get; set; } 

        #endregion
        //RenderHere
    }
}