using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models.Dto;

public class CreateProductDto
{
    [Required]
    public required string Name { get; set; }

    [Column(TypeName = "decimal(16,2)")]
    public required decimal Price { get; set; }

    [Required]
    public required int Quantity { get; set; }

    [Required]
    public string? Description { get; set; }
}
