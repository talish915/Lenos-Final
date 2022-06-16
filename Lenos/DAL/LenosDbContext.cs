using Lenos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lenos.DAL
{
    public class LenosDbContext : DbContext
    {
        public LenosDbContext(DbContextOptions<LenosDbContext> options) : base(options) { }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}
