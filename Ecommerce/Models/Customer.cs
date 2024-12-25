using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email address")]
    public required string Email { get; set; }

    [Required]
    public required string Address { get; set; }

    [Required]
    public bool IsDeleted { get; set; } = false;

    public ICollection<Order> Orders { get; set; } = [];
}
