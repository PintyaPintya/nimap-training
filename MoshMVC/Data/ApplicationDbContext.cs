using Microsoft.EntityFrameworkCore;
using MoshMVC.Models;

namespace MoshMVC.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                Id = 1,
                Name = "The Shawshank Redemption",
                Genre = "Drama",
                ReleaseDate = new DateOnly(1994, 9, 22),
                DateAdded = new DateOnly(2025, 1, 13),
                Stock = 3
            },
            new Movie
            {
                Id = 2,
                Name = "The Godfather",
                Genre = "Crime",
                ReleaseDate = new DateOnly(1972, 3, 24),
                DateAdded = new DateOnly(2025, 1, 13),
                Stock = 5
            },
            new Movie
            {
                Id = 3,
                Name = "The Dark Knight",
                Genre = "Action",
                ReleaseDate = new DateOnly(2008, 7, 18),
                DateAdded = new DateOnly(2025, 1, 13),
                Stock = 5
            },
            new Movie
            {
                Id = 4,
                Name = "Forrest Gump",
                Genre = "Drama",
                ReleaseDate = new DateOnly(1994, 7, 6),
                DateAdded = new DateOnly(2025, 1, 13),
                Stock = 5
            },
            new Movie
            {
                Id = 5,
                Name = "Inception",
                Genre = "Sci-Fi",
                ReleaseDate = new DateOnly(2010, 7, 16),
                DateAdded = new DateOnly(2025, 1, 13),
                Stock = 5
            }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "Qwer Tyui", EmailAddress = "qwer@mvc.com", Password = "password",  BirthDate = new DateOnly(2025,01,12), isSubscribedToNewsLetter = false, MembershipTypeId = 1 },
            new Customer { Id = 2, Name = "Asdf  Ghjk", EmailAddress = "asdf@mvc.com", Password = "password", isSubscribedToNewsLetter = true, MembershipTypeId = 2 }
        );

        modelBuilder.Entity<MembershipType>().HasData(
            new MembershipType { Id = 1, Name = "Pay as you go", SignUpFee = 0, DurationInMonths = 0, DiscountRate = 0 },
            new MembershipType { Id = 2, Name = "Monthly", SignUpFee = 30, DurationInMonths = 1, DiscountRate = 10 },
            new MembershipType { Id = 3, Name = "Quarterly", SignUpFee = 90, DurationInMonths = 3, DiscountRate = 15 },
            new MembershipType { Id = 4, Name = "Yearly", SignUpFee = 300, DurationInMonths = 12, DiscountRate = 20 }
        );
    }
}