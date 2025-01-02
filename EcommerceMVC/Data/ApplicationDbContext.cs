using EcommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Data;

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
                new Customer { Id = 1, Username = "john_doe", Email = "john.doe@example.com", Address = "123 Main St", IsDeleted = false },
                new Customer { Id = 2, Username = "jane_doe", Email = "jane.doe@example.com", Address = "456 Elm St", IsDeleted = false }
            );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, Quantity = 3, Description = "High-performance laptop", IsDeleted = false },
            new Product { Id = 2, Name = "Smartphone", Price = 499.99m, Quantity = 3, Description = "Latest model smartphone", IsDeleted = false },
            new Product { Id = 3, Name = "Headphones", Price = 199.99m, Quantity = 3, Description = "Noise-canceling headphones", IsDeleted = false }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, CustomerId = 1, TotalAmount = 1499.98m, Status = "Pending", OrderDate = DateOnly.FromDateTime(DateTime.Now), IsDeleted = false },
            new Order { Id = 2, CustomerId = 2, TotalAmount = 699.98m, Status = "Completed", OrderDate = DateOnly.FromDateTime(DateTime.Now), IsDeleted = false }
        );

        modelBuilder.Entity<OrderProduct>().HasData(
            new OrderProduct { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
            new OrderProduct { Id = 2, OrderId = 1, ProductId = 2, Quantity = 1 },
            new OrderProduct { Id = 3, OrderId = 2, ProductId = 2, Quantity = 1 },
            new OrderProduct { Id = 4, OrderId = 2, ProductId = 3, Quantity = 1 }
        );
    }
}