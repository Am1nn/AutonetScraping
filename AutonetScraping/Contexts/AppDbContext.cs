using Autonet_Domain.Entities.Concrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az_Database.Contextes
{
    public class Turbo_az_DB_Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object value = optionsBuilder.UseSqlServer("Data Source=ASUSROG\\SQLEXPRESS;Initial Catalog=AutonetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

      




            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Plate> Plates { get; set; }
        
    }
}