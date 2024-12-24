using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }

    public Customer? Customer { get; set; }

    [Required]
    [Column(TypeName = "decimal(16,2)")]
    public decimal TotalAmount { get; set; }

    [Required]
    public string Status { get; set; } = "Pending";

    [Required]
    public DateTime OrderDate { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}