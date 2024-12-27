using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Username = "johndoe", Role = "Admin", Name = "John Doe", Email = "john.doe@example.com", Address = "123 Main St", IsDeleted = false },
            new Customer { Id = 2, Username = "janesmith", Role = "Customer", Name = "Jane Smith", Email = "jane.smith@example.com", Address = "456 Elm St", IsDeleted = false }
        );

        // Seed data for Products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "TV", Price = 499.99m, Quantity = 3, Description = "4K Ultra HD TV", IsDeleted = false },
            new Product { Id = 2, Name = "Laptop", Price = 999.99m, Quantity = 3, Description = "High-performance laptop", IsDeleted = false },
            new Product { Id = 3, Name = "Smartphone", Price = 799.99m, Quantity = 1, Description = "Latest model smartphone", IsDeleted = false }
        );
    }
}
