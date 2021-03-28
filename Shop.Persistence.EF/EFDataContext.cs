using Microsoft.EntityFrameworkCore;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Shop.Persistence.EF
{
    public class EFDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=ShopDB;trusted_connection=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductEntry> ProductEntries { get; set; }
        public DbSet<AccountingDocument> AccountingDocuments { get; set; }
        public DbSet<SalesCheckList> SalesCheckLists { get; set; }
        public DbSet<SalesItem> SalesItems { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
