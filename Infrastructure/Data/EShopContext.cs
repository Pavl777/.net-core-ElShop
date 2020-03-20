using ApplicationCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructure.Data
{
   public class EShopContext : DbContext
    {
        public EShopContext() { 
        }

        public DbSet<Product> Products { get; set; }
        public DbSet <Species> Specieses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Microwave> Microwaves { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EShop;Trusted_Connection=True;");
        }
    }
}
