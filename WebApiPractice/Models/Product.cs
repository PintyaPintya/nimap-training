using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiPractice.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }

    [Column(TypeName = "decimal(8,2)")]
    public decimal Price { get; set; }
    
    public int Stock { get; set; }
    public int CategoryId { get; set; }
}
