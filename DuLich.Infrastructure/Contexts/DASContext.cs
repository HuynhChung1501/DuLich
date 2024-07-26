

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dulich.Domain.Models;

namespace DuLich.Infrastructure.Contexts
{
    public class DASContext : DbContext
    {
        private IConfiguration _configuration;
   

        public DASContext(DbContextOptions<DASContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DASContext() : base()
        {
        }

        public DASContext(DbContextOptions<DASContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
           

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DuLichContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }



        public DbSet<Dulieu> DuLieus { get; set; }
        public DbSet<ThongTinDiChuyen> ThongTinDiChuyens { get; set; }
        public DbSet<ThongTinPhuongTien> ThongTinPhuongTiens { get; set; }
        public DbSet<Menu> MenuModels { get; set; }    

        //RenderHere
    }
}