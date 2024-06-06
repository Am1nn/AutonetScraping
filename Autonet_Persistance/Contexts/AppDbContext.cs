using Autonet_Domain.Entities.Concrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonet_Persistance.Contexts
{
    public class AppDbContext:DbContext
    {


        private readonly IConfiguration _configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options,IConfiguration configuration) : base(options) {
            _configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        public DbSet<Phone> Phones { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<Seller> Sellers { get; set;}
    }
}
