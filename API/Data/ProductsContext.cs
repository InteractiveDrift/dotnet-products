using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public partial class ProductsContext : DbContext
{
    public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.ProducerId, "IX_Products_ProducerId");

            entity.HasIndex(e => e.ProductGroupId, "IX_Products_ProductGroupId");

            entity.HasIndex(e => e.SupplierId, "IX_Products_SupplierId");

            entity.HasOne(d => d.Producer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.ProductGroup).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        OnModelCreatingPartial(modelBuilder);
    }

     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
