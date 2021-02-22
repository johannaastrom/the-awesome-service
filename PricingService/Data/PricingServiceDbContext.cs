using Microsoft.EntityFrameworkCore;
using PricingService.Models;
using System;
using System.Collections.Generic;

namespace PricingService.Data
{
    public class PricingServiceDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ServiceCustomer> ServiceCustomers { get; set; }

        public PricingServiceDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceCustomer>().HasKey(x => new { x.ServiceId, x.CustomerId });
            modelBuilder.Entity<Discount>().HasOne(x => x.Customer).WithMany(y => y.Discounts);
        }
    }
}
