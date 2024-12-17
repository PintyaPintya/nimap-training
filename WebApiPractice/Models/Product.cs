using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPractice.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Range(0.01, 1000000)]
    [Column(TypeName = "decimal(18,2)")]

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    public string Category { get; set; }

    [Range(0.01, 1000000)]
    [Column(TypeName = "decimal(18,2)")]

    public decimal SupplierCost { get; set; }

    public string SupplierInfo { get; set; }
    
    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }
}
