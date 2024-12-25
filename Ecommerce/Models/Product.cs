using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(16,2)")]
    [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative")]
    public required decimal Price { get; set; }

    [Required]
    public required int Quantity { get; set; }

    public string? Description { get; set; }

    [Required]
    public bool IsDeleted { get; set; } = false;

    public ICollection<Order> Orders { get; set; } = [];
}
