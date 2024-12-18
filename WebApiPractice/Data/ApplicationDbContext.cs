using Microsoft.EntityFrameworkCore;
using WebApiPractice.Models;

namespace WebApiPractice.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "admin", Password = "password", Email = "admin@Example.com", Roles = new List<string> { "Admin", "User" } },
            new User { Id = 2, Username = "user", Password = "password", Email = "user@Example.com", Roles = new List<string> { "User" } },
            new User { Id = 3, Username = "test", Password = "password", Email = "test@Example.com", Roles = new List<string> { "Admin" } }
        );
    }
}
