using System.ComponentModel.DataAnnotations;

namespace MoshMVC.Models;

public class Movie
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string Genre { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public DateOnly DateAdded { get; set; }

    public int Stock { get; set; }
}