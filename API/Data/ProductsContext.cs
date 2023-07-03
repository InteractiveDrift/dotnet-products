using Microsoft.EntityFrameworkCore;
using API.Model;

namespace API.Data
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Producer>? Producers { get; set; }
        public static readonly string DbFile = "Data/products.sqlite";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbFile}");
        }
    }
}