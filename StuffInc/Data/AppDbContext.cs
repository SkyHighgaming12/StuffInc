using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StuffInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffInc.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shipping_Product>().HasKey(sp => new
            {
                sp.ShippingId,
                sp.ProductId
            });

            modelBuilder.Entity<Shipping_Product>().HasOne(p => p.Product).WithMany(sp => sp.Shipping_Products).HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<Shipping_Product>().HasOne(p => p.Shipping).WithMany(sp => sp.Shipping_Products).HasForeignKey(p => p.ShippingId);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipping_Product> Shipping_Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warranty> Warranties { get; set; }


        //orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }



    }
}
