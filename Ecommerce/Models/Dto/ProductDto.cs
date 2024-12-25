using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models.Dto;

public class ProductDto
{
    [Required]
    public string? Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,6)")]
    public decimal Price { get; set; }

    [Required]
    public string? Description { get; set; }
}
