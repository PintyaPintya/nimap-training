using System.ComponentModel.DataAnnotations;

namespace WebApiPractice.Models;

public class ProductCreateDto
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Range(0.01, 1000000)]
    public decimal Price { get; set; }

    public string Category { get; set; }

    public decimal SupplierCost { get; set; }

    public string SupplierInfo { get; set; }
    
    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }
}
