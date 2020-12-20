using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ShoppingCart.Data.Entities.ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartDetail> ShoppingCartDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart.Data.Entities.ShoppingCart>()
                .HasMany(c => c.ShoppingCartDetail)
                .WithOne(e => e.ShoppingCart)
                .IsRequired();

            modelBuilder.Entity<Category>()
              .HasMany(c => c.Products)
              .WithOne(e => e.Category)
              .IsRequired();

        }
    }

}
