using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base()
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
                .HasKey(x => x.Id);

            modelBuilder.Entity<Item>()
                .Property(x => x.Price)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Item>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.Product);

            modelBuilder.Entity<Order>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.Items)
                .WithOne(x => x.Order);

            modelBuilder.Entity<Order>()
                .Property(x => x.PriceTotal)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Order>()
                .Property(x => x.DiscountTotal)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Order>()
                .Ignore(x => x.OrderTotal);

            modelBuilder.Entity<Order>()
                .Property(x => x.Status)
                .HasConversion<int>();

            modelBuilder.Entity<OrderItem>()
                .HasKey(x => x.Id);
            
            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Item)
                .WithMany()
                .HasForeignKey(x => x.Item);

            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.Order);

            modelBuilder.Entity<OrderItem>()
                .Property(x => x.Discount)
                .HasPrecision(6, 2);

            modelBuilder.Entity<OrderItem>()
                .Ignore(x => x.Total);

            base.OnModelCreating(modelBuilder);
        }
    }
}
