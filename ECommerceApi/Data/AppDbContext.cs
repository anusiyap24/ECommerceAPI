using ECommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Attribute>()
                .Property(e => e.Values)
                .HasConversion(
                    v => string.Join(",", v.Select(av => av.Value)), // Corrected this line
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                          .Select(av => new AttributeValue { Value = av }).ToList()); // Corrected this line
        }

    }
}
