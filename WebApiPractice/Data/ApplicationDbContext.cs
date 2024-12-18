using Microsoft.EntityFrameworkCore;
using WebApiPractice.Models;

namespace WebApiPractice.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<DiscountRule> DiscountRules { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Category>().HasData(
    new Category { CategoryId = 1, CategoryName = "Electronics", Description = "Electronic gadgets and devices" },
    new Category { CategoryId = 2, CategoryName = "Books", Description = "Various genres of books" },
    new Category { CategoryId = 3, CategoryName = "Home Appliances", Description = "Appliances for everyday home use" }
);
        // Seed data for DiscountRule table
        modelBuilder.Entity<DiscountRule>().HasData(
            new DiscountRule { DiscountRuleId = 1, MinimumPrice = 100, MaximumDiscount = 10 },
            new DiscountRule { DiscountRuleId = 2, MinimumPrice = 500, MaximumDiscount = 20 },
            new DiscountRule { DiscountRuleId = 3, MinimumPrice = 999, MaximumDiscount = 30 }
        );
        // Seed data for Product table
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, Name = "Novel", Price = 50, CategoryId = 2, Discount = 0, Description = "Bestselling novel with an intriguing plot" },
            new Product { ProductId = 2, Name = "Microwave", Price = 150, CategoryId = 3, Discount = 10, Description = "Compact microwave oven suitable for small kitchens" },
            new Product { ProductId = 3, Name = "Smartphone", Price = 800, CategoryId = 1, Discount = 20, Description = "Latest model smartphone with advanced features" },
            new Product { ProductId = 4, Name = "Laptop", Price = 1200, CategoryId = 1, Discount = 30, Description = "High-performance laptop for gaming and productivity" }
        );
    }
}
