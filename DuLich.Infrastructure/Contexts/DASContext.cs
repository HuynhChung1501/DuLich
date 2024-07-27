
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

        public DbSet<Dulieu> DuLieus { get; set; }
        public DbSet<ThongTinDiChuyen> ThongTinDiChuyens { get; set; }
        public DbSet<ThongTinPhuongTien> ThongTinPhuongTiens { get; set; }
        public DbSet<MenuModel> MenuModels { get; set; }    

        //RenderHere
    }
}