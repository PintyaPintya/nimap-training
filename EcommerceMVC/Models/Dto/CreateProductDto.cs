using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceMVC.Models.Dto;

public class CreateProductDto
{
    [Required]
    public required string Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(16,2)")]
    [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
    public required decimal Price { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity cannot be less than zero")]
    public required int Quantity { get; set; }

    public string? Description { get; set; }
}