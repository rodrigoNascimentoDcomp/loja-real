using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasKey(x => x.ItemId);

            modelBuilder.Entity<Item>()
                .Property(x => x.Price)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Item>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Order>()
                .HasKey(x => x.OrderId);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.Items)
                .WithOne(x => x.Order);

            modelBuilder.Entity<Order>()
                .Property(x => x.Price)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Order>()
                .Property(x => x.DiscountPercentage)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Order>()
                .Ignore(x => x.Total);

            modelBuilder.Entity<Order>()
                .Property(x => x.Status)
                .HasConversion<int>();

            modelBuilder.Entity<OrderItem>()
                .HasKey(x => x.OrderItemId);
            
            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Item)
                .WithMany()
                .HasForeignKey(x => x.ItemId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<OrderItem>()
                .Property(x => x.Price)
                .HasPrecision(6, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(x => x.DiscountPercentage)
                .HasPrecision(6, 2);

            modelBuilder.Entity<OrderItem>()
                .Ignore(x => x.Total);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.ProductCategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
