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

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "iPhone",
                Price = 999.99m,
                Quantity = 3,
                Description = "Latest iPhone with A16 Bionic chip",
                IsDeleted = false
            },
                new Product
                {
                    Id = 2,
                    Name = "Galaxy S23",
                    Price = 899.99m,
                    Quantity = 3,
                    Description = "Flagship Samsung phone with high-end specs",
                    IsDeleted = false
                },
                new Product
                {
                    Id = 3,
                    Name = "Sony Headphones",
                    Price = 349.99m,
                    Quantity = 3,
                    Description = "Noise-canceling wireless headphones",
                    IsDeleted = false
                },
                new Product
                {
                    Id = 4,
                    Name = "Dell Laptop",
                    Price = 1199.99m,
                    Quantity = 3,
                    Description = "Compact and powerful ultrabook for professionals",
                    IsDeleted = false
                },
                new Product
                {
                    Id = 5,
                    Name = "Bose Speaker",
                    Price = 349.00m,
                    Quantity = 3,
                    Description = "Portable Bluetooth speaker with 360-degree sound",
                    IsDeleted = false
                }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                Username = "johndoe",
                Role = "Admin",
                Name = "John Doe",
                Email = "john.doe@example.com",
                Address = "123 Main St, Springfield, IL",
                IsDeleted = false
            },
            new Customer
            {
                Id = 2,
                Username = "janedoe",
                Role = "Customer",
                Name = "Jane Doe",
                Email = "jane.doe@example.com",
                Address = "456 Elm St, Springfield, IL",
                IsDeleted = false
            }
        );
    }
}