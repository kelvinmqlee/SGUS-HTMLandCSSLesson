using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication1.Models;

namespace WebApplication1.DbContextCustomer
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                        .ToTable("tblCustomer");
            modelBuilder.Entity<Customer>()
                        .HasKey(c => c.id);

            modelBuilder.Entity<Product>()
                        .ToTable("tblProduct");
            modelBuilder.Entity<Product>()
                        .HasKey(c => c.id);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-R08O3R9;Initial Catalog=CustomerDb;Integrated Security=True");
        //}
        public DbSet<Customer> Customers { get; set; }
    }
}
