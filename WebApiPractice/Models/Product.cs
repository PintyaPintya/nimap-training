using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPractice.Models;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Discount { get; set; }
    public Category? Category { get; set; }
}
