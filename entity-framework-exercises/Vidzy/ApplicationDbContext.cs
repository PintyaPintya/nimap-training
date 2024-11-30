using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Video>? Videos { get; set; }
    public DbSet<Genre>? Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=Nimap\\SQLEXPRESS;Database=Vidzy;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { GenreId = 1, Name = "Action" },
            new Genre { GenreId = 2, Name = "Comedy" },
            new Genre { GenreId = 3, Name = "Drama" }
        );

        modelBuilder.Entity<Video>().HasData(
            new Video { VideoId = 1, Name = "The Avengers", ReleaseDate = new DateTime(2012, 4, 25), GenreId = 1, Classification = Classification.Silver },
            new Video { VideoId = 2, Name = "The Hangover", ReleaseDate = new DateTime(2009, 6, 5), GenreId = 2, Classification = Classification.Gold },
            new Video { VideoId = 3, Name = "Titanic", ReleaseDate = new DateTime(1997, 12, 19), GenreId = 3, Classification = Classification.Platinum }
        );
    }
}