using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models.Dto;

public class CustomerDto
{
    [Required]
    public required string Name { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Address { get; set; }
}
