using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.Dto;

public class CustomerDto
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Role { get; set; }
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Address { get; set; }
}
