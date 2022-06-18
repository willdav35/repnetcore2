using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using repapp.Data.Entities;
using Microsoft.Extensions.Configuration;

namespace repapp.Data
{
    public class DataDbContext: IdentityDbContext<StoreUser>
    {

        private readonly IConfiguration _config;
        public DataDbContext(DbContextOptions<DataDbContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

     
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
              .Property(p => p.Price)
              .HasColumnType("money");

            modelBuilder.Entity<OrderItem>()
              .Property(o => o.UnitPrice)
              .HasColumnType("money");

            modelBuilder.Entity<Order>()
              .HasData(new Order()
              {
                  Id = 1,
                  OrderDate = DateTime.UtcNow,
                  OrderNumber = "12345"
              });
        }
    }
}
